package com.tamber.partyservice;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.EnableEurekaClient;

@SpringBootApplication
@EnableEurekaClient
public class PartyserviceApplication {

	public static void main(String[] args) {
		SpringApplication.run(PartyserviceApplication.class, args);
	}

}
