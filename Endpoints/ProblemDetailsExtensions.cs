using Flunt.Notifications;

namespace IWantApp.Endpoints;

public static class ProblemDetailsExtensions
{                                               //this extende o método da classe, para realizar as conversões
    public static Dictionary <string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications //Retorno de Erro Padrão RFC3231
                .GroupBy(g => g.Key) //Primeiro agrupo todas minhas Keys (campos)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
    }
}
