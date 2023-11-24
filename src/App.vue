<script setup>
import { RouterView } from 'vue-router'
import TopNav from './components/top-navigation.vue'
</script>

<template>
  <v-app>
    <TopNav />
    <v-main>
      <RouterView />
    </v-main>
  </v-app>
</template>

<style>


</style>