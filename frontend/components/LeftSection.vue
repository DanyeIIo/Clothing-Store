  <template>
            <div class="leftBar h-2/6 row-start-2 px-8">
                <h4 class="text-gray-500 font-bold">New releases(22)</h4>
                <hr class="border-t-2 border-gray-500 mt-2 py-4">
                <ul>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Sports Bras</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Bodysuits</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Tops & T-Shirts</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Hoodies & Pullovers</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Jackets & Vests</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Pants & Tights</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Shorts</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Compression & Baselayer</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Tracksuits</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Jumpsuits & Rompers</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Skirts & Dresses</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Swimwear</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Socks</nuxt-link></li>
                        <li class="text-gray-500 font-medium pb-0.5"><nuxt-link to="#" class="hover:text-gray-800">Accessories & Equipment</nuxt-link></li>
                </ul>
                <hr class="border-t-2 border-gray-500 my-8">

                <p>Gender</p>
                <input type="checkbox" class="" id="male">
                <label for="male">Male</label><br>
                <input type="checkbox" id="female">
                <label for="female">Female</label><br>
                <input type="checkbox" id="unisex">
                <label for="unisex">Unisex</label><br>

                <hr class="border-t-2 border-gray-500 my-8">

                <p>Kids</p>
                <input type="checkbox" class="" id="boy">
                <label for="boy">Boy</label><br>
                <input type="checkbox" id="girl">
                <label for="girl">Girl</label><br>

                <label class="inline-flex items-center mt-3">
                <input type="checkbox" class="form-checkbox h-3 w-3 text-gray-600"><span class="ml-2 text-gray-700">label</span>
                </label><br>

        </div>
</template>


<style scoped>
.leftBar{
  overflow-y: scroll;
}
.leftBar::-webkit-scrollbar {
  width: 7px;
  background-color: #ffffff;
}

.leftBar::-webkit-scrollbar-thumb {
  border-radius: 7px;
  background-color: rgba(107, 114, 128);
}

.leftBar::-webkit-scrollbar-track {
  border-radius: 7px;
  background-color: #ffffff;
}
</style>