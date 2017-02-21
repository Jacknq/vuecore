// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Globalization;
// using bVue.code.Backend.repo;
// using Microsoft.EntityFrameworkCore;


// namespace bVue.code.Backend
// {
//     /// <summary>
//     /// Generic repository
//     /// </summary>
//     public class GenericRepository : IRepository
//     {
//         private readonly string _connectionStringName;
//         private DbContext _context;
//      //   private readonly PluralizationService _pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));

//         /// <summary>
//         /// Initializes a new instance of the <see cref="Repository&lt;TEntity&gt;"/> class.
//         /// </summary>
//         public GenericRepository()
//             : this(string.Empty)
//         {
//         }

//         /// <summary>
//         /// Initializes a new instance of the <see cref="GenericRepository&lt;TEntity&gt;"/> class.
//         /// </summary>
//         /// <param name="connectionStringName">Name of the connection string.</param>
//         public GenericRepository(string connectionStringName)
//         {
//             this._connectionStringName = connectionStringName;
//         }

//         /// <summary>
//         /// Initializes a new instance of the <see cref="GenericRepository&lt;TEntity&gt;"/> class.
//         /// </summary>
//         /// <param name="context">The context.</param>
//         public GenericRepository(DbContext context)
//         {
//             if (context == null)
//                 throw new ArgumentNullException("context");
//             _context = context;
//         }

//         public TEntity GetByKey<TEntity>(object keyValue) where TEntity : class
//         {
//            // EntityKey key = GetEntityKey<TEntity>(keyValue);

//           //  object originalItem;
//            // if (((IObjectContextAdapter)DbContext).ObjectContext.TryGetObjectByKey(key, out originalItem))
//            // {
//            //     return (TEntity)originalItem;
//            // }
//             return DbContext.Set<TEntity>().Find(keyValue);
//            // return default(TEntity);
//         }

//         public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
//         {
//             /*
//              * From CTP4, I could always safely call this to return an IQueryable on DbContext
//              * then performed any with it without any problem:
//              */
//             // return DbContext.Set<TEntity>();

//             /*
//              * but with 4.1 release, when I call GetQuery<TEntity>().AsEnumerable(), there is an exception:
//              * ... System.ObjectDisposedException : The ObjectContext instance has been disposed and can no longer be used for operations that require a connection.
//              */

//             // here is a work around:
//             // - cast DbContext to IObjectContextAdapter then get ObjectContext from it
//             // - call CreateQuery<TEntity>(entityName) method on the ObjectContext
//             // - perform querying on the returning IQueryable, and it works!
//             var entityName = GetEntityName<TEntity>();
//             return ((IObjectContextAdapter)DbContext).ObjectContext.CreateQuery<TEntity>(entityName);
//         }

//         public IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
//         {
//             return GetQuery<TEntity>().Where(predicate);
//         }

//         // public IQueryable<TEntity> GetQuery<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
//         // {
//         //     return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>());
//         // }

//         public List<TEntity> GetSqlQuery<TEntity>(string sql, params object[] parameters) where TEntity : class
//         {
//             string orConn = DbContext.Database.Connection.ConnectionString;
//             string saveConn = (DbContext as GeneralDbContext).GetConnectionString();//connection string for direct sql must be without trace provider, since its not supported, however in this method later might be command finished event fired
//             var db = new DbContext(saveConn);

//             return db.Database.SqlQuery<TEntity>(sql, parameters).ToList();//DbContext.Database.SqlQuery<TEntity>(sql, parameters).ToList();
//         }

//         public IEnumerable<TEntity> Get<TEntity>(int pageNr, int pageSize, Expression<Func<TEntity, string>> orderBy, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
//         {
//             pageNr -= 1;
//             if (sortOrder == SortOrder.Ascending)
//             {
//                 return GetQuery<TEntity>().OrderBy(orderBy).Skip(pageNr*pageSize).Take(pageSize).AsEnumerable();
//             }
//             return GetQuery<TEntity>().OrderByDescending(orderBy).Skip(pageNr*pageSize).Take(pageSize).AsEnumerable();
//         }

//         public IEnumerable<TEntity> Get<TEntity>(int pageNr, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, string>> orderBy, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
//         {
//             pageNr -= 1;
//             if (sortOrder == SortOrder.Ascending)
//             {
//                 return GetQuery<TEntity>().Where(predicate).OrderBy(orderBy).Skip(pageNr*pageSize).Take(pageSize).AsEnumerable();
//             }
//             return GetQuery<TEntity>().Where(predicate).OrderByDescending(orderBy).Skip(pageNr*pageSize).Take(pageSize).AsEnumerable();
//         }

//         // public IEnumerable<TEntity> Get<TEntity>(int pageNr, int pageSize, ISpecification<TEntity> specification, Expression<Func<TEntity, string>> orderBy, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
//         // {
//         //     pageNr -= 1;
//         //     if (sortOrder == SortOrder.Ascending)
//         //     {
//         //         return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).OrderBy(orderBy).Skip(pageNr*pageSize).Take(pageSize).AsEnumerable();
//         //     }
//         //     return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).OrderByDescending(orderBy).Skip(pageNr*pageSize).Take(pageSize).AsEnumerable();
//         // }

//         public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
//         {
//             return GetQuery<TEntity>().Single<TEntity>(criteria);
//         }

//         // public TEntity Single<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
//         // {
//         //     return criteria.SatisfyingEntityFrom(GetQuery<TEntity>());
//         // }

//         public TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
//         {
//             return GetQuery<TEntity>().First(predicate);
//         }

//         // public TEntity First<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
//         // {
//         //     return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>()).First();
//         // }

//         public void Add<TEntity>(TEntity entity) where TEntity : class
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentNullException("entity");
//             }
//             DbContext.Set<TEntity>().Add(entity);
//         }

//         public void Attach<TEntity>(TEntity entity) where TEntity : class
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentNullException("entity");
//             }

//             DbContext.Set<TEntity>().Attach(entity);
//         }

//         public void Delete<TEntity>(TEntity entity) where TEntity : class
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentNullException("entity");
//             }
//             DbContext.Set<TEntity>().Remove(entity);
//         }

//         public void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
//         {
//             IEnumerable<TEntity> records = Find<TEntity>(criteria);

//             foreach (TEntity record in records)
//             {
//                 Delete<TEntity>(record);
//             }
//         }

//         // public void Delete<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
//         // {
//         //     IEnumerable<TEntity> records = Find<TEntity>(criteria);
//         //     foreach (TEntity record in records)
//         //     {
//         //         Delete<TEntity>(record);
//         //     }
//         // }

//         public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
//         {
//             return GetQuery<TEntity>().AsEnumerable();
//         }

//         public TEntity Save<TEntity>(TEntity entity) where TEntity : class
//         {
//             Add<TEntity>(entity);
//             DbContext.SaveChanges();
//             return entity;
//         }

//         public void Update2<TEntity>(TEntity entity) where TEntity : class, IEntity
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentException("Cannot add a null entity.");
//             }

//             var entry = DbContext.Entry<TEntity>(entity);

//             if (entry.State == EntityState.Detached)
//             {
//                 var set = DbContext.Set<TEntity>();
//                 TEntity attachedEntity = set.Find(entity.ID); // You need to have access to key

//                 if (attachedEntity != null)
//                 {
//                     var attachedEntry = DbContext.Entry(attachedEntity);
//                     attachedEntry.CurrentValues.SetValues(entity);
//                     // attachedEntry.State = EntityState.Modified; // This should help marking it properly
//                 }
//                 else
//                 {
//                     set.Attach(entity);
//                     entry.State = EntityState.Modified; // This should attach entity
//                 }
//             }
//         }

        // public void Update<TEntity>(TEntity entity) where TEntity : class
        // {
        //     DbSet<TEntity> _set = DbContext.Set<TEntity>();
        //     _set.Attach(entity);

        //     //TODO: complex properties
        //     DbContext.Entry(entity).State = System.Data.EntityState.Modified;
        //     //   DbContext.SaveChanges();
        // }

//         public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
//         {
//             return GetQuery<TEntity>().Where(criteria);
//         }

//         public TEntity FindOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
//         {
//             return GetQuery<TEntity>().Where(criteria).FirstOrDefault();
//         }

//         // public TEntity FindOne<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
//         // {
//         //     return criteria.SatisfyingEntityFrom(GetQuery<TEntity>());
//         // }

//         // public IEnumerable<TEntity> Find<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
//         // {
//         //     return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>()).AsEnumerable();
//         // }

//         public int Count<TEntity>() where TEntity : class
//         {
//             return GetQuery<TEntity>().Count();
//         }

//         public int Count<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
//         {
//             return GetQuery<TEntity>().Count(criteria);
//         }

//         // public int Count<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
//         // {
//         //     return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>()).Count();
//         // }

//         public IUnitOfWork UnitOfWork
//         {
//             get
//             {
//                 if (unitOfWork == null)
//                 {
//                     unitOfWork = new UnitOfWork(this.DbContext);
//                 }
//                 return unitOfWork;
//             }
//         }

//         // private EntityKey GetEntityKey<TEntity>(object keyValue) where TEntity : class
//         // {
//         //     var entitySetName = GetEntityName<TEntity>();
//         //     var objectSet = ((IObjectContextAdapter)DbContext).ObjectContext.CreateObjectSet<TEntity>();
//         //     var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
//         //     var entityKey = new EntityKey(entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
//         //     return entityKey;
//         // }

//         // private string GetEntityName<TEntity>() where TEntity : class
//         // {
//         //     return string.Format("{0}.{1}", ((IObjectContextAdapter)DbContext).ObjectContext.DefaultContainerName, _pluralizer.Pluralize(typeof(TEntity).Name));
//         // }

//         // public string GetConnectionString()
//         // {
//         //     return (DbContext as GeneralDbContext).GetConnectionString();
//         // }

//         // private DbContext DbContext
//         // {
//         //     get
//         //     {
//         //         if (this._context == null)
//         //         {
//         //             if (this._connectionStringName == string.Empty)
//         //                 this._context = DbContextManager.Current;
//         //             else
//         //                 this._context = DbContextManager.CurrentFor(this._connectionStringName);
//         //         }
//         //         return this._context;
//         //     }
//         // }

//         private IUnitOfWork unitOfWork;
//     }
// }


