using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories"; //Rota do meu Template, Ao criar a unidade templete "=>" seta o "/" 
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };    //Métodos de acesso
    public static Delegate Handle=> Action;  //Minha ação

    public static IResult Action (CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = new Category(categoryRequest.Name, "Teste", "Teste"); 

        if (!category.IsValid)//Retorna mensagem de erro
        {
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
        }
        
        context.Categories.Add(category);
        context.SaveChanges();
                      //↓Todo POST deve retornar Created
        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}; 

