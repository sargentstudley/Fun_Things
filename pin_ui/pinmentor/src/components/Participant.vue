<template>
  <div class="participant">
    <h3>Participant:</h3>
    <p>{{ firstName }} {{ lastName }}</p>
  </div>
</template>
<script>
export default {
  name: 'Participant',
  props: {
    firstName: String,
    lastName: String
  }
};
</script>
