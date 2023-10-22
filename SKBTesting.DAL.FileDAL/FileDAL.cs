using SKBTesting.DAL.Abstract;
using SKBTesting.Entities;
using System.Configuration;

namespace SKBTesting.DAL.FileDAL
{
    public class FileDAL : IItemDAL
    {
        private static List<ItemDTO> Items;
        private static string path;
        static FileDAL()
        {
            path = ConfigurationManager.AppSettings["FilePath"];
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            Items = new List<ItemDTO>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var temp = sr.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    Items.Add(new ItemDTO()
                    {
                        Id = Guid.Parse(temp[0]),
                        Name = temp[1],
                        Priority = int.Parse(temp[2]),
                        Description = temp[3],
                        Status = temp[4]
                    });
                }
            }
        }

        public void Add(ItemDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item is null");
            }
            Items.Add(item);
            Save();
        }

        public void Delete(Guid id)
        {
            ItemDTO item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new ArgumentNullException("Item not found");
            }
            Items.Remove(item);
            Save();
        }

        public ItemDTO Get(Guid id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
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
        public IEnumerable<ItemDTO> GetAll()
        {
            return Items;
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var item in Items)
                {
                    sw.WriteLine($"{item.Id}|{item.Name}|{item.Priority}|{item.Description}|{item.Status}");
                }
            }
        }

        public void Update(ItemDTO newItem)
        {
            ItemDTO item = Items.FirstOrDefault(i => i.Id == newItem.Id);
            if (item == null)
            {
                throw new ArgumentNullException("Item not found");
            }
            if (newItem.Status != "Done" & newItem.Status != "Almost done" & newItem.Status != "In progress")
            {
                throw new ArgumentException("Incorrect value for name");
            }
            item.Name = newItem.Name;
            item.Priority = newItem.Priority;
            item.Description = newItem.Description;
            item.Status = newItem.Status;
            Save();
        }
    }
}