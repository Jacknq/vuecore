
//export  module  avts{
//import { Vue as V} from './ext'
import {  Component, Prop, Watch, Lifecycle,CreateElement, p } from 'av-ts'
export {  Component, Prop, Watch, Lifecycle,CreateElement, p } from 'av-ts'
import { create, getHelper, Vuex, Store } from 'kilimanjaro'
export { create, getHelper, Vuex, Store } from 'kilimanjaro'
import   store   from './System/store'
import * as d  from '../code/Backend/repo/t4/hubsflow'
export { d }
//SgnRCloud
 var { getters, commit } = getHelper(store)

// }
import b = require('./ext');
//extension methods for default class
@Component({ 

 })
export class Vue extends b.Vue {
   	@Store vars = getters('vars')
  	@Store setvars = commit('varsset')
    @Store db = getters('db')
    public log(val:String){
     console.log(val);
   }
   public logErr(val:String){
     console.log(val);
   }
}
// declare module "Vue" {
// export class Vue extends V {

//    public log(val:String){
//      console.log(val);
//    }
//    public logError(val:String){
//      console.log(val);
//    }
// }}