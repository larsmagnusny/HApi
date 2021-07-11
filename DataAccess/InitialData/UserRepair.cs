using System.Linq;
using HApi.DataAccess.Entities;

namespace HApi.DataAccess.InitialData
{
    public static class UserRepair
    {
        public static void Repair(HContext db)
        {
            var users = db.Users.Where(o => o.Computers.Count == 0);

            foreach(var user in users)
            {
                UserComputerInit.Init(db, user.UserId);
                db.ChangeTracker.Clear();
            }
        }
    }
}
