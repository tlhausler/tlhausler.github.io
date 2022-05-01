package com.tamber.equipmentservice.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.tamber.equipmentservice.dto.EquipmentPlayerDTO;
import com.tamber.equipmentservice.model.Equipment;
import com.tamber.equipmentservice.service.EquipmentService;

@RestController
@RequestMapping("/equipment") // set base route for web request mapping for methods
public class EquipmentController {
	
	@Autowired
	private EquipmentService service;
	
	// host:port/equipment/
	@PostMapping("/")
	public Equipment saveEquipment(@RequestBody Equipment equipment) {
		return service.saveEquipment(equipment);
	}
	
	// host:port/equipment/{id}
	@GetMapping("/{id}")
	public Equipment getEquipmentById(@PathVariable int id) {
		return service.getEquipmentById(id);
	}
	
	// host:port/equipment/player/{id}
	@GetMapping("/player/{id}")
	public EquipmentPlayerDTO getEquipmentWithPlayer(@PathVariable("id") int id) {
		return service.getEquipmentWithPlayer(id);
	}
	
	// host:port/equipment/player/{id}/all
	@GetMapping("/player/{id}/all")
	public List<Equipment> getEquipmentByPlayerId(@PathVariable int id) {
		return service.getEquipmentByPlayerId(id);
	}

}
