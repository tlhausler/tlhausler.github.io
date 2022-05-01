package com.tamber.partyservice.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.tamber.partyservice.model.Party;

@Repository
public interface PartyRepository extends JpaRepository<Party, Integer> {
	// defining custom method contracts that are automatically implemented by spring for interaction with database.
	public Party findById(int id);
}
