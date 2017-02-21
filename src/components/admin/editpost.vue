<template>
   <!--<div class="container">
       <form>-->
        <div>
<div class="form-group">
  <div class="col-10">
    <div class="form-control alert alert-success" :class="{'hidden-xs-up':!saved}" role="alert">
      <strong>Done!</strong> Save successffull.
    </div>
  </div>
  <div class="col-10">
    <div class="form-control alert alert-danger hidden-xs-up" role="alert">
      <strong>Oops!</strong> Some error ocured.
    </div>
  </div>
</div>

<div class="form-group">
  <label for="example-text-input" class="col-2 col-form-label">Title</label>
  <div class="col-10">
    <input class="form-control" type="text" v-model="post.Title"  id="example-text-input">
  </div>
</div>

 <div class="form-group">
    <label class="col-2 col-form-label" for="exampleTextarea">Content</label>
    <div class="col-10">
    <textarea class="form-control"  v-model="post.Content" id="exampleTextarea" rows="10"></textarea>
    </div>
  </div>

 <div class="form-group">
    <div class="offset-8">
    <button type="submit" @click.stop='save' class="btn btn-primary">Save</button>
    </div>
       
     
    </div>
       
   </div>
</template>
<script lang="ts">
import { Component, create, getHelper, Vue, Store, Prop, Watch,d, p,Vuex,Lifecycle } from '../../ext1'
import DateTime from "typescript-dotnet-commonjs/System/Time/DateTime"
    var multiselect = require('vue-multiselect').default;
 
    @Component({
        components: { multiselect: multiselect }  
  
    })
    export default class epost extends Vue {
        name = 'editpost'
        mode = 'insert'

        mselected = [];
        options = ['polo', 'trans', 'golf','jaguar', 'a6', 'tiguan', 'kadjar','ateca']; 

        post:d.Post = new d.Post();
       
        saved:boolean =false;
  
    addTag(tag:string)
    {
        this.options.push(tag);
         this.mselected.push(tag)
    }
    updateSelectedTagging (value) { //this.post.Categories
       // console.log('@tag: ', value)
        this.mselected = value
      }
      save()
      {
        if(this.mode=='insert')
        {
          this.db.bHub.insertPost(this.post);
          this.saved = true;
          this.initNewData();
          this.showSucc();
          this.$parent.$emit("onsavepost", this.post);
        }
      
      }
      initNewData()
      {
          this.post = new d.Post();
          this.post.DateCreated = DateTime.now.toJsDate();

      }
      showSucc()
      {
          window.setTimeout(()=> {       
               this.saved = false;         
        }, 4000);              
      }
      showErr()
      {
               
      }
     
      @Lifecycle mounted() {
       //here you show the alert
       if(this.mode=='insert')
        {
         this.initNewData();
        }

      }
        

    }
</script>