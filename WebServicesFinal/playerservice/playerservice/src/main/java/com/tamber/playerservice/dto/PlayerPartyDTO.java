package com.tamber.playerservice.dto;

import com.tamber.playerservice.model.Player;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class PlayerPartyDTO {

	// create and return combined data of player and party
	private Player player;
	private Party party;
}
