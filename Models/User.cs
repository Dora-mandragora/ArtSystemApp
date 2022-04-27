using System.Collections.Generic;

namespace ArtSystemApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }

        public virtual Role Role { get; set; }
        public virtual Status Status { get; set; }
        public virtual Confirmation Confirmation { get; set; }
        public virtual Picture Image { get; set; }


        //для чего user будет FK
        public virtual ICollection<Work> Works { get; set; }
        public virtual ICollection<Folder> Folders { get; set; }
        public virtual ICollection<Access> Accesses { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
    public class Confirmation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
