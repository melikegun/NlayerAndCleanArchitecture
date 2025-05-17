namespace App.Services.Products
{
    //record olduğu için product1 == product2 gibi karşılaştırmalar değer üzerinden yapılır, referans üzerinden değil.
    //record tipi, sadece veri taşıma amacıyla kullanılan sınıflar için çok uygundur.
    public record ProductDto(int Id, string Name, decimal Price, int Stock);
    
}
