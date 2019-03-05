using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        //public ICollection<Author> Author { get; set; }
    }
}
