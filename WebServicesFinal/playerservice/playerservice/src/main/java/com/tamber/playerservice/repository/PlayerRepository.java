package com.tamber.playerservice.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.tamber.playerservice.model.Player;

@Repository
public interface PlayerRepository extends JpaRepository<Player, Integer> {
	// defining custom method contracts for automatic implementation by spring and JpaRepository
	public Player findById(int id);
	public List<Player> findByParty(int id);
}
