﻿using Domain.Enums;
using Newtonsoft.Json.Linq;

namespace Application.UseCases.Orders.RegisterOrder
{
    public class RegisterOrderDto
    {
        public string ProductDescription { get; set; }
        public decimal ProductValue { get; set; }
        public int ProductQuantity { get; set; }
        public string UserEmail { get; set; }
        public PaymentType PaymentType { get; set; }
        public JObject Payment { get; set; }
    }
}