

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace bVue.code
{
    public class BEntity
    {
        public BEntity()
        {
             DateCreated = DateTime.Now; 
        }
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }
        public int Count {get;set;} //for paging
        //  public bool Deleted { get; set; }

    }
    public class User : BEntity
    {
        public string UserName { get; set; }
        public List<Role> Roles { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get { return Roles.Any(r => r.Name.ToLower().Equals("admin")); } }
 
    }


    public class Role : BEntity
    {
        public string Name { get; set; }
    }

    public class Post : BEntity
    {
       // public int Id { get; set; }
        public Post() { }
        public string Title { get; set; }
        public string Content { get; set; }
    }




}