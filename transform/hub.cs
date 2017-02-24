using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.IO;
using bVue.code;
using System.Threading.Tasks;
using System.Linq.Expressions;
using transform;

namespace bVue.code
{
  
    public class DbManager
    {
        public static LiteRepo Instance { get; private set; }
        static DbManager()
        {
            Instance = new LiteRepo();
        }
    }
    //COPY HUB HERE and press fire context menu  -run custom tool on /.tt file
    public class bHub : Hub
    {
        public LiteRepo repo;

        public bHub()
        {
            repo = DbManager.Instance;
        }
        public override Task OnConnected()
        {
            // Set connection id for just connected client only
            var auth = GetAuthInfo();
            return Clients.Client(Context.ConnectionId).SetConnectionId(Context.ConnectionId);

            //this.OnDisconnected
        }

        public override Task OnDisconnected(bool stopCalled)
        {

            var d = base.OnDisconnected(stopCalled);
            this.Dispose();
            return d;
        }


        public async Task<List<Post>> GetPosts(string search, string orderby, int page, int pagesize)
        {
            // int c = 0;
            List<Post> q;
            if (!string.IsNullOrEmpty(search))
            {
                q = await repo.GetQuery<Post>(p => p.Title.Contains(search)
                || p.Content.Contains(search), orderby, page, pagesize);
                return q;
            }
            q = await repo.GetQuery<Post>(p => p.ID > 0, orderby, page, pagesize);

            return q;
        }

        public async Task<int> InsertPost(Post p)
        {
            return await Task.Run(() => { return repo.Insert<Post>(p); });
        }
        public async Task<bool> UpdatePost(Post p)
        {
            return await repo.Update<Post>(p);
        }
        public async Task<int> DeletePost(int id)
        {
            return await repo.Delete<Post>(p => p.ID == id);
        }



        public string ReturnSome()
        {
            return "abcd";
        }
        protected object GetAuthInfo()
        {
            var user = Context.User;
            return new
            {
                IsAuthenticated = user.Identity.IsAuthenticated,
                IsAdmin = user.IsInRole("Admin"),
                UserName = user.Identity.Name
            };
        }
    }

}