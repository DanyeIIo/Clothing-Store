<template>
    <div class="bg-home-page w-full">
        <Navbar />
        <Nuxt />
        <Footer />
    </div>
</template>
    
<script>
import Navbar from '@/components/Navbar'
import Footer from '@/components/Footer'
export default {
components: {
    Navbar,
    Footer
},
computed:{
    meta () {
    return[
        { charset: 'utf-8' },
        {
        name: 'viewport',
        content: 'width=device-width, initial-scale=1, maximum-scale=1 shrink-to-fit=no'
        },
        { hid: 'description', name: 'description', content: 'Главная' }
    ]
    }
},
head() {
    const canonical = `https://mysite.com${this.$route.path
    .toLowerCase()
    .replace(/\/$/, '')}`
    return {
    meta: [
        ...this.meta
    ],
    script: [
        // { src: 'https://markknol.github.io/console-log-viewer/console-log-viewer.js' }
    ],
    link: [{ rel: 'canonical', href: canonical }]
    }
}

}
</script>
<style scoped>
.home-page{
    background-image: url(../assets/pictures/home-bg.png); 
    /* background-image: url('data:image/svg+xml;utf8, <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1440 2028"><title>home-bg</title>'); */
    background-size: cover;

    /* background-position: ; */

    /* transform: translateY(40%); */
}

</style>
