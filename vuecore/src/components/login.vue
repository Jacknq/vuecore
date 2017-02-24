<template>
 <div class="modal login" id="loginModal" aria-hidden="true">
 
			  <div class="modal-dialog login">
				  <div class="modal-content">
					 <div class="modal-header">
            <h4 class="modal-title">Login </h4>
						<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
					
					</div>
					<div class="modal-body">  
						<div class="box">
							<div class="form loginBox">
								<form class="myform" method="post" action="/login" accept-charset="UTF-8">
									<div class="form-group">
										<label class="control-label">Username</label>
										<div class="controls">
											<input id="email" v-model="username" class="form-control" type="text" placeholder="Username" data-focus="true" name="username">
										</div>
									</div>
									<div class="form-group">
										<label class="control-label">password</label>
										<div class="controls">
											<input id="password" v-model="password" class="form-control" type="password"
											 placeholder="Password" name="password" @keyup.enter="LogIn">
										</div>
									</div>
									<!--<p class="text-center"><a href="">Forgot password?</a></p> data-dismiss="modal" -->
									<input class="btn btn-block"  type="button" value="Login" @click="LogIn" >
								</form>
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<!--<div class="forgot login-footer">
							<span>Looking to 
								 <a href="#">create an account</a>
							?</span>
						</div>-->
					</div>        
				  </div>
			  </div>
		  </div>
</template>
<script lang='ts'>
    import { Component, create, getHelper, Vue, Store, Prop, Watch } from '../ext1'
		(<any>window).jQuery = require('jquery');
		 import  store  from '../System/store'
 var { getters, commit,dispatch } = getHelper(store)

declare var $:any;
//import Vue = require('vue')
// Declare the component's type

 @Component({
    
    })
    export default class login extends Vue {
        name = 'login'
        username='';
		password='';	

    LogIn() {
			//console.log("login");
			var vars = this.vars;

			var self = this;
			$('#loginModal').modal('hide');
				return $.post(vars.servurl+"/token", { grant_type: "password", username: this.username, password: this.password })
						.done(function(data) {
								if (data && data.access_token) {
										vars.token = data.access_token;
										vars.isAuth = true;
										self.setvars(vars);
										//chatHub.useBearerToken(data.access_token);
										console.log("Login successful");
								}
						})
						.fail(function(xhr) {
								if (xhr.status == 400) {
									//	toastr.error("Invalid user name or password");
									console.log("Invalid user name or password");
								} else {
									//	toastr.error("Unexpected error while signing in");
												console.log("Invalid user name or password");
								}
						});
		}
  }



  </script>