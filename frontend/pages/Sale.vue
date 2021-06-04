<template>
<div>
    <h1 class="text-center">Sales</h1>
    <div class="container flex">
            <LeftSection />
            <ProdCatalog />
    </div>
</div>   
</template>

<script>
import LeftSection from '~/components/LeftSection'
import ProdCatalog from '~/components/prodCatalog'

export default {
    components: {
            LeftSection,
            ProdCatalog
    }                        
}
</script>


