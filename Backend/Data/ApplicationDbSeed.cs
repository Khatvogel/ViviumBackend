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
                    MacAddress = "74:E8:5F:B0:7A:13",
                    Name = "Handzeep",
                    Category = "Game",
                    LastOnline = DateTime.Now.ToUniversalTime().AddHours(1),
                    Started = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(1),
                    Finished = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(19),
                    AttemptId = 1
                },
                new Device
                {
                    MacAddress = "A2:C4:2B:6D:1B:10",
                    Name = "Zoutmeter",
                    Category = "Game",
                    LastOnline = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(20),
                    Started = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(21),
                    Finished = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(48),
                    AttemptId = 1
                },
                new Device
                {
                    MacAddress = "63:11:06:AB:43:79",
                    Name = "Zwenkelen",
                    Category = "Game",
                    LastOnline = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(50),
                    Started = DateTime.Now.ToUniversalTime().AddHours(1).AddMinutes(51),
                    Finished = DateTime.Now.ToUniversalTime().AddHours(2).AddMinutes(19),
                    AttemptId = 1
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
                    DeviceMacAddress = "74:E8:5F:B0:7A:13"
                },
                new AttemptDevice
                {
                    AttemptId = 1,
                    DeviceMacAddress = "A2:C4:2B:6D:1B:10"
                },
                new AttemptDevice
                {
                    AttemptId = 1,
                    DeviceMacAddress = "63:11:06:AB:43:79"
                }, new AttemptDevice
                {
                    AttemptId = 2,
                    DeviceMacAddress = "74:E8:5F:B0:7A:13"
                },
                new AttemptDevice
                {
                    AttemptId = 2,
                    DeviceMacAddress = "A2:C4:2B:6D:1B:10"
                },
                new AttemptDevice
                {
                    AttemptId = 2,
                    DeviceMacAddress = "63:11:06:AB:43:79"
                },
            };
        }
    }
}