using System.Collections.Generic;
using PlanningPoker.Persistence.Entities;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.Core.Mapping
{
    public static partial class TableMapper
    {
        public static Table AdaptToTable(this TableModel p1)
        {
            return p1 == null ? null : new Table()
            {
                DeckType = p1.DeckType,
                Name = p1.Name,
                Owner = p1.Owner == null ? null : new User()
                {
                    Id = p1.Owner.Id,
                    UserName = p1.Owner.UserName
                },
                OwnerId = p1.OwnerId,
                Players = funcMain1(p1.Players),
                CreatedOn = p1.CreatedOn,
                Id = p1.Id,
                ModifiedOn = p1.ModifiedOn
            };
        }
        public static Table AdaptTo(this TableModel p3, Table p4)
        {
            if (p3 == null)
            {
                return null;
            }
            Table result = p4 ?? new Table();
            
            result.DeckType = p3.DeckType;
            result.Name = p3.Name;
            result.Owner = funcMain2(p3.Owner, result.Owner);
            result.OwnerId = p3.OwnerId;
            result.Players = funcMain3(p3.Players, result.Players);
            result.CreatedOn = p3.CreatedOn;
            result.Id = p3.Id;
            result.ModifiedOn = p3.ModifiedOn;
            return result;
            
        }
        public static TableModel AdaptToModel(this Table p9)
        {
            return p9 == null ? null : new TableModel()
            {
                DeckType = p9.DeckType,
                Name = p9.Name,
                Owner = p9.Owner == null ? null : new UserModel()
                {
                    Id = p9.Owner.Id,
                    UserName = p9.Owner.UserName
                },
                OwnerId = p9.OwnerId,
                Players = funcMain4(p9.Players),
                CreatedOn = p9.CreatedOn,
                Id = p9.Id,
                ModifiedOn = p9.ModifiedOn
            };
        }
        public static TableModel AdaptTo(this Table p11, TableModel p12)
        {
            if (p11 == null)
            {
                return null;
            }
            TableModel result = p12 ?? new TableModel();
            
            result.DeckType = p11.DeckType;
            result.Name = p11.Name;
            result.Owner = funcMain5(p11.Owner, result.Owner);
            result.OwnerId = p11.OwnerId;
            result.Players = funcMain6(p11.Players, result.Players);
            result.CreatedOn = p11.CreatedOn;
            result.Id = p11.Id;
            result.ModifiedOn = p11.ModifiedOn;
            return result;
            
        }
        
        private static List<User> funcMain1(List<UserModel> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<User> result = new List<User>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                UserModel item = p2[i];
                result.Add(item == null ? null : new User()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static User funcMain2(UserModel p5, User p6)
        {
            if (p5 == null)
            {
                return null;
            }
            User result = p6 ?? new User();
            
            result.Id = p5.Id;
            result.UserName = p5.UserName;
            return result;
            
        }
        
        private static List<User> funcMain3(List<UserModel> p7, List<User> p8)
        {
            if (p7 == null)
            {
                return null;
            }
            List<User> result = new List<User>(p7.Count);
            
            int i = 0;
            int len = p7.Count;
            
            while (i < len)
            {
                UserModel item = p7[i];
                result.Add(item == null ? null : new User()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static List<UserModel> funcMain4(List<User> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            List<UserModel> result = new List<UserModel>(p10.Count);
            
            int i = 0;
            int len = p10.Count;
            
            while (i < len)
            {
                User item = p10[i];
                result.Add(item == null ? null : new UserModel()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static UserModel funcMain5(User p13, UserModel p14)
        {
            if (p13 == null)
            {
                return null;
            }
            UserModel result = p14 ?? new UserModel();
            
            result.Id = p13.Id;
            result.UserName = p13.UserName;
            return result;
            
        }
        
        private static List<UserModel> funcMain6(List<User> p15, List<UserModel> p16)
        {
            if (p15 == null)
            {
                return null;
            }
            List<UserModel> result = new List<UserModel>(p15.Count);
            
            int i = 0;
            int len = p15.Count;
            
            while (i < len)
            {
                User item = p15[i];
                result.Add(item == null ? null : new UserModel()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
    }
}