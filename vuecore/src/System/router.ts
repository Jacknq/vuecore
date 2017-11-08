import { Component, Vue } from '../ext'
//import Router = require('vue-router')
import { RouterOptions, Location, RouteConfig, Route } from 'vue-router'
import  VueRouter from 'vue-router'


//import './vendor' //bootstrap
//require('./main.scss'); //global css

/*
  For components that will be used in html (such as navbar),
  all you need to do is import the file somewhere in your code,
  they are automatically registered when the file is loaded.
  However, if you import the class (ex: import { Navbar } from './navbar'),
  you will have to call new Navbar() somewhere as well. You would want
  to do that if you are defining a components{} object in the @Component
  options parameter. 
*/

var separatets = require('../Views/separatets.vue').default

var home = require('../Views/home.vue').default
var admin = require('../Views/admin.vue').default
//var app = Vue.extend({});
//var ro :RouteConfig[] = [ { path:'/', component:VueRouter  }]

const router = new VueRouter({
  mode: 'history', base:'', //subdomain
  routes: [

    { path: '/',component: admin },
    { path: '/page/:nr',component: admin },
    { path: '/search/:term',component: home },


    { path: '/module/:compname' },
    { path: '*', redirect: '/' },

  ]
});
export default router
