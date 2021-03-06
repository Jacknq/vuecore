import { Component, Vue } from "vue-property-decorator";
//import Router = require('vue-router')
import { RouterOptions, Location, RouteConfig, Route } from "vue-router";
import VueRouter from "vue-router";
/*
  For components that will be used in html (such as navbar),
  all you need to do is import the file somewhere in your code,
  they are automatically registered when the file is loaded.
  However, if you import the class (ex: import { Navbar } from './navbar'),
  you will have to call new Navbar() somewhere as well. You would want
  to do that if you are defining a components{} object in the @Component
  options parameter. 
*/

var separatets = require("../Views/separatets.vue").default;

import listpost from "../components/post-list.vue"
import post from "../components/post.vue"
import index from "../Views/index.vue";

const router = new VueRouter({
  mode: "history",
  base: "", //subdomain
  routes: [
    { path: "/", component: index },
    { path: "/page/:nr", component: index },
    { path: "/post/:id", component: post },
    { path: "/search/:term", component: listpost },

    { path: "/module/:compname" },
    { path: "*", redirect: "/" }
  ]
});
export default router;
