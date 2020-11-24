import { Component, Vue } from "../ext1";
//let BootstrapVue = require('bootstrap-vue');
import multiselect from "vue-multiselect";

@Component({ components: { multiselect }, name: "ts" })
export default class extends Vue {
  // separatets extends Vue
  someabout = "aboutTS";
  name = "tscomponent";

  somemethod(): number {
    return 1;
  }
}
