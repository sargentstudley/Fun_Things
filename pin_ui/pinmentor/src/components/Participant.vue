<template>
    <div class="participant">
        First Name: {{ firstName }}
        Last Name: {{ lastName }}
    </div>
</template>
<script>
export default {
   name:'Participant',
   props: {
       firstName: String,
       lastName: String
   }
}
</script>