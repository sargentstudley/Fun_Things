import Vue from 'vue';
import VueRouter from 'vue-router';
import Coach from '../views/Coach.vue';
import Event from '../views/Event.vue';
import Participant from '../views/Participant.vue';
import Roster from '../views/Roster.vue';
import Schedule from '../views/Schedule.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/coach',
    name: 'coach',
    component: Coach
  },
  {
    path: '/event',
    name: 'event',
    component: Event
  },
  {
    path: '/participant',
    name: 'participant',
    component: Participant
  },
  {
    path: '/roster',
    name: 'roster',
    component: Roster
  },
  {
    path: '/schedule',
    name: 'schedule',
    component: Schedule
  }
];

const router = new VueRouter({
  routes
});

export default router;
