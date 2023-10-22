using SKBTesting.DAL.Abstract;
using SKBTesting.Entities;

namespace SKBTesting.DAL.MSSQLDAL
{
    public class MSSQLDAL: IItemDAL
    {
        public void Add(ItemDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item is null");
            }
            using (var db = new AppContext())
            {
                db.Items.Add(item);
                db.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var db = new AppContext())
            {
                var item = db.Items.FirstOrDefault(i => i.Id == id);
                if (item == null)
                {
                    throw new ArgumentNullException("Item not found");
                }
                db.Items.Remove(item);
                db.SaveChanges();
            }
        }

        public ItemDTO Get(Guid id)
        {
            using (var db = new AppContext())
            {
                var item = db.Items.FirstOrDefault(i => i.Id == id);
                if (item == null)
                {
                    throw new ArgumentNullException("Item not found");
                }
                return new ItemDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Priority = item.Priority,
                    Description = item.Description,
                    Status = item.Status
                };
            }
        }

        public IEnumerable<ItemDTO> GetAll()
        {
            using (var db = new AppContext())
            {
                var items = db.Items.ToList();
                return items;
            }
        }

        public void Update(ItemDTO newItem)
        {
            using (var db = new AppContext())
            {
                ItemDTO item = db.Items.FirstOrDefault(i => i.Id == newItem.Id);
                if (item == null)
                {
                    throw new ArgumentNullException("Item not found");
                }
                item.Name = newItem.Name;
                item.Priority = newItem.Priority;
                item.Description = newItem.Description;
                item.Status = newItem.Status;
                db.SaveChanges();
            }
        }
    }
}