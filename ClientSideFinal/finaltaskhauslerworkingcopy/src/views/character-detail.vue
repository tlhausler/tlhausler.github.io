<template>
  <div>
    <div class="section content-title-group">
      <h2 class="title">Edit Character</h2>
      <div class="card">
        <header class="card-header">
          <p class="card-header-title">{{ name }}</p>
        </header>
        <div class="card-content">
          <div class="content">
            <div class="field">
              <label class="label" for="id">characters Id: </label>
              <label class="input" name="id" readonly>{{ character.id }}</label>
            </div>
            <div class="field">
              <label class="label" for="name">name</label>
              <input class="input" name="name" v-model="character.name" />
            </div>
            <div class="field">
              <label class="label" for="race">race</label>
              <input class="input" name="race" v-model="character.race" />
            </div>
            <div class="field">
              <label class="label" for="class">class</label>
              <input class="input" name="class" v-model="character.class" />
            </div>
            <div class="field">
              <label class="label" for="party">party</label>
              <input class="input" name="party" v-model="character.party" />
            </div>
            <div class="field">
              <label class="label" for="str">strength</label>
              <input class="input" name="str" v-model="character.str" />
            </div>
            <div class="field">
              <label class="label" for="dex">dexterity</label>
              <input class="input" name="dex" v-model="character.dex" />
            </div>
            <div class="field">
              <label class="label" for="con">constitution</label>
              <input class="input" name="con" v-model="character.con" />
            </div>
            <div class="field">
              <label class="label" for="int">intelligence</label>
              <input class="input" name="int" v-model="character.int" />
            </div>
            <div class="field">
              <label class="label" for="wis">wisdom</label>
              <input class="input" name="wis" v-model="character.wis" />
            </div>
            <div class="field">
              <label class="label" for="cha">charisma</label>
              <input class="input" name="cha" v-model="character.cha" />
            </div>            
          </div>
        </div>
        <footer class="card-footer">
          <button
            class="link card-footer-item cancel-button"
            @click="cancelCharacter()"
          >
            <i class="fas fa-undo"></i>
            <span>Cancel</span>
          </button>
          <button class="link card-footer-item" @click="saveCharacter()">
            <i class="fas fa-save"></i>
            <span>Save</span>
          </button>
        </footer>
      </div>
    </div>
  </div>
</template>

<script>
import { dataService } from '../shared';

export default {
  name: 'CharacterDetail',
  props: {
    id: {
      type: Number,
      default: 0,
    },
  },
  data() {
    return {
      character: {},
    };
  },
  async created() {
    this.character = await dataService.getCharacter(this.id);
  },
  methods: {
    cancelCharacter() {
      this.$router.push({ name: 'Characters' });
    },
    async saveCharacter() {
      await dataService.updateCharacter(this.character);
      this.$router.push({ name: 'Characters' });
    },
  },
};
</script>
Character