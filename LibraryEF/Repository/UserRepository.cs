
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF.Repository
{
    public class UserRepository
    {
        public User SelectUserById(int idUser)
        {
            using (var db = new AppContext())
            {
                var users = db.Users.Where(us => us.Id == idUser).FirstOrDefault();
                return users;
            }
            
        }

        public List<User> GetAllUsers()
        {
            using(var db = new AppContext())
            {
                var allUser = db.Users.ToList();
                return allUser;
            }
        }

        public int InsertUser(User user)
        {
            using (var db = new AppContext())
            {
                try
                {
                    db.Users.Add(user);
                    return db.SaveChanges();
                }
                catch(Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    Console.WriteLine("Пользователь уже существует");
                    return 0;
                }
            }
        }
        public int DeleteUserById(int idUser)
        {
           var userDel =  SelectUserById(idUser);
            using (var db = new AppContext())
            {
                db.Users.Remove(userDel);
                return db.SaveChanges();
            }
        }

        public int UpdateUserById(int Id, string newName)
        {
           
            using (var db = new AppContext())
            {
                var userSelect = db.Users.Where(us => us.Id == Id).FirstOrDefault();
                userSelect.Name = newName;
               return db.SaveChanges();
            }
            

        }

        public int CountBookFromUser(int userId)
        {
            using (var db = new AppContext())
            {
             return db.Users
                .Where(user => user.Id == userId)
                .Select(user => user.ReservBooks.Count)
                .FirstOrDefault();
                 
            }
        }
    }
}
