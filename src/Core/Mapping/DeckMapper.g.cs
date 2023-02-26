using System.Collections.Generic;
using PlanningPoker.Persistence.Entities;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.Core.Mapping
{
    public static partial class DeckMapper
    {
        public static Deck AdaptToDeck(this DeckModel p1)
        {
            return p1 == null ? null : new Deck()
            {
                Type = p1.Type,
                Cards = funcMain1(p1.Cards),
                DeletedOn = p1.DeletedOn,
                IsDeleted = p1.IsDeleted,
                CreatedOn = p1.CreatedOn,
                Id = p1.Id,
                ModifiedOn = p1.ModifiedOn
            };
        }
        public static Deck AdaptTo(this DeckModel p5, Deck p6)
        {
            if (p5 == null)
            {
                return null;
            }
            Deck result = p6 ?? new Deck();
            
            result.Type = p5.Type;
            result.Cards = funcMain4(p5.Cards, result.Cards);
            result.DeletedOn = p5.DeletedOn;
            result.IsDeleted = p5.IsDeleted;
            result.CreatedOn = p5.CreatedOn;
            result.Id = p5.Id;
            result.ModifiedOn = p5.ModifiedOn;
            return result;
            
        }
        public static DeckModel AdaptToModel(this Deck p11)
        {
            return p11 == null ? null : new DeckModel()
            {
                Type = p11.Type,
                Cards = funcMain7(p11.Cards),
                DeletedOn = p11.DeletedOn,
                IsDeleted = p11.IsDeleted,
                CreatedOn = p11.CreatedOn,
                Id = p11.Id,
                ModifiedOn = p11.ModifiedOn
            };
        }
        public static DeckModel AdaptTo(this Deck p15, DeckModel p16)
        {
            if (p15 == null)
            {
                return null;
            }
            DeckModel result = p16 ?? new DeckModel();
            
            result.Type = p15.Type;
            result.Cards = funcMain10(p15.Cards, result.Cards);
            result.DeletedOn = p15.DeletedOn;
            result.IsDeleted = p15.IsDeleted;
            result.CreatedOn = p15.CreatedOn;
            result.Id = p15.Id;
            result.ModifiedOn = p15.ModifiedOn;
            return result;
            
        }
        
        private static List<Card> funcMain1(List<CardModel> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<Card> result = new List<Card>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                CardModel item = p2[i];
                result.Add(funcMain2(item));
                i++;
            }
            return result;
            
        }
        
        private static List<Card> funcMain4(List<CardModel> p7, List<Card> p8)
        {
            if (p7 == null)
            {
                return null;
            }
            List<Card> result = new List<Card>(p7.Count);
            
            int i = 0;
            int len = p7.Count;
            
            while (i < len)
            {
                CardModel item = p7[i];
                result.Add(funcMain5(item));
                i++;
            }
            return result;
            
        }
        
        private static List<CardModel> funcMain7(List<Card> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p12.Count);
            
            int i = 0;
            int len = p12.Count;
            
            while (i < len)
            {
                Card item = p12[i];
                result.Add(funcMain8(item));
                i++;
            }
            return result;
            
        }
        
        private static List<CardModel> funcMain10(List<Card> p17, List<CardModel> p18)
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
                result.Add(funcMain11(item));
                i++;
            }
            return result;
            
        }
        
        private static Card funcMain2(CardModel p3)
        {
            return p3 == null ? null : new Card()
            {
                UnicodeValue = p3.UnicodeValue,
                Value = p3.Value,
                Decks = funcMain3(p3.Decks),
                DeletedOn = p3.DeletedOn,
                IsDeleted = p3.IsDeleted,
                CreatedOn = p3.CreatedOn,
                Id = p3.Id,
                ModifiedOn = p3.ModifiedOn
            };
        }
        
        private static Card funcMain5(CardModel p9)
        {
            return p9 == null ? null : new Card()
            {
                UnicodeValue = p9.UnicodeValue,
                Value = p9.Value,
                Decks = funcMain6(p9.Decks),
                DeletedOn = p9.DeletedOn,
                IsDeleted = p9.IsDeleted,
                CreatedOn = p9.CreatedOn,
                Id = p9.Id,
                ModifiedOn = p9.ModifiedOn
            };
        }
        
        private static CardModel funcMain8(Card p13)
        {
            return p13 == null ? null : new CardModel()
            {
                UnicodeValue = p13.UnicodeValue,
                Value = p13.Value,
                Decks = funcMain9(p13.Decks),
                DeletedOn = p13.DeletedOn,
                IsDeleted = p13.IsDeleted,
                CreatedOn = p13.CreatedOn,
                Id = p13.Id,
                ModifiedOn = p13.ModifiedOn
            };
        }
        
        private static CardModel funcMain11(Card p19)
        {
            return p19 == null ? null : new CardModel()
            {
                UnicodeValue = p19.UnicodeValue,
                Value = p19.Value,
                Decks = funcMain12(p19.Decks),
                DeletedOn = p19.DeletedOn,
                IsDeleted = p19.IsDeleted,
                CreatedOn = p19.CreatedOn,
                Id = p19.Id,
                ModifiedOn = p19.ModifiedOn
            };
        }
        
        private static List<Deck> funcMain3(List<DeckModel> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            List<Deck> result = new List<Deck>(p4.Count);
            
            int i = 0;
            int len = p4.Count;
            
            while (i < len)
            {
                DeckModel item = p4[i];
                result.Add(item == null ? null : new Deck()
                {
                    Type = item.Type,
                    Cards = null,
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
        
        private static List<Deck> funcMain6(List<DeckModel> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            List<Deck> result = new List<Deck>(p10.Count);
            
            int i = 0;
            int len = p10.Count;
            
            while (i < len)
            {
                DeckModel item = p10[i];
                result.Add(item == null ? null : new Deck()
                {
                    Type = item.Type,
                    Cards = null,
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
        
        private static List<DeckModel> funcMain9(List<Deck> p14)
        {
            if (p14 == null)
            {
                return null;
            }
            List<DeckModel> result = new List<DeckModel>(p14.Count);
            
            int i = 0;
            int len = p14.Count;
            
            while (i < len)
            {
                Deck item = p14[i];
                result.Add(item == null ? null : new DeckModel()
                {
                    Type = item.Type,
                    Cards = null,
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
        
        private static List<DeckModel> funcMain12(List<Deck> p20)
        {
            if (p20 == null)
            {
                return null;
            }
            List<DeckModel> result = new List<DeckModel>(p20.Count);
            
            int i = 0;
            int len = p20.Count;
            
            while (i < len)
            {
                Deck item = p20[i];
                result.Add(item == null ? null : new DeckModel()
                {
                    Type = item.Type,
                    Cards = null,
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
