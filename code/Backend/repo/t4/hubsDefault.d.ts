////////////////////
// available hubs //
////////////////////
//#region available hubs

interface SignalR {

    /**
      * The hub implemented by bVue.code.bHub
      */
    bHub : bHub;
}
//#endregion available hubs

///////////////////////
// Service Contracts //
///////////////////////
//#region service contracts

//#region bHub hub

interface bHub {
    
    /**
      * This property lets you send messages to the bHub hub.
      */
    server : bHubServer;

    /**
      * The functions on this property should be replaced if you want to receive messages from the bHub hub.
      */
    client : any;
}

interface bHubServer {

    /** 
      * Sends a "getPosts" message to the bHub hub.
      * Contract Documentation: ---
      * @param search {string} 
      * @param orderby {string} 
      * @param page {number} 
      * @param pagesize {number} 
      * @return {JQueryPromise of IPost[]}
      */
    getPosts(search: string, orderby: string, page: number, pagesize: number): JQueryPromise<IPost[]>;

    /** 
      * Sends a "insertPost" message to the bHub hub.
      * Contract Documentation: ---
      * @param p {IPost} 
      * @return {JQueryPromise of number}
      */
    insertPost(p: IPost): JQueryPromise<number>;

    /** 
      * Sends a "updatePost" message to the bHub hub.
      * Contract Documentation: ---
      * @param p {IPost} 
      * @return {JQueryPromise of boolean}
      */
    updatePost(p: IPost): JQueryPromise<boolean>;

    /** 
      * Sends a "deletePost" message to the bHub hub.
      * Contract Documentation: ---
      * @param id {number} 
      * @return {JQueryPromise of number}
      */
    deletePost(id: number): JQueryPromise<number>;

    /** 
      * Sends a "getCategories" message to the bHub hub.
      * Contract Documentation: ---
      * @param search {string} 
      * @param orderby {string} 
      * @param page {number} 
      * @param pagesize {number} 
      * @return {JQueryPromise of ICategory[]}
      */
    getCategories(search: string, orderby: string, page: number, pagesize: number): JQueryPromise<ICategory[]>;

    /** 
      * Sends a "insertCategory" message to the bHub hub.
      * Contract Documentation: ---
      * @param p {ICategory} 
      * @return {JQueryPromise of number}
      */
    insertCategory(p: ICategory): JQueryPromise<number>;

    /** 
      * Sends a "updateCategory" message to the bHub hub.
      * Contract Documentation: ---
      * @param p {ICategory} 
      * @return {JQueryPromise of boolean}
      */
    updateCategory(p: ICategory): JQueryPromise<boolean>;

    /** 
      * Sends a "deleteCategory" message to the bHub hub.
      * Contract Documentation: ---
      * @param id {number} 
      * @return {JQueryPromise of number}
      */
    deleteCategory(id: number): JQueryPromise<number>;

    /** 
      * Sends a "getTags" message to the bHub hub.
      * Contract Documentation: ---
      * @param search {string} 
      * @param orderby {string} 
      * @param page {number} 
      * @param pagesize {number} 
      * @return {JQueryPromise of ITag[]}
      */
    getTags(search: string, orderby: string, page: number, pagesize: number): JQueryPromise<ITag[]>;

    /** 
      * Sends a "insertTag" message to the bHub hub.
      * Contract Documentation: ---
      * @param p {ITag} 
      * @return {JQueryPromise of number}
      */
    insertTag(p: ITag): JQueryPromise<number>;

    /** 
      * Sends a "updateTag" message to the bHub hub.
      * Contract Documentation: ---
      * @param p {ITag} 
      * @return {JQueryPromise of boolean}
      */
    updateTag(p: ITag): JQueryPromise<boolean>;

    /** 
      * Sends a "deleteTag" message to the bHub hub.
      * Contract Documentation: ---
      * @param id {number} 
      * @return {JQueryPromise of number}
      */
    deleteTag(id: number): JQueryPromise<number>;

    /** 
      * Sends a "returnSome" message to the bHub hub.
      * Contract Documentation: ---
      * @return {JQueryPromise of string}
      */
    returnSome(): JQueryPromise<string>;
}

//#endregion bHub hub

//#endregion service contracts



////////////////////
// Data Contracts //
////////////////////
//#region data contracts


/**
  * Data contract for bVue.code.Tag
  */
interface ITag extends ICategory
{
}


/**
  * Data contract for bVue.code.Category
  */
interface ICategory extends IBEntity
{
    name?: string;
    posts?: IPost[];
}


/**
  * Data contract for bVue.code.BEntity
  */
interface IBEntity
{
    iD?: number;
    dateCreated?: Date;
    dateChanged?: Date;
    count?: number;
}


/**
  * Data contract for bVue.code.Post
  */
interface IPost extends IBEntity
{
    title?: string;
    content?: string;
    blog?: IBlog;
    categories?: ICategory[];
    tags?: ITag[];
    comments?: IComment[];
    published?: boolean;
    rating?: number;
    slug?: string;
    fileInfos?: IBFileInfo[];
}


/**
  * Data contract for bVue.code.BFileInfo
  */
interface IBFileInfo extends IBEntity
{
}


/**
  * Data contract for bVue.code.Comment
  */
interface IComment extends IBEntity
{
    author?: string;
    text?: string;
    post?: IPost;
}


/**
  * Data contract for bVue.code.Blog
  */
interface IBlog extends IBEntity
{
    name?: string;
    posts?: IPost[];
}

//#endregion data contracts

