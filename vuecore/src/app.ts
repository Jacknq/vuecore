declare var require: any;
import { Component, Vue } from "./ext1";
//import Router = require('vue-router')
import { RouterOptions, Location, RouteConfig, Route } from "vue-router";
import VueRouter from "vue-router";
//import Vue from 'vue'
import router from "./System/router";
import  store  from "./System/store";
import App from "./app.vue";
Vue.use(VueRouter);
Vue.config.devtools = true; //enable debug for build

let appl = new Vue({
  el: "#app",
  router: router,
  store: store,
  components: { App: App },
  render: h => h("App")
});

//rt.push('/about');//will navigate to specific route
export default { appl, router }; //app
