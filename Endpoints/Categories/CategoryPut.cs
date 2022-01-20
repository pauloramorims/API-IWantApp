using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id}";                                  //Rota do meu Template, Ao criar a unidade templete "=>" seta o "/" 
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };    //Métodos de acesso
    public static Delegate Handle=> Action;                                          //Minha ação

    public static IResult Action ([FromRoute] Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
        
        category.Name= categoryRequest.Name;
        category.Active=categoryRequest.Active;
     
        context.SaveChanges();
       
        return Results.Ok();
    }
}; 

