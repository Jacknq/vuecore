# VueCore

All in Vue2+ js Typescript example bootstrap native 4, hot reload, Vuex, .NET CORE 5 backend  webapi NoSql LiteDB..

runs on linux

#### if using any other editor set vuecore folder as root folder for vue

## Visual Studio integration
##### VS Code - C# extension, vetur plugin for vue files
##### VS2017 - node js window present, better go with task runner as described lower
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

dotnet watch run

# deploy with scp to your server
npm run deploy

# build the frontend to dist folder
npm run build

# build the backend to bin
dotnet build 
```
![screenshot](/src/assets/screen1.png)

For detailed explanation on how things work, checkout the [guide](http://vuejs-templates.github.io/webpack/) and [docs for vue-loader](http://vuejs.github.io/vue-loader).
``` cmd
#### T4 transforms tt template in .net core
dotnet tt trans -f test.tt

#### updating dotnet libs
dotnet-outdated
dotnet tool uninstall --global dotnet-outdated
dotnet tool install --global dotnet-outdated-tool

```

### other handy commands
```
dotnet nuget locals all --clear
dotnet tool install dotnet-script --version 1.0.1
dotnet script test.csx

dotnet tool install TextTemplating.Tool --version 5.0.1.12
dotnet tool uninstall Texttemplating.Tool 
dotnet tt trans -f person.tt
```
