using auto.Domain.Entities;
using auto.Domain.Repositories.Abstract;
using auto.Models;
using Microsoft.EntityFrameworkCore;

namespace auto.Domain.Repositories.EntityFramework
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationContext _db;

        public BrandRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Brand entity)
        {
            try
            {
                Brand b = new Brand()
                {
                    Name = entity.Name,
                    Active = entity.Active
                };
                await _db.Brands.AddAsync(b);
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
                Brand brand = _db.Brands.FirstOrDefault(t => t.Id == id);
                if (brand != null)
                {
                    _db.Entry(brand).State = EntityState.Deleted;
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

        public async Task<List<Brand>> GetAll()
        {
            List<Brand> responce = await _db.Brands
                                            .OrderByDescending(b => b.Active)
                                            .ToListAsync();
            return responce;
        }

        public async Task<Brand> GetById(int id)
        {
            Brand responce = await _db.Brands.FirstOrDefaultAsync(r => r.Id == id);
            return responce;
        }

        public async Task<bool> Update(Brand entity, int id)
        {
            try
            {
                Brand brand = await this.GetById(id);

                if (brand != null)
                {
                    brand.Name = entity.Name;
                    brand.Active = entity.Active;
                    _db.Brands.Update(brand);
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
