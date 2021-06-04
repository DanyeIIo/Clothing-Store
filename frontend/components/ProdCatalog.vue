<template>
    <div class="w-5/6">        
        <div>
        </div>
        <div class="flex mx-auto px-8 flex-wrap justify-between">
        <div class="prodCard w-2/6 mx-auto p-8" v-for="item in allItems" :key="item.id">
                <!-- <img :src="item.avatar" /> -->
                <p class="text-center font-bold">{{ item.name }}</p>
                <p class="text-center font-bold text-sm text-gray-400">${{ item.cost }}</p>
        </div>
        </div>

    <div class="paginator mx-auto w-1/6">

        <div class="page">
            
        </div>

        </div>  
    </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
    // data: {
    //     return: {
    //         ItemsPerPage: 6
    //     }
    // },
    // props: {
    //     itemsData: {
    //         type: array,
    //         default: () => {
    //             return []
    //         }
    //     }
    // },
    computed: mapGetters(["allPosts", 'postsCount', 'allItems']), // второй способ

    methods: mapActions(['fetchPosts', 'GET_ITEMS_FROM_API']), // более короткий способ вызова  UPD. actions это МЕТОД

    async mounted(){
            //this.$store.dispatch("fetchPosts"); 
            // вызываем action которыый затем вызовет mutation который уже передает данные на страницу
            this.fetchPosts(),
            this.GET_ITEMS_FROM_API()
    },
}
</script>