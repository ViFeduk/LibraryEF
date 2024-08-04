using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DateOfIssue { get; set; }
        public string  Athor { get; set; }
        public string Genre { get; set; }
        public int userId { get; set; }
        public User ReservUser { get; set; }
    }
}
