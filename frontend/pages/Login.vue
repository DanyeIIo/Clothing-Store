<template>
    <div class="w-3/6 mx-auto">
    <h1>Регистрация</h1>
        <form @submit.prevent="submit">
            <input type="text" v-model="email" placeholder="email" class="bg-gray-200 p-2">
            <input type="text" v-model="password" placeholder="password" class="bg-gray-200 p-2">
            <button class="bg-purple-300 p-4" type="submit">Send</button>
        </form>
    </div>
</template>


<script>
export default {
    data() {
        return {
            email: '',
            password: ''
        }
    },
    methods: {
        submimt() {

        }
    }
}
</script>