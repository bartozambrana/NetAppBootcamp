using System;
using System.Collections.Generic;

namespace AssessmentApplication.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Claims = new HashSet<Claim>();
        }

        public long Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Vin { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Year { get; set; }
        public long OwnerId { get; set; }

        public virtual Owner Owner { get; set; } = null!;
        public virtual ICollection<Claim> Claims { get; set; }
    }
}
