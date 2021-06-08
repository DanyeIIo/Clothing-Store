<template>
    <section>
        <h1>dynamic Product page {{$route.params.id}} </h1>
        
    </section>
</template>

<script>
export default {
    // validate({params}){
    //     return /^\d+$/.test(params.id)
    // },
    components: {

    },
    computed: mapGetters(['allItems']),
    methods: mapActions(['fetchPosts', 'GET_ITEMS_FROM_API']),
    async mounted(){
        this.fetchPosts(),
        this.GET_ITEMS_FROM_API()
    }  

}
</script>