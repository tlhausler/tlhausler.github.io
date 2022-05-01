import * as axios from 'axios';

import { API } from './config';

const getCharacters = async function() {
  try {
    const response = await axios.get(`${API}/characters`);

    let data = parseList(response);

    const characters = data;

    return characters;
  } catch (error) {
    console.error(error);
    return [];
  }
};

const getCharacter = async function(id) {
  try {
    console.log("Try to get character: " + id);
    const response = await axios.get(`${API}/characters/${id}`);
    let character = parseItem(response, 200);
    return character;
  } catch (error) {
    console.error(error);
    return null;
  }
};

const updateCharacter = async function(character) {
  try {
    const response = await axios.put(`${API}/characters/${character.id}`, character);
    const updatedCharacter = parseItem(response, 200);
    return updatedCharacter;
  } catch (error) {
    console.error(error);
    return null;
  }
};

const parseList = response => {
  if (response.status !== 200) throw Error(response.message);
  if (!response.data) return [];
  let list = response.data;
  if (typeof list !== 'object') {
    list = [];
  }
  return list;
};

export const parseItem = (response, code) => {
  if (response.status !== code) throw Error(response.message);
  let item = response.data;
  if (typeof item !== 'object') {
    item = undefined;
  }
  return item;
};

export const dataService = {
  getCharacters,
  getCharacter,
  updateCharacter,
};
