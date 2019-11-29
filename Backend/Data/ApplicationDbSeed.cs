using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;

namespace Backend.Data
{
    public class ApplicationDbSeed
    {
        public static async Task SeedAsync(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Attempts.Any())
            {
                applicationDbContext.Attempts.AddRange(GetPreConfiguredAttempts());
                await applicationDbContext.SaveChangesAsync();
            }

            if (!applicationDbContext.Devices.Any())
            {
                applicationDbContext.Devices.AddRange(GetPreConfiguredDevices());
                await applicationDbContext.SaveChangesAsync();
            }

            if (!applicationDbContext.AttemptDevices.Any())
            {
                applicationDbContext.AttemptDevices.AddRange(
                    GetPreConfiguredAttemptDevices());

                await applicationDbContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Device> GetPreConfiguredDevices()
        {
            return new List<Device>
            {
                new Device
                {
                    Id = 1,
                    MacAddress = "74:E8:5F:B0:7A:13",
                    Name = "Handzeep",
                    Category = "Game",
                    LastOnline = DateTime.Now.ToUniversalTime().AddHours(1),
                    Order = 1
                },
                new Device
                {
                    Id = 2,
                    MacAddress = "A2:C4:2B:6D:1B:10",
                    Name = "Zoutmeter",
                    Category = "Game",
                    LastOnline = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(20),
                    Order = 1
                },
                new Device
                {
                    Id = 3,
                    MacAddress = "63:11:06:AB:43:79",
                    Name = "Zwenkelen",
                    Category = "Game",
                    LastOnline = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(50),
                    Order = 2
                }
            };
        }

        private static IEnumerable<Attempt> GetPreConfiguredAttempts()
        {
            return new List<Attempt>
            {
                new Attempt
                {
                    Id = 1,
                    StartDate = DateTime.Now.ToUniversalTime().AddDays(-3).AddHours(1),
                },
                new Attempt
                {
                    Id = 2,
                    StartDate = DateTime.Now.ToUniversalTime().AddHours(1),
                }
            };
        }

        private static IEnumerable<AttemptDevice> GetPreConfiguredAttemptDevices()
        {
            return new List<AttemptDevice>
            {
                new AttemptDevice
                {
                    AttemptId = 1,
                    DeviceId = 1
                },
                new AttemptDevice
                {
                    AttemptId = 1,
                    DeviceId = 2
                },
                new AttemptDevice
                {
                    AttemptId = 1,
                    DeviceId = 3
                },
                new AttemptDevice
                {
                    AttemptId = 2,
                    DeviceId = 1,
                    StartedAt = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(1),
                    FinishedAt = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(11)
                },
                new AttemptDevice
                {
                    AttemptId = 2,
                    DeviceId = 2,
                    StartedAt = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(11),
                },
                new AttemptDevice
                {
                    AttemptId = 2,
                    DeviceId = 3
                }
            };
        }
    }
}