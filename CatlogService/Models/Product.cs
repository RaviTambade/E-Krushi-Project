namespace CatlogService.Models;

public class Product{

    public int ProductId{get; set;}

    public string ProductTitle{get; set;}

    public double UnitPrice{get; set;}

    public int StockAvailable{get; set;}

    public string Image{get; set;}

    public int CategoryId{get; set;}


}