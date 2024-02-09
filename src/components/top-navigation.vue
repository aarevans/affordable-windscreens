<template>
  <v-app-bar app color="indigo" dark scroll-behavior="collapse">
    <v-spacer></v-spacer> <!-- Spacer before buttons -->

    <router-link to="/" tag="v-btn" text>Home</router-link>
    <router-link to="/about" tag="v-btn" text>About</router-link>
    <router-link to="/contact" tag="v-btn" text>Contact</router-link>

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