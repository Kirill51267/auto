using auto.Domain.Entities;
using auto.Domain.Repositories.Abstract;
using auto.Models;
using Microsoft.EntityFrameworkCore;

namespace auto.Domain.Repositories.EntityFramework
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationContext _db;

        public ModelRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Model entity, int brandId)
        {
            try
            {
                Model m = new Model
                {
                    Name = entity.Name,
                    Active = entity.Active,
                    Brand = await _db.Brands.FirstOrDefaultAsync(b => b.Id == brandId)
                };
                await _db.Models.AddAsync(m);
                await _db.SaveChangesAsync();

                return true;

            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Model model = await _db.Models.FirstOrDefaultAsync(m => m.Id == id);
                if (model != null)
                {
                    _db.Entry(model).State = EntityState.Deleted;
                    await _db.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Model>> GetAllByBrandId(int brandId)
        {
            Brand brand = _db.Brands.FirstOrDefault(b => b.Id == brandId);
            List<Model> responce = await _db.Models.Where(m => m.Brand == brand)
                                                         .OrderByDescending(m => m.Active)
                                                         .ToListAsync();
            return responce;
        }

        public async Task<List<Model>> GetAll()
        {
            List<Model> responce = await _db.Models.OrderBy(m => m.Brand)
                                                   .OrderByDescending(m => m.Active)
                                                   .ToListAsync();
            return responce;
        }

        public async Task<Model> GetById(int id)
        {
            Model responce = await _db.Models.FirstOrDefaultAsync(m => m.Id == id);
            return responce;
        }

        public async Task<bool> Update(Model entity, int id)
        {
            try
            {
                Model model = await this.GetById(id);

                if (model != null)
                {
                    model.Name = entity.Name;
                    model.Active = entity.Active;
                    _db.Models.Update(model);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
