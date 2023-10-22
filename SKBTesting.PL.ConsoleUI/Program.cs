using NLog;
using SKBTesting.BLL.Abstract;
using SKBTesting.DI.Provaiders;
using SKBTesting.Entities;
using SKBTesting.PL.ConsoleUI.Models;

namespace SKBTesting.PL.ConsoleUI
{
    internal class Program
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        static ILogic logic = Provaider.Logic;
        static void Main(string[] args)
        {
            try
            {
                int number = 0;
                while (number != 8)
                {
                    Menu();
                    int.TryParse(Console.ReadLine(), out number);
                    switch (number)
                    {
                        case 1:
                            {
                                logic.Add(Add());
                                logger.Info("Add");
                            }
                            break;
                        case 2:
                            {
                                Delete();
                                logger.Info("Delete");
                            }
                            break;
                        case 3:
                            {
                                Get();
                                logger.Info("Get");
                            }
                            break;
                        case 4:
                            {
                                GetByName();
                                logger.Info("GetByName");
                            }
                            break;
                        case 5:
                            {
                                Output(logic.GetAll());
                                logger.Info("GetAll");
                            }
                            break;
                        case 6:
                            {
                                Output(logic.GetOrdered());
                                logger.Info("GetOrdered");
                            }
                            break;
                        case 7:
                            {
                                logic.Update(Update());
                                logger.Info("Update");
                            }
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("Press any key to return");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception ex)

            {
                logger.Error(ex);
                Console.WriteLine(ex.Message);
            }
        }
        private static void Get()
        {
            var allItems = logic.GetAll();
            int itemsCount = allItems.Count();
            Output(allItems);
            Console.WriteLine("Enter number of item, you want to get");
            int number = 0;
            int.TryParse(Console.ReadLine(), out number);
            if (number > 0 && number <= itemsCount)
            {
                number--;
                var item = (ItemVM)allItems.Skip(number).First();
                Output(item);
            }
        }
        private static void GetByName() 
        {
            Console.WriteLine("Enter the name of item, you want to get");
            var name = Console.ReadLine();
            var item = (ItemVM)logic.GetByName(name);
            if (item == null) 
            {
                throw new ArgumentNullException("Item not found");
            }
            Output(item);
        }

        private static ItemDTO Update()
        {
            var allItems = logic.GetAll();
            int itemsCount = allItems.Count();
            Output(allItems);
            Console.WriteLine("Enter number of item you want to update");
            int number = 0;
            int.TryParse(Console.ReadLine(), out number);
            if (number > 0 && number <= itemsCount)
            {
                number--;
                var item = allItems.Skip(number).First();
                var newItem = new ItemDTO() { Id = item.Id };
                Console.WriteLine("Enter new name");
                newItem.Name = Console.ReadLine();
                Console.WriteLine("Enter new priority level");
                newItem.Priority = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter new description");
                newItem.Description = Console.ReadLine();
                Console.WriteLine("Enter new status");
                newItem.Status = Console.ReadLine();
                if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Description) || string.IsNullOrEmpty(item.Status)) 
                {
                    throw new ArgumentException("You entered incorrect value");
                }
                return newItem;
            }
            else
            {
                throw new ArgumentNullException("You entered incorrect number");
            }
        }
        private static void Delete()
        {
            var allItems = logic.GetAll();
            int itemsCount = allItems.Count();
            Output(allItems);
            Console.WriteLine("Enter number of item you want to delete");
            int number = 0;
            int.TryParse(Console.ReadLine(), out number);
            if (number > 0 && number <= itemsCount)
            {
                number--;
                var item = allItems.Skip(number).First();
                logic.Delete(item.Id);
            }
        }
        private static void Output(ItemVM item)
        {
            Console.WriteLine($"Id - {item.Id};\nName - {item.Name};\nPriority - {item.Priority};\nDescription - {item.Description};\nStatus - {item.Status}.");
        }
        private static void Output(IEnumerable<ItemDTO> items)
        {
            var number = 0;
            foreach (var item in items)
            {
                number++;
                Console.WriteLine($"{number} - {(ItemVM)item}");
            }
        }
        private static ItemDTO Add()
        {
            Console.WriteLine("Enter name of item");
            string name = Console.ReadLine();
            Console.WriteLine("Enter priority of item");
            int prioroty = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter description of item");
            string description = Console.ReadLine();
            return new ItemVM(name, prioroty, description);
        }

        static void Menu()
        {
            Console.WriteLine("Choose the action:");
            Console.WriteLine("1 - Add item");
            Console.WriteLine("2 - Delete item");
            Console.WriteLine("3 - Get item by number");
            Console.WriteLine("4 - Get item by name");
            Console.WriteLine("5 - Get all items");
            Console.WriteLine("6 - Get all items ordered by priority");
            Console.WriteLine("7 - Update item");
            Console.WriteLine("8 - Exit");
        }
    }
}