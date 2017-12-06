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
            <h2> Admin</h2>
            <editpost/>
            
            <home/>
        </div>
    </div>
</div>

</template>
<script lang="ts">
import { Component, Vue } from "../ext";
//imagine origin of component will be direfent library one day,
// this way you only make update in ext file
import editpost from "../components/admin/editpost.vue";
import home from "../Views/home.vue";
var multiselect = require("vue-multiselect").default;

@Component({
  components: { multiselect: multiselect, editpost, home }
})
export default class admin extends Vue {
  name = "admin";

  public somemethod(newSelected) {
    console.log("enter your code");
  }
  mounted() {
    //here you show the alert
    this.$on("onsavepost", () => {
      console.log("catched the event1");
      this.$children.forEach((value, index, array) => {
        value.$emit("onsavepost");
      }); //.$forceUpdate();
    });
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