namespace WebAPI.Model.Dto.Payment
{
    public class SubscriptionDto
    {
        public long Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public long UserId { get; set; }
    }
}
