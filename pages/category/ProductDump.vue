<template>
<div class="w-1/3 mx-auto">
    <nuxt-link :to="`/product/${product.pSlug}`">
        <p>{{ product.pName }}</p>
        <img :src="product.image" />
    </nuxt-link>
    <p>Цена {{ product.pPrice }}</p>
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
