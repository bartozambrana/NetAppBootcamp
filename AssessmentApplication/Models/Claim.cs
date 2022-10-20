using System;
using System.Collections.Generic;

namespace AssessmentApplication.Models
{
    public partial class Claim
    {
        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime Date { get; set; }
        public long VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
