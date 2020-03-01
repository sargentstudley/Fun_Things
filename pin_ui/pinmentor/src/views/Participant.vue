<template>
  <div>
    This page will act as both an individual edit page for coaches, and also a
    landing page for participants to view themselves and their progress. Note:
    import individual participantt components, then they can be added just like
    an HTML tag here!
    <ul>
      <Participant firstName="John" lastName="Doe"/>
    </ul>
  </div>
</template>

<script>
import Participant from '../components/Participant';

export default {
  name: 'ParticipantList',
  data: () => {
    return {
      participants: []
    }
  },
  components: {
    Participant,
  },
  methods: {
    fetchData: () => {
      let self = this;
      // This needs to be replaced with an ENV variable that gets injected on-build, or something equivilent.
      // Request currently doesn't work because CORS violation (in this case 192.168.99.100 is my docker host). 
      // This is where Ngnix might come in very handy. 
      // Also, check Axios - seems a common framework for Vue and API interaction.
      const myRequest = new Request('http://192.168.99.100/api/participant/');
      fetch(myRequest)
        .then((response) => {return response.json()})
        .then((data) => {
          self.participants = data;
        }).catch(error => { console.log(error); });
    }
  },
  mounted() {
    this.fetchData();
  }
};
</script>

<style scoped></style>

