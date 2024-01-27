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
                Deck = funcMain1(p1.Deck),
                DeckId = p1.DeckId,
                Name = p1.Name,
                Owner = p1.Owner == null ? null : new User()
                {
                    Id = p1.Owner.Id,
                    UserName = p1.Owner.UserName
                },
                OwnerId = p1.OwnerId,
                Players = funcMain3(p1.Players),
                Id = p1.Id
            };
        }
        public static Table AdaptTo(this TableModel p5, Table p6)
        {
            if (p5 == null)
            {
                return null;
            }
            Table result = p6 ?? new Table();
            
            result.Deck = funcMain4(p5.Deck, result.Deck);
            result.DeckId = p5.DeckId;
            result.Name = p5.Name;
            result.Owner = funcMain6(p5.Owner, result.Owner);
            result.OwnerId = p5.OwnerId;
            result.Players = funcMain7(p5.Players, result.Players);
            result.Id = p5.Id;
            return result;
            
        }
        public static TableModel AdaptToModel(this Table p15)
        {
            return p15 == null ? null : new TableModel()
            {
                Deck = funcMain8(p15.Deck),
                DeckId = p15.DeckId,
                Name = p15.Name,
                Owner = p15.Owner == null ? null : new UserModel()
                {
                    Id = p15.Owner.Id,
                    UserName = p15.Owner.UserName
                },
                OwnerId = p15.OwnerId,
                Players = funcMain10(p15.Players),
                Id = p15.Id
            };
        }
        public static TableModel AdaptTo(this Table p19, TableModel p20)
        {
            if (p19 == null)
            {
                return null;
            }
            TableModel result = p20 ?? new TableModel();
            
            result.Deck = funcMain11(p19.Deck, result.Deck);
            result.DeckId = p19.DeckId;
            result.Name = p19.Name;
            result.Owner = funcMain13(p19.Owner, result.Owner);
            result.OwnerId = p19.OwnerId;
            result.Players = funcMain14(p19.Players, result.Players);
            result.Id = p19.Id;
            return result;
            
        }
        
        private static Deck funcMain1(DeckModel p2)
        {
            return p2 == null ? null : new Deck()
            {
                Type = p2.Type,
                Cards = funcMain2(p2.Cards),
                Id = p2.Id
            };
        }
        
        private static IList<User> funcMain3(IList<UserModel> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            IList<User> result = new List<User>(p4.Count);
            
            ICollection<User> list = result;
            
            int i = 0;
            int len = p4.Count;
            
            while (i < len)
            {
                UserModel item = p4[i];
                list.Add(item == null ? null : new User()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static Deck funcMain4(DeckModel p7, Deck p8)
        {
            if (p7 == null)
            {
                return null;
            }
            Deck result = p8 ?? new Deck();
            
            result.Type = p7.Type;
            result.Cards = funcMain5(p7.Cards, result.Cards);
            result.Id = p7.Id;
            return result;
            
        }
        
        private static User funcMain6(UserModel p11, User p12)
        {
            if (p11 == null)
            {
                return null;
            }
            User result = p12 ?? new User();
            
            result.Id = p11.Id;
            result.UserName = p11.UserName;
            return result;
            
        }
        
        private static IList<User> funcMain7(IList<UserModel> p13, IList<User> p14)
        {
            if (p13 == null)
            {
                return null;
            }
            IList<User> result = new List<User>(p13.Count);
            
            ICollection<User> list = result;
            
            int i = 0;
            int len = p13.Count;
            
            while (i < len)
            {
                UserModel item = p13[i];
                list.Add(item == null ? null : new User()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static DeckModel funcMain8(Deck p16)
        {
            return p16 == null ? null : new DeckModel()
            {
                Type = p16.Type,
                Cards = funcMain9(p16.Cards),
                Id = p16.Id
            };
        }
        
        private static IList<UserModel> funcMain10(IList<User> p18)
        {
            if (p18 == null)
            {
                return null;
            }
            IList<UserModel> result = new List<UserModel>(p18.Count);
            
            ICollection<UserModel> list = result;
            
            int i = 0;
            int len = p18.Count;
            
            while (i < len)
            {
                User item = p18[i];
                list.Add(item == null ? null : new UserModel()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static DeckModel funcMain11(Deck p21, DeckModel p22)
        {
            if (p21 == null)
            {
                return null;
            }
            DeckModel result = p22 ?? new DeckModel();
            
            result.Type = p21.Type;
            result.Cards = funcMain12(p21.Cards, result.Cards);
            result.Id = p21.Id;
            return result;
            
        }
        
        private static UserModel funcMain13(User p25, UserModel p26)
        {
            if (p25 == null)
            {
                return null;
            }
            UserModel result = p26 ?? new UserModel();
            
            result.Id = p25.Id;
            result.UserName = p25.UserName;
            return result;
            
        }
        
        private static IList<UserModel> funcMain14(IList<User> p27, IList<UserModel> p28)
        {
            if (p27 == null)
            {
                return null;
            }
            IList<UserModel> result = new List<UserModel>(p27.Count);
            
            ICollection<UserModel> list = result;
            
            int i = 0;
            int len = p27.Count;
            
            while (i < len)
            {
                User item = p27[i];
                list.Add(item == null ? null : new UserModel()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static List<Card> funcMain2(List<CardModel> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            List<Card> result = new List<Card>(p3.Count);
            
            int i = 0;
            int len = p3.Count;
            
            while (i < len)
            {
                CardModel item = p3[i];
                result.Add(item == null ? null : new Card()
                {
                    UnicodeValue = item.UnicodeValue,
                    Value = item.Value,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static List<Card> funcMain5(List<CardModel> p9, List<Card> p10)
        {
            if (p9 == null)
            {
                return null;
            }
            List<Card> result = new List<Card>(p9.Count);
            
            int i = 0;
            int len = p9.Count;
            
            while (i < len)
            {
                CardModel item = p9[i];
                result.Add(item == null ? null : new Card()
                {
                    UnicodeValue = item.UnicodeValue,
                    Value = item.Value,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static List<CardModel> funcMain9(List<Card> p17)
        {
            if (p17 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p17.Count);
            
            int i = 0;
            int len = p17.Count;
            
            while (i < len)
            {
                Card item = p17[i];
                result.Add(item == null ? null : new CardModel()
                {
                    UnicodeValue = item.UnicodeValue,
                    Value = item.Value,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static List<CardModel> funcMain12(List<Card> p23, List<CardModel> p24)
        {
            if (p23 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p23.Count);
            
            int i = 0;
            int len = p23.Count;
            
            while (i < len)
            {
                Card item = p23[i];
                result.Add(item == null ? null : new CardModel()
                {
                    UnicodeValue = item.UnicodeValue,
                    Value = item.Value,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
    }
}