﻿using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; }

    public Category(string name)
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name", "Nome é obrigatório!");
            //.IsNullOrEmpty(email, "Email")
            //.IsEmail(email, "Email");
            //.IsEmail(email, "Email");
        AddNotifications(contract);
        
        Name = name;
        Active = true;
    }
}
