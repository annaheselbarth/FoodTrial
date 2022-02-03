﻿using FoodTrial.Data;
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
    }
}
