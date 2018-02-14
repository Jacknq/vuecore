﻿
// Get signalr.d.ts.ts from https://github.com/borisyankov/DefinitelyTyped (or delete the reference)
// <reference path="signalr.d.ts" />
// <reference path="jquery.d.ts" />
//AUTOGENERATED DO NOT EDIT THIS FILE 
////////////////////
// available hubs //
////////////////////
//#region available hubs
//JS header:
//import $ from 'jquery';
//window.jQuery = $;
//require('ms-signalr-client');
//TS header:
(<any>window).jQuery = require('jquery');

declare var $:any;
require('ms-signalr-client');

export class SgnRCloud {

    /** * The hub implemented by bVue.code.bHub    */
  public  bHub : bHub;	 

public	connection:any;
public	url: string;
public	cookie: string;
public connected:boolean;

 constructor(url: string, cookie: string){ 
		this.connection = $.hubConnection(url);this.url=url;this.cookie=cookie; 
	    this.connection.qs = { token: cookie };
		this.bHub = new bHub(this.connection);
	//var p = this.connection.createHubProxy('xyz');
		this.connected = false;
		this.connection.start({ transport: ['webSockets', 'serverSentEvents', 'longPolling'] }) //jsonp: true
            .then(() => {  //NEW BABEL SINTAX NO NEED JQUERY DONE
                    console.log('Now connected, connection ID=' + this.connection.id);            
                   this.connected = true;
              })
            .fail(function() { console.log('Could not connect'); }); 
			 }
}
//#endregion available hubs

///////////////////////
// Service Contracts //
///////////////////////
//#region service contracts

//#region bHub hub

//declare class bHub {
    
    /**
      * This property lets you send messages to the bHub hub.
      */
//    server : bHubServer;

    /**
      * The functions on this property should be replaced if you want to receive messages from the bHub hub.
  //    */
 //   client : any;
//}

export class bHub {
connection:any;
proxy:any;
 constructor(conn:any){
 this.connection = conn;
 this.proxy = this.connection.createHubProxy('bHub');
  this.proxy.on('xbroadcastMessage', (name, message) => {
              console.log(message);          
           });
	  }
client : any;
 

    /** 
      * Sends a "getPosts" message to the bHub hub.
      * Contract Documentation: ---
      * @param search {string} 
      * @param orderby {string} 
      * @param page {number} 
      * @param pagesize {number} 
      * @return {JQueryPromise of Post[]}
      */
    getPosts(search : string, orderby : string, page : number, pagesize : number) : Promise<Post[]>
{

	   return  this.proxy.invoke('getPosts'  , search, orderby, page, pagesize);
		
}

    /** 
      * Sends a "insertPost" message to the bHub hub.
      * Contract Documentation: ---
      * @param p {Post} 
      * @return {JQueryPromise of number}
      */
    insertPost(p : Post) : Promise<number>
{

	   return  this.proxy.invoke('insertPost'  , p);
		
}

    /** 
      * Sends a "updatePost" message to the bHub hub.
      * Contract Documentation: ---
      * @param p {Post} 
      * @return {JQueryPromise of boolean}
      */
    updatePost(p : Post) : Promise<boolean>
{

	   return  this.proxy.invoke('updatePost'  , p);
		
}

    /** 
      * Sends a "deletePost" message to the bHub hub.
      * Contract Documentation: ---
      * @param id {number} 
      * @return {JQueryPromise of number}
      */
    deletePost(id : number) : Promise<number>
{

	   return  this.proxy.invoke('deletePost'  , id);
		
}

    /** 
      * Sends a "returnSome" message to the bHub hub.
      * Contract Documentation: ---
      * @return {JQueryPromise of string}
      */
    returnSome() : Promise<string>
{

	   return  this.proxy.invoke('returnSome' );
		
}
}

//#endregion bHub hub

//#endregion service contracts



////////////////////
// Data Contracts //
////////////////////
//#region data contracts


/**
  * Data contract for bVue.code.BEntity
  */
export class BEntity {
    ID : number;
    DateCreated : Date;
    DateChanged : Date;
    Count : number;
}


/**
  * Data contract for bVue.code.Post
  */
export class Post extends BEntity {
    Title : string;
    Content : string;
}
export default SgnRCloud;
//#endregion data contracts
