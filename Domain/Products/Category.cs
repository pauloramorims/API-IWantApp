using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Category(string name, string createdBy, string editedBy)
    {
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreateOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Validate();
    }

    private void Validate() //ctrl+R+M → cria o método selecionado
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(Name, "Name", "Nome é obrigatório!")
            .IsGreaterOrEqualsThan(Name, 3, "Name") //Aceita apenas nomes maior que tres caract
            .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
            .IsNotNullOrEmpty(EditedBy, "EditedBy");
        //.IsNullOrEmpty(email, "Email")
        //.IsEmail(email, "Email");
        //.IsEmail(email, "Email");
        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active)
    {
        Active = active;
        Name = name;

        Validate();
    }
}
