// function for Mock API
import axios from 'axios'

const categories = [
    {
        id: 'clothings',
        cName: 'Clothings',
        cSlug: 'clothings',
        cImage: 'https://cdn.discordapp.com/attachments/847046439380713523/848241741198000128/nigga.png',
        products: []
    },
    {
        id: 'shoes',
        cName: 'Shoes',
        cSlug: 'shoes',
        cImage: 'https://cdn.discordapp.com/attachments/847046439380713523/848242745289736232/shoes-neon.png',
        products: []
    },
    {
        id: 'accessories',
        cName: 'Accessories',
        cSlug: 'accessories',
        cImage: 'https://cdn.discordapp.com/attachments/847046439380713523/848242739321765938/acces_1.png',
        products: []
    }
]
function addProductsToCategory (products, category) {
    const categoryInner = { ...category, products: [] }
    products.map(p => {
        if (p.category_id === category.id) {
        categoryInner.products.push({
            id: p.id,
            pName: p.name,
            pCost: p.cost,
            pAvatar: p.avatar
        })
        }
    })
    return categoryInner
}

export const state = () => ({
CategoriesCards: [],
currentCategory: {},
currentProduct: {},

posts: [],

item: Object,
items: [],
users: []

})

export const actions = {
    async getCategoriesCards ({ commit }) {
        try {
        await commit('SET_CATEGORIES_CARDS', categories)
        } catch (err) {
        console.log(err)
        throw new Error('Внутреняя ошибка сервера, сообщите администратору')
        }
    },
    async getCurrentCategory ({ commit }, { route }) {
        const category = categories.find((clothings) => clothings.cSlug === route.params.CategorySlug)
        const products = await this.$axios.$get('Products')

        await commit('SET_CURRENT_CATEGORY', addProductsToCategory(products, category))
    },

    // ------------------- for sales page with axios

    async GET_ITEMS_FROM_API({commit}) {
    const res = await this.$axios.$get('Products')
    // const res = await axios.get('http://localhost:44380/api/Products')
    await commit('SET_ITEMS_TO_VUEX', res)
    },
    async GET_ITEM_TO_ID({commit}, index) {
        const res = await this.$axios.$get('Products/' + index)
        await commit('SET_ITEM_ID_TO_VUEX', res)
    },


    // ------------------- for new releases page

    async fetchPosts(context) {    // actions: забирает некую информацию из базы
        const res = await fetch('http://www.json-generator.com/api/json/get/ceVCfZFSBe?indent=2');
        const posts = await res.json();
        context.commit('updatePosts', posts) // вызываем мутацию и также передаем туда наш массив 
    }
    // https://jsonplaceholder.typicode.com/photos?_limit=3
}

export const mutations = {
    SET_CATEGORIES_CARDS (state, categories) {
        state.CategoriesCards = categories
    },
    SET_CURRENT_CATEGORY (state, category) {
        state.currentCategory = category
    },
    SET_CURRENT_PRODUCT (state, product) {
    state.currentProduct = product
    },
    updatePosts (state, posts) { // mutations: изменяет инфу уже на самой страничке
        state.posts = posts
    },
    SET_ITEMS_TO_VUEX(state, items) {
        state.items = items
    },
    SET_ITEM_ID_TO_VUEX(state, item){
        state.item = item
    },
    POST_SEND_LOGIN(state, newUser) {
        state.users.push(newUser);
    }

}

export const getters = {
    allPosts(state) {
        return state.posts
    },
    postsCount(state) {
        return state.posts.length
    },
    allItems(state) {
        return state.items
    },
    oneItem(state) {
        return state.item
    }
} 
