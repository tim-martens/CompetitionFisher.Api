using System;

namespace CompetitionFisher.Data.Models
{
    public class Result
    {
        public Guid Id { get; set; }
        public Guid ContestantId { get; set; }
        public Guid CompetitionId { get; set; }

        public int TotalNumber { get; set; }
        public int TotalWeight { get; set; }

        public virtual Contestant Contestant { get; set; }
        public virtual Competition Competition { get; set; }

    }
}
