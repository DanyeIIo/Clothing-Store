<template>
    <div class="row-start-4">        
        <div>
        </div>
        <div class= "p-4 grid md:grid-rows-3 md:grid-flow-col gap-4  sm:grid-rows-4 sm:grid-flow-row">
        <!-- <ItemContainer 
            v-for="product in paginatedProducts" 
            :key="product.id"
            :item_data="product"
        /> -->
        <div class="prodCard mx-auto cursor-pointer" 
        v-for="(product) in paginatedProducts"
        :key="product.id" 
        @click.prevent="openProduct(product)">
        

            <img :src="product.avatar" />
            <p class="text-center font-bold">{{ product.name }}</p>
            <p class="text-center font-bold" v-if="product.model != null">"{{ product.model }}"</p>
            <p class="text-center font-bold text-sm text-gray-400">${{ product.cost }}.00</p>
            </div>
        </div>

    <div v-if="pages < 9" class="paginator my-8 grid grid-flow-col gap-2">
        
        <div class="justify-self-start transform hover:scale-110 cursor-pointer">
            <div @click="prevPage(pageNumber)" v-if="pageNumber > 1" class="grid grid-flow-col">
                <img src="~/assets/pictures/ArrowBlack.png" alt="Prev page" class="transform rotate-180">
                <p>Prev Page</p>
            </div>
        </div>

        <div v-for="page in pages" 
        :key="page" 
        @click="ChangePage(page)"
        class=" pt-0.5 text-center mx-1 hover:bg-deep-blue hover:text-white"
        :class="{'bg-deep-blue text-white': page === pageNumber}">
            {{ page }}
        </div>

        <div class="pr-40 justify-self-end transform hover:scale-110 cursor-pointer">
            <div @click="nextPage(pageNumber)" v-if="pageNumber < pages" class="grid grid-flow-col">
                <p>Next Page</p>
                <img src="~/assets/pictures/ArrowBlack.png" alt="Next page" class="">
            </div>
        </div>

        </div>  
    </div>
</template>

<script>
import ItemContainer from '~/components/ItemContainer.vue'

export default {
    props: {
        ProductsList: {
            type: Array,
            default: () => {
                return []
            }
        }
    },
    components: {
        ItemContainer
    },
    data() {
        return {
            ItemsPerPage: 9,
            pageNumber: +this.$route.query.page || 1,
        }
    },
    computed: {
        pages() {
            return Math.ceil(this.ProductsList.length / this.ItemsPerPage);
        },
        paginatedProducts() {
            let startElem = (this.pageNumber - 1) * this.ItemsPerPage;
            let endElem = startElem + this.ItemsPerPage;
            return this.ProductsList.slice(startElem, endElem);
        }
    },
    methods: {
        ChangePage(page) {
            this.$router.push(`${this.$route.path}?page=${page}`);
            this.pageNumber = page;
        },
        nextPage(pageNumber) {
            // if(pageNumber + 1 > Math.ceil(this.ProductsList.length / this.ItemsPerPage)){
            //     return;
            // }
            this.$router.push(`${this.$route.path}?page=${pageNumber+1}`);
            this.pageNumber++;
        },
        prevPage(pageNumber) {
            // if(pageNumber - 1 < Math.ceil(this.ProductsList.length / this.ItemsPerPage)){
            //     return;
            // }
            this.$router.push(`${this.$route.path}?page=${pageNumber-1}`);
            this.pageNumber--;
        },
        openProduct(product) {
            this.$router.push('/cat/product/' + product.id)
            // this.$router.push(`${this.$route.path}/product/${product.id}`);
        }
    }
    
}
</script>