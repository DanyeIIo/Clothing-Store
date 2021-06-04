<template>
<div class="container flex">
        <LeftSection />
        <ProductsCatalog />
</div>   
</template>

<script>

import LeftSection from '~/components/LeftSection'
import ProductsCatalog from '~/components/ProductsCatalog'

export default {
components: {
        LeftSection,
        ProductsCatalog
}                        
}
</script>


