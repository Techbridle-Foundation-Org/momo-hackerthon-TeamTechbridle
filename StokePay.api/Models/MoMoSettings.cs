namespace StokePay.api.Models
{
    public class MoMoSettings
    {
        public string BaseUrl { get; set; } = "https://proxy.momoapi.mtn.com";
        public string SubscriptionKey { get; set; } = "01c62724f8424c02a198881a580fb635";
        public string AuthBasic { get; set; } = String.Empty;
        public string TargetEnv { get; set; } = String.Empty;
       
    }
}
