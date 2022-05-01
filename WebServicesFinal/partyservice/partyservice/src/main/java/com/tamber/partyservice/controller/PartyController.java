package com.tamber.partyservice.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.tamber.partyservice.model.Party;
import com.tamber.partyservice.service.PartyService;


@RestController
@RequestMapping("/parties") // set base route for web request mapping
public class PartyController {

	@Autowired
	private PartyService service;
	
	// this method will take a party, pass it on to the service, then to the repository which will save it.
	// It will then return the party we passed to it through the controller and to the user.
	@PostMapping("/") // host:port/parties/
	public Party saveParty(@RequestBody Party party) {
		return service.saveParty(party);
	}
	
	// host:port/parties/{id}
	@GetMapping("/{id}")
	public Party getPartyById(@PathVariable int id) {
		return service.getPartyById(id);
	}
}
