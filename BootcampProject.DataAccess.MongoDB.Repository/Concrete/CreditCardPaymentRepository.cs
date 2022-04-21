using BootcampProject.Core.DTOs;
using BootcampProject.DataAccess.MongoDB.Repository.Abstract;
using BootcampProject.Domain.MongoDbEntities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BootcampProject.DataAccess.MongoDB.Repository.Concrete
{
    public class CreditCardPaymentRepository : ICreditCardPaymentRepository
    {
        private readonly IMongoCollection<User> _users;
        
        public CreditCardPaymentRepository(IUserStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            
            _users = database.GetCollection<User>(settings.CollectionName);
        }

        public void AddUser(User user)
        {
            _users.InsertOne(user);
        }

        public void AddCreditCard(User user)
        {
            user.CreditCards[0].Balance = 10000d;
            var filter = Builders<User>.Filter.Eq(x => x.Email, user.Email);
            var cardToAdd = Builders<User>.Update.Push("CreditCards", user.CreditCards[0]);
            _users.UpdateOne(filter, cardToAdd);
        }

        public List<CreditCard> GetCreditCardsOfUser(string email)
        {
            return _users.Find(x => x.Email == email).FirstOrDefault().CreditCards.ToList();
        }

        public void DeleteCreditCard(string email, string cardNumber)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Email, email);
            var cardToDelete = Builders<User>.Update.PullFilter(x => x.CreditCards, y => y.CardNumber == cardNumber);
            _users.UpdateOne(filter, cardToDelete);
        }

        public ResponseDto MakePayment(User entity, double amount)
        {
            var filter = Builders<User>.Filter.Where(x => x.Email == entity.Email && x.CreditCards.Any(y => y.CardNumber == entity.CreditCards[0].CardNumber &&
                                                                                                            y.CVV == entity.CreditCards[0].CVV &&
                                                                                                            y.Expiry == entity.CreditCards[0].Expiry));

            var user = _users.Find(filter).FirstOrDefault();
            if (user == null) return new ResponseDto { Success = false, Error = "Card information is not correct"};

            var card =   user.CreditCards.FirstOrDefault(x => x.CardNumber == entity.CreditCards[0].CardNumber);

            if(card.Balance < amount)
            {
                return new ResponseDto { Success = false, Error = "Insufficient balance" };
            }

            var cardToUpdate = Builders<User>.Update.Set(x => x.CreditCards[-1].Balance, card.Balance - amount);

            var result = _users.UpdateOne(filter, cardToUpdate);

            if (!result.IsAcknowledged) return new ResponseDto { Success = false, Error = "Problem occured during payment please try again."};

            return new ResponseDto { Success = true, Data = "Payment recieved" };
        }

        public void UpdateCreditCard(User entity)
        {
            var filter = Builders<User>.Filter.Where(x => x.Email == entity.Email && x.CreditCards.Any(y => y.CardNumber == entity.CreditCards[0].CardNumber));

            var cardToUpdate = Builders<User>.Update.Set(x => x.CreditCards[-1].Balance, entity.CreditCards[0].Balance);
        }
    }
}
