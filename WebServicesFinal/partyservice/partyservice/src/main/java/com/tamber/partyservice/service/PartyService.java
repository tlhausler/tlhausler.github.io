package com.tamber.partyservice.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.tamber.partyservice.model.Party;
import com.tamber.partyservice.repository.PartyRepository;

@Service
public class PartyService {
	// Here PartyService will handle communication with PartyRepository layer.
	
	//Spring will handle instantiating our partyRepo with the Autowired annotation.
	@Autowired
	private PartyRepository partyRepo;
	
	// method for saving data posted to service
	public Party saveParty(Party party) {
		return partyRepo.save(party);
	}

	// method for getting party data by id
	public Party getPartyById(int id) {
		return partyRepo.findById(id);
	}

}
