# VueCore

All in Vue2+ js Typescript template bootstrap 4, hot reload, Vuex, .net core backend signalr webapi litedb..
T4 template in source hubsfloww.tt in visual studio community, on click genarate proxy out of csharp model out of the box!
runs on ubuntu 16.04!
 Lets rock!

## Visual Studio integration
##### VS Code - C# extension, vetur plugin for vue files
##### VS2017 - node js window present, or any extension
##### VS2015 - It is highly recommended that the following extensions are installed
- [NPM Task Runner](https://visualstudiogallery.msdn.microsoft.com/8f2f2cbc-4da5-43ba-9de2-c9d08ade4941) (VS2017 compatible)
- [Vue.js Pack](https://visualstudiogallery.msdn.microsoft.com/30fd019a-7b90-4f75-bb54-b8f49f18fbe1)



## Build Setup

``` cmd
# install dependencies
npm install

# serve frontend with hot reload at localhost:8080
npm run dev

--second terminal should start the backend
dotnet run


# deploy with scp to your server
npm run deploy

# build the frontend to dist folder
npm run build

# build the backend to bin
dotnet build 
```
![screenshot](/vuecore/src/assets/screen1.png)

For detailed explanation on how things work, checkout the [guide](http://vuejs-templates.github.io/webpack/) and [docs for vue-loader](http://vuejs.github.io/vue-loader).

#### T4 transforms tt template in .net core
dotnet t4 trans -f test.tt
