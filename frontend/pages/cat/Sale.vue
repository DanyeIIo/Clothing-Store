<template>
<div>
    <h1 class="text-center">Sales</h1>
    <div class="flex flex-row" >
        <LeftSection />
        <ProdCatalog :ProductsList="allItems"/>
    </div>
    
</div>   
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

import LeftSection from '~/components/LeftSection'
import ProdCatalog from '~/components/prodCatalog'

export default {
    components: {
        LeftSection,
        ProdCatalog
    },
    computed: mapGetters(["allPosts", 'postsCount', 'allItems']), // второй способ
    methods: mapActions(['fetchPosts', 'GET_ITEMS_FROM_API']), // более короткий способ вызова  UPD. actions это МЕТОД
//     methods: {
//         ...mapActions([
//         'GET_ITEMS_FROM_API'
//         ])
//     },

    async mounted(){
        //this.$store.dispatch("fetchPosts"); 
        // вызываем action которыый затем вызовет mutation который уже передает данные на страницу
        this.fetchPosts(),
        this.GET_ITEMS_FROM_API()
    }   
}
</script>


