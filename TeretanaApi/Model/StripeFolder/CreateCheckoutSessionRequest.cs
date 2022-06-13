namespace TeretanaApi.Model.StripeFolder
{
    public class CreateCheckoutSessionRequest
    {
        public Dictionary<string,int> Prices { get; set; }
        public string FailureUrl { get; set; }
        public string SuccessUrl { get; set; }
        public string ClientReferenceId { get; set; }
    }
}
