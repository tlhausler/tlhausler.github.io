using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Title45MCADB.Entities
{
    public class Title45
    {
        // Simple class for setting up single table in database with Entity Framework.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Chapter { get; set; }
        public string Part { get; set; }
        public string Section { get; set; }
        public string Content { get; set; }

        public Title45(string title, string chapter, string part, string section, string content)
        {
            Title = title;
            Chapter = chapter;
            Part = part;
            Section = section;
            Content = content;
        }

        public Title45()
        {

        }

    }
}
