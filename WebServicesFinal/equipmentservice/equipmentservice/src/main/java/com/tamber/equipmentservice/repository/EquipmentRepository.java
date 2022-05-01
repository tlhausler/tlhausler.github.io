package com.tamber.equipmentservice.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.tamber.equipmentservice.dto.Player;
import com.tamber.equipmentservice.model.Equipment;

@Repository
public interface EquipmentRepository extends JpaRepository<Equipment, Integer> {
	// defining custom method contracts that are automatically implemented by spring and JpaRepository.
	public Equipment findById(int id);
	public List<Equipment> findByPlayer(int id);
}
