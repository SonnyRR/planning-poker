using System.Collections.Generic;
using Mapster;
using PlanningPoker.Persistence.Entities;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.Core.Mapping
{
    public static partial class UserMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static User AdaptToUser(this UserModel p1)
        {
            return p1 == null ? null : new User()
            {
                Tables = funcMain1(p1.Tables),
                Id = p1.Id,
                UserName = p1.UserName
            };
        }
        public static User AdaptTo(this UserModel p5, User p6)
        {
            if (p5 == null)
            {
                return null;
            }
            User result = p6 ?? new User();
            
            result.Tables = funcMain4(p5.Tables, result.Tables);
            result.Id = p5.Id;
            result.UserName = p5.UserName;
            return result;
            
        }
        public static UserModel AdaptToModel(this User p11)
        {
            return p11 == null ? null : new UserModel()
            {
                Tables = funcMain7(p11.Tables),
                Id = p11.Id,
                UserName = p11.UserName
            };
        }
        public static UserModel AdaptTo(this User p15, UserModel p16)
        {
            if (p15 == null)
            {
                return null;
            }
            UserModel result = p16 ?? new UserModel();
            
            result.Tables = funcMain10(p15.Tables, result.Tables);
            result.Id = p15.Id;
            result.UserName = p15.UserName;
            return result;
            
        }
        
        private static IList<Table> funcMain1(IList<TableModel> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p2.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                TableModel item = p2[i];
                list.Add(funcMain2(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<Table> funcMain4(IList<TableModel> p7, IList<Table> p8)
        {
            if (p7 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p7.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p7.Count;
            
            while (i < len)
            {
                TableModel item = p7[i];
                list.Add(funcMain5(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<TableModel> funcMain7(IList<Table> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p12.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p12.Count;
            
            while (i < len)
            {
                Table item = p12[i];
                list.Add(funcMain8(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<TableModel> funcMain10(IList<Table> p17, IList<TableModel> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p17.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p17.Count;
            
            while (i < len)
            {
                Table item = p17[i];
                list.Add(funcMain11(item));
                i++;
            }
            return result;
            
        }
        
        private static Table funcMain2(TableModel p3)
        {
            return p3 == null ? null : new Table()
            {
                DeckType = p3.DeckType,
                Name = p3.Name,
                Owner = TypeAdapterConfig1.GetMapFunction<UserModel, User>().Invoke(p3.Owner),
                OwnerId = p3.OwnerId,
                Players = funcMain3(p3.Players),
                CreatedOn = p3.CreatedOn,
                Id = p3.Id,
                ModifiedOn = p3.ModifiedOn
            };
        }
        
        private static Table funcMain5(TableModel p9)
        {
            return p9 == null ? null : new Table()
            {
                DeckType = p9.DeckType,
                Name = p9.Name,
                Owner = TypeAdapterConfig1.GetMapFunction<UserModel, User>().Invoke(p9.Owner),
                OwnerId = p9.OwnerId,
                Players = funcMain6(p9.Players),
                CreatedOn = p9.CreatedOn,
                Id = p9.Id,
                ModifiedOn = p9.ModifiedOn
            };
        }
        
        private static TableModel funcMain8(Table p13)
        {
            return p13 == null ? null : new TableModel()
            {
                DeckType = p13.DeckType,
                Name = p13.Name,
                Owner = TypeAdapterConfig1.GetMapFunction<User, UserModel>().Invoke(p13.Owner),
                OwnerId = p13.OwnerId,
                Players = funcMain9(p13.Players),
                CreatedOn = p13.CreatedOn,
                Id = p13.Id,
                ModifiedOn = p13.ModifiedOn
            };
        }
        
        private static TableModel funcMain11(Table p19)
        {
            return p19 == null ? null : new TableModel()
            {
                DeckType = p19.DeckType,
                Name = p19.Name,
                Owner = TypeAdapterConfig1.GetMapFunction<User, UserModel>().Invoke(p19.Owner),
                OwnerId = p19.OwnerId,
                Players = funcMain12(p19.Players),
                CreatedOn = p19.CreatedOn,
                Id = p19.Id,
                ModifiedOn = p19.ModifiedOn
            };
        }
        
        private static ICollection<User> funcMain3(ICollection<UserModel> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            ICollection<User> result = new List<User>(p4.Count);
            
            IEnumerator<UserModel> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserModel item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<UserModel, User>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<User> funcMain6(ICollection<UserModel> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            ICollection<User> result = new List<User>(p10.Count);
            
            IEnumerator<UserModel> enumerator = p10.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserModel item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<UserModel, User>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<UserModel> funcMain9(ICollection<User> p14)
        {
            if (p14 == null)
            {
                return null;
            }
            ICollection<UserModel> result = new List<UserModel>(p14.Count);
            
            IEnumerator<User> enumerator = p14.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                User item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<User, UserModel>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<UserModel> funcMain12(ICollection<User> p20)
        {
            if (p20 == null)
            {
                return null;
            }
            ICollection<UserModel> result = new List<UserModel>(p20.Count);
            
            IEnumerator<User> enumerator = p20.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                User item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<User, UserModel>().Invoke(item));
            }
            return result;
            
        }
    }
}