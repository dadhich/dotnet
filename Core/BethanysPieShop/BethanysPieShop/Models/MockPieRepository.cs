using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        private List<Pie> _pies;

        public MockPieRepository()
        {
            if (_pies == null)
                InitializePies();
        }

        private void InitializePies()
        {
            _pies = new List<Pie>
            {
                new Pie{Id = 1,Name="Apple Pie",Price=12.95M,ShortDescription="Fabulous Apple Pie",LongDescription="Amazing and delicious Apple Pie made from finest apples",ImageUrl="",ImageThumbnailUrl="",IsPieOfTheWeek=false},
                new Pie{Id = 2,Name="Blueberry Cheese Cake",Price=18.95M,ShortDescription="Perfect Cake",LongDescription="Scintillating Blue Berry Chese Cake made from finest Cheese and Blueberries",ImageUrl="",ImageThumbnailUrl="",IsPieOfTheWeek=false},
                new Pie{Id = 3,Name="Cheese Cake",Price=18.95M,ShortDescription="Lovable Cheese Cake",LongDescription="Come, fall in love with the most amazing cheese cake",ImageUrl="",ImageThumbnailUrl="",IsPieOfTheWeek=false},
                new Pie{Id = 4,Name="Cherry Pie",Price=15.95M,ShortDescription="Wonderful Cherry Pie",LongDescription="Amazing and delicious Cherry Pie made from finest cherries",ImageUrl="",ImageThumbnailUrl="",IsPieOfTheWeek=false}
            };
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return _pies;
        }

        public Pie GetPieById(int pieId)
        {
            return _pies.FirstOrDefault(p => p.Id == pieId);
        }
    }
}
