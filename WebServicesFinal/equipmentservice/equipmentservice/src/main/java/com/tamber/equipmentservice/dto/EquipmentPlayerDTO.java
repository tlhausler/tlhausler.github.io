package com.tamber.equipmentservice.dto;

import com.tamber.equipmentservice.model.Equipment;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class EquipmentPlayerDTO {
	// create and return combined data of equipment and player
	private Equipment equipment;
	private Player player;
}
