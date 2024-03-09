using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

public class User
{
    [Key]
    public int id { get; set; }
    public string? login { get; set; }
    public string? password { get; set; }
    public string? type_user { get; set; }
    public static User? currentUser { get; set; }
}
public class Product
{
    [Key]
    public int? id_product { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
    public int? price { get; set; }
    public string? category { get; set; }
    public static Product? currentProduct { get; set; }
}


