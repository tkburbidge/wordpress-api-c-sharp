using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressApiClient.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Locale { get; set; }
        public string Nickname { get; set; }
        public string Slug { get; set; }
        public DateTime RegisteredDate { get; set; }
        public List<string> Roles { get; set; }
        public string Password { get; set; }
    }
}
