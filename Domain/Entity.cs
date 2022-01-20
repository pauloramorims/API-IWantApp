using Flunt.Notifications;

namespace IWantApp.Domain;

public abstract class Entity : Notifiable<Notification>//abstact faz com que a classe não seja instanciada apenas Herdada.
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; set; } //estilo de um hash, lado ruim que n é performático
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreateOn { get; set; }
    public string EditedBy { get; set; }
    public DateTime EditedOn { get; set; }
}
