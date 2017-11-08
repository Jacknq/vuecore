//import { Component, create, getHelper, Store } from '../ext'
import  Vue from 'vue'
import * as moment from 'moment'
import { StorageService } from './localstorage'
import * as cl  from '../../code/Backend/repo/t4/hubsflow'
interface Oauth{
  data:object,
  provider:string
}
export interface storeData {
    count: number, isAuth: boolean, lang: string,
     mandantid: number,
     location:string, token:string, servurl:string, dateformat:string//, db:cl.SgnRCloud
     oauth:Oauth
}
var host = window.document.location.port=='8080'?'http://localhost:5000':window.location.origin;
//will be in local storage
const dstate : storeData = { 
  count: 0, isAuth: false,token:'', lang: 'de', 
  mandantid: 0, location:'AT', 
  servurl : host, dateformat:'DD.MM.YYYY'
  ,oauth:null
//db : null 
  };


const storage = new StorageService();
//state.db = new cl.SgnRCloud(state.servurl, state.token);
      storage.setItemInit(storage.C_ENV_KEY, dstate);


const storeData : storeData = JSON.parse(storage.getItem(storage.C_ENV_KEY));

//most simplyfied no vuex
  // var storee = {
  //                db: new cl.SgnRCloud(dstate.servurl, storeData.token),
  //                vars:storeData, 
  //                setvars:(s:storeData)=>{storee.vars = s; storage.setItem(storage.C_ENV_KEY, s)},
  //                setdb:(s:cl.SgnRCloud)=>{storee.db = s;}
  //              }
               import Vuex from 'vuex'
               Vue.use(Vuex);
//playing around with vuex
export interface State {
  db: cl.SgnRCloud,
  vars:storeData
}
const statee:State = {
  db: new cl.SgnRCloud(dstate.servurl, storeData.token),
  vars:storeData
}
               const store =  new Vuex.Store({
               
                 state:statee,
                  mutations: {
                   setvars (state, s:storeData) {
                      state.vars = s; storage.setItem(storage.C_ENV_KEY, s)
                   },
                   setdb(state,s:cl.SgnRCloud){state.db = s;}
                  }
               })

    //  store.subscribe(s => {
    //    if(s.type=='setvars')
    //    {console.log('subscribed');}
    //  })    
     store.subscribe((mutate,  statee ) => {
      if(mutate.type=='setvars')
      {console.log('subscribed muttate');}
    })     
//cmpdStore.db = new cl.SgnRCloud(state.servurl, state.token);
//END COMpound store

//how to subscribe
// store.subscribe(s => {
//   if (s.type == 'increment') console.log('sumbsicribed increment is' + JSON.stringify(s.payload))
//   // else console.log(s.payload) //s
//   //console.log(store.state)
// })//
export default store