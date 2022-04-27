using System.Collections.Generic;

namespace ArtSystemApp.Models
{
    public class Work
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }

        public virtual User User { get; set; }
        public virtual Theme Theme { get; set; }
        public virtual Picture Image { get; set; }
        public virtual Access Access { get; set; }
        public virtual Folder Folder { get; set; }
    }

    public class Theme
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<Work> Works { get; set; }
    }

    public class Folder
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Work> Works { get; set; }
    }

    public class Access
    {
        public int Id { get; set; }
        public int Name { get; set; }
        //public Image Image { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Work> Works { get; set; }
    }
}
