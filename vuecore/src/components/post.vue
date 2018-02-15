<template>
   <div>
            <article v-if="dpost!=null" class="clearfix" >
                
                  <div class="post-date">
                    <div class="row justify-content-between">
                      <div class="col-6">
                        {{ dpost.DateCreated | dtformat }} | <a href="#"> Jack </a>
                      </div>
                      <div class="col-2">
                        <span> <a href="#">11 <i class="fa fa-comments-o" aria-hidden="true"></i></a > </span>
                      </div>
                    </div>
                 
                  </div>
                  <h3> <router-link :to="'/post/'+dpost.ID" >{{ dpost.Title }}</router-link> </h3>
                   
                  <div v-if="dpost.Content!=null">
                  {{ dpost.Content }}
                  </div>                  
                   <a :href="'/post/'+dpost.ID"> . . . </a>
                  
                  <a v-if="!vars.isAuth" @click.prevent="delpost(dpost.ID)" href="#">Delete</a>
                 
                </article>
   </div>
</template>
<script lang="ts">
import { Component, Vue, Prop, Watch, d } from "../ext1";

@Component({})
export default class post extends Vue {
  id = "post";

  @Prop({ default:null}) post: d.Post;
  dpost = this.post;

created()
{
  if(this.dpost==null)
  {
     if (this.$route.params["id"] != null) {
    this.db.bHub.getPosts(this.$route.params["id"], "", 1,1)
    .then((r:d.Post[])=>{
      if(r!=null&& r.length>0)
      {
      this.dpost = r[0];
      }
      });
     }
  }
}

  delpost(ID: number) {
  
    this.db.bHub.deletePost(ID).then((ID) => {
      //success
      this.$emit("ondeletepost", ID);
    });
  }
}
</script>
<!--<style lang="less" >
</style>-->