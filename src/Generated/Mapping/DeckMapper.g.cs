using System.Collections.Generic;
using PlanningPoker.Generated.Models;
using PlanningPoker.Persistence.Entities;

namespace PlanningPoker.Generated.Mapping
{
    public static partial class DeckMapper
    {
        public static Deck AdaptToDeck(this DeckModel p1)
        {
            return p1 == null ? null : new Deck()
            {
                Type = p1.Type,
                Cards = funcMain1(p1.Cards),
                Id = p1.Id
            };
        }
        public static Deck AdaptTo(this DeckModel p3, Deck p4)
        {
            if (p3 == null)
            {
                return null;
            }
            Deck result = p4 ?? new Deck();
            
            result.Type = p3.Type;
            result.Cards = funcMain2(p3.Cards, result.Cards);
            result.Id = p3.Id;
            return result;
            
        }
        public static DeckModel AdaptToModel(this Deck p7)
        {
            return p7 == null ? null : new DeckModel()
            {
                Type = p7.Type,
                Cards = funcMain3(p7.Cards),
                Id = p7.Id
            };
        }
        public static DeckModel AdaptTo(this Deck p9, DeckModel p10)
        {
            if (p9 == null)
            {
                return null;
            }
            DeckModel result = p10 ?? new DeckModel();
            
            result.Type = p9.Type;
            result.Cards = funcMain4(p9.Cards, result.Cards);
            result.Id = p9.Id;
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
        
        private static List<Card> funcMain2(List<CardModel> p5, List<Card> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            List<Card> result = new List<Card>(p5.Count);
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                CardModel item = p5[i];
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
        
        private static List<CardModel> funcMain3(List<Card> p8)
        {
            if (p8 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p8.Count);
            
            int i = 0;
            int len = p8.Count;
            
            while (i < len)
            {
                Card item = p8[i];
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
        
        private static List<CardModel> funcMain4(List<Card> p11, List<CardModel> p12)
        {
            if (p11 == null)
            {
                return null;
            }
            List<CardModel> result = new List<CardModel>(p11.Count);
            
            int i = 0;
            int len = p11.Count;
            
            while (i < len)
            {
                Card item = p11[i];
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