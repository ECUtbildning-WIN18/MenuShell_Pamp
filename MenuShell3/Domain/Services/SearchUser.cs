using System.Collections.Generic;
using System.Linq;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services
{
    class SearchUser
    {
        private readonly Dictionary<string, User> _users;

        public SearchUser(Dictionary<string, User> users)
        {
            _users = users;
        }

        public IEnumerable<User> UserSearch(string searchName)
        {
            var searchHits = _users.Where(p => p.Key.StartsWith(searchName)).Select(p => p.Value);

            return searchHits;
        }
    }
}
/*
var values = dictionary.Where(pv => 
             pv.Key.StartsWith("A") || 
             (pv.Key.Length >= 3 && pv.Key[2] == 'e') || 
             pv.Key.Length < 4 || 
             pv.Key[3] != 'd').Select(pv => pv.Value);
*/

