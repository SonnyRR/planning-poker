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
                Owner = funcMain3(p1.Owner),
                OwnerId = p1.OwnerId,
                Players = funcMain5(p1.Players),
                CreatedOn = p1.CreatedOn,
                Id = p1.Id,
                ModifiedOn = p1.ModifiedOn
            };
        }
        public static Table AdaptTo(this TableModel p9, Table p10)
        {
            if (p9 == null)
            {
                return null;
            }
            Table result = p10 ?? new Table();
            
            result.Deck = funcMain8(p9.Deck, result.Deck);
            result.DeckId = p9.DeckId;
            result.Name = p9.Name;
            result.Owner = funcMain10(p9.Owner, result.Owner);
            result.OwnerId = p9.OwnerId;
            result.Players = funcMain12(p9.Players, result.Players);
            result.CreatedOn = p9.CreatedOn;
            result.Id = p9.Id;
            result.ModifiedOn = p9.ModifiedOn;
            return result;
            
        }
        public static TableModel AdaptToModel(this Table p23)
        {
            return p23 == null ? null : new TableModel()
            {
                Deck = funcMain15(p23.Deck),
                DeckId = p23.DeckId,
                Name = p23.Name,
                Owner = funcMain17(p23.Owner),
                OwnerId = p23.OwnerId,
                Players = funcMain19(p23.Players),
                CreatedOn = p23.CreatedOn,
                Id = p23.Id,
                ModifiedOn = p23.ModifiedOn
            };
        }
        public static TableModel AdaptTo(this Table p31, TableModel p32)
        {
            if (p31 == null)
            {
                return null;
            }
            TableModel result = p32 ?? new TableModel();
            
            result.Deck = funcMain22(p31.Deck, result.Deck);
            result.DeckId = p31.DeckId;
            result.Name = p31.Name;
            result.Owner = funcMain24(p31.Owner, result.Owner);
            result.OwnerId = p31.OwnerId;
            result.Players = funcMain26(p31.Players, result.Players);
            result.CreatedOn = p31.CreatedOn;
            result.Id = p31.Id;
            result.ModifiedOn = p31.ModifiedOn;
            return result;
            
        }
        
        private static Deck funcMain1(DeckModel p2)
        {
            return p2 == null ? null : new Deck()
            {
                Type = p2.Type,
                Cards = funcMain2(p2.Cards),
                DeletedOn = p2.DeletedOn,
                IsDeleted = p2.IsDeleted,
                CreatedOn = p2.CreatedOn,
                Id = p2.Id,
                ModifiedOn = p2.ModifiedOn
            };
        }
        
        private static User funcMain3(UserModel p4)
        {
            return p4 == null ? null : new User()
            {
                Tables = funcMain4(p4.Tables),
                Id = p4.Id,
                UserName = p4.UserName
            };
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
                list.Add(funcMain6(item));
                i++;
            }
            return result;
            
        }
        
        private static Deck funcMain8(DeckModel p11, Deck p12)
        {
            if (p11 == null)
            {
                return null;
            }
            Deck result = p12 ?? new Deck();
            
            result.Type = p11.Type;
            result.Cards = funcMain9(p11.Cards, result.Cards);
            result.DeletedOn = p11.DeletedOn;
            result.IsDeleted = p11.IsDeleted;
            result.CreatedOn = p11.CreatedOn;
            result.Id = p11.Id;
            result.ModifiedOn = p11.ModifiedOn;
            return result;
            
        }
        
        private static User funcMain10(UserModel p15, User p16)
        {
            if (p15 == null)
            {
                return null;
            }
            User result = p16 ?? new User();
            
            result.Tables = funcMain11(p15.Tables, result.Tables);
            result.Id = p15.Id;
            result.UserName = p15.UserName;
            return result;
            
        }
        
        private static IList<User> funcMain12(IList<UserModel> p19, IList<User> p20)
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
                list.Add(funcMain13(item));
                i++;
            }
            return result;
            
        }
        
        private static DeckModel funcMain15(Deck p24)
        {
            return p24 == null ? null : new DeckModel()
            {
                Type = p24.Type,
                Cards = funcMain16(p24.Cards),
                DeletedOn = p24.DeletedOn,
                IsDeleted = p24.IsDeleted,
                CreatedOn = p24.CreatedOn,
                Id = p24.Id,
                ModifiedOn = p24.ModifiedOn
            };
        }
        
        private static UserModel funcMain17(User p26)
        {
            return p26 == null ? null : new UserModel()
            {
                Tables = funcMain18(p26.Tables),
                Id = p26.Id,
                UserName = p26.UserName
            };
        }
        
        private static IList<UserModel> funcMain19(IList<User> p28)
        {
            if (p28 == null)
            {
                return null;
            }
            IList<UserModel> result = new List<UserModel>(p28.Count);
            
            ICollection<UserModel> list = result;
            
            int i = 0;
            int len = p28.Count;
            
            while (i < len)
            {
                User item = p28[i];
                list.Add(funcMain20(item));
                i++;
            }
            return result;
            
        }
        
        private static DeckModel funcMain22(Deck p33, DeckModel p34)
        {
            if (p33 == null)
            {
                return null;
            }
            DeckModel result = p34 ?? new DeckModel();
            
            result.Type = p33.Type;
            result.Cards = funcMain23(p33.Cards, result.Cards);
            result.DeletedOn = p33.DeletedOn;
            result.IsDeleted = p33.IsDeleted;
            result.CreatedOn = p33.CreatedOn;
            result.Id = p33.Id;
            result.ModifiedOn = p33.ModifiedOn;
            return result;
            
        }
        
        private static UserModel funcMain24(User p37, UserModel p38)
        {
            if (p37 == null)
            {
                return null;
            }
            UserModel result = p38 ?? new UserModel();
            
            result.Tables = funcMain25(p37.Tables, result.Tables);
            result.Id = p37.Id;
            result.UserName = p37.UserName;
            return result;
            
        }
        
        private static IList<UserModel> funcMain26(IList<User> p41, IList<UserModel> p42)
        {
            if (p41 == null)
            {
                return null;
            }
            IList<UserModel> result = new List<UserModel>(p41.Count);
            
            ICollection<UserModel> list = result;
            
            int i = 0;
            int len = p41.Count;
            
            while (i < len)
            {
                User item = p41[i];
                list.Add(funcMain27(item));
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
                    Decks = null,
                    DeletedOn = item.DeletedOn,
                    IsDeleted = item.IsDeleted,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<Table> funcMain4(IList<TableModel> p5)
        {
            if (p5 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p5.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                TableModel item = p5[i];
                list.Add(item == null ? null : new Table()
                {
                    Deck = null,
                    DeckId = item.DeckId,
                    Name = item.Name,
                    Owner = null,
                    OwnerId = item.OwnerId,
                    Players = null,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static User funcMain6(UserModel p7)
        {
            return p7 == null ? null : new User()
            {
                Tables = funcMain7(p7.Tables),
                Id = p7.Id,
                UserName = p7.UserName
            };
        }
        
        private static List<Card> funcMain9(List<CardModel> p13, List<Card> p14)
        {
            if (p13 == null)
            {
                return null;
            }
            List<Card> result = new List<Card>(p13.Count);
            
            int i = 0;
            int len = p13.Count;
            
            while (i < len)
            {
                CardModel item = p13[i];
                result.Add(item == null ? null : new Card()
                {
                    UnicodeValue = item.UnicodeValue,
                    Value = item.Value,
                    Decks = null,
                    DeletedOn = item.DeletedOn,
                    IsDeleted = item.IsDeleted,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<Table> funcMain11(IList<TableModel> p17, IList<Table> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p17.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p17.Count;
            
            while (i < len)
            {
                TableModel item = p17[i];
                list.Add(item == null ? null : new Table()
                {
                    Deck = null,
                    DeckId = item.DeckId,
                    Name = item.Name,
                    Owner = null,
                    OwnerId = item.OwnerId,
                    Players = null,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static User funcMain13(UserModel p21)
        {
            return p21 == null ? null : new User()
            {
                Tables = funcMain14(p21.Tables),
                Id = p21.Id,
                UserName = p21.UserName
            };
        }
        
        private static List<CardModel> funcMain16(List<Card> p25)
        {
            if (p25 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p25.Count);
            
            int i = 0;
            int len = p25.Count;
            
            while (i < len)
            {
                Card item = p25[i];
                result.Add(item == null ? null : new CardModel()
                {
                    UnicodeValue = item.UnicodeValue,
                    Value = item.Value,
                    Decks = null,
                    DeletedOn = item.DeletedOn,
                    IsDeleted = item.IsDeleted,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<TableModel> funcMain18(IList<Table> p27)
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
                list.Add(item == null ? null : new TableModel()
                {
                    Deck = null,
                    DeckId = item.DeckId,
                    Name = item.Name,
                    Owner = null,
                    OwnerId = item.OwnerId,
                    Players = null,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static UserModel funcMain20(User p29)
        {
            return p29 == null ? null : new UserModel()
            {
                Tables = funcMain21(p29.Tables),
                Id = p29.Id,
                UserName = p29.UserName
            };
        }
        
        private static List<CardModel> funcMain23(List<Card> p35, List<CardModel> p36)
        {
            if (p35 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p35.Count);
            
            int i = 0;
            int len = p35.Count;
            
            while (i < len)
            {
                Card item = p35[i];
                result.Add(item == null ? null : new CardModel()
                {
                    UnicodeValue = item.UnicodeValue,
                    Value = item.Value,
                    Decks = null,
                    DeletedOn = item.DeletedOn,
                    IsDeleted = item.IsDeleted,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<TableModel> funcMain25(IList<Table> p39, IList<TableModel> p40)
        {
            if (p39 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p39.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p39.Count;
            
            while (i < len)
            {
                Table item = p39[i];
                list.Add(item == null ? null : new TableModel()
                {
                    Deck = null,
                    DeckId = item.DeckId,
                    Name = item.Name,
                    Owner = null,
                    OwnerId = item.OwnerId,
                    Players = null,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static UserModel funcMain27(User p43)
        {
            return p43 == null ? null : new UserModel()
            {
                Tables = funcMain28(p43.Tables),
                Id = p43.Id,
                UserName = p43.UserName
            };
        }
        
        private static IList<Table> funcMain7(IList<TableModel> p8)
        {
            if (p8 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p8.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p8.Count;
            
            while (i < len)
            {
                TableModel item = p8[i];
                list.Add(item == null ? null : new Table()
                {
                    Deck = null,
                    DeckId = item.DeckId,
                    Name = item.Name,
                    Owner = null,
                    OwnerId = item.OwnerId,
                    Players = null,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<Table> funcMain14(IList<TableModel> p22)
        {
            if (p22 == null)
            {
                return null;
            }
            IList<Table> result = new List<Table>(p22.Count);
            
            ICollection<Table> list = result;
            
            int i = 0;
            int len = p22.Count;
            
            while (i < len)
            {
                TableModel item = p22[i];
                list.Add(item == null ? null : new Table()
                {
                    Deck = null,
                    DeckId = item.DeckId,
                    Name = item.Name,
                    Owner = null,
                    OwnerId = item.OwnerId,
                    Players = null,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<TableModel> funcMain21(IList<Table> p30)
        {
            if (p30 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p30.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p30.Count;
            
            while (i < len)
            {
                Table item = p30[i];
                list.Add(item == null ? null : new TableModel()
                {
                    Deck = null,
                    DeckId = item.DeckId,
                    Name = item.Name,
                    Owner = null,
                    OwnerId = item.OwnerId,
                    Players = null,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<TableModel> funcMain28(IList<Table> p44)
        {
            if (p44 == null)
            {
                return null;
            }
            IList<TableModel> result = new List<TableModel>(p44.Count);
            
            ICollection<TableModel> list = result;
            
            int i = 0;
            int len = p44.Count;
            
            while (i < len)
            {
                Table item = p44[i];
                list.Add(item == null ? null : new TableModel()
                {
                    Deck = null,
                    DeckId = item.DeckId,
                    Name = item.Name,
                    Owner = null,
                    OwnerId = item.OwnerId,
                    Players = null,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn
                });
                i++;
            }
            return result;
            
        }
    }
}