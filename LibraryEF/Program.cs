using LibraryEF.Repository;

namespace LibraryEF
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            BookRepository bookRepository = new BookRepository();
            UserRepository userRepository = new UserRepository();

             var query1 =  bookRepository.GetBooksByGenreAndYear("Психология", 1999, 2200);
            foreach (var book in query1)
            {
                Console.WriteLine(book.Title);
            }
            var query2 = bookRepository.BookCountByAthor("Кто-то");
            Console.WriteLine("Кол-во книг автора Кто-то равно " + query2);
            var query3 = bookRepository.GetCountBookByGenre("Психология");
            Console.WriteLine("Кол-во книг жанра психология равено "+ query3);
            var query4 = bookRepository.ExistOfBook("Кто-то", "Люди");
            Console.WriteLine("Существует ли книга с автором кто-то и названием люди - " + query4);
            var query5 = bookRepository.IsBookingBokked("Люди");
            Console.WriteLine("Зарезервирована ли кнгиа Люди - " +query5);

            var query6 = userRepository.CountBookFromUser(1);
           
            Console.WriteLine("Кол-во книг у пользвователя 1 равно - "+ query6);
            var query7 = bookRepository.LastPublishedBook();
            Console.WriteLine("Название самой новой кнгии - " +query7.Title);

            var query8 = bookRepository.GetAllBooksSortedTitle();
            Console.WriteLine("Список всех книг в сортировке ");
            foreach (var book in query8)
            {
                Console.Write( book.Title+ ", ");
            }
            Console.WriteLine();
            var query9 = bookRepository.GetAllBookdSortYearDesc();
            foreach (var book in query9)
                Console.WriteLine($"Название книги: {book.Title}, год выпуска {book.DateOfIssue}");
        }
    }
}
