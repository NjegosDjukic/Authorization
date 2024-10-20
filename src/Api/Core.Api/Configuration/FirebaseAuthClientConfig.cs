namespace Core.API.Configuration;

public class FirebaseAuthClientConfig
{
    public string ApiKey { get; set; }
    public string AuthDomain { get; set; }
    public string DatabaseUrl { get; set; }
    public string ProjectId { get; set; }
    public string StorageBucket { get; set; }
    public string MessagingSenderId { get; set; }
    public string GoogleClientId { get; set; }
    public string FcmApiKey { get; set; }
    public string FcmPushUrl { get; set; }
}