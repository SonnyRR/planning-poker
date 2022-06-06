using System.Collections.Generic;
using Mapster;
using PlanningPoker.Persistence.Entities;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.Core.Mapping
{
    public static partial class TableMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static Table AdaptToTable(this TableModel p1)
        {
            return p1 == null ? null : new Table()
            {
                DeckType = p1.DeckType,
                Name = p1.Name,
                Owner = funcMain1(p1.Owner),
                OwnerId = p1.OwnerId,
                Players = funcMain3(p1.Players),
                CreatedOn = p1.CreatedOn,
                Id = p1.Id,
                ModifiedOn = p1.ModifiedOn
            };
        }
        public static Table AdaptTo(this TableModel p7, Table p8)
        {
            if (p7 == null)
            {
                return null;
            }
            Table result = p8 ?? new Table();
            
            result.DeckType = p7.DeckType;
            result.Name = p7.Name;
            result.Owner = funcMain6(p7.Owner, result.Owner);
            result.OwnerId = p7.OwnerId;
            result.Players = funcMain8(p7.Players, result.Players);
            result.CreatedOn = p7.CreatedOn;
            result.Id = p7.Id;
            result.ModifiedOn = p7.ModifiedOn;
            return result;
            
        }
        public static TableModel AdaptToModel(this Table p17)
        {
            return p17 == null ? null : new TableModel()
            {
                DeckType = p17.DeckType,
                Name = p17.Name,
                Owner = funcMain11(p17.Owner),
                OwnerId = p17.OwnerId,
                Players = funcMain13(p17.Players),
                CreatedOn = p17.CreatedOn,
                Id = p17.Id,
                ModifiedOn = p17.ModifiedOn
            };
        }
        public static TableModel AdaptTo(this Table p23, TableModel p24)
        {
            if (p23 == null)
            {
                return null;
            }
            TableModel result = p24 ?? new TableModel();
            
            result.DeckType = p23.DeckType;
            result.Name = p23.Name;
            result.Owner = funcMain16(p23.Owner, result.Owner);
            result.OwnerId = p23.OwnerId;
            result.Players = funcMain18(p23.Players, result.Players);
            result.CreatedOn = p23.CreatedOn;
            result.Id = p23.Id;
            result.ModifiedOn = p23.ModifiedOn;
            return result;
            
        }
        
        private static User funcMain1(UserModel p2)
        {
            return p2 == null ? null : new User()
            {
                Tables = funcMain2(p2.Tables),
                Id = p2.Id,
                UserName = p2.UserName
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
                result.Add(funcMain4(item));
            }
            return result;
            
        }
        
        private static User funcMain6(UserModel p9, User p10)
        {
            if (p9 == null)
            {
                return null;
            }
            User result = p10 ?? new User();
            
            result.Tables = funcMain7(p9.Tables, result.Tables);
            result.Id = p9.Id;
            result.UserName = p9.UserName;
            return result;
            
        }
        
        private static ICollection<User> funcMain8(ICollection<UserModel> p13, ICollection<User> p14)
        {
            if (p13 == null)
            {
                return null;
            }
            ICollection<User> result = new List<User>(p13.Count);
            
            IEnumerator<UserModel> enumerator = p13.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserModel item = enumerator.Current;
                result.Add(funcMain9(item));
            }
            return result;
            
        }
        
        private static UserModel funcMain11(User p18)
        {
            return p18 == null ? null : new UserModel()
            {
                Tables = funcMain12(p18.Tables),
                Id = p18.Id,
                UserName = p18.UserName
            };
        }
        
        private static ICollection<UserModel> funcMain13(ICollection<User> p20)
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
                result.Add(funcMain14(item));
            }
            return result;
            
        }
        
        private static UserModel funcMain16(User p25, UserModel p26)
        {
            if (p25 == null)
            {
                return null;
            }
            UserModel result = p26 ?? new UserModel();
            
            result.Tables = funcMain17(p25.Tables, result.Tables);
            result.Id = p25.Id;
            result.UserName = p25.UserName;
            return result;
            
        }
        
        private static ICollection<UserModel> funcMain18(ICollection<User> p29, ICollection<UserModel> p30)
        {
            if (p29 == null)
            {
                return null;
            }
            ICollection<UserModel> result = new List<UserModel>(p29.Count);
            
            IEnumerator<User> enumerator = p29.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                User item = enumerator.Current;
                result.Add(funcMain19(item));
            }
            return result;
            
        }
        
        private static IList<Table> funcMain2(IList<TableModel> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p3.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p3.Count;
            
            while (i < len)
            {
                TableModel item = p3[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<TableModel, Table>().Invoke(item));
                i++;
            }
            return result;
            
        }
        
        private static User funcMain4(UserModel p5)
        {
            return p5 == null ? null : new User()
            {
                Tables = funcMain5(p5.Tables),
                Id = p5.Id,
                UserName = p5.UserName
            };
        }
        
        private static IList<Table> funcMain7(IList<TableModel> p11, IList<Table> p12)
        {
            if (p11 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p11.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p11.Count;
            
            while (i < len)
            {
                TableModel item = p11[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<TableModel, Table>().Invoke(item));
                i++;
            }
            return result;
            
        }
        
        private static User funcMain9(UserModel p15)
        {
            return p15 == null ? null : new User()
            {
                Tables = funcMain10(p15.Tables),
                Id = p15.Id,
                UserName = p15.UserName
            };
        }
        
        private static IList<TableModel> funcMain12(IList<Table> p19)
        {
            if (p19 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p19.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p19.Count;
            
            while (i < len)
            {
                Table item = p19[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<Table, TableModel>().Invoke(item));
                i++;
            }
            return result;
            
        }
        
        private static UserModel funcMain14(User p21)
        {
            return p21 == null ? null : new UserModel()
            {
                Tables = funcMain15(p21.Tables),
                Id = p21.Id,
                UserName = p21.UserName
            };
        }
        
        private static IList<TableModel> funcMain17(IList<Table> p27, IList<TableModel> p28)
        {
            if (p27 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p27.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p27.Count;
            
            while (i < len)
            {
                Table item = p27[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<Table, TableModel>().Invoke(item));
                i++;
            }
            return result;
            
        }
        
        private static UserModel funcMain19(User p31)
        {
            return p31 == null ? null : new UserModel()
            {
                Tables = funcMain20(p31.Tables),
                Id = p31.Id,
                UserName = p31.UserName
            };
        }
        
        private static IList<Table> funcMain5(IList<TableModel> p6)
        {
            if (p6 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p6.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p6.Count;
            
            while (i < len)
            {
                TableModel item = p6[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<TableModel, Table>().Invoke(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<Table> funcMain10(IList<TableModel> p16)
        {
            if (p16 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p16.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p16.Count;
            
            while (i < len)
            {
                TableModel item = p16[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<TableModel, Table>().Invoke(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<TableModel> funcMain15(IList<Table> p22)
        {
            if (p22 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p22.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p22.Count;
            
            while (i < len)
            {
                Table item = p22[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<Table, TableModel>().Invoke(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<TableModel> funcMain20(IList<Table> p32)
        {
            if (p32 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p32.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p32.Count;
            
            while (i < len)
            {
                Table item = p32[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<Table, TableModel>().Invoke(item));
                i++;
            }
            return result;
            
        }
    }
}