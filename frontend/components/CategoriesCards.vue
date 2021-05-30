<template>
  <div>
    <div class="flex justify-center w-full px-8">
      <div v-for="category in categories" :key="category.cSlug" class="relative px-4">
        <nuxt-link :to="`/category/${category.cSlug}`">
          <img :src="category.cImage"  />

            <p class="text-center bg-purple-600 bg-opacity-50 text-2xl tracking-wide text-white font-custom hover:bg-purple-600 hover:text-black absolute h-14 w-3/6 pt-3 top-56 left-24">
            {{ category.cName }}</p>
        </nuxt-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    categories: {
      type: Array,
      default: () => []
    }
  }
}
</script>

