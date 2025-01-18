using System;
using System.Collections.Generic;
using PlanningPoker.Generated.Models;
using PlanningPoker.Persistence;
using PlanningPoker.Persistence.Entities;

namespace PlanningPoker.Generated.Mapping
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
                Rounds = funcMain6(p1.Rounds),
                Id = p1.Id
            };
        }
        public static Table AdaptTo(this TableModel p10, Table p11)
        {
            if (p10 == null)
            {
                return null;
            }
            Table result = p11 ?? new Table();
            
            result.Deck = funcMain9(p10.Deck, result.Deck);
            result.DeckId = funcMain11(p10.Deck == null ? null : (Guid?)p10.Deck.Id, result.DeckId);
            result.Name = p10.Name;
            result.Owner = funcMain12(p10.Owner, result.Owner);
            result.OwnerId = funcMain13(p10.Owner == null ? null : (Guid?)p10.Owner.Id, result.OwnerId);
            result.Players = funcMain14(p10.Players, result.Players);
            result.Rounds = funcMain15(p10.Rounds, result.Rounds);
            result.Id = p10.Id;
            return result;
            
        }
        public static TableModel AdaptToModel(this Table p28)
        {
            return p28 == null ? null : new TableModel()
            {
                Deck = funcMain18(p28.Deck),
                Name = p28.Name,
                Owner = p28.Owner == null ? null : new UserModel()
                {
                    Id = p28.Owner.Id,
                    UserName = p28.Owner.UserName
                },
                Players = funcMain20(p28.Players),
                Rounds = funcMain21(p28.Rounds),
                Id = p28.Id
            };
        }
        public static TableModel AdaptTo(this Table p35, TableModel p36)
        {
            if (p35 == null)
            {
                return null;
            }
            TableModel result = p36 ?? new TableModel();
            
            result.Deck = funcMain24(p35.Deck, result.Deck);
            result.Name = p35.Name;
            result.Owner = funcMain26(p35.Owner, result.Owner);
            result.Players = funcMain27(p35.Players, result.Players);
            result.Rounds = funcMain28(p35.Rounds, result.Rounds);
            result.Id = p35.Id;
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
        
        private static IList<Round> funcMain6(IList<RoundModel> p7)
        {
            if (p7 == null)
            {
                return null;
            }
            IList<Round> result = new List<Round>(p7.Count);
            
            ICollection<Round> list = result;
            
            int i = 0;
            int len = p7.Count;
            
            while (i < len)
            {
                RoundModel item = p7[i];
                list.Add(funcMain7(item));
                i++;
            }
            return result;
            
        }
        
        private static Deck funcMain9(DeckModel p12, Deck p13)
        {
            if (p12 == null)
            {
                return null;
            }
            Deck result = p13 ?? new Deck();
            
            result.Type = p12.Type;
            result.Cards = funcMain10(p12.Cards, result.Cards);
            result.Id = p12.Id;
            return result;
            
        }
        
        private static Guid funcMain11(Guid? p16, Guid p17)
        {
            return p16 == null ? default(Guid) : (Guid)p16;
        }
        
        private static User funcMain12(UserModel p18, User p19)
        {
            if (p18 == null)
            {
                return null;
            }
            User result = p19 ?? new User();
            
            result.Id = p18.Id;
            result.UserName = p18.UserName;
            return result;
            
        }
        
        private static Guid funcMain13(Guid? p20, Guid p21)
        {
            return p20 == null ? default(Guid) : (Guid)p20;
        }
        
        private static IList<User> funcMain14(IList<UserModel> p22, IList<User> p23)
        {
            if (p22 == null)
            {
                return null;
            }
            IList<User> result = new List<User>(p22.Count);
            
            ICollection<User> list = result;
            
            int i = 0;
            int len = p22.Count;
            
            while (i < len)
            {
                UserModel item = p22[i];
                list.Add(item == null ? null : new User()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<Round> funcMain15(IList<RoundModel> p24, IList<Round> p25)
        {
            if (p24 == null)
            {
                return null;
            }
            IList<Round> result = new List<Round>(p24.Count);
            
            ICollection<Round> list = result;
            
            int i = 0;
            int len = p24.Count;
            
            while (i < len)
            {
                RoundModel item = p24[i];
                list.Add(funcMain16(item));
                i++;
            }
            return result;
            
        }
        
        private static DeckModel funcMain18(Deck p29)
        {
            return p29 == null ? null : new DeckModel()
            {
                Type = p29.Type,
                Cards = funcMain19(p29.Cards),
                Id = p29.Id
            };
        }
        
        private static IList<UserModel> funcMain20(IList<User> p31)
        {
            if (p31 == null)
            {
                return null;
            }
            IList<UserModel> result = new List<UserModel>(p31.Count);
            
            ICollection<UserModel> list = result;
            
            int i = 0;
            int len = p31.Count;
            
            while (i < len)
            {
                User item = p31[i];
                list.Add(item == null ? null : new UserModel()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<RoundModel> funcMain21(IList<Round> p32)
        {
            if (p32 == null)
            {
                return null;
            }
            IList<RoundModel> result = new List<RoundModel>(p32.Count);
            
            ICollection<RoundModel> list = result;
            
            int i = 0;
            int len = p32.Count;
            
            while (i < len)
            {
                Round item = p32[i];
                list.Add(funcMain22(item));
                i++;
            }
            return result;
            
        }
        
        private static DeckModel funcMain24(Deck p37, DeckModel p38)
        {
            if (p37 == null)
            {
                return null;
            }
            DeckModel result = p38 ?? new DeckModel();
            
            result.Type = p37.Type;
            result.Cards = funcMain25(p37.Cards, result.Cards);
            result.Id = p37.Id;
            return result;
            
        }
        
        private static UserModel funcMain26(User p41, UserModel p42)
        {
            if (p41 == null)
            {
                return null;
            }
            UserModel result = p42 ?? new UserModel();
            
            result.Id = p41.Id;
            result.UserName = p41.UserName;
            return result;
            
        }
        
        private static IList<UserModel> funcMain27(IList<User> p43, IList<UserModel> p44)
        {
            if (p43 == null)
            {
                return null;
            }
            IList<UserModel> result = new List<UserModel>(p43.Count);
            
            ICollection<UserModel> list = result;
            
            int i = 0;
            int len = p43.Count;
            
            while (i < len)
            {
                User item = p43[i];
                list.Add(item == null ? null : new UserModel()
                {
                    Id = item.Id,
                    UserName = item.UserName
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<RoundModel> funcMain28(IList<Round> p45, IList<RoundModel> p46)
        {
            if (p45 == null)
            {
                return null;
            }
            IList<RoundModel> result = new List<RoundModel>(p45.Count);
            
            ICollection<RoundModel> list = result;
            
            int i = 0;
            int len = p45.Count;
            
            while (i < len)
            {
                Round item = p45[i];
                list.Add(funcMain29(item));
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
        
        private static Round funcMain7(RoundModel p8)
        {
            return p8 == null ? null : new Round()
            {
                Description = p8.Description,
                TableId = p8.TableId,
                FinalEstimation = p8.FinalEstimation,
                StartedOn = p8.StartedOn,
                EndedOn = p8.EndedOn,
                Votes = funcMain8(p8.Votes),
                Id = p8.Id
            };
        }
        
        private static List<Card> funcMain10(List<CardModel> p14, List<Card> p15)
        {
            if (p14 == null)
            {
                return null;
            }
            List<Card> result = new List<Card>(p14.Count);
            
            int i = 0;
            int len = p14.Count;
            
            while (i < len)
            {
                CardModel item = p14[i];
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
        
        private static Round funcMain16(RoundModel p26)
        {
            return p26 == null ? null : new Round()
            {
                Description = p26.Description,
                TableId = p26.TableId,
                FinalEstimation = p26.FinalEstimation,
                StartedOn = p26.StartedOn,
                EndedOn = p26.EndedOn,
                Votes = funcMain17(p26.Votes),
                Id = p26.Id
            };
        }
        
        private static List<CardModel> funcMain19(List<Card> p30)
        {
            if (p30 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p30.Count);
            
            int i = 0;
            int len = p30.Count;
            
            while (i < len)
            {
                Card item = p30[i];
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
        
        private static RoundModel funcMain22(Round p33)
        {
            return p33 == null ? null : new RoundModel()
            {
                Description = p33.Description,
                TableId = p33.TableId,
                FinalEstimation = p33.FinalEstimation,
                StartedOn = p33.StartedOn,
                EndedOn = p33.EndedOn,
                Elapsed = p33.Elapsed,
                Votes = funcMain23(p33.Votes),
                Id = p33.Id
            };
        }
        
        private static List<CardModel> funcMain25(List<Card> p39, List<CardModel> p40)
        {
            if (p39 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p39.Count);
            
            int i = 0;
            int len = p39.Count;
            
            while (i < len)
            {
                Card item = p39[i];
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
        
        private static RoundModel funcMain29(Round p47)
        {
            return p47 == null ? null : new RoundModel()
            {
                Description = p47.Description,
                TableId = p47.TableId,
                FinalEstimation = p47.FinalEstimation,
                StartedOn = p47.StartedOn,
                EndedOn = p47.EndedOn,
                Elapsed = p47.Elapsed,
                Votes = funcMain30(p47.Votes),
                Id = p47.Id
            };
        }
        
        private static IList<Vote> funcMain8(IList<VoteModel> p9)
        {
            if (p9 == null)
            {
                return null;
            }
            IList<Vote> result = new List<Vote>(p9.Count);
            
            ICollection<Vote> list = result;
            
            int i = 0;
            int len = p9.Count;
            
            while (i < len)
            {
                VoteModel item = p9[i];
                list.Add(item == null ? null : new Vote()
                {
                    RoundId = item.RoundId,
                    Round = null,
                    Estimation = item.Estimation,
                    Duration = item.Duration,
                    Username = item.Username,
                    PlayerId = item.PlayerId,
                    Player = null,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<Vote> funcMain17(IList<VoteModel> p27)
        {
            if (p27 == null)
            {
                return null;
            }
            IList<Vote> result = new List<Vote>(p27.Count);
            
            ICollection<Vote> list = result;
            
            int i = 0;
            int len = p27.Count;
            
            while (i < len)
            {
                VoteModel item = p27[i];
                list.Add(item == null ? null : new Vote()
                {
                    RoundId = item.RoundId,
                    Round = null,
                    Estimation = item.Estimation,
                    Duration = item.Duration,
                    Username = item.Username,
                    PlayerId = item.PlayerId,
                    Player = null,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<VoteModel> funcMain23(IList<Vote> p34)
        {
            if (p34 == null)
            {
                return null;
            }
            IList<VoteModel> result = new List<VoteModel>(p34.Count);
            
            ICollection<VoteModel> list = result;
            
            int i = 0;
            int len = p34.Count;
            
            while (i < len)
            {
                Vote item = p34[i];
                list.Add(item == null ? null : new VoteModel()
                {
                    RoundId = item.RoundId,
                    Round = null,
                    Estimation = item.Estimation,
                    Duration = item.Duration,
                    Username = item.Username,
                    PlayerId = item.PlayerId,
                    Player = null,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<VoteModel> funcMain30(IList<Vote> p48)
        {
            if (p48 == null)
            {
                return null;
            }
            IList<VoteModel> result = new List<VoteModel>(p48.Count);
            
            ICollection<VoteModel> list = result;
            
            int i = 0;
            int len = p48.Count;
            
            while (i < len)
            {
                Vote item = p48[i];
                list.Add(item == null ? null : new VoteModel()
                {
                    RoundId = item.RoundId,
                    Round = null,
                    Estimation = item.Estimation,
                    Duration = item.Duration,
                    Username = item.Username,
                    PlayerId = item.PlayerId,
                    Player = null,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
    }
}