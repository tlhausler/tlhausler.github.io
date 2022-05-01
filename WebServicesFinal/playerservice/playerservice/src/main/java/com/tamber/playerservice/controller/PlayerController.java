package com.tamber.playerservice.controller;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.tamber.playerservice.dto.PlayerPartyDTO;
import com.tamber.playerservice.model.Player;
import com.tamber.playerservice.service.PlayerService;

@RestController
@RequestMapping("/players") // set base route for web request mapping
public class PlayerController {
	
	@Autowired
	private PlayerService service;
	
	// host:port/players/
	@PostMapping("/")
	public Player savePlayer(@RequestBody Player player) {
		return service.savePlayer(player);
	}
	
	// host:port/players/{id}
	@GetMapping("/{id}")
	public Player getPlayerById(@PathVariable int id) {
		return service.getPlayerById(id);
	}
	
	// host:port/players/party/{id}
	@GetMapping("/party/{id}")
	public PlayerPartyDTO getPlayerWithParty(@PathVariable("id") int id) {
		return service.getPlayerWithParty(id);
	}
	
	// host:port/players/party/{id}/all
	@GetMapping("/party/{id}/all")
	public List<Player> getPlayersByPartyId(@PathVariable int id) {
		return service.getPlayersByPartyId(id);
	}

}
