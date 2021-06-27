using HApi.Crypto;
using HApi.Models;
using HApi.Storage.Entities;
using LiteDB;
using System;

namespace HApi.Storage.InitialData
{
    public static class UserInit
    {
        public static void Init(LiteDatabase db, RegisterParameters registerParameters)
        {
            var users = db.GetCollection<User>();
            var profiles = db.GetCollection<Profile>();

            User user = new User
            {
                UserId = Guid.NewGuid(),
                Username = registerParameters.Username,
                Password_SHA256 = (new SHA256Hash(registerParameters.Password)).ToString()
            };

            Profile profile = new Profile
            {
                FirstName = registerParameters.FirstName,
                LastName = registerParameters.LastName,
                Email = registerParameters.Email
            };

            users.Insert(user);
            users.EnsureIndex(o => o.UserId);
            profiles.Insert(profile);
            profiles.EnsureIndex(o => o.UserId);

            UserComputerInit.Init(db, user.UserId);
        }
    }
}