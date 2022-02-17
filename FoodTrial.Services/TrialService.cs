using FoodTrial.Data;
using FoodTrial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Services
{
    public class TrialService
    {
        private readonly Guid _userId;

        public TrialService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTrial(TrialCreate trial)
        {
            var entity =
                new Trial()
                {
                    FoodId = trial.FoodId,
                    Comment = trial.Comment,
                    DateTime = trial.DateTime,
                    NumberOfDays = trial.NumberOfDays,
                    Symptoms = trial.Symptoms,
                    MedicalIntervention = trial.MedicalIntervention,
                    ReactionType = trial.ReactionType,
                    IsSafe = trial.IsSafe
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trials.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TrialListItem> GetTrials()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Trials
                        .Select(
                            t =>
                                new TrialListItem
                                {
                                    TrialId = t.TrialId,
                                    FoodId = t.FoodId,
                                    Comment = t.Comment,
                                    DateTime = t.DateTime,
                                    NumberOfDays = t.NumberOfDays,
                                    MedicalIntervention = t.MedicalIntervention,
                                    //Symptoms = t.Symptoms,
                                    ReactionType = t.ReactionType,
                                    IsSafe = t.IsSafe
                                });
                return query.ToArray();

            }
        }

        public TrialDetail GetTrialById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trials
                        .Single(t => t.TrialId == id);
                return
                    new TrialDetail
                    {
                        TrialId = entity.TrialId,
                        FoodId = entity.FoodId,
                        Comment = entity.Comment,
                        DateTime = entity.DateTime,
                        NumberOfDays = entity.NumberOfDays,
                        MedicalIntervention = entity.MedicalIntervention,
                        //Symptoms = entity.Symptoms,
                        ReactionType = entity.ReactionType,
                        IsSafe = entity.IsSafe
                    };
            }
        }

        

        public bool UpdateTrial(TrialEdit trial)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Trials
                            .Single(t => t.TrialId == trial.TrialId);
                    entity.TrialId = trial.TrialId;
                    entity.FoodId = trial.FoodId;
                    entity.Comment = trial.Comment;
                    entity.DateTime = trial.DateTime;
                    entity.NumberOfDays = trial.NumberOfDays;
                    entity.MedicalIntervention = trial.MedicalIntervention;
                    //entity.Symptoms = trial.Symptoms;
                    entity.ReactionType = trial.ReactionType;
                    entity.IsSafe = trial.IsSafe;

                    return ctx.SaveChanges() == 1;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTrial(int trialId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trials
                        .Single(t => t.TrialId == trialId);
                ctx.Trials.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
