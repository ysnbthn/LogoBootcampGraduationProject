using BootcampProject.Core.DTOs;
using BootcampProject.Domain.MongoDbEntities;
using System.Collections.Generic;

namespace BootcampProject.DataAccess.MongoDB.Repository.Abstract
{
    public interface ICreditCardPaymentRepository
    {
        void AddUser(User entity);
        void AddCreditCard(User entity);
        void DeleteCreditCard(string email, string cardNumber);
        void UpdateCreditCard(User entity);

        List<CreditCard> GetCreditCardsOfUser(string email);

        ResponseDto MakePayment(User user, double amount);
    }
}
