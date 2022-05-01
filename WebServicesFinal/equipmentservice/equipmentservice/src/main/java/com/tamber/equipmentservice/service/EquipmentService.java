package com.tamber.equipmentservice.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import com.tamber.equipmentservice.dto.EquipmentPlayerDTO;
import com.tamber.equipmentservice.dto.Player;
import com.tamber.equipmentservice.model.Equipment;
import com.tamber.equipmentservice.repository.EquipmentRepository;

@Service
public class EquipmentService {
	
	// instantiate instance of our repo and autowire it
	@Autowired
	private EquipmentRepository repo;
	
	//instantiate instance of rest template and autowire it
	@Autowired
	private RestTemplate restTemplate;
	
	// method calls repo to save equipment to database. 
	public Equipment saveEquipment(Equipment equipment) {
		return repo.save(equipment);
	}
	
	// method calls repo for getting equipment by its id.
	public Equipment getEquipmentById(int id) {
		return repo.findById(id);
	}
	
	// method that instantiates our DTO so we can get both player and equipment information by the equipment id. 
	public EquipmentPlayerDTO getEquipmentWithPlayer(int id) {
		EquipmentPlayerDTO response = new EquipmentPlayerDTO();
		Equipment equipment = repo.findById(id);
		Player player = restTemplate.getForObject("http://PLAYER-SERVICE/players/" + equipment.getPlayer(), Player.class);
		
		response.setEquipment(equipment);
		response.setPlayer(player);
		
		return response;
	}
	
	// method that will return all equipment associated with a player by their id. 
	public List<Equipment> getEquipmentByPlayerId(int id) {
		return repo.findByPlayer(id);
	}
}
