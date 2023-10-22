using SKBTesting.BLL.Abstract;
using SKBTesting.BLL.BaseLogic;
using SKBTesting.DAL.Abstract;
using SKBTesting.DAL.FileDAL;
using SKBTesting.DAL.MSSQLDAL;
using System.Configuration;

namespace SKBTesting.DI.Provaiders
{
    public static class Provaider
    {
        public static IItemDAL DAL { get; private set; }
        public static ILogic Logic { get; private set; }
        static Provaider()
        {
            string typeDAL = ConfigurationManager.AppSettings["TypeDAL"];
            string typeLogic = ConfigurationManager.AppSettings["TypeBLL"];
            switch (typeDAL)
            {
                case "File":
                    {
                        DAL = new FileDAL();
                    }
                    break;
                case "DB":
                    {
                        DAL = new MSSQLDAL();
                    }
                    break;
                default:
                    break;
            }
            switch (typeLogic)
            {
                case "BaseLogic":
                    {
                        Logic = new BaseLogic(DAL);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}