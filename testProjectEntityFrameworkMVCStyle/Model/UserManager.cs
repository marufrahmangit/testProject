using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjectEntityFrameworkMVCStyle.Model.DB;
using testProjectEntityFrameworkMVCStyle.Model.ViewModel;

namespace testProjectEntityFrameworkMVCStyle.Model
{
    public class UserManager
    {
        private  DatabaseEntities dbEntities = new DatabaseEntities();

        public void AddUser(string firstName, string lastName, string phone)
        {
            tblUser user = new tblUser();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Phone = phone;

            dbEntities.tblUsers.Add(user);
            dbEntities.SaveChanges();
        }

        public IEnumerable<UserName> GetUserFirstName()
        {
            var user = from o in dbEntities.tblUsers
                       select new UserName
                       {
                           UserID = o.Id,
                           FirstName = o.FirstName
                       };
            return user.ToList();
        }

        public IEnumerable<UserDetail> GetUserDetail(int userID)
        {
            var user = from o in dbEntities.tblUsers
                       where o.Id == userID
                       select new UserDetail
                       {
                           UserID = o.Id,
                           FirstName = o.FirstName,
                           LastName = o.LastName,
                           Phone = o.Phone
                       };
            return user.ToList();
        }

        public void UpdateUser(UserDetail userDetail)
        {
            var user = (from o in dbEntities.tblUsers
                        where o.Id == userDetail.UserID
                        select o).First();
            user.FirstName = userDetail.FirstName;
            user.LastName = userDetail.LastName;
            user.Phone = userDetail.Phone;
            dbEntities.SaveChanges();
        }

        public void DeleteUser(int userID)
        {
            var user = (from o in dbEntities.tblUsers
                        where o.Id == userID
                        select o).First();
            dbEntities.tblUsers.Remove(user);
            dbEntities.SaveChanges();
        }
    }
}