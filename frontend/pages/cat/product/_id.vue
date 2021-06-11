<template>
    <section>
        <!-- <h1>dynamic Product page {{$route.params.id}} </h1> -->
        <!-- <div class="prodCard mx-auto cursor-pointer">

            <img :src="oneItem.avatar" />
            <p class="text-center font-bold">{{ oneItem.name }}</p>
            <p class="text-center font-bold">{{ oneItem.model }}</p>
            <p class="text-center font-bold text-sm text-gray-400">{{ oneItem.cost }}</p>
            <p class="text-center font-bold text-sm text-gray-400">{{ oneItem.id }}</p>
            </div> -->
        <div class="leftSide flex">
            <VueSlickCarousel v-bind="settings" @init="onInitCarousel" class="w-3/6 mx-20">
                <template #prevArrow="arrowOption">
                    <div class="l-arrow">
                        <img src="~/assets/pictures/ArrowBlack.png" alt="Prev page" class="transform rotate-180">
                        {{ arrowOption.currentSlide }}/{{ arrowOption.slideCount }}
                    </div>
                </template>
                <!-- <div class="bg-red-600 text-white text-center text-4xl font-semibold p-36">Red</div> -->
                <img src="https://cdn.discordapp.com/attachments/847046439380713523/852085016644681738/14285993_27516459_2048.jpg" alt="">
                <div class="bg-yellow-400 text-white text-center text-4xl font-semibold p-36">Yellow</div>
                <div class="bg-green-400 text-white text-center text-4xl font-semibold p-36">Green</div>
                <div class="bg-blue-600 text-white text-center text-4xl font-semibold p-36">Blue</div>
                <template #nextArrow="arrowOption">
                    <div class="r-arrow">
                        <img src="~/assets/pictures/ArrowBlack.png" alt="Prev page">
                        {{ arrowOption.currentSlide }}/{{ arrowOption.slideCount }}
                    </div>
                </template>
            </VueSlickCarousel>

            <div class="rightSide w-3/6">
                <h2 class="text-center">{{ oneItem.name }}</h2>
                <p  class="text-center"> "{{ oneItem.model }}"</p>
                <p  class="text-center"> ${{ oneItem.cost }}.00</p>

                <div class="border-2 m-8 h-40">

                </div>
                <div class="border-2 m-8 h-40">

                </div>
            </div>
        </div>
            <div class="description w-5/6 px-20">
                <p>{{ oneItem.description }}</p>
            </div>

            <div class="mx-auto w-1/3 my-8">
                <img src="~/assets/pictures/qr-code.png" class="mx-auto" alt="">
            </div>
    </section>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

import VueSlickCarousel from 'vue-slick-carousel'
import 'vue-slick-carousel/dist/vue-slick-carousel.css'
// optional style for arrows & dots
import 'vue-slick-carousel/dist/vue-slick-carousel-theme.css'
export default {
    // validate({params}){
    //     return /^\d+$/.test(params.id)
    // },
    components: {
        VueSlickCarousel
    },
    data() {
        return {
            settings: {
                dots: true,
                infinite: true,
                rows: 1,
                initialSlide: 0,
                speed: 500,
                slidesToShow: 1,
                slidesToScroll: 1,
                swipeToSlide: true,
                arrows: true,
            },
        }
    },
    computed: mapGetters(['allItems', 'oneItem']),
    methods: mapActions(['GET_ITEMS_FROM_API', 'GET_ITEM_TO_ID']),
    async mounted(){
        this.GET_ITEMS_FROM_API(),
        this.GET_ITEM_TO_ID(this.$route.params.id)
    }  

}
</script>

<style scoped>
.l-arrow{
    margin-left: 50px;
    z-index: 3;
    fill: cyan;
}
.r-arrow{
    margin-right: 50px;
    z-index: 3;
    color: cyan;
    
}
</style>