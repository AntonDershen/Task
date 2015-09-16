using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Interface.Repository
{
    public interface IAchievementRepository
    {
        void Create(int userId);
        void Update(UserAchievement userAchievement);
        UserAchievement Get(int userId);
    }
}
