using System.Collections.Generic;
using PlanningPoker.Persistence;
using PlanningPoker.Persistence.Entities;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.Core.Mapping
{
    public static partial class VoteMapper
    {
        public static Vote AdaptToVote(this VoteModel p1)
        {
            return p1 == null ? null : new Vote()
            {
                RoundId = p1.RoundId,
                Round = funcMain1(p1.Round),
                Estimation = p1.Estimation,
                Duration = p1.Duration,
                Username = p1.Username,
                PlayerId = p1.PlayerId,
                Player = p1.Player == null ? null : new User()
                {
                    Id = p1.Player.Id,
                    UserName = p1.Player.UserName
                },
                Id = p1.Id
            };
        }
        public static Vote AdaptTo(this VoteModel p4, Vote p5)
        {
            if (p4 == null)
            {
                return null;
            }
            Vote result = p5 ?? new Vote();
            
            result.RoundId = p4.RoundId;
            result.Round = funcMain3(p4.Round, result.Round);
            result.Estimation = p4.Estimation;
            result.Duration = p4.Duration;
            result.Username = p4.Username;
            result.PlayerId = p4.PlayerId;
            result.Player = funcMain5(p4.Player, result.Player);
            result.Id = p4.Id;
            return result;
            
        }
        public static VoteModel AdaptToModel(this Vote p12)
        {
            return p12 == null ? null : new VoteModel()
            {
                RoundId = p12.RoundId,
                Round = funcMain6(p12.Round),
                Estimation = p12.Estimation,
                Duration = p12.Duration,
                Username = p12.Username,
                PlayerId = p12.PlayerId,
                Player = p12.Player == null ? null : new UserModel()
                {
                    Id = p12.Player.Id,
                    UserName = p12.Player.UserName
                },
                Id = p12.Id
            };
        }
        public static VoteModel AdaptTo(this Vote p15, VoteModel p16)
        {
            if (p15 == null)
            {
                return null;
            }
            VoteModel result = p16 ?? new VoteModel();
            
            result.RoundId = p15.RoundId;
            result.Round = funcMain8(p15.Round, result.Round);
            result.Estimation = p15.Estimation;
            result.Duration = p15.Duration;
            result.Username = p15.Username;
            result.PlayerId = p15.PlayerId;
            result.Player = funcMain10(p15.Player, result.Player);
            result.Id = p15.Id;
            return result;
            
        }
        
        private static Round funcMain1(RoundModel p2)
        {
            return p2 == null ? null : new Round()
            {
                Description = p2.Description,
                TableId = p2.TableId,
                FinalEstimation = p2.FinalEstimation,
                StartedOn = p2.StartedOn,
                EndedOn = p2.EndedOn,
                Votes = funcMain2(p2.Votes),
                Id = p2.Id
            };
        }
        
        private static Round funcMain3(RoundModel p6, Round p7)
        {
            if (p6 == null)
            {
                return null;
            }
            Round result = p7 ?? new Round();
            
            result.Description = p6.Description;
            result.TableId = p6.TableId;
            result.FinalEstimation = p6.FinalEstimation;
            result.StartedOn = p6.StartedOn;
            result.EndedOn = p6.EndedOn;
            result.Votes = funcMain4(p6.Votes, result.Votes);
            result.Id = p6.Id;
            return result;
            
        }
        
        private static User funcMain5(UserModel p10, User p11)
        {
            if (p10 == null)
            {
                return null;
            }
            User result = p11 ?? new User();
            
            result.Id = p10.Id;
            result.UserName = p10.UserName;
            return result;
            
        }
        
        private static RoundModel funcMain6(Round p13)
        {
            return p13 == null ? null : new RoundModel()
            {
                Description = p13.Description,
                TableId = p13.TableId,
                FinalEstimation = p13.FinalEstimation,
                StartedOn = p13.StartedOn,
                EndedOn = p13.EndedOn,
                Elapsed = p13.Elapsed,
                Votes = funcMain7(p13.Votes),
                Id = p13.Id
            };
        }
        
        private static RoundModel funcMain8(Round p17, RoundModel p18)
        {
            if (p17 == null)
            {
                return null;
            }
            RoundModel result = p18 ?? new RoundModel();
            
            result.Description = p17.Description;
            result.TableId = p17.TableId;
            result.FinalEstimation = p17.FinalEstimation;
            result.StartedOn = p17.StartedOn;
            result.EndedOn = p17.EndedOn;
            result.Elapsed = p17.Elapsed;
            result.Votes = funcMain9(p17.Votes, result.Votes);
            result.Id = p17.Id;
            return result;
            
        }
        
        private static UserModel funcMain10(User p21, UserModel p22)
        {
            if (p21 == null)
            {
                return null;
            }
            UserModel result = p22 ?? new UserModel();
            
            result.Id = p21.Id;
            result.UserName = p21.UserName;
            return result;
            
        }
        
        private static IList<Vote> funcMain2(IList<VoteModel> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            IList<Vote> result = new List<Vote>(p3.Count);
            
            ICollection<Vote> list = result;
            
            int i = 0;
            int len = p3.Count;
            
            while (i < len)
            {
                VoteModel item = p3[i];
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
        
        private static IList<Vote> funcMain4(IList<VoteModel> p8, IList<Vote> p9)
        {
            if (p8 == null)
            {
                return null;
            }
            IList<Vote> result = new List<Vote>(p8.Count);
            
            ICollection<Vote> list = result;
            
            int i = 0;
            int len = p8.Count;
            
            while (i < len)
            {
                VoteModel item = p8[i];
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
        
        private static IList<VoteModel> funcMain7(IList<Vote> p14)
        {
            if (p14 == null)
            {
                return null;
            }
            IList<VoteModel> result = new List<VoteModel>(p14.Count);
            
            ICollection<VoteModel> list = result;
            
            int i = 0;
            int len = p14.Count;
            
            while (i < len)
            {
                Vote item = p14[i];
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
        
        private static IList<VoteModel> funcMain9(IList<Vote> p19, IList<VoteModel> p20)
        {
            if (p19 == null)
            {
                return null;
            }
            IList<VoteModel> result = new List<VoteModel>(p19.Count);
            
            ICollection<VoteModel> list = result;
            
            int i = 0;
            int len = p19.Count;
            
            while (i < len)
            {
                Vote item = p19[i];
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