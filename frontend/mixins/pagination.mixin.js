import _ from 'lodash'
// Vue.component('paginate', VuejsPaginate)

export default{
    data() {
        return{
            page: 1,
            pageSize: 6,
            pageCount: 0,
            allItems: [],
            items: []
        }
    },
    methods: {
        setupPagination(allItems) {
            this.allItems = _.chunk(allItems, this.pageSize);
            this.pageCount = _.size(this.allItems);
            this.items = this.allItems[this.page - 1] || this.allItems[0];
        }
    }
}