<template>
   <div class="row">
              <div class="col-sm-8 col-md-offset-1 blog-main">
                <div v-for="post in posts" :key="post.ID">                
                    <post :post="post"></post>
                </div>             
                
                <nav class="blog-pagination">
                <router-link v-if="pagenr>1" class="btn btn-outline-secondary" :to="'/page/'+(pagenr-1)">Newer</router-link>
                <a v-else class="btn btn-outline-secondary disabled" href="#"> Newer </a>
                <router-link v-if="pagenr<pagecount" class="btn btn-outline-primary" :to="'/page/'+(pagenr+1)">Older</router-link>
                   <a v-else class="btn btn-outline-secondary disabled" href="#"> Older </a>
                </nav>

              </div>
              <!-- /.blog-main -->

  <p>
   
                <a href="#"> Back to top</a>
                <div> {{msg}} </div>
              
                
               
            </div>
            <!-- /.row -->
    
</template>
<script lang="ts">
import { Component, Vue, Watch, d } from "../ext1";//encapsulate libs, good when source changes 
import { RouterOptions, Location, RouteConfig, Route } from "vue-router";

//import store from "../System/store";
import { Api } from "../../test";
import post from "../components/post.vue";


@Component({
  name: "home",
  components: {
    post
  }
})
export default class extends Vue {
  id = "listpost";
  posts: d.Post[] = null;
  pagenr = 1;
  pagesize = 3;
  pagecount = 1;
  msg = "";

  created() {
    this.getData();

    //here you show the alert
    this.$store.state.bus.$on("onsavepost", (post:d.Post) => {
      this.getData();
    });
    this.log('url:'+this.vars.servurl);
    let api: Api = new Api(this.vars.servurl);
    if(this.msg=='')
    {  api.test.hello("something").then((val)=>{  this.msg = val;    });    }

  }
  mounted()
  {
 
  }

  getData() {
    if (this.$route.params["nr"] != null) {
      this.pagenr = Number.parseInt(this.$route.params["nr"]);
    }
    if (this.db.connected) {
      this.db.bHub
        .getPosts("", "", this.pagenr, this.pagesize)
        .then((res: d.Post[]) => {
          this.posts = res; //
          if (res.length > 0) this.pagecount = res[0].Count / this.pagesize;
        })
        .catch((reason: any) => {
          console.log(reason);
        });
    }
  }

 

  @Watch("connected")
  watchthis(neval, oldval) {
    //
    console.log(this.$route.path);
    if (this.connected) {
      this.getData();
    }
  }

  @Watch("$route", { immediate: true })
  watchpath(this, newVal?: any, oldVal?: any) {
    // this.$route.path:string , newVal?:any, oldVal?:any
    if (this.$route.path != undefined) this.getData();
  }
}
</script>
