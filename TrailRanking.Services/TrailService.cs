using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailRanking.Data;
using TrailRanking.Models;

namespace TrailRanking.Services
{
    public class TrailService
    {
        private readonly Guid _userId;

        public TrailService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTrail(TrailCreate model)
        {
            var entity =
                new Trail()
                {
                    TrailName = model.TrailName,
                    Description = model.Description,
                    EquipmentId = model.EquipmentId,
                    TrailRank = model.TrailRank,
                    Location = model.Location,
                    CreatedUtc = DateTimeOffset.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trails.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TrailListItem> GetTrails()
        {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx.Trails
                            .Select(
                                e =>
                                    new TrailListItem
                                    {
                                        TrailId = e.TrailId,
                                        TrailName = e.TrailName,
                                        CreatedUtc = e.CreatedUtc
                                    }
                            );
                    return query.ToArray();
                }
        }
        public TrailDetail GetTrailById(int trailId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx
                         .Trails
                         .Single(e => e.TrailId == trailId);
                return
                    new TrailDetail
                    {
                        TrailId = entity.TrailId,
                        TrailName = entity.TrailName,
                        Description = entity.Description,
                        EquipmentId = entity.EquipmentId,
                        TrailRank = entity.TrailRank,
                        Location = entity.Location,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateTrail(TrailEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                            ctx
                                .Trails
                                .Single(e => e.TrailId == model.TrailId);
                entity.TrailName = model.TrailName;
                entity.Description = model.Description;
                entity.EquipmentId = model.EquipmentId;
                entity.TrailRank = model.TrailRank;
                entity.Location = model.Location;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTrail(int trailId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trails
                        .Single(e => e.TrailId == trailId);
                ctx.Trails.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
