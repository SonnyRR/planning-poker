using System.Collections.Generic;
using PlanningPoker.Persistence.Entities;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.Core.Mapping
{
    public static partial class CardMapper
    {
        public static Card AdaptToCard(this CardModel p1)
        {
            return p1 == null ? null : new Card()
            {
                UnicodeValue = p1.UnicodeValue,
                Value = p1.Value,
                Decks = funcMain1(p1.Decks),
                DeletedOn = p1.DeletedOn,
                IsDeleted = p1.IsDeleted,
                CreatedOn = p1.CreatedOn,
                Id = p1.Id,
                ModifiedOn = p1.ModifiedOn
            };
        }
        public static Card AdaptTo(this CardModel p5, Card p6)
        {
            if (p5 == null)
            {
                return null;
            }
            Card result = p6 ?? new Card();
            
            result.UnicodeValue = p5.UnicodeValue;
            result.Value = p5.Value;
            result.Decks = funcMain4(p5.Decks, result.Decks);
            result.DeletedOn = p5.DeletedOn;
            result.IsDeleted = p5.IsDeleted;
            result.CreatedOn = p5.CreatedOn;
            result.Id = p5.Id;
            result.ModifiedOn = p5.ModifiedOn;
            return result;
            
        }
        public static CardModel AdaptToModel(this Card p11)
        {
            return p11 == null ? null : new CardModel()
            {
                UnicodeValue = p11.UnicodeValue,
                Value = p11.Value,
                Decks = funcMain7(p11.Decks),
                DeletedOn = p11.DeletedOn,
                IsDeleted = p11.IsDeleted,
                CreatedOn = p11.CreatedOn,
                Id = p11.Id,
                ModifiedOn = p11.ModifiedOn
            };
        }
        public static CardModel AdaptTo(this Card p15, CardModel p16)
        {
            if (p15 == null)
            {
                return null;
            }
            CardModel result = p16 ?? new CardModel();
            
            result.UnicodeValue = p15.UnicodeValue;
            result.Value = p15.Value;
            result.Decks = funcMain10(p15.Decks, result.Decks);
            result.DeletedOn = p15.DeletedOn;
            result.IsDeleted = p15.IsDeleted;
            result.CreatedOn = p15.CreatedOn;
            result.Id = p15.Id;
            result.ModifiedOn = p15.ModifiedOn;
            return result;
            
        }
        
        private static List<Deck> funcMain1(List<DeckModel> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<Deck> result = new List<Deck>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                DeckModel item = p2[i];
                result.Add(funcMain2(item));
                i++;
            }
            return result;
            
        }
        
        private static List<Deck> funcMain4(List<DeckModel> p7, List<Deck> p8)
        {
            if (p7 == null)
            {
                return null;
            }
            List<Deck> result = new List<Deck>(p7.Count);
            
            int i = 0;
            int len = p7.Count;
            
            while (i < len)
            {
                DeckModel item = p7[i];
                result.Add(funcMain5(item));
                i++;
            }
            return result;
            
        }
        
        private static List<DeckModel> funcMain7(List<Deck> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            List<DeckModel> result = new List<DeckModel>(p12.Count);
            
            int i = 0;
            int len = p12.Count;
            
            while (i < len)
            {
                Deck item = p12[i];
                result.Add(funcMain8(item));
                i++;
            }
            return result;
            
        }
        
        private static List<DeckModel> funcMain10(List<Deck> p17, List<DeckModel> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            List<DeckModel> result = new List<DeckModel>(p17.Count);
            
            int i = 0;
            int len = p17.Count;
            
            while (i < len)
            {
                Deck item = p17[i];
                result.Add(funcMain11(item));
                i++;
            }
            return result;
            
        }
        
        private static Deck funcMain2(DeckModel p3)
        {
            return p3 == null ? null : new Deck()
            {
                Type = p3.Type,
                Cards = funcMain3(p3.Cards),
                DeletedOn = p3.DeletedOn,
                IsDeleted = p3.IsDeleted,
                CreatedOn = p3.CreatedOn,
                Id = p3.Id,
                ModifiedOn = p3.ModifiedOn
            };
        }
        
        private static Deck funcMain5(DeckModel p9)
        {
            return p9 == null ? null : new Deck()
            {
                Type = p9.Type,
                Cards = funcMain6(p9.Cards),
                DeletedOn = p9.DeletedOn,
                IsDeleted = p9.IsDeleted,
                CreatedOn = p9.CreatedOn,
                Id = p9.Id,
                ModifiedOn = p9.ModifiedOn
            };
        }
        
        private static DeckModel funcMain8(Deck p13)
        {
            return p13 == null ? null : new DeckModel()
            {
                Type = p13.Type,
                Cards = funcMain9(p13.Cards),
                DeletedOn = p13.DeletedOn,
                IsDeleted = p13.IsDeleted,
                CreatedOn = p13.CreatedOn,
                Id = p13.Id,
                ModifiedOn = p13.ModifiedOn
            };
        }
        
        private static DeckModel funcMain11(Deck p19)
        {
            return p19 == null ? null : new DeckModel()
            {
                Type = p19.Type,
                Cards = funcMain12(p19.Cards),
                DeletedOn = p19.DeletedOn,
                IsDeleted = p19.IsDeleted,
                CreatedOn = p19.CreatedOn,
                Id = p19.Id,
                ModifiedOn = p19.ModifiedOn
            };
        }
        
        private static List<Card> funcMain3(List<CardModel> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            List<Card> result = new List<Card>(p4.Count);
            
            int i = 0;
            int len = p4.Count;
            
            while (i < len)
            {
                CardModel item = p4[i];
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
        
        private static List<Card> funcMain6(List<CardModel> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            List<Card> result = new List<Card>(p10.Count);
            
            int i = 0;
            int len = p10.Count;
            
            while (i < len)
            {
                CardModel item = p10[i];
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
        
        private static List<CardModel> funcMain9(List<Card> p14)
        {
            if (p14 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p14.Count);
            
            int i = 0;
            int len = p14.Count;
            
            while (i < len)
            {
                Card item = p14[i];
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
        
        private static List<CardModel> funcMain12(List<Card> p20)
        {
            if (p20 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p20.Count);
            
            int i = 0;
            int len = p20.Count;
            
            while (i < len)
            {
                Card item = p20[i];
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
    }
}