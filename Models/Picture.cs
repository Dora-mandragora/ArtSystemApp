using System.Collections;
using System.Collections.Generic;

namespace ArtSystemApp.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public byte[] Img { get; set; }
        public virtual Format Format { get; set; }


    }

    public class Format
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Picture> Images { get; set; }
    }
}
