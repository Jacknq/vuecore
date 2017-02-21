// Get signalr.d.ts.ts from https://github.com/borisyankov/DefinitelyTyped (or delete the reference)
/// <reference path="signalr.d.ts" />
/// <reference path="jquery.d.ts" />

////////////////////
// available hubs //
////////////////////
//#region available hubs
//var SgnlR = (function($){
//interface SignalR {

    /**
      * The hub implemented by SignalServ.Hubs.DonorHub
      */
  //  donorHub : DonorHub;
//}
//#endregion available hubs

///////////////////////
// Service Contracts //
///////////////////////
//#region service contracts

//#region DonorHub hub

//interface DonorHub {
    
    /**
      * This property lets you send messages to the DonorHub hub.
      */
   // server : DonorHubServer;

    /**
      * The functions on this property should be replaced if you want to receive messages from the DonorHub hub.
      */
  //  client : any;
//}

//interface DonorHubServer {

    /** 
      * Sends a "send" message to the DonorHub hub.
      * Contract Documentation: ---
      * @param name {string} 
      * @param message {string} 
      * @return {JQueryPromise of void}
      */
  //  send(name : string, message : string) : JQueryPromise<void>

    /** 
      * Sends a "getAll" message to the DonorHub hub.
      * Contract Documentation: ---
      * @return {JQueryPromise of Person[]}
      */
  //  getAll() : JQueryPromise<Person[]>

    /** 
      * Sends a "findPerson" message to the DonorHub hub.
      * Contract Documentation: ---
      * @param name {string} 
      * @return {JQueryPromise of Person[]}
      */
  //  findPerson(name : string) : JQueryPromise<Person[]>

    /** 
      * Sends a "insertPerson" message to the DonorHub hub.
      * Contract Documentation: ---
      * @param pers {Person} 
      * @return {JQueryPromise of number}
      */
  //  insertPerson(pers : Person) : JQueryPromise<number>

    /** 
      * Sends a "getimage" message to the DonorHub hub.
      * Contract Documentation: ---
      * @return {JQueryPromise of ImageMessage}
      */
  //  getimage() : JQueryPromise<ImageMessage>

    /** 
      * Sends a "heeilou" message to the DonorHub hub.
      * Contract Documentation: ---
      * @param howmouch {number} 
      * @return {JQueryPromise of number}
      */
  //  heeilou(howmouch : number) : JQueryPromise<number>
//}

//#endregion DonorHub hub

//#endregion service contracts



////////////////////
// Data Contracts //
////////////////////
//#region data contracts


/**
  * Data contract for SignalDomain.ImageMessage
  */
  
function ImageMessage(){ return{
   Data :'',
      FileName :'',
   }}
  

/**
  * Data contract for SignalDomain.Person
  */
  
function Person(){ return{
   FirstName :'',
      LastName :'',
      Age :0,
      BirthDay :new Date('0001-01-01'),
      hasHair :false,
      Address :{},
      HairColor :0,
      mayday :new Date('0001-01-01'),
   }}
  

/**
  * Data contract for SignalDomain.colors
  */
  
function colors(){ return{
   red :0,  
   blue :1,  
   white :2,  
}}
  

/**
  * Data contract for SignalDomain.Address
  */
  
function Address(){ return{
   State :'',
      City :'',
   }}
  //#endregion data contracts
//})(jQuery);
