<template>
   <div class="row">
              <div class="col-sm-8 col-md-offset-1 blog-main">
                  <article class="clearfix" v-for="post in posts">
                
                  <div class="post-date">
                    <div class="row justify-content-between">
                      <div class="col-6">
                        {{ new Date(post.DateCreated).toLocaleDateString('de') }} | <a href=""> Jack </a>
                      </div>
                      <div class="col-2">
                        <span> <a href="">11 <i class="fa fa-comments-o" aria-hidden="true"></i></a > </span>
                      </div>
                    </div>
                 
                  </div>
                  <h3> <a :href="'/post/'+post.ID"> {{ post.Title }}</a></h3>
                  <p> 
                  <div v-if="post.Content!=null">
                  {{ post.Content.substr(0, 250) }}
                  </div>
                  <div v-else>
                  </div>
                   <a :href="'/post/'+post.ID"> . . . </a>
                  </p>
                  <a v-if="vars.isAuth" @click.prevent="delpost(post.ID)" href="#">Delete</a>
                 
                </article>             
                
                <nav class="blog-pagination">
                <router-link v-if="pagenr>1" class="btn btn-outline-secondary" :to="'/page/'+(pagenr-1)">Newer</router-link>
                <a v-else class="btn btn-outline-secondary disabled" href="#"> Newer </a>
                <router-link v-if="pagenr<pagecount" class="btn btn-outline-primary" :to="'/page/'+(pagenr+1)">Older</router-link>
                   <a v-else class="btn btn-outline-secondary disabled" href="#"> Older </a>
                </nav>

              </div>
              <!-- /.blog-main -->

  <p>
    <div v-on:onsavepost="getData"></div>
                <a href="#"> Back to top</a>
              </p>
            </div>
            <!-- /.row -->
    
</template>
<script lang="ts">
import  {Component, Vue, Watch,d }  from '../ext1'
import { RouterOptions, Location, RouteConfig, Route } from 'vue-router'
//import  {Vue }  from '../ext'
 var multiselect = require('vue-multiselect').default;
 import  store  from '../System/store'


 import DateTime from "typescript-dotnet-commonjs/System/Time/DateTime"


 @Component({
      name: 'home', components:{
        multiselect:multiselect   
    
     }
 })
export default class extends Vue {
  id='home'
   posts:d.Post[]=null
   pagenr = 1
   pagesize = 3
   pagecount = 1

    mounted() { this.getData();
  
       //here you show the alert
       this.$on("onsavepost",()=>{ 
        // console.log("catched the event2");
         this.getData();
         });
           
   } 

   getData()
   {
     if(this.$route.params["nr"]!=null)
     {
      this.pagenr = Number.parseInt( this.$route.params["nr"]);
     }
     if (this.db.connected) {
       this.db.bHub.getPosts("", "", this.pagenr,this.pagesize).then((res:
         d.Post[]) => {  this.posts = res;//
           if(res.length>0)
           this.pagecount =res[0].Count/this.pagesize;

         }).catch((reason:any)=>{console.log(reason);});
       }

    }

    delpost(ID:number)
    {
      //console.log("deleting"+ID);
        this.db.bHub.deletePost(ID).then(()=>{

      this.getData();
       // console.log("getin data");
        });
     
    }

  @Watch('db', { immediate:true })
  watchthis(neval, oldval) { // 
    console.log(this.$route.path);
      if (this.db.connected) {
        this.getData();    
    }
  }


  @Watch("$route", { immediate:true })
        watchpath(this, newVal?: any, oldVal?: any) { // this.$route.path:string , newVal?:any, oldVal?:any 
            if (this.$route.path != undefined)
                 this.getData();    
        }


   }
 

</script>
