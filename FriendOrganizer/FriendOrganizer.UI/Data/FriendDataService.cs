using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            //TODO: Add data from real database
            yield return new Friend { FirstName = "Pankaj", LastName = "Gupta" };
            yield return new Friend { FirstName = "Amitkumar", LastName = "Jain" };
            yield return new Friend { FirstName = "Devendra", LastName = "Agrawal" };
            yield return new Friend { FirstName = "Amisha", LastName = "Dadheech" };
        }
    }
}
