using System.Collections.Generic;
using Mapster;
using PlanningPoker.Core.Models.DTO;
using PlanningPoker.Persistence.Entities;

namespace PlanningPoker.Core.Mapping
{
    public static partial class UserMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static User AdaptToUser(this UserDto p1)
        {
            return p1 == null ? null : new User()
            {
                Tables = funcMain1(p1.Tables),
                Id = p1.Id,
                UserName = p1.UserName
            };
        }
        public static User AdaptTo(this UserDto p5, User p6)
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
        public static UserDto AdaptToDto(this User p11)
        {
            return p11 == null ? null : new UserDto()
            {
                Tables = funcMain7(p11.Tables),
                Id = p11.Id,
                UserName = p11.UserName
            };
        }
        public static UserDto AdaptTo(this User p15, UserDto p16)
        {
            if (p15 == null)
            {
                return null;
            }
            UserDto result = p16 ?? new UserDto();
            
            result.Tables = funcMain10(p15.Tables, result.Tables);
            result.Id = p15.Id;
            result.UserName = p15.UserName;
            return result;
            
        }
        
        private static IList<Table> funcMain1(IList<TableDto> p2)
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
                TableDto item = p2[i];
                list.Add(funcMain2(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<Table> funcMain4(IList<TableDto> p7, IList<Table> p8)
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
                TableDto item = p7[i];
                list.Add(funcMain5(item));
                i++;
            }
            return result;
            
        }
        
        private static IList<TableDto> funcMain7(IList<Table> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            IList<TableDto> result = new List<TableDto>(p12.Count);
            
            ICollection<TableDto> list = result;
            
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
        
        private static IList<TableDto> funcMain10(IList<Table> p17, IList<TableDto> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            IList<TableDto> result = new List<TableDto>(p17.Count);
            
            ICollection<TableDto> list = result;
            
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
        
        private static Table funcMain2(TableDto p3)
        {
            return p3 == null ? null : new Table()
            {
                DeckType = p3.DeckType,
                Name = p3.Name,
                Players = funcMain3(p3.Players),
                CreatedOn = p3.CreatedOn,
                Id = p3.Id,
                ModifiedOn = p3.ModifiedOn
            };
        }
        
        private static Table funcMain5(TableDto p9)
        {
            return p9 == null ? null : new Table()
            {
                DeckType = p9.DeckType,
                Name = p9.Name,
                Players = funcMain6(p9.Players),
                CreatedOn = p9.CreatedOn,
                Id = p9.Id,
                ModifiedOn = p9.ModifiedOn
            };
        }
        
        private static TableDto funcMain8(Table p13)
        {
            return p13 == null ? null : new TableDto()
            {
                DeckType = p13.DeckType,
                Name = p13.Name,
                Players = funcMain9(p13.Players),
                CreatedOn = p13.CreatedOn,
                Id = p13.Id,
                ModifiedOn = p13.ModifiedOn
            };
        }
        
        private static TableDto funcMain11(Table p19)
        {
            return p19 == null ? null : new TableDto()
            {
                DeckType = p19.DeckType,
                Name = p19.Name,
                Players = funcMain12(p19.Players),
                CreatedOn = p19.CreatedOn,
                Id = p19.Id,
                ModifiedOn = p19.ModifiedOn
            };
        }
        
        private static ICollection<User> funcMain3(ICollection<UserDto> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            ICollection<User> result = new List<User>(p4.Count);
            
            IEnumerator<UserDto> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserDto item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<UserDto, User>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<User> funcMain6(ICollection<UserDto> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            ICollection<User> result = new List<User>(p10.Count);
            
            IEnumerator<UserDto> enumerator = p10.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserDto item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<UserDto, User>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<UserDto> funcMain9(ICollection<User> p14)
        {
            if (p14 == null)
            {
                return null;
            }
            ICollection<UserDto> result = new List<UserDto>(p14.Count);
            
            IEnumerator<User> enumerator = p14.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                User item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<User, UserDto>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<UserDto> funcMain12(ICollection<User> p20)
        {
            if (p20 == null)
            {
                return null;
            }
            ICollection<UserDto> result = new List<UserDto>(p20.Count);
            
            IEnumerator<User> enumerator = p20.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                User item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<User, UserDto>().Invoke(item));
            }
            return result;
            
        }
    }
}