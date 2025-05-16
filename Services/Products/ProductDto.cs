namespace App.Services.Products
{
    //record product1 == product2 yazıp içerikleir aynıysa true dönmesi için.
    public record ProductDto(int Id, string Name, decimal Price, int Stock);
    
}
