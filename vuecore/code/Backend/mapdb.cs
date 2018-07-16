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
            .Id(p=>p.ID);

            maper.Entity<User>()
            .DbRef(x => x.Roles, "role");
        }
    }
}