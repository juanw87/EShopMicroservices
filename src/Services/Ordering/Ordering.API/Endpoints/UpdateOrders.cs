﻿
using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Ordering.API.Endpoints;
public record UpdateOrderRequest(OrderDto Order);
public record UpdateOrderResponse(bool isSuccess);

public class UpdateOrders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateOrderCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateOrderResponse>();

            return Results.Ok(response);
        })
            .WithName("UpdateOrder")
            .Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update order")
            .WithDescription("Update order");
    }
}
