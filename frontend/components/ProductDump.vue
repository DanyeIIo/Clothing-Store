<template>
<div class="">
    <nuxt-link :to="`/product/${product.id}`">
        <p>{{ product.name }}</p>
        <img :src="product.avatar" />
    </nuxt-link>
    <p>Цена {{ product.cost }}</p>
</div>
</template>

<script>
export default {
    props: {
        product: {
        type: Object,
        default: () => {}
        }
    }
}
</script>
