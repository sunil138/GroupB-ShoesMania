namespace PaymentDetails_Mongo.Models
{
    public class PaymentStoreSetting
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string PaymentsCollectionName { get; set; } = null!;
    }
}
