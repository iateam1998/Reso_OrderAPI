using AutoMapper;
using DataService.Model.Entity;
using DataService.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.ServiceAPI
{

    public interface IPaymentService : IBaseService<Payment, PaymentViewModel>
    {
        void CreatePayment(PaymentViewModel payment);
        int CreatePaymentReturnId(PaymentViewModel payment);
    }

    public class PaymentService : BaseService<Payment, PaymentViewModel>, IPaymentService
    {
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public void CreatePayment(PaymentViewModel payment)
        {
            this.Create(payment);
        }

        public int CreatePaymentReturnId(PaymentViewModel payment)
        {
            this.Create(payment);
            return payment.PaymentId;
        }
    }
}
