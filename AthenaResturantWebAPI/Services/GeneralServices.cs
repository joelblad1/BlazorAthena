using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorAthena.Models;
using AthenaResturantWebAPI.Data.Context;
using Microsoft.AspNetCore.Identity;


namespace AthenaResturantWebAPI.Services
{
    public class GeneralServices
    {

        private readonly AppDbContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GeneralServices
            (
                AppDbContext appDbContext,
                //UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager
            )

        {

            _context = appDbContext;
            //_userManager = userManager;
            _roleManager = roleManager;

        }


        //public async Task SeedIdentityData()
        //{
        //    string[] roleNames = { "Admin", "User", "Manager", "Employee" };

        //    // Create roles
        //    foreach (var roleName in roleNames)
        //    {
        //        if (!await _roleManager.RoleExistsAsync(roleName))
        //        {
        //            var role = new IdentityRole { Name = roleName };
        //            await _roleManager.CreateAsync(role);
        //        }
        //    }

        //    // Create a default admin user
        //    if (_userManager.Users.All(u => u.UserName != "admin@example.com"))
        //    {
        //        var adminUser = new ApplicationUser
        //        {
        //            UserName = "admin@example.com",
        //            Email = "admin@example.com",
        //        };
        //        await _userManager.CreateAsync(adminUser, "Admin123!"); // Replace with your desired password

        //        // Assign the admin user to the "Admin" role
        //        await _userManager.AddToRoleAsync(adminUser, "Admin");
        //    }

        //    // Create user accounts for Kim, Julia, Joel, Peter, Paul with roles
        //    var usersWithRoles = new List<(string UserName, string Email, string Password, string Role)>
        //     {
        //          ("Kim", "kim@example.com", "Password123!", "User"),
        //          ("Julia", "julia@example.com", "Password123!", "Manager"),
        //          ("Joel", "joel@example.com", "Password123!", "Employee"),
        //          ("Peter", "peter@example.com", "Password123!", "Admin"),
        //          ("Paul", "paul@example.com", "Password123!", "User")
        //     };

        //    foreach (var (userName, email, password, role) in usersWithRoles)
        //    {
        //        var user = await _userManager.FindByNameAsync(userName);

        //        if (user == null)
        //        {
        //            user = new ApplicationUser { UserName = userName, Email = email };
        //            await _userManager.CreateAsync(user, password);
        //        }

        //        if (!await _userManager.IsInRoleAsync(user, role))
        //        {
        //            await _userManager.AddToRoleAsync(user, role);
        //        }
        //    }
          
        //}
        public void SeedData(AppDbContext context)
        {

            if (!context.Products.Any())
            {

                // Seeding
                var bevrageSubCategory = new SubCategory { Name = "Beverages ", ID = 1 };
                var mainCourseSubCategory = new SubCategory { Name = "Main Courses " };
                var dessertSubCategory = new SubCategory { Name = "Desserts " };

                context.SubCategories.AddRange(bevrageSubCategory, mainCourseSubCategory, dessertSubCategory);
                context.Products.AddRange(
                    new Product
                    {

                        Name = "Vap",
                        Price = 1.99,
                        Description = "Refreshing carbonated beverage",
                        Image = "soda.png",
                        Available = true,
                        SubCategoryId = bevrageSubCategory.ID

                    },
                    new Product
                    {

                        Name = "Iced Tea",
                        Price = 1.99,
                        Description = "Chilled tea served with ice",
                        Image = "iced_tea.jpg",
                        Available = true,
                        SubCategoryId = bevrageSubCategory.ID

                    },
                    new Product
                    {

                        Name = "Fruit Smoothie",
                        Price = 4.99,
                        Description = "Blend of fresh fruits and yogurt",
                        Image = "Blended-fruit-smoothies.jpg",
                        Available = true,
                        SubCategoryId = bevrageSubCategory.ID

                    },
                    new Product
                    {

                        Name = "Grilled Chicken Sandwich",
                        Price = 8.99,
                        Description = "Grilled chicken breast with fresh veggies on a bun",
                        Image = "grilled_chicken_sandwich.jpg",
                        Available = true,
                        SubCategoryId = mainCourseSubCategory.ID

                    },
                    new Product
                    {

                        Name = "Classic Burger",
                        Price = 10.99,
                        Description = "Juicy beef patty with lettuce, tomato and cheese",
                        Image = "Classic_Burger.jpg",
                        Available = true,
                        SubCategoryId = mainCourseSubCategory.ID

                    },
                    new Product
                    {

                        Name = "Vegetarian Pizza",
                        Price = 10.99,
                        Description = "Thin-crust pizza with assorted veggies",
                        Image = "Vegetable-Pizza.jpg",
                        Available = true,
                        SubCategoryId = mainCourseSubCategory.ID

                    },
                    new Product
                    {
                        Name = "Grilled Salmon",
                        Price = 12.99,
                        Description = "Freshly grilled salmon fillet with lemon butter",
                        Image = "grilled_Salmon.jpg",
                        Available = true,
                        SubCategoryId = mainCourseSubCategory.ID
                    },


                    new Product
                    {

                        Name = "Chocolate Brownie Sundae",
                        Price = 5.99,
                        Description = "Warm chocolate brownie topped with vanilla ice cream and hot fudge",
                        Image = "Fudge_Sunday.jpg",
                        Available = true,
                        SubCategoryId = dessertSubCategory.ID


                    },
                    new Product
                    {

                        Name = "Cheesecake",
                        Price = 6.99,
                        Description = "Creamy and rich New York - style cheesecake",
                        Image = "CheeseCake.jpg",
                        Available = true,
                        SubCategoryId = dessertSubCategory.ID


                    },
                    new Product
                    {

                        Name = "Fudge Brownie",
                        Price = 4.99,
                        Description = "Decadent chocolate fudge brownie",
                        Image = "Brownie.jpg",
                        Available = true,
                        SubCategoryId = dessertSubCategory.ID


                    },
                    new Product
                    {

                        Name = "Tiramisu",
                        Price = 8.99,
                        Description = "Classic Italian dessert with layers of coffee-soaked ladyfingers and mascarpone",
                        Image = "Tiramisu.jpg",
                        Available = true,
                        SubCategoryId = dessertSubCategory.ID

                    }

                    );

                _context.SaveChanges();



            }
        }
    }
}
