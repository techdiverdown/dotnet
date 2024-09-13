using Microsoft.AspNetCore.Mvc;

using OneReview.Domain;
using OneReview.Services;

namespace OneReview.Controllers;

// this uri will be host/products because
// the class name is ProductsController and the 
// attribute [controller] gets the classname
// with the Controller part removed and lowercased
// although but upper and lower case works in the request.
// it could also just be written as [Route("products")] and thats the same
[Route("[controller]")]
public class ProductsController(ProductsService productsService) : ControllerBase
{
    private readonly ProductsService _productsService = productsService;
    
    // [HttpPost] this is an attribute from ASP.NET core to indicate a method
    // in a controller should handle HTTP POST requests.
    [HttpPost]
    public IActionResult Create([FromBody]CreateProductRequest request)
    {
        // mapping to internal representation from the request object that came in
        var product = request.ToDomain();

        // invoking the use case
        _productsService.Create(product);
        
        // mapping to external representation and returning the response
        var response = new ProductResponse(
            product.Id,
            product.Name,
            product.Category,
            product.Subcategory);
        
        // return response
        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { ProductId = product.Id },
            value: ProductResponse.FromDomain(product));
    }

    [HttpGet("{productId:guid}")]
    public IActionResult Get(Guid productId)
    {
        // invoking the use case
        var product = _productsService.Get(productId);
        
        // mapping to external representation
        return product is null 
            ? Problem(statusCode: StatusCodes.Status404NotFound, detail: "Product not found") 
            : Ok(ProductResponse.FromDomain(product));
    }
    public record CreateProductRequest(
        string Name,
        string Category,
        string Subcategory)
    {
        // method to take an instance of CreateProductRequest and map
        // it to an instance of Product class
        public Product ToDomain()
        {
            return new Product
        {
            Name = this.Name,
            Category = Category,
            Subcategory = Subcategory
        };
    }
}

    public record ProductResponse(
        Guid id,
        string Name,
        string Category,
        string Subcategory)
    {
        public static ProductResponse FromDomain(Product product)
        {
            return new ProductResponse
            (
                product.Id,
                product.Name,
                product.Category,
                product.Subcategory
            );
        }
    }
}