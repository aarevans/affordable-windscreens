<template>
  <v-container>
    <!-- Placeholder for banner -->
    <v-row>
      <v-col cols="12">
        <img src='../assets/banner.png' height="250" style="display: block; margin-left: auto; margin-right: auto; text-align: center;">
      </v-col>
    </v-row>

    <!-- Text and Large Image -->
    <v-row>
      <v-col cols="12" class="text-center mb-5">
        <h1>Welcome to AffordableWindscreens4u!</h1>
        <p>We are a reliable windscreen repair company based in North Wales but serves North Wales, Chester and beyond! Please contact us directly on 07889177751 or fill in our contact form and someone will get back to you as soon as possible.</p>
        <!-- Adjusted Large Image Placeholder with Custom Styling -->
        <div class="image-container" style="display: inline-block; width: 30%;">
          <v-img
            src="https://via.placeholder.com/600x400"
            aspect-ratio="1.5"
            contain
            style="width: 100%; height: auto;"
          ></v-img>
        </div>
      </v-col>
    </v-row>

    <!-- Button to Open Contact Form Dialog -->
    <v-row justify="center">
      <v-btn color="primary" dark @click="dialog = true">
        Click here to get in touch for a quote
      </v-btn>
    </v-row>

    <!-- Contact Form Dialog -->
    <v-dialog v-model="dialog" persistent max-width="600px">
      <v-card>
        <v-card-title>
          Contact Us
        </v-card-title>

        <v-card-text>
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
            <!-- Optional Phone Number Field -->
            <v-text-field
              v-model="phone"
              label="Phone Number"
            ></v-text-field>
            <v-textarea
              v-model="message"
              :rules="[rules.required]"
              label="Message"
              required
            ></v-textarea>
            <v-btn :disabled="!valid" @click="submitForm" color="primary">Submit</v-btn>
          </v-form>
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="dialog = false">Close</v-btn>
          <v-btn color="blue darken-1" text @click="submitForm" :disabled="!valid">Submit</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script>

  export default {
    data: () => ({
      dialog: false,
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
          console.log('Form submitted', { name: this.name, email: this.email,phone: this.phone, message: this.message });
          this.sendEmail();
          this.dialog = false; // Close the dialog on successful submission
        }
      },
        async sendEmail() {
          const formData = { name: this.name, email: this.email, phone: this.phone, message: this.message };
          try {
              const response = await fetch('https://fun-affordable-windscreens.azurewebsites.net/api/email?', {
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
  