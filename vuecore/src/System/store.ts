import Vue from "vue";
//import { Component, Vue } from "../ext1";
import * as moment from "moment";
import { StorageService } from "./localstorage";
import * as cl from "../../code/Backend/repo/t4/domain";
import * as ext from "../ext1";
import Vuex, { Store } from "vuex";
Vue.use(Vuex);
interface Oauth {
  data: object;
  provider: string;
}//define shape of your store
export interface storeData {
  count: number;
  isAuth: boolean;
  lang: string;
  mandantid: number;
  location: string;
  token: string;
  servurl: string;
  dateformat: string;
  oauth: Oauth;
}//lets store backend url somewhere
var host =
  window.document.location.port == "8080"
    ? "http://localhost:5000"
    : window.location.origin;
//define initial values
const dstate: storeData = {
  count: 0,
  isAuth: false,
  token: "",
  lang: "de",
  mandantid: 0,
  location: "AT",
  servurl: host,
  dateformat: "DD.MM.YYYY",
  oauth: null  
};

const storage = new StorageService();
//set initial state in localstorage if doesnt exist
storage.setItemInit(storage.C_ENV_KEY, dstate);

const storeData: storeData = JSON.parse(storage.getItem(storage.C_ENV_KEY));
export class VueBus extends Vue
{  
  public onSavePost(func:(p:cl.Post)=>void)
  {  
    this.$on("onsavepost", func);
  }
}
//defining state
export interface State {
  bus:VueBus
  db: cl.SgnRCloud;
  vars: storeData;
}
//you can have multiple slots in state, local state and imported types
// const statee: State = {
//   bus: new VueBus(store),
//   db: new cl.SgnRCloud(dstate.servurl, storeData.token),
//   vars: storeData
// };

//creating typed vuex
let store = new Vuex.Store<State>({
  state: {
    bus: new VueBus(),
    db: new cl.SgnRCloud(dstate.servurl, storeData.token),
    vars: storeData
  } as State,
  mutations: {
    setvars(state, s: storeData) {
      state.vars = s;
      storage.setItem(storage.C_ENV_KEY, s);//update local storage
    },
    setdb(state, s: cl.SgnRCloud) {
      state.db = s;
    }
  }
});
store.subscribe((mutate, statee) => {
  if (mutate.type == "setvars") {
    console.log("subscribed muttate");
  }
});

export default store;
