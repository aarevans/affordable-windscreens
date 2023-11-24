<template>
  <v-app-bar app color="indigo" dark scroll-behavior="collapse">
    <v-spacer></v-spacer> <!-- Spacer before buttons -->

    <v-btn text>Home</v-btn>
    <v-btn text>About</v-btn>
    <v-btn text>Contact</v-btn>

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