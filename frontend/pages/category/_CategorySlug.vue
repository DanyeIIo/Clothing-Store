<template>
<div>
    <h1>category page</h1>
    <h1>{{ category.cName }}</h1>
    <div class="flex">
        <LeftBar />
        <div v-for="product in allItems" :key="product.id">
            <img :src="product.avatar" />
            <p class="text-center font-bold">{{ product.name }}</p>
            <p class="text-center font-bold">{{ product.model }}</p>
            <p class="text-center font-bold text-sm text-gray-400">{{ product.cost }}</p>
        </div>
    </div>
</div>
</template>

<script>
import { mapState, mapGetters, mapActions } from 'vuex'
import ProductDump from '@/components/ProductDump'
import LeftBar from '~/components/LeftSection.vue'
import ItemContainer from '~/components/ItemContainer.vue'
export default {
    components: {
        ProductDump,
        LeftBar,
        ItemContainer
    },
        async asyncData ({ app, params, route, error }) {
            try {
            await app.store.dispatch('getCurrentCategory', { route })
            } catch (err) {
            console.log(err)
            return error({
                statusCode: 404,
                message: 'Категория не найдена или сервер не доступен'
            })
            }
        },
    computed: {
        ...mapState({
        category: 'currentCategory'
        }),
        ...mapGetters([
            'allPosts',
            'postsCount',
            'allItems'
        ])
    },
    methods: mapActions(['fetchPosts', 'GET_ITEMS_FROM_API']),
    async mounted(){
        this.fetchPosts(),
        this.GET_ITEMS_FROM_API()
    }  
}
</script>
<style scoped>
.productList {
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
}
</style>