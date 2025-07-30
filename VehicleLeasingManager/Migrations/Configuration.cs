namespace VehicleLeasingManager.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VehicleLeasingManager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VehicleLeasingManager.Models.VehicleLeasingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VehicleLeasingManager.Models.VehicleLeasingContext context)
        {
            var supplier1Id = Guid.NewGuid();
            var supplier2Id = Guid.NewGuid();
            var supplier3Id = Guid.NewGuid();

            var branch1Id = Guid.NewGuid();
            var branch2Id = Guid.NewGuid();
            var branch3Id = Guid.NewGuid();

            var client1Id = Guid.NewGuid();
            var client2Id = Guid.NewGuid();
            var client3Id = Guid.NewGuid();

            var driver1Id = Guid.NewGuid();
            var driver2Id = Guid.NewGuid();
            var driver3Id = Guid.NewGuid();

            var suppliers = new List<Supplier>
            {
                new Supplier { SupplierId = supplier1Id, SupplierName = "Mdingi Industrial Design Technologies", ContactInfo = "info@mdingiidtech.co.za" },
                new Supplier { SupplierId = supplier2Id, SupplierName = "Pan African Information Communication Technology Association", ContactInfo = "info@paicta.org" },
                new Supplier { SupplierId = supplier3Id, SupplierName = "Rosond", ContactInfo = "info@rosond.com" }
            };

            var branches = new List<Branch>
            {
                new Branch { BranchId = branch1Id, BranchName = "Eastern Cape", Location = "Mthatha" },
                new Branch { BranchId = branch2Id, BranchName = "Eastern Cape", Location = "East London" },
                new Branch { BranchId = branch3Id, BranchName = "Gauteng", Location = "Johannesburg" },
            };

            var clients = new List<Client>
            {
                new Client { ClientId = client1Id, CompanyName = "Agri Plant Care", ContactDetails = "zolani@apc.com" },
                new Client { ClientId = client2Id, CompanyName = "Ntapane Junior Secondary School", ContactDetails = "info@ntapanejss.com" },
                new Client { ClientId = client3Id, CompanyName = "Zebros", ContactDetails = "kholeka@zebros.com" },
            };

            var drivers = new List<Driver>
            {
                new Driver { DriverId = driver1Id, FullName = "Okuhle Mbongwe", LicenseNumber = "D1234567", Phone = "0764835831" },
                new Driver { DriverId = driver2Id, FullName = "Zolani Mabhongo", LicenseNumber = "D9876543", Phone = "0839575309" },
                new Driver { DriverId = driver3Id, FullName = "Ngcali Nundu", LicenseNumber = "A9876543", Phone = "0744551115" },
            };
            
            context.Suppliers.AddRange(suppliers);
            context.Branches.AddRange(branches);
            context.Clients.AddRange(clients);
            context.Drivers.AddRange(drivers);
            context.SaveChanges();

            var vehicles = new List<Vehicle>
            {
                new Vehicle {
                    VehicleId = Guid.NewGuid(),
                    Manufacturer = "Toyota", Model = "Hilux", Year = 2021, RegistrationNumber = "ABQ123EC",
                    SupplierId = supplier1Id, BranchId = branch1Id, ClientId = client1Id, DriverId = driver1Id
                },
                new Vehicle {
                    VehicleId = Guid.NewGuid(),
                    Manufacturer = "Ford", Model = "Ranger", Year = 2022, RegistrationNumber = "XYI987EC",
                    SupplierId = supplier2Id, BranchId = branch2Id, ClientId = client2Id, DriverId = driver2Id
                },
                new Vehicle {
                    VehicleId = Guid.NewGuid(),
                    Manufacturer = "VW", Model = "Polo", Year = 2022, RegistrationNumber = "XYI987GP",
                    SupplierId = supplier3Id, BranchId = branch3Id, ClientId = client3Id, DriverId = driver3Id
                }
            };

            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
        }
    }
}
