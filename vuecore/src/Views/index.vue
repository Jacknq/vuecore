<template>
<div class="container-fluid">
    <div class="row">
        <div class="col-md-3 col-lg-3">

            <div class="bootstrap-vertical-nav">

                <button class="btn btn-primary hidden-md-up" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
                    <span class="">Menu</span>
                </button>

                <div class="collapse" id="collapseExample">
                    <ul class="nav flex-column" id="exCollapsingNavbar3">
                        <li class="nav-item">
                            <a class="nav-link active" href="#">Post</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link disabled" href="#">Comments</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link disabled" href="#">Category</a>
                        </li>
                        <li class="nav-item">
                      <!--<router-link exact data-toggle="collapse" data-target="navbar-header" to="/">Home</router-link>-->
                      </li>
                    </ul>
                </div>

            </div>

        </div>
          <div class="col-md-9 col-lg-9">
            <h2> Index</h2>
            <editpost @onsavepost="onsavepost"/>
            
            <listpost/>
        </div>
    </div>
</div>

</template>
<script lang="ts">
import { Component, Vue, d } from "../ext1";
//imagine origin of component will be direfent library one day,
// this way you only make update only in ext file
import editpost from "../components/post-edit.vue";
import listpost from "../components/post-list.vue";
var multiselect = require("vue-multiselect").default;

@Component({
  components: { multiselect: multiselect, editpost, listpost }
})
export default class admin extends Vue {
  name = "admin";

  public somemethod(newSelected) {
    console.log("enter your code");
  }
  mounted() {
    //here you show the alert
    // this.$on("onsavepost", () => {
    //  }); //.$forceUpdate();
    // });
  }
  onsavepost(post: d.Post) {
    console.log("catched the event1");
  }
}
</script>
<style lang="less" >
/*
 * Sidebar
 */
/* Creates a vertical nav starting at 768px (sm) */
@media (min-width: 480px) {
  .bootstrap-vertical-nav .collapse {
    display: block;
  }
}
</style>