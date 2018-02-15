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
import { Component, Vue, Prop, Watch, d } from "../ext1";
import DateTime from "typescript-dotnet-commonjs/System/Time/DateTime";
// var multiselect = require('vue-multiselect').default;

@Component({
  // components: { multiselect: multiselect }
})
export default class epost extends Vue {
  name = "editpost";
  mode = "insert";

  post: d.Post = new d.Post();

  saved: boolean = false;

  save() {
    if (this.mode == "insert") {
      this.db.bHub.insertPost(this.post).then((v: number) => {
        this.saved = true;
        //let know parent
        this.$emit("onsavepost", this.post);
        //in this case I dont share any global state, didnt modify any state,
        //so I raise event on eventbus - otherwise I would commit mutation
        this.$store.state.bus.$emit("onsavepost", this.post);

        this.initNewData();
        this.showSucc();
      });
    }
  }
  initNewData() {
    this.post = new d.Post();
    this.post.DateCreated = DateTime.now.toJsDate();
  }
  showSucc() {
    window.setTimeout(() => {
      this.saved = false;
    }, 4000);
  }
  showErr() {}

  mounted() {
    //here you show the alert
    if (this.mode == "insert") {
      this.initNewData();
    }
  }
}
</script>