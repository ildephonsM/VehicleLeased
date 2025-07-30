using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleLeasingManager.Models
{
    public class Driver
    {
        public Guid DriverId { get; set; }
        public string FullName { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone {  get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

    }
}