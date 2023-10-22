using SKBTesting.BLL.Abstract;
using SKBTesting.DAL.Abstract;
using SKBTesting.Entities;

namespace SKBTesting.BLL.BaseLogic
{
    public class BaseLogic: ILogic
    {
        IItemDAL repo;
        public BaseLogic(IItemDAL DAL)
        {
            if (DAL == null)
            {
                throw new ArgumentNullException("DAL component is null");
            }
            repo = DAL;
        }
        public void Add(ItemDTO item)
        {
            repo.Add(item);
        }

        public void Delete(Guid id)
        {
            repo.Delete(id);
        }

        public ItemDTO Get(Guid id)
        {
            return repo.Get(id);
        }
        public ItemDTO GetByName(string name)
        {
            return repo.GetAll().FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<ItemDTO> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public IEnumerable<ItemDTO> GetOrdered()
        {
            return repo.GetAll().OrderByDescending(x => x.Priority).ToList();
        }

        public void Update(ItemDTO newItem)
        {
            repo.Update(newItem);
        }
    }
}