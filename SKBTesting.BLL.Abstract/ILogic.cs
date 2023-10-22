using SKBTesting.Entities;

namespace SKBTesting.BLL.Abstract
{
    public interface ILogic
    {
        ItemDTO Get(Guid id);
        ItemDTO GetByName(string name);
        IEnumerable<ItemDTO> GetAll();
        IEnumerable<ItemDTO> GetOrdered();
        void Update(ItemDTO newItem);
        void Delete(Guid id);
        void Add(ItemDTO item);
    }
}