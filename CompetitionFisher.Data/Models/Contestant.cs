using System;
using System.Collections.Generic;

namespace CompetitionFisher.Data.Models
{
    public class Contestant
    {
        public Guid Id { get; set; }
        public string Auth0UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Competition> Competitions { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
