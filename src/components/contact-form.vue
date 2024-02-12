<template>
    <v-container>
      <v-form ref="form" v-model="valid" lazy-validation>
        <v-text-field
          v-model="name"
          :rules="[rules.required]"
          label="Name"
          required
        ></v-text-field>
        <v-text-field
          v-model="email"
          :rules="[rules.required, rules.email]"
          label="E-mail"
          required
        ></v-text-field>
        <v-textarea
          v-model="message"
          :rules="[rules.required]"
          label="Message"
          required
        ></v-textarea>
        <v-btn :disabled="!valid" @click="submitForm">Submit</v-btn>
      </v-form>
    </v-container>
  </template>
  
  <script>
  export default {
    data: () => ({
      valid: true,
      name: '',
      email: '',
      message: '',
      rules: {
        required: value => !!value || 'Required.',
        email: value => {
          const pattern = /[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+/;
          return pattern.test(value) || 'Invalid e-mail.';
        },
      },
    }),
    methods: {
      submitForm() {
        if (this.$refs.form.validate()) {
          // Here you'll handle the form submission to send an email
          console.log('Form submitted', { name: this.name, email: this.email, message: this.message });
          this.sendEmail();
        }
      },
      async sendEmail() {
        const formData = { name: this.name, email: this.email, message: this.message };
        try {
            const response = await fetch('https://fun-affordable-windscreens.azurewebsites.net/api/email?KcB-VS90BkA3ZEEdsjWru77OF-tX-m6yZv0n24u0SkPjAzFu6zvnPg==', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
            });
            if (response.ok) {
            // Handle success
            console.log('Email sent successfully');
            } else {
            // Handle error
            console.error('Failed to send email');
            }
        } catch (error) {
            console.error('Error sending email:', error);
        }}
    }
}
  </script>
  