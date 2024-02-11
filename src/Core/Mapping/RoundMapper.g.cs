using System.Collections.Generic;
using PlanningPoker.Persistence;
using PlanningPoker.Persistence.Entities;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.Core.Mapping
{
    public static partial class RoundMapper
    {
        public static Round AdaptToRound(this RoundModel p1)
        {
            return p1 == null ? null : new Round()
            {
                Description = p1.Description,
                TableId = p1.TableId,
                FinalEstimation = p1.FinalEstimation,
                StartedOn = p1.StartedOn,
                EndedOn = p1.EndedOn,
                Votes = funcMain1(p1.Votes),
                Id = p1.Id
            };
        }
        public static Round AdaptTo(this RoundModel p3, Round p4)
        {
            if (p3 == null)
            {
                return null;
            }
            Round result = p4 ?? new Round();
            
            result.Description = p3.Description;
            result.TableId = p3.TableId;
            result.FinalEstimation = p3.FinalEstimation;
            result.StartedOn = p3.StartedOn;
            result.EndedOn = p3.EndedOn;
            result.Votes = funcMain2(p3.Votes, result.Votes);
            result.Id = p3.Id;
            return result;
            
        }
        public static RoundModel AdaptToModel(this Round p7)
        {
            return p7 == null ? null : new RoundModel()
            {
                Description = p7.Description,
                TableId = p7.TableId,
                FinalEstimation = p7.FinalEstimation,
                StartedOn = p7.StartedOn,
                EndedOn = p7.EndedOn,
                Elapsed = p7.Elapsed,
                Votes = funcMain3(p7.Votes),
                Id = p7.Id
            };
        }
        public static RoundModel AdaptTo(this Round p9, RoundModel p10)
        {
            if (p9 == null)
            {
                return null;
            }
            RoundModel result = p10 ?? new RoundModel();
            
            result.Description = p9.Description;
            result.TableId = p9.TableId;
            result.FinalEstimation = p9.FinalEstimation;
            result.StartedOn = p9.StartedOn;
            result.EndedOn = p9.EndedOn;
            result.Elapsed = p9.Elapsed;
            result.Votes = funcMain4(p9.Votes, result.Votes);
            result.Id = p9.Id;
            return result;
            
        }
        
        private static IList<Vote> funcMain1(IList<VoteModel> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            IList<Vote> result = new List<Vote>(p2.Count);
            
            ICollection<Vote> list = result;
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                VoteModel item = p2[i];
                list.Add(item == null ? null : new Vote()
                {
                    RoundId = item.RoundId,
                    Round = item.Round == null ? null : new Round()
                    {
                        Description = item.Round.Description,
                        TableId = item.Round.TableId,
                        FinalEstimation = item.Round.FinalEstimation,
                        StartedOn = item.Round.StartedOn,
                        EndedOn = item.Round.EndedOn,
                        Votes = null,
                        Id = item.Round.Id
                    },
                    Estimation = item.Estimation,
                    Duration = item.Duration,
                    Username = item.Username,
                    PlayerId = item.PlayerId,
                    Player = item.Player == null ? null : new User()
                    {
                        Id = item.Player.Id,
                        UserName = item.Player.UserName
                    },
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<Vote> funcMain2(IList<VoteModel> p5, IList<Vote> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            IList<Vote> result = new List<Vote>(p5.Count);
            
            ICollection<Vote> list = result;
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                VoteModel item = p5[i];
                list.Add(item == null ? null : new Vote()
                {
                    RoundId = item.RoundId,
                    Round = item.Round == null ? null : new Round()
                    {
                        Description = item.Round.Description,
                        TableId = item.Round.TableId,
                        FinalEstimation = item.Round.FinalEstimation,
                        StartedOn = item.Round.StartedOn,
                        EndedOn = item.Round.EndedOn,
                        Votes = null,
                        Id = item.Round.Id
                    },
                    Estimation = item.Estimation,
                    Duration = item.Duration,
                    Username = item.Username,
                    PlayerId = item.PlayerId,
                    Player = item.Player == null ? null : new User()
                    {
                        Id = item.Player.Id,
                        UserName = item.Player.UserName
                    },
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<VoteModel> funcMain3(IList<Vote> p8)
        {
            if (p8 == null)
            {
                return null;
            }
            IList<VoteModel> result = new List<VoteModel>(p8.Count);
            
            ICollection<VoteModel> list = result;
            
            int i = 0;
            int len = p8.Count;
            
            while (i < len)
            {
                Vote item = p8[i];
                list.Add(item == null ? null : new VoteModel()
                {
                    RoundId = item.RoundId,
                    Round = item.Round == null ? null : new RoundModel()
                    {
                        Description = item.Round.Description,
                        TableId = item.Round.TableId,
                        FinalEstimation = item.Round.FinalEstimation,
                        StartedOn = item.Round.StartedOn,
                        EndedOn = item.Round.EndedOn,
                        Elapsed = item.Round.Elapsed,
                        Votes = null,
                        Id = item.Round.Id
                    },
                    Estimation = item.Estimation,
                    Duration = item.Duration,
                    Username = item.Username,
                    PlayerId = item.PlayerId,
                    Player = item.Player == null ? null : new UserModel()
                    {
                        Id = item.Player.Id,
                        UserName = item.Player.UserName
                    },
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static IList<VoteModel> funcMain4(IList<Vote> p11, IList<VoteModel> p12)
        {
            if (p11 == null)
            {
                return null;
            }
            IList<VoteModel> result = new List<VoteModel>(p11.Count);
            
            ICollection<VoteModel> list = result;
            
            int i = 0;
            int len = p11.Count;
            
            while (i < len)
            {
                Vote item = p11[i];
                list.Add(item == null ? null : new VoteModel()
                {
                    RoundId = item.RoundId,
                    Round = item.Round == null ? null : new RoundModel()
                    {
                        Description = item.Round.Description,
                        TableId = item.Round.TableId,
                        FinalEstimation = item.Round.FinalEstimation,
                        StartedOn = item.Round.StartedOn,
                        EndedOn = item.Round.EndedOn,
                        Elapsed = item.Round.Elapsed,
                        Votes = null,
                        Id = item.Round.Id
                    },
                    Estimation = item.Estimation,
                    Duration = item.Duration,
                    Username = item.Username,
                    PlayerId = item.PlayerId,
                    Player = item.Player == null ? null : new UserModel()
                    {
                        Id = item.Player.Id,
                        UserName = item.Player.UserName
                    },
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
    }
}