namespace ProductClientHub.Communication.Requests
{
    public class RequestsClientJson
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // = string.Empty porque o valor da string pode ser nullo, e se for nullo pode dar erro.
    }
}