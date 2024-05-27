using Microsoft.EntityFrameworkCore;
using Online_Pet_Store_Example.Model;

namespace Online_Pet_Store_Example;

public class DbSeeds
{
    public async Task AddSeedsIfDbEmpty()
    {
        try
        {
            var context = new PetStoreExampleContext();
            var allAccounts = await context.UserAccounts.ToListAsync();
            if (allAccounts.Count == 0)
            {
                await AddSeedsToDb();
            }

            var allAccounts2 = await context.UserAccounts.ToListAsync();
            if (allAccounts2.Count == 0)
            {
                Logger.Log("Error: Was unable to Add seeds to Database");
            }
        }
        catch (Exception e)
        {
            Logger.Log(e.ToString());
        }
    }

    public async Task AddSeedsToDb()
    {
        try
        {
            Logger.Log("Attempting to add Seeds to Database");
            var context = new PetStoreExampleContext();

            var homePage = CreatePage(1, "home");
            await context.Pages.AddAsync(homePage);

            var contactUsPage = CreatePage(2, "contact us");
            await context.Pages.AddAsync(contactUsPage);

            var aboutUsPage = CreatePage(3, "about us");
            await context.Pages.AddAsync(aboutUsPage);

            var adminPermission =
                CreatePermission(1, "admin", new List<int> {homePage.Id, contactUsPage.Id, aboutUsPage.Id});
            await context.Permissions.AddAsync(adminPermission);

            var viewerPermission =
                CreatePermission(2, "viewer", new List<int> {homePage.Id, contactUsPage.Id, aboutUsPage.Id});
            await context.Permissions.AddAsync(viewerPermission);

            var barkBrand = CreateBrand(1, "Bark");
            await context.Brands.AddAsync(barkBrand);

            var kettleBrand = CreateBrand(2, "Kettle");
            await context.Brands.AddAsync(kettleBrand);

            var meowBrand = CreateBrand(3, "Meow");
            await context.Brands.AddAsync(meowBrand);

            var item1 = CreateItem(1, "Bark's Dry Dog Food 2kg", barkBrand.Id, "B4123");
            await context.Items.AddAsync(item1);

            var item2 = CreateItem(2, "Meow Kitty Litter 2kg", meowBrand.Id, "C409013-52");
            await context.Items.AddAsync(item2);

            var item3 = CreateItem(3, "Kettle Beef Wet Dog food 500g", kettleBrand.Id, "K9-40042-B52");
            await context.Items.AddAsync(item3);

            var stock1 = CreateStock(item1.Id, 500);
            await context.Stocks.AddAsync(stock1);

            var stock2 = CreateStock(item2.Id, 0);
            await context.Stocks.AddAsync(stock2);

            var stock3 = CreateStock(item3.Id, 40);
            await context.Stocks.AddAsync(stock3);

            var testCustomer = CreateCustomer(1, "test", "testy", "testy@fakeemail.com", null);
            await context.Customers.AddAsync(testCustomer);

            var customer1 = CreateCustomer(2, "John", "Smith", "johnny1970@fakeemail.com", null);
            await context.Customers.AddAsync(customer1);

            var customer2 = CreateCustomer(3, "Maria", "Jolie", "mariaJ2000@fakeemail.com", null);
            await context.Customers.AddAsync(customer2);

            var testAccount = CreateUserAccount(1, testCustomer.Id, "test");
            await context.UserAccounts.AddAsync(testAccount);
            await context.SaveChangesAsync();
            Logger.Log("Seeds added successfully");
        }
        catch (Exception e)
        {
            Logger.Log("Error: Was unable to Add seeds to Database");
            throw;
        }
    }

    private Customer CreateCustomer(int? id, string name, string surname, string email, byte[]? image)
    {
        var customer = new Customer();
        if (id.HasValue)
        {
            customer.Id = id.Value;
        }

        customer.Name = name;
        customer.Email = email;
        customer.Surname = surname;
        customer.Image = image;
        return customer;
    }

    private Stock CreateStock(int id, int stockAmount)
    {
        var stock = new Stock();
        stock.Itemid = id;
        stock.StockAmount = stockAmount;
        return stock;
    }

    private UserAccount CreateUserAccount(int? id, int customerId, string username)
    {
        var user = new UserAccount();
        if (id.HasValue)
        {
            user.Id = id.Value;
        }

        user.CustomerId = customerId;
        user.UserName = username;
        return user;
    }

    private Permission CreatePermission(int? id, string name, List<int> allowedPageIds)
    {
        var permission = new Permission();
        if (id.HasValue)
        {
            permission.Id = id.Value;
        }

        permission.Name = name;
        permission.AllowedPageIds = allowedPageIds;
        return permission;
    }

    private Brand CreateBrand(int? id, string name)
    {
        var brand = new Brand();
        if (id.HasValue)
        {
            brand.Id = id.Value;
        }

        brand.Name = name;
        return brand;
    }

    private Item CreateItem(int? id, string name, int brandId, string serialNumber)
    {
        var item = new Item();
        if (id.HasValue)
        {
            item.Id = id.Value;
        }

        item.Name = name;
        item.BrandId = brandId;
        item.SerialNumber = serialNumber;
        return item;
    }

    private Page CreatePage(int? id, string name)
    {
        var page = new Page();
        if (id.HasValue)
        {
            page.Id = id.Value;
        }

        page.Name = name;
        return page;
    }
}