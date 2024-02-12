<script setup>

</script>

<template>
  <div id="app">
    <v-spacer></v-spacer>
    <p>This is a basic Vue.js landing page.</p>
    <v-spacer></v-spacer>
    <v-form v-model="valid">
        <v-container>
            <v-row>
                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="firstname"
                    :rules="nameRules"
                    :counter="10"
                    label="First name"
                    required
                    hide-details
                ></v-text-field>
                </v-col>
            </v-row>
            <v-row>
                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="lastname"
                    :rules="nameRules"
                    :counter="10"
                    label="Last name"
                    hide-details
                    required
                ></v-text-field>
                </v-col>
            </v-row>
            <v-row>
                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="email"
                    :rules="emailRules"
                    label="E-mail"
                    hide-details
                    required
                ></v-text-field>
                </v-col>
            </v-row>
        </v-container>
    </v-form>
  </div>
</template>