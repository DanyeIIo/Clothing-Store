<template>
    <div class="w-5/6">        
        <div>
        <h1 class="text-center">Products count: {{ postsCount }}</h1>
        </div>
        <div class="flex mx-auto px-8 flex-wrap justify-between">
        <div class="prodCard w-2/6 mx-auto p-8" v-for="post in allPosts" :key="post.id">
                <img :src="post.avatar" />
                <p class="text-center font-bold">{{ post.name }}</p>
                <p class="text-center font-bold text-sm text-gray-400">{{ post.Cost }}</p>
        </div>
        </div>
    <div class="mx-auto w-1/6">
        <p>чертова пагинация</p>

        <div class="page">
            
        </div>







        <!-- <paginate
        :page-count="20"
        :click-handler="functionName"
        :prev-text="'Prev'"
        :next-text="'Next'"
        :container-class="'className'">
        </paginate>
        <script src="https://unpkg.com/vuejs-paginate@latest"></script> -->
    </div>  
    </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
// import paginationMixin from '~/mixins/pagination.mixin'

export default {
        // mixins: [paginationMixin],
    computed: mapGetters(["allPosts", 'postsCount']), // второй способ

    methods: mapActions(['fetchPosts']), // более короткий способ вызова actions  UPD. actions это МЕТОД

    // computed: { // первый вариант вызова getters
    //     allposts(){
    //         return this.$store.getters.allPosts;
    //     }
    // },
    async mounted(){
            //this.$store.dispatch("fetchPosts"); // вызываем action которыый затем вызовет mutation который уже передает данные на страницу
            this.fetchPosts();
    },
}
</script>