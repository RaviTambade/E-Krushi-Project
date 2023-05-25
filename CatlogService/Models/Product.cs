namespace CatlogService.Models;

public class Product{

    public int Id{get; set;}

    public string Title{get; set;}

    public double UnitPrice{get; set;}

    public int StockAvailable{get; set;}

    public string Image{get; set;}

    public int CategoryId{get; set;}


}