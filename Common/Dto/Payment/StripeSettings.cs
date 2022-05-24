namespace Common.Dto.Payment
{
    public class StripeSettings
    {
        public string PublicKey { get; set; } = string.Empty;
        public string WHSecret { get; set; } = string.Empty;
    }
}
