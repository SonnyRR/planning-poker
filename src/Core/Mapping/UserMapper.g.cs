using PlanningPoker.Persistence.Entities;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.Core.Mapping
{
    public static partial class UserMapper
    {
        public static User AdaptToUser(this UserModel p1)
        {
            return p1 == null ? null : new User()
            {
                Id = p1.Id,
                UserName = p1.UserName
            };
        }
        public static User AdaptTo(this UserModel p2, User p3)
        {
            if (p2 == null)
            {
                return null;
            }
            User result = p3 ?? new User();
            
            result.Id = p2.Id;
            result.UserName = p2.UserName;
            return result;
            
        }
        public static UserModel AdaptToModel(this User p4)
        {
            return p4 == null ? null : new UserModel()
            {
                Id = p4.Id,
                UserName = p4.UserName
            };
        }
        public static UserModel AdaptTo(this User p5, UserModel p6)
        {
            if (p5 == null)
            {
                return null;
            }
            UserModel result = p6 ?? new UserModel();
            
            result.Id = p5.Id;
            result.UserName = p5.UserName;
            return result;
            
        }
    }
}