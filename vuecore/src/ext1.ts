
import { Component, Inject, Model, Prop, Watch  } from 'vue-property-decorator'
export { Component, Inject, Model, Prop, Watch  } from 'vue-property-decorator'
//import Vue from 'vue'
import store, {  storeData }   from './System/store'
declare var require: any
import  VueRouter from 'vue-router';
import axio, { AxiosRequestConfig, AxiosPromise } from 'axios';
import * as d  from '../code/Backend/repo/t4/hubsflow'

var moment = require("moment");
export { d }
//SgnRCloud
 //var { getters, commit } = getHelper(store)

// }
//import b = require('./ext');
import * as b from './ext';
b.Vue.use(VueRouter);
//import { State,Mutation, Action, Getter } from 'vuex-class'

//extension methods for default class
// @Trait class VegetableSearchable extends b.Vue {
//   vegetableName = 'tomato'
//   searchVegetable() { alert('find vegi!')}
// }
//extend inferace for validations
declare module 'vue/types/options' {
  interface ComponentOptions<V extends b.Vue> {
    validations?: {} //; validations () {};
  }
}

//declare module 'vue/types/vue' {
  // 3. Declare augmentation for Vue
//interface Vue {
//$myProperty: string
  //}
//}
//declare module "Vue" {
  export class Vue extends b.Vue {
    $v:any;

    get db () { 
       return store.state.db
    }
   get connected () {
   return store.state.db.connected
   }
    get vars () {
      return store.state.vars
    }
   // @State('db')db : d.SgnRCloud; // = store.db;
  //  @State('vars') vars:storeData
   // vars : storeData= store.vars;
   // @Mutation('setvars') setvars: (payload:  storeData ) => void
    //@Mutation('setdb') setdb: (payload: d.SgnRCloud ) => void
    axios = axio;
  
  //@Store setvars = commit('varsset')  
      public log(val:String){
      console.log(val);
    }
    public logErr(val:String){
      console.log(val);
    }
    //@Watch('connected', {immediate:true })
    // watchthis(neval, oldval) {        
    //    this.$forceUpdate(); //$children.map(.mounted();
    //  }

      setvars(vars:storeData):void
      {
        store.commit('setvars',vars);
      }
    setdb(db:d.SgnRCloud):void
      {
       store.commit('setdb',db);
      }
    
  }
//}
 
var v = new Vue();
//EXAMPLE OF DATETIME formatting - FILTER
 b.Vue.filter('dtformat', function (val) {
  	
   if(val!=null && val!='')
     return  moment(val).format(v.vars.dateformat);
 return '';
 })

// declare module "Vue" {
// export class Vue extends V {

//    public log(val:String){
//      console.log(val);
//    }
//    public logError(val:String){
//      console.log(val);
//    }
// }}