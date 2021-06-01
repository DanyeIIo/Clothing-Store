// function for Mock API

const sleep = m => new Promise(r => setTimeout(r, m))
const categories = [
    {
        id: 'clothings',
        cTitle: 'Clothings',
        cName: 'Clothings',
        cSlug: 'clothings',
        cImage: 'https://cdn.discordapp.com/attachments/847046439380713523/848241741198000128/nigga.png',
        cMetaDescription: 'Мета описание',
        cDesc: 'Описание',
        products: []
    },
    {
        id: 'shoes',
        cTitle: 'Shoes',
        cName: 'Shoes',
        cSlug: 'shoes',
        cImage: 'https://cdn.discordapp.com/attachments/847046439380713523/848242745289736232/shoes-neon.png',
        cMetaDescription: 'Мета описание',
        cDesc: 'Описание',
        products: []
    },
    {
        id: 'accessories',
        cTitle: 'Accessories',
        cName: 'Accessories',
        cSlug: 'accessories',
        cImage: 'https://cdn.discordapp.com/attachments/847046439380713523/848242739321765938/acces_1.png',
        cMetaDescription: 'Мета описание',
        cDesc: 'Описание',
        products: []
    }
]
function addProductsToCategory (products, category) {
    const categoryInner = { ...category, products: [] }
    products.map(p => {
        if (p.category_id === category.id) {
        categoryInner.products.push({
            id: p.id,
            pName: p.pName,
            pSlug: p.pSlug,
            pPrice: p.pPrice,
            image: `https://source.unsplash.com/300x300/?${p.pName}`
        })
        }
    })
    return categoryInner
}

export const state = () => ({
CategoriesCards: [],
currentCategory: {},
currentProduct: {}
})
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
    GET_ALL_PRODUCTS (state, products) {
        state.products = products
    }
}
export const actions = {
    async getCategoriesCards ({ commit }) {
        try {
        await sleep(1000)
        await commit('SET_CATEGORIES_CARDS', categories)
        } catch (err) {
        console.log(err)
        throw new Error('Внутреняя ошибка сервера, сообщите администратору')
        }
    },
    async getAllProducts()
    {
        let res = await this.$axios.get('/api/Products')
        return res;
    },
    async getCurrentCategory ({ commit }, { route }) {
    await sleep(1000)
    const category = categories.find((cat) => cat.cSlug === route.params.CategorySlug)
    const products = await this.$axios.$get('/mock/products.json')

    await commit('SET_CURRENT_CATEGORY', addProductsToCategory(products, category))
    }
}