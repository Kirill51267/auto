using auto.Domain.Entities;
using auto.Models;

namespace auto.Domain.Repositories.Abstract
{
    public interface IModelRepository
    {
        Task<bool> Create(Model entity, int brandId);

        Task<bool> Update(Model entity, int id);

        Task<bool> Delete(int id);

        Task<Model> GetById(int id);

        Task<List<Model>> GetAllByBrandId(int BrandId);

        Task<List<Model>> GetAll();

    }
}
