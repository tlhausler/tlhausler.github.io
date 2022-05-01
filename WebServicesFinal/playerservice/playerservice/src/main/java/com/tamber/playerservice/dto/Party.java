package com.tamber.playerservice.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class Party {

	// placeholder class that will store the Party from our rest template call to the party service
	private int Id;
	private String name;
	private String setting;
	private String sessionDay;
}
