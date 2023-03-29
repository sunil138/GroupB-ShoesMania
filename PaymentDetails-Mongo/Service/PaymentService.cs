using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PaymentDetails_Mongo.Models;

namespace PaymentDetails_Mongo.Service
{
    public class PaymentService
    {
        private readonly IMongoCollection<Payments> _paymentCollection;
        public PaymentService(IOptions<PaymentStoreSetting> paymentStoreSetting)
        {
            var mongoClient = new MongoClient(
                paymentStoreSetting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                paymentStoreSetting.Value.DatabaseName);

            _paymentCollection = mongoDatabase.GetCollection<Payments>(
                paymentStoreSetting.Value.PaymentsCollectionName);
        }
        public async Task<List<Payments>> GetAsync() =>
        await _paymentCollection.Find(_ => true).ToListAsync();

        public async Task<Payments?> GetAsync(string id) =>
             await _paymentCollection.Find(x => x.id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Payments payments) =>
       await _paymentCollection.InsertOneAsync(payments);
        public async Task UpdateAsync(string id, Payments updatedPayment) =>
        await _paymentCollection.ReplaceOneAsync(x => x.id == id, updatedPayment);
        public async Task RemoveAsync(string id) =>
        await _paymentCollection.DeleteOneAsync(x => x.id == id);

        //public Task<List<Payments>> GetPaymentsByUserId(int userId) =>

        //   Task.FromResult(_paymentCollection.AsQueryable()
        //        .Where(x => x.UserId == userId)
        //        .ToList());
    }
}
