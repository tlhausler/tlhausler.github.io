using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Net;
using System.Net.Http;
using Title45MCADB;
using Title45MCADB.Entities;

namespace MCAWebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chapterUrls = new List<string>();

            // Establish base URL for MCA Title 45
            string urlBase = "https://leg.mt.gov/bills/mca/title_0450/";

            // Implementing web scraper to acquire all data associated with MCA Title 45 laws.
            try
            {
                // build path for getting to list of chapters for title 45
                string url = urlBase + "chapters_index.html";
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(url)
                };
                // request html data from page
                var result = httpClient.GetAsync("").Result;

                string strData = "";

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    // if successfully acquired, read the returned content as a string.
                    strData = result.Content.ReadAsStringAsync().Result;

                    HtmlDocument htmlDocument = new();

                    //construct html document with the string data
                    htmlDocument.LoadHtml(strData);

                    //gets all items with class "line"
                    var lis = htmlDocument.DocumentNode.SelectNodes("//*[@class='line']");  
                    foreach (var li in lis)
                    {
                        // Verify we are proceeding down the html as expected.  Go to second child node and get it's first attribute, return its value.
                        Console.WriteLine("href: " + li.ChildNodes[1].Attributes[0].Value); //result: href: ./chapter_0090/parts_index.html
                        string fullUrl = urlBase + li.ChildNodes[1].Attributes[0].Value.Substring(2);
                        Console.WriteLine("full url: " + fullUrl);
                        // add these newly built urls to the chapterUrls list.
                        chapterUrls.Add(fullUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled error: " + ex.Message);
            }

            //next step
            List<string> partsUrls = new List<string>();
            try
            {
                foreach (var cUrl in chapterUrls)
                {
                    // build path for getting to list of parts for each chapter
                    string urlPartBase = cUrl.Substring(0, cUrl.Length - 16);

                    var httpClient = new HttpClient
                    {
                        BaseAddress = new Uri(cUrl)
                    };
                    var result = httpClient.GetAsync("").Result;

                    // if successfully acquired, read the returned content as a string.
                    string strData = "";

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        strData = result.Content.ReadAsStringAsync().Result;

                        HtmlDocument htmlDocument = new();
                        //construct html document with the string data
                        htmlDocument.LoadHtml(strData);

                        //gets all items with class heading
                        var lis = htmlDocument.DocumentNode.SelectNodes("//*[@class='heading']");  
                        foreach (var li in lis)
                        {
                            Console.WriteLine("href: " + li.ChildNodes[1].Attributes[0].Value); //result: href: ./part_0010/sections_index.html
                            string fullPartUrl = urlPartBase + li.ChildNodes[1].Attributes[0].Value.Substring(2);
                            Console.WriteLine("full url: " + fullPartUrl);
                            partsUrls.Add(fullPartUrl);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unhandled error: " + ex.Message);
            }

            //next step
            List<string> sectionUrls = new List<string>();
            try
            {
                foreach (var sUrl in partsUrls)
                {
                    // build path for getting to list of sections for each part
                    string urlSectionBase = sUrl.Substring(0, sUrl.Length - 19);

                    var httpClient = new HttpClient
                    {
                        BaseAddress = new Uri(sUrl)
                    };
                    var result = httpClient.GetAsync("").Result;

                    // if successfully acquired, read the returned content as a string.
                    string strData = "";

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        strData = result.Content.ReadAsStringAsync().Result;

                        HtmlDocument htmlDocument = new();
                        //construct html document with the string data
                        htmlDocument.LoadHtml(strData);

                        var lis = htmlDocument.DocumentNode.SelectNodes("//*[@class='line']");  //gets all items with class line
                        foreach (var li in lis)
                        {
                            Console.WriteLine("href: " + li.ChildNodes[1].Attributes[0].Value); //result: href: ./part_0010/sections_index.html
                            string fullSectionUrl = urlSectionBase + li.ChildNodes[1].Attributes[0].Value.Substring(2);
                            Console.WriteLine("full url: " + fullSectionUrl);
                            sectionUrls.Add(fullSectionUrl);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unhandled error: " + ex.Message);
            }

            // Here we reach the page that has all the information we need to build our Title45 objects for the database.
            using (var ctx = new MCADbContext()) {
                ctx.Database.EnsureCreated();
                foreach (var sectionUrl in sectionUrls)
                {
                    try
                    {
                        var httpClient = new HttpClient
                        {
                            BaseAddress = new Uri(sectionUrl)
                        };
                        var result = httpClient.GetAsync("").Result;

                        string strData = "";

                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            strData = result.Content.ReadAsStringAsync().Result;

                            HtmlDocument htmlDocument = new();
                            htmlDocument.LoadHtml(strData);

                            //acquire information from html from our sectionUrls list and set them to local variables.
                            var titleH4 = htmlDocument.DocumentNode.SelectNodes("//*[@class='section-title-title']")[0];
                            var chTitleH3 = htmlDocument.DocumentNode.SelectNodes("//*[@class='section-chapter-title']")[0];
                            var partTitleH2 = htmlDocument.DocumentNode.SelectNodes("//*[@class='section-part-title']")[0];
                            var secTitleH1 = htmlDocument.DocumentNode.SelectNodes("//*[@class='section-section-title']")[0];
                            var contentDiv = htmlDocument.DocumentNode.SelectNodes("//*[@class='section-content']")[0];

                            String sectionContent = "";

                            //Content can be in separate tags, so we loop over the child nodes for the content div and add it to our sectionContent string.
                            foreach (var p in contentDiv.ChildNodes)
                            {
                                if (p.ChildNodes.Count == 1 && contentDiv.ChildNodes[0].Name == "span")
                                {
                                    sectionContent += p.ChildNodes[0].InnerText;
                                }
                                if (!string.IsNullOrWhiteSpace(p.InnerText))
                                {
                                    sectionContent += p.InnerText;
                                }
                            }

                            //once all necessary parts have been acquired from the HTML, we build a Title45 object, add it to the DbSet in the context and save changes.
                            Title45 entry = new Title45(titleH4.InnerText, chTitleH3.InnerText, partTitleH2.InnerText, secTitleH1.InnerText, sectionContent);
                            ctx.Title45Items.Add(entry);
                            ctx.SaveChanges();
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Unhandled error: " + ex.Message);
                    }
                }
                foreach(Title45 titlethingy in ctx.Title45Items)
                {
                    Console.WriteLine(titlethingy.Content);
                }
            }

            Console.WriteLine("The End");
        }
    }
}
