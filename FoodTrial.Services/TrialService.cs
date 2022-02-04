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
                    
                    Comment = trial.Comment,
                    DateTime = trial.DateTime,
                    NumberOfDays = trial.NumberOfDays,
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
                                    Symptoms = t.Symptoms,
                                    ReactionType = t.ReactionType,
                                    IsSafe = t.IsSafe
                                });
                return query.ToArray();

            }
        }
    }
}
