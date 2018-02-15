<template>
  <div>
    <div  ref="main">
      <div class="wwide">
        <!--<div class="col-xs-2 line" > <hr></div>-->
        <div id="main-nav" class="">
    
         
        </div>
        <section id="hero" class="light-typo">
          <div id="cover-image" class="image-bg animated fadeIn"> </div>

          <div class="container welcome-content">
        
          </div>
        </section>
      </div>
      <!--<div class="col-xs-8 line" > <hr></div>-->

      <div class="site-wrapper">

        <div class="site-wrapper-inner">
       
       


          <div class="container">

         <transition name="fade" mode="out-in">
          <!--<div v-if="this.$route.params.compname==undefined">-->
           
          <router-view class="view"></router-view>
         
        </transition>

          </div>
          <!-- /.container -->

          <div class="container">
            <footer class="blog-footer">
              <p>Designed by <a href="https://github.com/jack85">@Jack</a></p>
            
            </footer>
          </div>
        </div>
      </div>
    </div>
    <!-- end main-->
  
  </div>


</template>
<script lang="ts">
import index from "./Views/index.vue";
import post from "./components/post.vue";
//import  store  from './System/store'
import { Component, Vue } from "./ext1";
import "bootstrap";

@Component({
  components: { index, post }
})
export default class App extends Vue {
  name = "App";
  viewactive = "main"; //second

  get loc() {
    return "at"; //this.vars.location;
  }

  mounted() {
    //here you show the alert
  }
}
</script>
<style lang="less" >
@import url("./../node_modules/bootstrap/dist/css/bootstrap.min.css");
@import url("./../node_modules/font-awesome/css/font-awesome.min.css");
/*  @import "./node_modules/bootstrap-select/dist/css/bootstrap-select.css";*/
/*@import "//maxcdn.bootstrapcdn.com/bootswatch/3.3.6/sandstone/bootstrap.min.css"*/

/* cyrillic-ext */

html,
body {
  font-size: 100%;
  font-family: "Open Sans", helvetica, arial, sans-serif;
  /*color: #404040;*/
  color: white;
  background-color: #333;
  position: relative;
}

#main-nav {
  /* background-color: #80B959; */
  height: 55px;
  line-height: 55px;
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  z-index: 1040;
}
.nav-header .btn {
  margin: 10px 10px 4px 0;
  line-height: 32px;
  height: 34px;
}

.btn.pull-right {
  margin: 0;
}

.btn.outline-white {
  background: transparent;
  border: 1px solid #fff;
  box-shadow: none;
  color: #fff;
  text-decoration: none;
}
.btn.outline-white:hover {
  background: #fff;
  border-color: #fff;
  color: #383838;
  top: 0;
  text-decoration: none;
}
.btn.outline-none {
  background: transparent;
  border: 0px solid #fff;
  box-shadow: none;
  color: #fff;
  text-decoration: none;
}

.btn {
  font-family: "Open Sans", helvetica, arial, sans-serif;
  font-size: 13px;
  cursor: pointer;
  padding: 0 26px;
  line-height: 38px;
  display: inline-block;
  margin: 0 10px 4px 0;
  height: 40px;
  text-decoration: none;
  letter-spacing: 1px;
  font-weight: 700;
  outline: none;
  position: relative;
  background: #80b959;
  color: #fff;
  border: 1px solid #80b959;
  border-radius: 4px;
}
.nav-icon {
  float: right !important;
  width: 55px;
  height: 35px;
  /* margin-right: -15px;*/
  padding-left: 10px;
  border: 0;
  color: #fff;
  text-decoration: none;
}
/*.icon-menu2:before {
  
}*/

:before,
:after {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}
.blog-nav {
  margin-left: -10px;
}
.nav-brand {
  font-family: "Merriweather", georgia, serif;
  font-weight: 700;
  font-size: 23px;
  font-style: italic;
  padding: 0;
  color: #444;
  border: 0;
}
/*
 * Override Bootstrap's default container.
 */
#hero {
  /*background-color: #80B959;*/
  padding: 55px 0;
  min-height: 200px;
  height: 25vh;

  padding-bottom: 1em;
  position: relative;
}
#hero #cover-image {
  position: absolute;
  top: 0;
  left: 0;
  height: 100%;
  width: 100%;
  background-position: center center;
  background-size: cover;
  -webkit-animation-delay: 0.15s;
  -moz-animation-delay: 0.15s;
  -o-animation-delay: 0.15s;
  -ms-animation-delay: 0.15s;
  animation-delay: 0.15s;
  transform: translateZ(0);
}

.fadeIn {
  -webkit-animation-name: fadeIn;
  animation-name: fadeIn;
}

.animated {
  -webkit-animation-duration: 1s;
  animation-duration: 1s;
  -webkit-animation-fill-mode: both;
  animation-fill-mode: both;
}

.image-bg {
  background-image: url("./assets/bg.jpg");
}

.light-typo {
  color: #fff;
}
.container {
  max-width: 60rem;
}
/*
 * Masthead for nav
 */
.h1,
.h2,
.h3,
.h4,
.h5,
.h6,
h1,
h2,
h3,
h4,
h5,
h6 {
  color: #ccc;
  font-weight: 600;
}
.blog-masthead {
  /*margin-bottom: 3rem;*/

  /* background-color: #333;
  -webkit-box-shadow: inset 0 -.1rem .25rem rgba(0,0,0,.1);
          box-shadow: inset 0 -.1rem .25rem rgba(0,0,0,.1); */
  border-top: 0.05rem solid #e5e5e5;
  .container {
    text-align: center;
    font-size: 1.8rem;
  }
}

/* Nav links */
.nav-link {
  position: relative;
  padding: 0.5rem;
  font-weight: 500;
  color: #999;
  font-weight: bold;
}
.nav-link:hover,
.nav-link:focus {
  color: #fff;
  background-color: transparent;
}

/* Active state gets a caret at the bottom */
.nav-link.active {
  color: #fff;
}
.nav-link.active:before {
  position: absolute;
  top: 0;
  left: 50%;
  width: 0;
  height: 0;
  margin-left: -0.3rem;
  vertical-align: middle;
  content: "";
  border-right: 0.3rem solid transparent;
  border-top: 0.3rem solid;
  border-left: 0.3rem solid transparent;
}

/*
 * Blog name and description
 */

.blog-header {
  padding-bottom: 1.25rem;
  margin-bottom: 2rem;
  border-bottom: 0.05rem solid #eee;
}
.blog-title {
  margin-bottom: 0;
  font-size: 1.5rem;
  font-weight: normal;
}
.blog-description {
  font-size: 1.1rem;
  color: #999;
}

@media (min-width: 40em) {
  .blog-title {
    font-size: 3.5rem;
  }
}

/*
 * Main column and sidebar layout
 */

/* Sidebar modules for boxing content */
.sidebar-module {
  padding: 1rem;
  /*margin: 0 -1rem 1rem;*/
}
.sidebar-module-inset {
  padding: 1rem;
  /* background-color: #f5f5f5; */
  border-radius: 0.25rem;
}
.sidebar-module-inset p:last-child,
.sidebar-module-inset ul:last-child,
.sidebar-module-inset ol:last-child {
  margin-bottom: 0;
}

/* Pagination */
.blog-pagination {
  margin-bottom: 1rem;
}
.blog-pagination > .btn {
  border-radius: 2rem;
}

/*
 * Blog posts
 */

/*
 * Footer
 */

.blog-footer {
  padding: 0.5rem 5rem;
  color: #999;
  text-align: left;
  /* background-color: #444; */
  border-top: 0.05rem solid #e5e5e5;
}
.blog-footer p:last-child {
  margin-bottom: 0;
}

/*
 * Globals
 */
.content .post-date {
  font-family: "Open Sans", helvetica, arial, sans-serif;
  color: #9f9f9f;
  font-weight: bold;
  font-size: 12px;
  font-size: 0.75rem;
  text-transform: uppercase;
  position: relative;
}

article .post-date {
  margin-top: 1em;
}

html * {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

.content .post-date {
  font-family: "Open Sans", helvetica, arial, sans-serif;
  color: #9f9f9f;
  font-weight: bold;
  font-size: 12px;
  font-size: 0.75rem;
  text-transform: uppercase;
  position: relative;
}
article {
  border-bottom: 1px solid #ccc;
  margin-bottom: 1em;
}
article .post-date {
  margin-top: 1em;
}
article h3 a {
  color: white;
  border: 0;
  /* text-align: center; */
}
/* Links */

a:focus,
a:hover {
  color: #fff;
}
a {
  font-weight: bold;
  color: #80b959;
  border-bottom: 1px solid rgba(198, 70, 61, 0);
  -webkit-transition: border 0.2s;
  -moz-transition: border 0.2s;
  transition: border 0.2s;
}

/* Custom default button */
.btn-secondary,
.btn-secondary:hover,
.btn-secondary:focus {
  color: #333;
  text-shadow: none; /* Prevent inheritance from `body` */
  background-color: #fff;
  border: 0.05rem solid #fff;
}

/*
 * Base structure
 */

/*html,
body {
  height: 100%;
  background-color: #333;
}
body {
  color: #fff;
  text-align: center;
  text-shadow: 0 .05rem .1rem rgba(0,0,0,.5);
}*/

/* Extra markup and styles for table-esque vertical and horizontal centering */
.site-wrapper {
  display: table;
  width: 100%;
  height: 100%; /* For at least Firefox */
  min-height: 100%;
  -webkit-box-shadow: inset 0 0 5rem rgba(0, 0, 0, 0.5);
  box-shadow: inset 0 0 5rem rgba(0, 0, 0, 0.5);
}
.site-wrapper-inner {
  display: table-cell;
  vertical-align: top;
}
.cover-container {
  margin-right: auto;
  margin-left: auto;
}

/* Padding for spacing */
.inner {
  padding: 2rem;
}

/*
 * Header
 */

.masthead {
  margin-bottom: 2rem;
}

.masthead-brand {
  margin-bottom: 0;
}

.nav-masthead .nav-link {
  padding: 0.25rem 0;
  font-weight: bold;
  color: rgba(255, 255, 255, 0.5);
  background-color: transparent;
  border-bottom: 0.25rem solid transparent;
}

.nav-masthead .nav-link:hover,
.nav-masthead .nav-link:focus {
  border-bottom-color: rgba(255, 255, 255, 0.25);
}

.nav-masthead .nav-link + .nav-link {
  margin-left: 1rem;
}

.nav-masthead .active {
  color: #fff;
  border-bottom-color: #fff;
}

@media (min-width: 48em) {
  .masthead-brand {
    float: left;
  }
  .nav-masthead {
    float: right;
  }
}

/*
 * Cover
 */

.cover {
  padding: 0 1.5rem;
}
.cover .btn-lg {
  padding: 0.75rem 1.25rem;
  font-weight: bold;
}

/*
 * Footer
 */

.mastfoot {
  color: rgba(255, 255, 255, 0.5);
}

/*
 * Affix and center
 */

@media (min-width: 40em) {
  /* Pull out the header and footer */
  .masthead {
    position: fixed;
    top: 0;
  }
  .mastfoot {
    position: fixed;
    bottom: 0;
  }
  /* Start the vertical centering */
  .site-wrapper-inner {
    vertical-align: middle;
  }
  /* Handle the widths */
  .masthead,
  .mastfoot,
  .cover-container {
    width: 100%; /* Must be percentage or pixels for horizontal alignment */
  }
}

@media (min-width: 62em) {
  .masthead,
  .mastfoot,
  .cover-container {
    width: 42rem;
  }
}
</style>