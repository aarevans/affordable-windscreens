<template>
  <v-container>
    <!-- Placeholder for banner -->
    <v-row>
      <div class="banner-container">
        <img src="../assets/banner.png" alt="Banner" class="banner-image">
      </div>
    </v-row>

    <!-- Text and Large Image -->
    <v-row align="center" justify="center">
      <div class="content">
      <div class="image-container">
        <img src="../assets/van.png" alt="Van Image" class="responsive-image">
      </div>
      <div class="text-container">
        <h1>Welcome to Our Service</h1>
        <p>Here is some information about the van and the services we offer. Please contact us for more details.</p>
      </div>
    </div>
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
    <br />
    <br />
    <br />
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

<style>
.content {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  text-align: center;
}

.image-container {
  flex: 1 1 300px; /* Allows the image container to grow and shrink but not be smaller than 300px */
  max-width: 50%; /* Limits the image container's width to half of the parent container */
  padding: 10px; /* Adds some space around the image */
}

.responsive-image {
  max-width: 100%;
  height: auto; /* Maintains the aspect ratio */
}

.text-container {
  flex: 1 1 300px; /* Allows the text container to grow and shrink but not be smaller than 300px */
  max-width: 50%; /* Limits the text container's width to half of the parent container */
  padding: 10px; /* Adds some space around the text */
}

.banner-container {
  width: 100%; /* Ensures the container spans the full width */
  overflow: hidden; /* Hides parts of the image that overflow the container */
  display: flex; /* Aligns the child img */
  justify-content: center; /* Centers the img horizontally */
}

.banner-image {
  width: 100%; /* Makes the image fully responsive */
  height: auto; /* Maintains aspect ratio */
  object-fit: cover; /* Covers the area of the container without stretching. Can crop edges on smaller screens */
  min-width: 300px; /* Minimum width to prevent the image from becoming too small */
}

@media (max-width: 600px) { /* Adjusts the layout for screens smaller than 600px */
  .content {
    flex-direction: column; /* Stacks the image and text vertically */
  }

  .image-container, .text-container {
    max-width: 100%; /* Allows the image and text containers to fill the entire width of the parent container */
  }

  .responsive-image {
    max-height: 200px; /* Optionally limits the image height on smaller screens */
  }
  
  .banner-container {
    height: 200px; /* Sets a fixed height on smaller screens to control the appearance */
  }
}
</style>

  