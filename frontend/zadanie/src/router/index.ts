import DetailedView from '@/views/DetailedView.vue'
import { createRouter, createWebHistory } from 'vue-router'
import EmployeeView from '../views/EmployeeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'employees',
      component: EmployeeView
    },
    {
      path: '/archive',
      name: 'archive',
      component: () => import('../views/ArchiveView.vue')
    },
    {
      path: '/positions',
      name: 'positions',
      component: () => import('../views/PositionView.vue')
    },
    {
      path: '/employee/:id',
      component: () => import('../views/DetailedView.vue')
    },
    {
      path: '/employee/:id/edit',
      component: () => import('../views/DetailedView.vue')
    },
    {
      path: '/employee/create',
      component: ()=> import('../views/DetailedView.vue')
    }
  ]
})

export default router
