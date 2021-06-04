<template>
    <div class="container">
        <div class="leftMenu">

        </div>
        <div >
            <h1>{{ postsCount }}</h1>
        </div>
        <div class="flex mx-auto w-2/3 px-8 flex-wrap justify-between">
            <div class="w-2/6 mx-auto" v-for="post in allPosts" :key="post.id">
                <img :src="post.thumbnailUrl" />
                <p>{{ post.title }}</p>
            </div>
        </div>
    </div>    
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
export default {
    computed: mapGetters(["allPosts", 'postsCount']), // второй способ
    methods: mapActions(['fetchPosts']), // более короткий способ вызова  UPD. actions это МЕТОД

    // computed: { // первый вариант
    //     allposts(){
    //         return this.$store.getters.allPosts;
    //     }
    // },
    async mounted(){
        //this.$store.dispatch("fetchPosts"); // вызываем action которыый затем вызовет mutation который уже передает данные на страницу
        this.fetchPosts(14);
    }                                      
}
</script>

