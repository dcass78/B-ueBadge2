using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailRanking.Data;
using TrailRanking.Models;

namespace TrailRanking.Services
{
    public class EquipmentService
    {
        private readonly Guid _userId;

        public EquipmentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateEquipment(EquipmentCreate model)
        {
            var entity =
                new Equipment()
                {
                    OwnerId = _userId,
                    EquipmentName = model.EquipmentName,
                    EquipmentUse = model.EquipmentUse,
                    CreatedUtc = DateTimeOffset.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Equipment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<EquipmentListItem> GetEquipment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Equipment
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                              e => new EquipmentListItem
                              {
                                    EquipmentId = e.EquipmentId,
                                    EquipmentName = e.EquipmentName,
                                    CreatedUtc = e.CreatedUtc
                              }
                        );
                return query.ToArray();
            }
        }
        public EquipmentDetail GetEquipmentById(int equipmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx
                         .Equipment
                         .Single(e => e.EquipmentId == equipmentId && e.OwnerId == _userId);
                return
                    new EquipmentDetail
                    {
                        EquipmentId = entity.EquipmentId,
                        EquipmentName = entity.EquipmentName,
                        EquipmentUse = entity.EquipmentUse,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateEquipment(EquipmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                            ctx
                                .Equipment
                                .Single(e => e.EquipmentId == model.EquipmentId && e.OwnerId == _userId);
                entity.EquipmentName = model.EquipmentName;
                entity.EquipmentUse = model.EquipmentUse;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteEquipment(int equipmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Equipment
                        .Single(e => e.EquipmentId == equipmentId && e.OwnerId == _userId );
                ctx.Equipment.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
