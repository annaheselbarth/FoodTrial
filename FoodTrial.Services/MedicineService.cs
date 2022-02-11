using FoodTrial.Data;
using FoodTrial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrial.Services
{
    public class MedicineService
    {
        private readonly Guid _userId;

        public MedicineService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMedicine(MedicineCreate medicine)
        {
            var entity =
                new Medicine()
                {
                    MedicineId = medicine.MedicineId,
                    TrialId = medicine.TrialId,
                    Name = medicine.Name,
                    Dose = medicine.Dose,
                    Frequency = medicine.Frequency,
                    Comment = medicine.Comment
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Medicines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MedicineListItem> GetMedicines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Medicines
                        .Select(
                            m =>
                                new MedicineListItem
                                {
                                    MedicineId = m.MedicineId,
                                    Name = m.Name,
                                    Dose = m.Dose,
                                    Frequency = m.Frequency,
                                    Comment = m.Comment
                                });
                return query.ToArray();

            }
        }

        public MedicineDetail GetMedicineById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Medicines
                        .Single(m => m.MedicineId == id);
                return
                    new MedicineDetail
                    {
                        MedicineId = entity.MedicineId,
                        TrialId = entity.TrialId,
                        Name = entity.Name,
                        Dose = entity.Dose,
                        Frequency = entity.Frequency,
                        Comment = entity.Comment
                    };
            }
        }

        public bool UpdateMedicine(MedicineEdit medicine)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                    ctx
                         .Medicines
                         .Single(m => m.MedicineId == medicine.MedicineId);
                    entity.MedicineId = medicine.MedicineId;
                    entity.TrialId = medicine.TrialId;
                    entity.Name = medicine.Name;
                    entity.Dose = medicine.Dose;
                    entity.Frequency = medicine.Frequency;
                    entity.Comment = medicine.Comment;

                    return ctx.SaveChanges() == 1;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMedicine(int medicineId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Medicines
                        .Single(m => m.MedicineId == medicineId);
                ctx.Medicines.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
