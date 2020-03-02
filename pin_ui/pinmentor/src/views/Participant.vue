<template>
  <div>
    This page will act as both an individual edit page for coaches, and also a
    landing page for participants to view themselves and their progress. Note:
    import individual participantt components, then they can be added just like
    an HTML tag here!
    <ul>
      <li v-for="p in participants" :key="p.id">
        <Participant :firstName="p.firstName" :lastName="p.lastName" />
      </li>
    </ul>
  </div>
</template>

<script>
import Participant from '../components/Participant';
import axios from 'axios';

export default {
  name: 'ParticipantList',
  data: () => {
    return {
      participants: []
    };
  },
  components: {
    Participant
  },
  created() {
    axios
      .get('http://192.168.99.100/api/participant/')
      .then(response => {
        this.participants = response.data;
        console.log('Fetched participants OK');
      })
      .catch(e => {
        console.log('Error fetching participants: ' + e);
      });
  }
};
</script>

<style scoped></style>
