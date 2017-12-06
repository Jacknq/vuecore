import { Component, Inject, Model, Prop, Watch } from "vue-property-decorator";
export { Component, Inject, Model, Prop, Watch } from "vue-property-decorator";
//import Vue from 'vue'
import store, { storeData } from "./System/store";
declare var require: any;
import VueRouter from "vue-router";
import axio, { AxiosRequestConfig, AxiosPromise } from "axios";
import * as d from "../code/Backend/repo/t4/hubsflow";
import  moment from "moment";
export { d };
import * as b from "./ext";
b.Vue.use(VueRouter);
//extending default vue with some more stuff
// 3. Declare augmentation for Vue

export class Vue extends b.Vue {
  $v: any;

  get db() {
    return store.state.db;
  }
  get connected() {
    return store.state.db.connected;
  }
  get vars() {
    return store.state.vars;
  } 
  axios = axio;

  //@Store setvars = commit('varsset')
  public log(val: String) {
    console.log(val);
  }
  public logErr(val: String) {
    console.log(val);
  }

  setvars(vars: storeData): void {
    store.commit("setvars", vars);
  }
  setdb(db: d.SgnRCloud): void {
    store.commit("setdb", db);
  }
}
//}

var v = new Vue();
//EXAMPLE OF DATETIME formatting - FILTER
b.Vue.filter("dtformat", function(val) {
  if (val != null && val != "") return moment(val).format(v.vars.dateformat);
  return "";
});

//extend inferace for validations
// declare module 'vue/types/options' {
//   interface ComponentOptions<V extends b.Vue> {
//     validations?: {} //; validations () {};
//   }
// }
