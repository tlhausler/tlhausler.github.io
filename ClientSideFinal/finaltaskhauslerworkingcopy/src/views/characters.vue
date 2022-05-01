<template>
  <div class="content-container">
    <div class="columns">
      <div class="column is-8">
        <div class="section content-title-group">
          <h2 class="title">Character</h2>
          <ul>
            <li v-for="character in characters" :key="character.id">
              <div class="card">
                <div class="card-content">
                  <div class="content">
                    <div :key="character.name" class="name">
                      {{ character.name }}
                    </div>
                    <div class="raceAndClass">{{ character.race }} {{ character.class }}</div>
                    <div class="party">{{ character.party }}</div>
                  </div>
                </div>
                <footer class="card-footer">
                  <router-link
                    tag="button"
                    class="link card-footer-item"
                    :to="{ name: 'CharacterDetail', params: { id: character.id } }"
                  >
                    <i class="fas fa-check"></i>
                    <span>Select Character</span>
                  </router-link>
                </footer>
              </div>
            </li>
          </ul>
        </div>
        <div class="notification is-info" v-show="message">{{ message }}</div>
      </div>
    </div>
  </div>
</template>

<script>
import { dataService } from '../shared';

export default {
  name: 'Characters',
  data() {
    return {
      characters: [],
      message: '',
    };
  },
  async created() {
    await this.loadCharacters();
  },
  methods: {
    async loadCharacters() {
      this.characters = [];
      this.message = 'getting the characters, please be patient';

      this.characters = await dataService.getCharacters();

      this.message = '';
    },
  },
};
</script>
