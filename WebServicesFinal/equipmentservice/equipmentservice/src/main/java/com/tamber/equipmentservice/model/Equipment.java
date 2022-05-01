package com.tamber.equipmentservice.model;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

import org.springframework.stereotype.Component;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Component
@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Equipment {

	@Id
	@GeneratedValue(strategy = GenerationType.AUTO)
	private int Id;
	private int player;
	private String name;
	private String type;
	private String description;
}
