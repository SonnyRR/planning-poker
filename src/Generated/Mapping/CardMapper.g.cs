using PlanningPoker.Generated.Models;
using PlanningPoker.Persistence.Entities;

namespace PlanningPoker.Generated.Mapping
{
    public static partial class CardMapper
    {
        public static Card AdaptToCard(this CardModel p1)
        {
            return p1 == null ? null : new Card()
            {
                UnicodeValue = p1.UnicodeValue,
                Value = p1.Value,
                Id = p1.Id
            };
        }
        public static Card AdaptTo(this CardModel p2, Card p3)
        {
            if (p2 == null)
            {
                return null;
            }
            Card result = p3 ?? new Card();
            
            result.UnicodeValue = p2.UnicodeValue;
            result.Value = p2.Value;
            result.Id = p2.Id;
            return result;
            
        }
        public static CardModel AdaptToModel(this Card p4)
        {
            return p4 == null ? null : new CardModel()
            {
                UnicodeValue = p4.UnicodeValue,
                Value = p4.Value,
                Id = p4.Id
            };
        }
        public static CardModel AdaptTo(this Card p5, CardModel p6)
        {
            if (p5 == null)
            {
                return null;
            }
            CardModel result = p6 ?? new CardModel();
            
            result.UnicodeValue = p5.UnicodeValue;
            result.Value = p5.Value;
            result.Id = p5.Id;
            return result;
            
        }
    }
}