<template>
  <div class="home">
    <Participant firstName="Jack" lastName="Blakely" />
    <Participant firstName="Matt" lastName="Studley" />
  </div>
</template>

<script>
// @ is an alias to /src
import Participant from '@/components/Participant.vue';

export default {
  name: 'Home',
  components: {
    Participant
  }
};
</script>
