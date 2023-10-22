using SKBTesting.Entities;

namespace SKBTesting.DAL.Abstract
{
    public interface IItemDAL
    {
        ItemDTO Get(Guid id);
        IEnumerable<ItemDTO> GetAll();
        void Update(ItemDTO newItem);
        void Delete(Guid id);
        void Add(ItemDTO item);
    }
}