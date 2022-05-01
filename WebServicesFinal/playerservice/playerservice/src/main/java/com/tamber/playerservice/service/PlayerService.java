package com.tamber.playerservice.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import com.tamber.playerservice.dto.Party;
import com.tamber.playerservice.dto.PlayerPartyDTO;
import com.tamber.playerservice.model.Player;
import com.tamber.playerservice.repository.PlayerRepository;

@Service
public class PlayerService {
	
	//instantiate instance of PlayerRepository
	@Autowired
	private PlayerRepository playerRepo;
	
	//instantiate instance of RestTemplate
	@Autowired
	private RestTemplate restTemplate;
	
	// method calls on playerRepo to save player data to database
	public Player savePlayer(Player player) {
		return playerRepo.save(player);
	}
	
	// method calls on playerRepo to get player by id
	public Player getPlayerById(int id) {
		return playerRepo.findById(id);
	}
	
	// instantiate DTO to build a response that includes both player and party data using restTemplate call to party service
	public PlayerPartyDTO getPlayerWithParty(int id) {
		PlayerPartyDTO response = new PlayerPartyDTO();
		Player player = playerRepo.findById(id);
		Party party = restTemplate.getForObject("http://PARTY-SERVICE/parties/" + player.getParty(), Party.class);
		
		response.setPlayer(player);
		response.setParty(party);
		
		return response;
	}
	
	// return all players associated with a party by the party's id.
	public List<Player> getPlayersByPartyId(int id) {
		return playerRepo.findByParty(id);
	}

}
