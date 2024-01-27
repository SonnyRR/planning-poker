using System;
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
                DeckId = funcMain3(p1.Deck == null ? null : (Guid?)p1.Deck.Id),
                Name = p1.Name,
                Owner = p1.Owner == null ? null : new User()
                {
                    Id = p1.Owner.Id,
                    UserName = p1.Owner.UserName
                },
                OwnerId = funcMain4(p1.Owner == null ? null : (Guid?)p1.Owner.Id),
                Players = funcMain5(p1.Players),
                Id = p1.Id
            };
        }
        public static Table AdaptTo(this TableModel p7, Table p8)
        {
            if (p7 == null)
            {
                return null;
            }
            Table result = p8 ?? new Table();
            
            result.Deck = funcMain6(p7.Deck, result.Deck);
            result.DeckId = funcMain8(p7.Deck == null ? null : (Guid?)p7.Deck.Id, result.DeckId);
            result.Name = p7.Name;
            result.Owner = funcMain9(p7.Owner, result.Owner);
            result.OwnerId = funcMain10(p7.Owner == null ? null : (Guid?)p7.Owner.Id, result.OwnerId);
            result.Players = funcMain11(p7.Players, result.Players);
            result.Id = p7.Id;
            return result;
            
        }
        public static TableModel AdaptToModel(this Table p21)
        {
            return p21 == null ? null : new TableModel()
            {
                Deck = funcMain12(p21.Deck),
                Name = p21.Name,
                Owner = p21.Owner == null ? null : new UserModel()
                {
                    Id = p21.Owner.Id,
                    UserName = p21.Owner.UserName
                },
                Players = funcMain14(p21.Players),
                Id = p21.Id
            };
        }
        public static TableModel AdaptTo(this Table p25, TableModel p26)
        {
            if (p25 == null)
            {
                return null;
            }
            TableModel result = p26 ?? new TableModel();
            
            result.Deck = funcMain15(p25.Deck, result.Deck);
            result.Name = p25.Name;
            result.Owner = funcMain17(p25.Owner, result.Owner);
            result.Players = funcMain18(p25.Players, result.Players);
            result.Id = p25.Id;
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
        
        private static Guid funcMain3(Guid? p4)
        {
            return p4 == null ? default(Guid) : (Guid)p4;
        }
        
        private static Guid funcMain4(Guid? p5)
        {
            return p5 == null ? default(Guid) : (Guid)p5;
        }
        
        private static IList<User> funcMain5(IList<UserModel> p6)
        {
            if (p6 == null)
            {
                return null;
            }
            IList<User> result = new List<User>(p6.Count);
            
            ICollection<User> list = result;
            
            int i = 0;
            int len = p6.Count;
            
            while (i < len)
            {
                UserModel item = p6[i];
                list.Add(item == null ? null : new User()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static Deck funcMain6(DeckModel p9, Deck p10)
        {
            if (p9 == null)
            {
                return null;
            }
            Deck result = p10 ?? new Deck();
            
            result.Type = p9.Type;
            result.Cards = funcMain7(p9.Cards, result.Cards);
            result.Id = p9.Id;
            return result;
            
        }
        
        private static Guid funcMain8(Guid? p13, Guid p14)
        {
            return p13 == null ? default(Guid) : (Guid)p13;
        }
        
        private static User funcMain9(UserModel p15, User p16)
        {
            if (p15 == null)
            {
                return null;
            }
            User result = p16 ?? new User();
            
            result.Id = p15.Id;
            result.UserName = p15.UserName;
            return result;
            
        }
        
        private static Guid funcMain10(Guid? p17, Guid p18)
        {
            return p17 == null ? default(Guid) : (Guid)p17;
        }
        
        private static IList<User> funcMain11(IList<UserModel> p19, IList<User> p20)
        {
            if (p19 == null)
            {
                return null;
            }
            IList<User> result = new List<User>(p19.Count);
            
            ICollection<User> list = result;
            
            int i = 0;
            int len = p19.Count;
            
            while (i < len)
            {
                UserModel item = p19[i];
                list.Add(item == null ? null : new User()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static DeckModel funcMain12(Deck p22)
        {
            return p22 == null ? null : new DeckModel()
            {
                Type = p22.Type,
                Cards = funcMain13(p22.Cards),
                Id = p22.Id
            };
        }
        
        private static IList<UserModel> funcMain14(IList<User> p24)
        {
            if (p24 == null)
            {
                return null;
            }
            IList<UserModel> result = new List<UserModel>(p24.Count);
            
            ICollection<UserModel> list = result;
            
            int i = 0;
            int len = p24.Count;
            
            while (i < len)
            {
                User item = p24[i];
                list.Add(item == null ? null : new UserModel()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static DeckModel funcMain15(Deck p27, DeckModel p28)
        {
            if (p27 == null)
            {
                return null;
            }
            DeckModel result = p28 ?? new DeckModel();
            
            result.Type = p27.Type;
            result.Cards = funcMain16(p27.Cards, result.Cards);
            result.Id = p27.Id;
            return result;
            
        }
        
        private static UserModel funcMain17(User p31, UserModel p32)
        {
            if (p31 == null)
            {
                return null;
            }
            UserModel result = p32 ?? new UserModel();
            
            result.Id = p31.Id;
            result.UserName = p31.UserName;
            return result;
            
        }
        
        private static IList<UserModel> funcMain18(IList<User> p33, IList<UserModel> p34)
        {
            if (p33 == null)
            {
                return null;
            }
            IList<UserModel> result = new List<UserModel>(p33.Count);
            
            ICollection<UserModel> list = result;
            
            int i = 0;
            int len = p33.Count;
            
            while (i < len)
            {
                User item = p33[i];
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
        
        private static List<Card> funcMain7(List<CardModel> p11, List<Card> p12)
        {
            if (p11 == null)
            {
                return null;
            }
            List<Card> result = new List<Card>(p11.Count);
            
            int i = 0;
            int len = p11.Count;
            
            while (i < len)
            {
                CardModel item = p11[i];
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
        
        private static List<CardModel> funcMain13(List<Card> p23)
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
        
        private static List<CardModel> funcMain16(List<Card> p29, List<CardModel> p30)
        {
            if (p29 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p29.Count);
            
            int i = 0;
            int len = p29.Count;
            
            while (i < len)
            {
                Card item = p29[i];
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