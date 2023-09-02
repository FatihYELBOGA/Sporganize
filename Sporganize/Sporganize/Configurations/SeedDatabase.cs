using Microsoft.EntityFrameworkCore;
using Sporganize.Enumerations;
using Sporganize.Models;

namespace Sporganize.Configurations
{
    public class SeedDatabase
    {

        public static void Seed(DataContext dataContext)
        {
            if (dataContext.Database.GetPendingMigrations().Count() == 0)
            {
                if (dataContext.users.Count() == 0)
                {
                    dataContext.provinces.AddRange(provinces);
                    dataContext.districts.AddRange(districts);
                    dataContext.streets.AddRange(streets);
                    dataContext.users.AddRange(users);

                    dataContext.SaveChanges();
                }
            }
        }

        private static Province[] provinces =
        {
            new Province()
            {
                Name = "Istanbul",
            }
        };

        private static District[] districts =
        {
            new District()
            {
                Name = "Kadikoy",
                Province = provinces[0]
            },
            new District()
            {
                Name = "Esenler",
                Province = provinces[0]
            }
        };

        private static Street[] streets =
        {
            new Street()
            {
                Name = "Acibadem",
                District = districts[0]
            },
            new Street()
            {
                Name = "Bostanci",
                District = districts[0]
            },
            new Street()
            {
                Name = "Fatih",
                District = districts[1]
            },
            new Street()
            {
                Name = "Davutpasa",
                District = districts[1]
            }
        };

        private static User[] users =
        {
            new User()
            {
                Username = "fatihyelboga@gmail.com",
                Password = "fatih123",
                FirstName = "Fatih",
                LastName = "YELBOGA",
                Phone = "+90-541-361-57-50",
                Gender = Gender.MALE,
                Street = streets[0],
                Role = Role.OWNER
            },
            new User()
            {
                Username = "enesdemirel@gmail.com",
                Password = "enes123",
                FirstName = "Enes",
                LastName = "DEMIREL",
                Phone = "+90-545-840-50-08",
                Gender = Gender.MALE,
                Street = streets[0],
                Role = Role.USER
            },
            new User()
            {  
                Username = "osmanaltunay@gmail.com",
                Password = "osman123",
                FirstName = "Osman",
                LastName = "ALTUNAY",
                Phone = "+90-542-970-50-40",
                Gender = Gender.MALE,
                Street = streets[0],
                Role = Role.USER
            },
            new User()
            {
                Username = "mervenurozan@gmail.com",
                Password = "merve123",
                FirstName = "Merve",
                LastName = "OZAN",
                Phone = "+90-535-742-08-32",
                Gender = Gender.FEMALE,
                Street = streets[0],
                Role = Role.USER
            },
            new User()
            {
                Username = "zaferakman@gmail.com",
                Password = "zafer123",
                FirstName = "Zafer",
                LastName = "AKMAN",
                Phone = "+90-536-080-42-07",
                Gender = Gender.MALE,
                Street = streets[0],
                Role = Role.USER
            }
        };

        private static UserFriends[] userFriends = 
        {
            new UserFriends()
            {
                FirstFriend = users[1],
                SecondFriend = users[2]
            },
            new UserFriends()
            {
                FirstFriend = users[2],
                SecondFriend = users[3]
            }
        };

    }
}
