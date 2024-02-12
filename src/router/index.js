import { createRouter, createWebHistory } from 'vue-router'
import LandingPage from '../views/landing-page.vue'
import ContactPage from '../views/contact.vue'
import AboutPage from '../views/about.vue'


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
    {
      path: '/about',
      name: 'about',
      component: AboutPage
    }
  ]
})

export default router
