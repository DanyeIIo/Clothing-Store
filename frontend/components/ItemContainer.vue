<template>
        <div class="prodCard mx-auto">
            <img :src="item_data.avatar" />
            <p class="text-center font-bold">{{ item_data.name }}</p>
            <p class="text-center font-bold">{{ item_data.model }}</p>
            <p class="text-center font-bold text-sm text-gray-400">{{ item_data.cost }}</p>
    </div>
</template>

<script>
export default {
    props: {
        item_data: {
            type: Object,
            default: () => {
                return {}
            }
        }
    }
}
</script>