package com.tamber.equipmentservice.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class Player {

	// placeholder copy of player class from player service
	// will store the player we get through RestTemplate call to player service
	private int Id;
	private int partyId;
	private String name;
	private String race;
	private String playerClass;
	private int level;
}
