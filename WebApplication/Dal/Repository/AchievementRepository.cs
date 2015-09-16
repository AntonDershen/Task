using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.EntityFramework;
using DataAccess.Interface.Repository;
using System.Data.Entity;
namespace DataAccess.Repository
{
    public class AchievementRepository : IAchievementRepository
    {
        private  DbContext context;
        public AchievementRepository(DbContext context)
        {
  
            this.context = context;
        }
        public void Create(int userId)
        {
            context.Set<UserAchievement>().Add(new UserAchievement()
            {
                UserId = userId
            });
        }
        public void Update(UserAchievement userAchievement)
        {
            using(var db = new EntityModel())
            {
                var achievement = db.UsersAchievements.Find(userAchievement.Id);
                achievement = userAchievement;
                db.SaveChanges();
            }

        }
        public UserAchievement Get(int userId)
        {
            return context.Set<UserAchievement>().FirstOrDefault(x => x.UserId == userId);
        }
    }
}
