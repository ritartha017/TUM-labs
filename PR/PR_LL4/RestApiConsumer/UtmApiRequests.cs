using RestSharp;
using RestApiConsumer.Dtos;
using RestApiConsumer.Models;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace RestApiConsumer;

class UtmApiRequests
{
    /// <summary>
    /// 1. Loops through categories list
    /// </summary>
    /// <returns></returns>
    public List<CategoryShortDto>? GetCategories()
    {
        var url = "http://localhost:65052/api/Category/categories";
        var client = new RestClient(url);

        var response = client.Execute<List<CategoryShortDto>?>(new RestRequest());

        return response.Data;
    }

    /// <summary>
    /// 2. Shows details about a category
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public CategoryShortDto? GetCategoryById(int id)
    {
        var url = "http://localhost:65052";
        var client = new RestClient(url);
        var request = new RestRequest("api/Category/categories/{id}")
            .AddUrlSegment("id", id);

        var response = client.Execute<CategoryShortDto?>(request);

        return response.Data;
    }

    /// <summary>
    /// 3. Creates new category
    /// </summary>
    /// <param name="category"></param>
    public void PostCategory(Category category)
    {
        var url = "http://localhost:65052";
        var client = new RestClient(url);
        var request = new RestRequest("api/Category/categories", Method.Post);
        request.RequestFormat = RestSharp.DataFormat.Json;
        request.AddJsonBody(category);
        var response = client.Execute(request);
    }

    /// <summary>
    /// 4. Deletes category by id
    /// </summary>
    /// <param name="id"></param>
    public void DeleteCategory(int id)
    {
        var url = "http://localhost:65052";
        var client = new RestClient(url);
        var request = new RestRequest("api/Category/categories/{id}", Method.Delete)
            .AddUrlSegment("id", id);

        var response = client.Execute(request);
    }

    /// <summary>
    /// 5. Updates title for category id
    /// </summary>
    /// <param name="id"></param>
    public void UpdateTitleForCategoryId(int id)
    {
        var url = "http://localhost:65052";
        var client = new RestClient(url);
        var request = new RestRequest("api/Category/categories/{id}/products", Method.Post)
            .AddUrlSegment("id", id);
        request.RequestFormat = RestSharp.DataFormat.Json;
        request.AddJsonBody(new ProductShortDto
        {
            Id = 2,
            Title = "SomeRandomTitle",
            Price = 200,
            CategoryId = id
        });
        var response = client.Execute(request);
    }

    /// <summary>
    /// 6. Creates new product for category id
    /// </summary>
    /// <param name="id">Category id</param>
    public void PostProductForCategoryId(int id)
    {
        var url = "http://localhost:65052";
        var client = new RestClient(url);
        var request = new RestRequest("api/Category/categories/{id}/products", Method.Post)
            .AddUrlSegment("id", id);
        request.RequestFormat = RestSharp.DataFormat.Json;
        request.AddJsonBody(new ProductShortDto
        {
            Id = 2,
            Title = "SomeRandomTitle",
            Price = 200,
            CategoryId = id
        });
        var response = client.Execute(request);
    }

    /// <summary>
    /// 7. Shows list of products for category id
    /// </summary>
    /// <param name="id">Category id</param>
    /// <returns></returns>
    public List<ProductShortDto>? GetProductsForCategoryId(int id)
    {
        var url = "http://localhost:65052";
        var client = new RestClient(url);
        var request = new RestRequest("api/Category/categories/{id}/products")
            .AddUrlSegment("id", id);

        var response = client.Execute<List<ProductShortDto>?>(request);

        return response.Data;
    }
}