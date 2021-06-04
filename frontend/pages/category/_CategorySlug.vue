<template>
<div>
    <h1>{{ category.cName }}</h1>
    <p>{{ category.cDesc }}</p>
    <div :class="productList">
    <div v-for="product in category.products" :key="product.id">
        <!-- <ProductDump :product="product" /> -->
    </div>
    </div>
</div>
</template>

<script>
import ProductDump from '@/components/ProductDump'
import { mapState } from 'vuex'
export default {
components: {
    ProductDump
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
    })
},
head () {
    return {
    title: this.category.cTitle,
    meta: [
        {
        hid: 'description',
        name: 'description',
        content: this.category.cMetaDescription
        }
    ]
    }
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