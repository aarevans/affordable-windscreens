import { createRouter, createWebHistory } from 'vue-router'
import LandingPage from '../views/landing-page.vue'
import ContactPage from '../views/contact.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'landing',
      component: LandingPage
    },
    {
      path: '/contact',
      name: 'contact',
      component: ContactPage
    },

  ]
})

export default router
