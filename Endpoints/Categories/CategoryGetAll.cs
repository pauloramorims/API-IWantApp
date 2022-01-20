using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories"; //Rota do meu Template, Ao criar a unidade templete "=>" seta o "/" 
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };    //Métodos de acesso
    public static Delegate Handle=> Action;  //Minha ação


    public static IResult Action (ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();
        var response = categories.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name, Active = c.Active });
                      //↓Todo POST deve retornar Created
        return Results.Ok(response);
    }
}; 

