using bVue.code;
using bVue.code.Backend.repo;
using LiteDB;

namespace bvue.code.Backend
{
    public class mapdb
    {

        public BsonMapper maper { get; set; }
        public mapdb()
        {
            this.maper = BsonMapper.Global;

            maper.Entity<Post>()
            .Id(p=>p.ID).Index(x => x.Title)
            .Index(x => x.Content);
        
            //dbpost
     

            maper.Entity<User>()
            .Index(x => x.UserName)
            .Index(x => x.Email)
            .DbRef(x => x.Roles, "role");
      

        }
    }
}