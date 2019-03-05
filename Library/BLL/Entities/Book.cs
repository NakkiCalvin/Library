using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int? BookId { get; set; }
        

        public Storage Storage { get; set; }
    }
}
