import { Component, Inject, Model, Prop, Watch } from "vue-property-decorator";
export { Component, Inject, Model, Prop, Watch, Emit, Provide } from "vue-property-decorator";
//import Vue from 'vue'
import moment from "moment";
declare var require: any;
import VueRouter from "vue-router";
//import axio, { AxiosRequestConfig, AxiosPromise } from "axios";
import * as d from "../code/Backend/repo/t4/domain";

export { d };
import * as b from "vue-property-decorator";
b.Vue.use(VueRouter);
import store, { storeData, State } from "./System/store";
import { Store } from "vuex";


//extending default vue with some more stuff

export class Vue extends b.Vue {
  $v: any;
  $store = store;
  
  
  get db() {
    return this.$store.state.db;
  }
  get connected() {
    return this.$store.state.db.connected;
  }
  get vars() {
    return this.$store.state.vars;
  }
  get $storets() {//if you want separate computed prop
    return this.$store as Store<State>; //store;//
  }

  public log(val: String) {
    console.log(val);
  }
  public logErr(val: String) {
    console.log(val);
  }

  setvars(vars: storeData): void {
    this.$store.commit("setvars", vars);
  }
  setdb(db: d.SgnRCloud): void {
    this.$store.commit("setdb", db);
  }
}

//EXAMPLE OF DATETIME formatting - FILTER
Vue.filter("dtformat", val => {
  if (val != null && val != "")
    return moment(val).format(store.state.vars.dateformat);
  return "";
});

//extend inferace for validations
// declare module 'vue/types/options' {
//   interface ComponentOptions<V extends b.Vue> {
//     validations?: {} //; validations () {};
//   }
// }
