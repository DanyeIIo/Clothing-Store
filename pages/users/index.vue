<template>
    <section>
        <div class="mx-auto w-3/4">
            <h1 class="text-center">Users page</h1>
            <ul>
                <li v-for="user of 5" :key="user">
                    <a href="#" @click.prevent="openUser(user)"> User {{user}} </a>
                </li>
            </ul>
        </div>
    </section>
</template>

<script>
export default {
    methods:{
        openUser(user){
            this.$router.push('/users/' + user)
        }
    }
}
</script>