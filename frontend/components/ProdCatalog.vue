<template>
    <div class="row-start-4">        
        <div>
        </div>
        <div class="flex px-4 flex-row flex-wrap">
        <!-- <ItemContainer 
            v-for="product in paginatedProducts" 
            :key="product.id"
            :item_data="product"
        /> -->
        <div class="prodCard mx-auto cursor-pointer" 
        v-for="product in ProductsList"
        :key="product.id" 
        @click.prevent="openProduct(product)">

            <img :src="product.avatar" />
            <p class="text-center font-bold">{{ product.name }}</p>
            <p class="text-center font-bold">{{ product.model }}</p>
            <p class="text-center font-bold text-sm text-gray-400">{{ product.cost }}</p>
            </div>
        </div>

    <div v-if="pages > 9" class="paginator mx-auto flex flex-wrap justify-center">
        <p @click="prevPage(pageNumber)" v-if="pageNumber > 1">prev</p>

        <div v-for="page in pages" 
        :key="page" 
        @click="ChangePage(page)"
        class="page p-2 border-2 mx-1 border-blue-500 hover:bg-gray-400">
            {{ page }}
        </div>

        <p @click="nextPage(pageNumber)" v-if="pageNumber < pages">next</p>
        <div>
        </div>
        <!-- <p class="text-red-500">{{ this.pageNumber }}</p> -->
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
            // currentPage: 0
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
            if(pageNumber + 1 > Math.ceil(this.ProductsList.length / this.ItemsPerPage)){
                return;
            }
            this.$router.push(`${this.$route.path}?page=${pageNumber+1}`);
            this.pageNumber++;
            console.log(pageNumber)
        },
        prevPage(pageNumber) {
            if(pageNumber - 1 < Math.ceil(this.ProductsList.length / this.ItemsPerPage)){
                return;
            }
            this.$router.push(`${this.$route.path}?page=${pageNumber-1}`);
            this.pageNumber--;
        },
        openProduct(product) {
            // this.$router.push('/cat/product/' + product.id)
            this.$router.push(`${this.$route.path}/product/${product.id}`);
        }
    }
    
}
</script>