using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Storage
    {
        public int Id { get; set; }
        
        public ICollection<Book> Books { get; set; }
        public ICollection<Author> Authors { get; set; }

        public Storage()
        {
            Books = new List<Book>();
            Authors = new List<Author>();
        }
    }
}
