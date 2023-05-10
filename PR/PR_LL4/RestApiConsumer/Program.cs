using Spectre.Console;
using RestApiConsumer;
using System.Text.Json;
using RestApiConsumer.Dtos;

UtmApiRequests requester = new UtmApiRequests();

int option = 0;
while (true)
{
    try
    {
        Console.Clear();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Chose an [blue]option[/]?")
                .PageSize(10)
                .AddChoices(new[] { "1 - Get all available categories",
                                    "2 - Show details for category id",
                                    "3 - Create new category",
                                    "4 - Delete category by id",
                                    "5 - Update title for category id",
                                    "6 - Create new product for category id",
                                    "7 - Show list of products for category id",
                                    "8 - Exit." }));
        option = Convert.ToInt32(choice[0].ToString());
    }
    catch (System.FormatException)
    {
        Console.WriteLine("Please enter an integer value between 1 and 7");
        continue;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An unexpected error happened. Please try again");
        Console.WriteLine(ex);
        continue;
    }
    switch (option)
    {
        case 1:
            CallGetCategories();
            Console.ReadKey();
            break;
        case 2:
            CallGetCategories();
            CallGetCategoryById();
            Console.ReadKey();
            break;
        case 3:
            CallPostCategory();
            Console.ReadKey();
            break;
        case 4:
            CallGetCategories();
            CallDeleteCategory();
            Console.ReadKey();
            break;
        case 5:
            CallGetCategories();
            CallUpdateTitleForCategoryId();
            Console.ReadKey();
            break;
        case 6:
            CallGetCategories();
            CallPostProductForCategoryId();
            Console.ReadKey();
            break;
        case 7:
            CallGetCategories();
            CallGetProductsForCategoryId();
            Console.ReadKey();
            break;
        case 8:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Please enter an integer value between 1 and 7");
            break;
    }
}

// 7
void CallGetProductsForCategoryId()
{
    Console.WriteLine("Input category to show the products");
    var requesteId = Console.ReadLine();
    Int32.TryParse(requesteId, out int id);
    var res = requester.GetCategoryById(id);
    if (res is null)
    {
        Console.WriteLine("Unexistent category id.");
        return;
    }
    var products = requester.GetProductsForCategoryId(id);
    if (products.Count <= 0)
    {
        Console.WriteLine($"There are no existing products for category id = {id}.");
        return;
    }
    foreach (var category in products.Select((value, i) => new { i, value }))
    {
        string jsonString = JsonSerializer.Serialize(category.value);
        AnsiConsole.Write(
            new Panel(jsonString)
                .Header(category.i.ToString())
                .Collapse()
                .RoundedBorder()
                .BorderColor(Color.Yellow));
    }
}

// 6
void CallPostProductForCategoryId()
{
    Console.WriteLine("Input category id to add new product:");
    var requesteId = Console.ReadLine();
    Int32.TryParse(requesteId, out int id);
    var res = requester.GetCategoryById(id);
    if (res is null)
    {
        Console.WriteLine("Unexistent category id.");
        return;
    }
    Console.WriteLine("Enter title:");
    var newProductTitle = Console.ReadLine();
    Console.WriteLine("Enter price:");
    var requestedProductPrice = Console.ReadLine();
    Decimal.TryParse(requestedProductPrice, out decimal newProductPrice);
    var newProduct = new ProductShortDto
    {
        Title = newProductTitle,
        Price = newProductPrice,
    };
    requester.PostProductForCategoryId(id, newProduct);
}

// 5
void CallUpdateTitleForCategoryId()
{
    Console.WriteLine("Input category id to update the title:");
    var requesteId = Console.ReadLine();
    Int32.TryParse(requesteId, out int id);
    var res = requester.GetCategoryById(id);
    if (res is null)
    {
        Console.WriteLine("Unexistent category id.");
        return;
    }
    Console.WriteLine("Enter new title:");
    var newProductTitle = Console.ReadLine();
    requester.UpdateTitleForCategoryId(id, newProductTitle);
}

// 4
void CallDeleteCategory()
{
    Console.WriteLine("Input category id to delete:");
    var requesteId = Console.ReadLine();
    Int32.TryParse(requesteId, out int id);
    var res = requester.GetCategoryById(id);
    if (res is null)
    {
        Console.WriteLine("Unexistent category id.");
        return;
    }
    requester.DeleteCategory(id);
}

// 3
void CallPostCategory()
{
    Console.WriteLine("Input desired category title:");
    var title = Console.ReadLine();
    var category = new CreateCategoryDto()
    {
        Title = title
    };
    requester.PostCategory(category);
}

// 2
void CallGetCategoryById()
{
    Console.WriteLine("Input wanted category id: ");
    var requesteId = Console.ReadLine();
    Int32.TryParse(requesteId, out int id);
    var res = requester.GetCategoryById(id);
    if (res is null)
    {
        Console.WriteLine("Unexistent category id.");
        return;
    }
    string jsonString = JsonSerializer.Serialize(res);
    AnsiConsole.Write(
        new Panel(jsonString)
            .Header(requesteId)
            .Collapse()
            .RoundedBorder()
            .BorderColor(Color.Yellow));
}

// 1
void CallGetCategories()
{
    Console.WriteLine("Available categories:");
    var res = requester.GetCategories();
    if (res is null) {
        Console.WriteLine("There are no existing categories.");
        return;
    }
    foreach(var category in res.Select((value, i) => new { i, value }))
    {
        string jsonString = JsonSerializer.Serialize(category.value);
        AnsiConsole.Write(
            new Panel(jsonString)
                .Header(category.i.ToString())
                .Collapse()
                .RoundedBorder()
                .BorderColor(Color.Yellow));
     }
}
