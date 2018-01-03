import { Component, Inject, Model, Prop, Watch } from "vue-property-decorator";
export { Component, Inject, Model, Prop, Watch } from "vue-property-decorator";
//import Vue from 'vue'
import store, { storeData, State } from "./System/store";
declare var require: any;
import VueRouter from "vue-router";
//import axio, { AxiosRequestConfig, AxiosPromise } from "axios";
import * as d from "../code/Backend/repo/t4/hubsflow";
import moment from "moment";
export { d };
import * as b from "./ext";
import { Store } from "vuex";
b.Vue.use(VueRouter);

//extending default vue with some more stuff

export class Vue extends b.Vue {
  $v: any;

  get db() {
    return this.$storets.state.db;
  }
  get connected() {
    return this.$storets.state.db.connected;
  }
  get vars() {
    return this.$storets.state.vars;
  }
  get $storets() {
    return this.$store as Store<State>; //store;//
  }

  public log(val: String) {
    console.log(val);
  }
  public logErr(val: String) {
    console.log(val);
  }

  setvars(vars: storeData): void {
    this.$storets.commit("setvars", vars);
  }
  setdb(db: d.SgnRCloud): void {
    this.$storets.commit("setdb", db);
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
