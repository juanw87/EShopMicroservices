﻿namespace Ordering.Application.Orders.Queries.GetOrders;
public class GetOrdersHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersQuery, GetOrderResult>
{
    public async Task<GetOrderResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.pageIndex;
        var pageSize = query.PaginationRequest.pageSize;

        var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);

        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)           
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetOrderResult(new PaginatedResult<OrderDto>(pageIndex,pageSize,totalCount,orders.ToOrderDtoList()));
    }
}
