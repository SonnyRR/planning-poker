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
                Players = funcMain1(p1.Players),
                CreatedOn = p1.CreatedOn,
                Id = p1.Id,
                ModifiedOn = p1.ModifiedOn
            };
        }
        public static Table AdaptTo(this TableModel p5, Table p6)
        {
            if (p5 == null)
            {
                return null;
            }
            Table result = p6 ?? new Table();
            
            result.DeckType = p5.DeckType;
            result.Name = p5.Name;
            result.Players = funcMain4(p5.Players, result.Players);
            result.CreatedOn = p5.CreatedOn;
            result.Id = p5.Id;
            result.ModifiedOn = p5.ModifiedOn;
            return result;
            
        }
        public static TableModel AdaptToModel(this Table p11)
        {
            return p11 == null ? null : new TableModel()
            {
                DeckType = p11.DeckType,
                Name = p11.Name,
                Players = funcMain7(p11.Players),
                CreatedOn = p11.CreatedOn,
                Id = p11.Id,
                ModifiedOn = p11.ModifiedOn
            };
        }
        public static TableModel AdaptTo(this Table p15, TableModel p16)
        {
            if (p15 == null)
            {
                return null;
            }
            TableModel result = p16 ?? new TableModel();
            
            result.DeckType = p15.DeckType;
            result.Name = p15.Name;
            result.Players = funcMain10(p15.Players, result.Players);
            result.CreatedOn = p15.CreatedOn;
            result.Id = p15.Id;
            result.ModifiedOn = p15.ModifiedOn;
            return result;
            
        }
        
        private static ICollection<User> funcMain1(ICollection<UserModel> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            ICollection<User> result = new List<User>(p2.Count);
            
            IEnumerator<UserModel> enumerator = p2.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserModel item = enumerator.Current;
                result.Add(funcMain2(item));
            }
            return result;
            
        }
        
        private static ICollection<User> funcMain4(ICollection<UserModel> p7, ICollection<User> p8)
        {
            if (p7 == null)
            {
                return null;
            }
            ICollection<User> result = new List<User>(p7.Count);
            
            IEnumerator<UserModel> enumerator = p7.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserModel item = enumerator.Current;
                result.Add(funcMain5(item));
            }
            return result;
            
        }
        
        private static ICollection<UserModel> funcMain7(ICollection<User> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            ICollection<UserModel> result = new List<UserModel>(p12.Count);
            
            IEnumerator<User> enumerator = p12.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                User item = enumerator.Current;
                result.Add(funcMain8(item));
            }
            return result;
            
        }
        
        private static ICollection<UserModel> funcMain10(ICollection<User> p17, ICollection<UserModel> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            ICollection<UserModel> result = new List<UserModel>(p17.Count);
            
            IEnumerator<User> enumerator = p17.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                User item = enumerator.Current;
                result.Add(funcMain11(item));
            }
            return result;
            
        }
        
        private static User funcMain2(UserModel p3)
        {
            return p3 == null ? null : new User()
            {
                Tables = funcMain3(p3.Tables),
                Id = p3.Id,
                UserName = p3.UserName
            };
        }
        
        private static User funcMain5(UserModel p9)
        {
            return p9 == null ? null : new User()
            {
                Tables = funcMain6(p9.Tables),
                Id = p9.Id,
                UserName = p9.UserName
            };
        }
        
        private static UserModel funcMain8(User p13)
        {
            return p13 == null ? null : new UserModel()
            {
                Tables = funcMain9(p13.Tables),
                Id = p13.Id,
                UserName = p13.UserName
            };
        }
        
        private static UserModel funcMain11(User p19)
        {
            return p19 == null ? null : new UserModel()
            {
                Tables = funcMain12(p19.Tables),
                Id = p19.Id,
                UserName = p19.UserName
            };
        }
        
        private static IList<Table> funcMain3(IList<TableModel> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p4.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p4.Count;
            
            while (i < len)
            {
                TableModel item = p4[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<TableModel, Table>().Invoke(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<Table> funcMain6(IList<TableModel> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p10.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p10.Count;
            
            while (i < len)
            {
                TableModel item = p10[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<TableModel, Table>().Invoke(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<TableModel> funcMain9(IList<Table> p14)
        {
            if (p14 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p14.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p14.Count;
            
            while (i < len)
            {
                Table item = p14[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<Table, TableModel>().Invoke(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<TableModel> funcMain12(IList<Table> p20)
        {
            if (p20 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p20.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p20.Count;
            
            while (i < len)
            {
                Table item = p20[i];
                list.Add(TypeAdapterConfig1.GetMapFunction<Table, TableModel>().Invoke(item));
                i++;
            }
            return result;
            
        }
    }
}