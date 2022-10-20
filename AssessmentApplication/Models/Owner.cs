using System;
using System.Collections.Generic;

namespace AssessmentApplication.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DriverLicense { get; set; } = null!;

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
