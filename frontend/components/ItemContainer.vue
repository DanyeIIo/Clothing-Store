<template>
        <div class="prodCard w-2/6 mx-auto p-8">
            <img :src="item.avatar" />
            <p class="text-center font-bold">{{ item.name }}</p>
            <p class="text-center font-bold text-sm text-gray-400">{{ item.Cost }}</p>
    </div>
</template>