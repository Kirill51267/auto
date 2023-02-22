using auto.Domain.Entities;
using auto.Models;
using System.Diagnostics;

namespace auto.Domain.Repositories.Abstract
{
    public interface IBrandRepository
    {
        Task<bool> Create(Brand entity);

        Task<bool> Update(Brand entity, int id);

        Task<bool> Delete(int id);

        Task<Brand> GetById(int id);

        Task<List<Brand>> GetAll();
    }
}
