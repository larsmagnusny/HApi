using HApi.Storage.Entities;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.Storage.InitialData
{
    public static class UserRepair
    {
        public static void Repair(LiteDatabase db)
        {
            var users = db.GetCollection<User>().FindAll();
            var profiles = db.GetCollection<Profile>();
            var computers = db.GetCollection<UserComputer>();

            foreach(var user in users)
            {
                if(computers.FindOne(o => o.UserId == user.UserId) == null)
                {
                    UserComputerInit.Init(db, user.UserId);
                }
            }
        }
    }
}
