using FoodTrial.Data;
using FoodTrial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Services
{
    public class FoodService
    {
        private readonly Guid _userId;

        public FoodService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFood(FoodCreate food)
        {
            var entity =
                new Food()
                {
                    Name = food.Name,
                    AllergenGroup = food.AllergenGroup,
                    FoodGroup = food.FoodGroup,
                    Description = food.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Foods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FoodListItem> GetFoods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Foods
                        .Select(
                            f =>
                                new FoodListItem
                                {
                                    FoodId = f.FoodId,
                                    Name = f.Name,
                                    AllergenGroup = f.AllergenGroup,
                                    FoodGroup = f.FoodGroup,
                                    Description = f.Description
                                });
                return query.ToArray();

            }
        }

        public FoodDetail GetFoodById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Foods
                        .Single(f => f.FoodId == id);
                return
                    new FoodDetail
                    {
                        FoodId = entity.FoodId,
                        Name = entity.Name,
                        AllergenGroup = entity.AllergenGroup,
                        FoodGroup = entity.FoodGroup,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateFood(FoodEdit food)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Foods
                            .Single(f => f.FoodId == food.FoodId);
                    entity.FoodId = food.FoodId;
                    entity.Name = food.Name;
                    entity.AllergenGroup = food.AllergenGroup;
                    entity.FoodGroup = food.FoodGroup;
                    entity.Description = food.Description;

                    return ctx.SaveChanges() == 1;

                }
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteFood(int foodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Foods
                        .Single(f => f.FoodId == foodId);
                ctx.Foods.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
