﻿namespace Application.UseCases.Orders.ListOrders
{
    public interface IListOrdersUseCase
    {
        Task<List<ListOrdersDto>> Execute();
    }
}
