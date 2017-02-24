using bVue.code;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace transform
{
    public enum OrderBy
    {
        Desc, Asc
    }
    public class LiteRepo //: Hub
    {
        static string dbpath = @"Data//data.db";

        public LiteRepo(string connectionString)
        {
            dbpath = connectionString;
            m = new mapper();

        }
        public LiteRepo()
        { m = new mapper(); }

        mapper m;
        public LiteDatabase GetDb
        {
            get
            {
                GC.Collect();
                return new LiteDatabase(dbpath, m.maper);
            }
        }

        // public static string Dbpath { get => dbpath; set => dbpath = value; }


        public async Task<List<TEntity>> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate, string orderby, int page, int pageSize = int.MaxValue) where TEntity : class
        {
            using (var db = GetDb)
            {
                // TypeDescriptor..GetConverter(TEntity)
                if (string.IsNullOrEmpty(orderby))
                { orderby = "ID desc"; }
                OrderBy orderByDir = parseOrderBy(orderby);
                var col = db.GetCollection<TEntity>(GetName(typeof(TEntity)));
                var f = col.Find(predicate);
                if (orderByDir == OrderBy.Desc)
                {
                    f = f.OrderByDescending(s => s.GetType()
                            .GetProperty(orderby.Split(' ')[0]).GetValue(s, null));
                }
                else
                {
                    f = f.OrderBy(s => s.GetType()
                      .GetProperty(orderby.Split(' ')[0]).GetValue(s, null));
                }
                int count = f.Count();

                var r = await Task.Run(() => f.Skip((page - 1) * pageSize).Take(pageSize).ToList()); //., pageSize).ToList();
                r.ForEach(el => (el as BEntity).Count = count);//Bentity
                return r;
            }
        }

        private OrderBy parseOrderBy(string orderby)
        {
            string t = orderby.ToLower().Trim();
            if (t.EndsWith(" asc"))
            {
                var spl = t.Split(' ');
                return OrderBy.Asc;
            }
            return OrderBy.Desc;
        }

        public async Task<int> Insert<TEntity>(TEntity data) where TEntity : class
        {
            using (var db = GetDb)
            {
                var col = db.GetCollection<TEntity>(GetName(typeof(TEntity)));

                return await Task.Run(() => col.Insert(data));
            }
        }
        public async Task<bool> Update<TEntity>(TEntity data) where TEntity : class
        {
            using (var db = GetDb)
            {
                var col = db.GetCollection<TEntity>(GetName(typeof(TEntity)));
                if (data is BEntity)
                { (data as BEntity).DateChanged = DateTime.Now; }//bentity
                return await Task.Run(() => col.Update(data));
            }
        }
        public async Task<int> Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            using (var db = GetDb)
            {
                var col = db.GetCollection<TEntity>(GetName(typeof(TEntity)));

                return await Task.Run(() => col.Delete(predicate));
            }
        }


        // public List<LiteFileInfo> GetFileList()

        public static string GetName(Type type)
        {
            var str = (type.ToString());
            if (str.Contains("["))
            { str = str.Substring(str.LastIndexOf('[')); }
            str = str.Split(',')[0];
            return str.Substring(str.LastIndexOf(".") + 1).ToLower();
        }

    }
    public class mapper
    {

        public BsonMapper maper { get; set; }
        public mapper()
        {
            this.maper = BsonMapper.Global;

            maper.Entity<Post>()
            .Index(x => x.Title)
            .Index(x => x.Content);
            //dbpost


            maper.Entity<User>()
            .Index(x => x.UserName)
            .Index(x => x.Email)
            .DbRef(x => x.Roles, "role");            

        }
    }

}
