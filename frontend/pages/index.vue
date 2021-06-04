<template>
  <section>
    <div class="mx-auto my-40">
      <div class="container mx-auto px-8 bg-transparent relative">
        <h1 class="text-6xl ml-8 text-gray-100 custom-font font-bold">
          Build a different, <br> like you want.
          </h1>
        <p class="font-poppy text-sm ml-20 text-gray-100 -mt-4 leading-relaxed">
          Find all your favorites at Slaves. Shop the <br> latest and greatest releases from Nike, Jordan,<br> adidas, Converse, Vans, and much more.
          </p>
        
        <div class="absolute left-2/4 -top-1/3">
          <img src="../assets/pictures/sneaker.png" class="-mt-8 -ml-8">
        </div>
        <nuxt-link to="#" class="block text-sm">
          <button class="px-10 py-4 bg-gray-50 rounded-md ml-24 mt-14 hover:bg-purple-700 hover:text-white shadow-md">
            View All Products
          </button>
        </nuxt-link>

      </div>
    </div>

    <div class="mt-60">
      <categories-cards :categories="categories" />
    </div>

  </section>
</template>

<script>
import CategoriesCards from '@/components/CategoriesCards'
import { mapState } from 'vuex'
export default {
  layout: 'home',

  components: {
    CategoriesCards
  },
  async asyncData ({ app, route, params, error, store }) {
    try {
      await store.dispatch('getCategoriesCards')
    } catch (err) {
      console.log(err)
      return error({
        statusCode: 404,
        message: 'Категории не найдены или сервер не доступен'
      })
    }
  },
  computed: {
    ...mapState({
      categories: 'CategoriesCards'
    })
  }

}
</script>

<style scoped>
.custom-font{
  font-family:verdana;
}
</style>
