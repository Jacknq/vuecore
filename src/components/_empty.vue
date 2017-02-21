<template>
   <div>

   </div>
</template>
<script lang="ts">
    import { Component, create, getHelper, Vue, Store, Prop, Watch } from '../ext'

    var multiselect = require('vue-multiselect').default;
 
    @Component({
        components: { multiselect: multiselect }  //multiselect:Multiselect 
        // watch:{ '$route.path': function(newVal?:any, oldVal?:any ){ // this.$route.path:string , newVal?:any, oldVal?:any 
        //      if(this.$route.path!=undefined)
        //      console.log('Changed current path to: ' + this.$route.path);
        //  } } 
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