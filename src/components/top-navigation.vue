<template>
  <v-app-bar app color="indigo" dark scroll-behavior="collapse">
    <v-spacer></v-spacer> <!-- Spacer before buttons -->

    <!-- Using router-links instead of plain buttons -->
    <router-link to="/" custom v-slot="{ navigate }">
      <v-btn text @click="navigate">Home</v-btn>
    </router-link>
    <router-link to="/about" custom v-slot="{ navigate }">
      <v-btn text @click="navigate">About</v-btn>
    </router-link>
    <router-link to="/contact" custom v-slot="{ navigate }">
      <v-btn text @click="navigate">Contact</v-btn>
    </router-link>

    <v-spacer></v-spacer> <!-- Spacer after buttons -->
  </v-app-bar>

  <v-img :src="banner" height="125" cover ></v-img>
</template>


<script setup>

import banner from '../assets/banner.png'

</script>

<style>
.v-app-bar {
  margin-bottom: 0;
}
</style>