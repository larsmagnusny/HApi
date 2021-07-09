using HApi.Crypto;
using HApi.DataAccess.Entities;
using HApi.Models;
using System;

namespace HApi.DataAccess.InitialData
{
    public static class UserInit
    {
        public static void Init(HContext db, RegisterParameters registerParameters)
        {
            User user = new User
            {
                UserId = Guid.NewGuid(),
                Username = registerParameters.Username,
                Password_SHA256 = (new SHA256Hash(registerParameters.Password)).ToString(),
                Profile = new Profile
                {
                    FirstName = registerParameters.FirstName,
                    LastName = registerParameters.LastName,
                    Email = registerParameters.Email
                }
            };
            db.Users.Add(user);

            db.SaveChanges();

            UserComputerInit.Init(db, user.UserId);
        }
    }
}