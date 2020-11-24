<template>
   <div>

   </div>
</template>
<script lang="ts">
    import { Component, Vue, Prop, Watch } from '../ext1' 
 
    @Component({
      
    })
    export default class compname extends Vue {
        name = 'compname'
    
        public somemethod(newSelected) {
            console.log("enter your code")
          
        }          

    }
</script>
<!--<style lang="less" >
</style>-->