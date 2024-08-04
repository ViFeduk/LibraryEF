using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF.Repository
{
    public class BookRepository
    {
        public Book SelectBookById(int IdBook)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(us => us.Id == IdBook).FirstOrDefault();
                return book;
            }

        }

        public List<Book> GetAllBooks()
        {
            using (var db = new AppContext())
            {
                var allBooks = db.Books.ToList();
                return allBooks;
            }
        }

        public int InsertBook(Book book)
        {
            using (var db = new AppContext())
            {
                try
                {
                    db.Books.Add(book);
                    return db.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    Console.WriteLine("книга уже существует");
                    return 0;
                }
            }
        }
        public int DeleteBookById(int idBook)
        {
            var bookDel = SelectBookById(idBook);
            using (var db = new AppContext())
            {
                db.Books.Remove(bookDel);
                return db.SaveChanges();
            }
        }

        public int UpdateBookById(int Id, int newYear)
        {

            using (var db = new AppContext())
            {
                var BookSelect = db.Books.Where(us => us.Id == Id).FirstOrDefault();
                BookSelect.DateOfIssue = newYear;
                return db.SaveChanges();
            }


        }

        public List<Book> GetBooksByGenreAndYear(string genre, int year1, int year2)
        {
            using (var db =new AppContext())
            {
                var bookQuery = db.Books.Where(b => b.Genre == genre && b.DateOfIssue >= year1 && b.DateOfIssue <= year2).ToList() ;
                return bookQuery;
            }
        }

        public int BookCountByAthor(string athor)
        {
            using (var db = new AppContext())
            {
                var query = db.Books.Where(u => u.Athor == athor).Count();
                return query;
            }
        }

        public int GetCountBookByGenre(string genre)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(b => b.Genre == genre).Count();
            }
        }

        public bool ExistOfBook(string athor, string title)
        {
            using (var db =new AppContext())
            {
                return db.Books.Any(b => b.Title == title && b.Athor == athor);
            }

        }

        public bool IsBookingBokked(string title)
        {
            using(var db =new AppContext())
            {
                return db.Books.Where(b => b.Title == title).Any(b => b.ReservUser != null);
            }

        }

        public Book LastPublishedBook()
        {
            using (var db = new AppContext())
            {
                var query = from b in db.Books
                            where b.DateOfIssue == (db.Books.Max(b => b.DateOfIssue))
                            select b;
                return query.FirstOrDefault();
               

                          
                             
                
            }
        }
        public List<Book> GetAllBooksSortedTitle()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderBy(u  => u.Title).ToList();
            }
        }
        public List<Book> GetAllBookdSortYearDesc()
        {
            using ( var db = new AppContext())
            {
                return db.Books.OrderByDescending(b => b.DateOfIssue).ToList();
            }
        }
    }
}
