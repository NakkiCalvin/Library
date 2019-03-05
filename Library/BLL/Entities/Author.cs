using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        public int? AuthorId { get; set; }

        public Storage Storage { get; set; }
    }
}
