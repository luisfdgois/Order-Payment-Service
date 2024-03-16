﻿using Application.UseCases.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Orders.ListOrders
{
    public class ListOrdersUseCase : IListOrdersUseCase
    {
        private readonly DbContext _dbContext;

        public ListOrdersUseCase(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderDto>> Execute()
        {
            return await _dbContext.Set<Order>()
                                   .Include(o => o.Payment)
                                   .AsNoTrackingWithIdentityResolution()
                                   .Select(o => new OrderDto(o.Id, o.Payment.Status, o.ProductDescription, o.ProductValue,
                                                             o.ProductQuantity, o.UserEmail, o.CreatedOn, o.LastUpdate))
                                   .ToListAsync();
        }
    }
}