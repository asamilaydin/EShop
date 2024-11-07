using System;

namespace Application.Order.Delete
{
    public sealed record DeleteOrderCommandResponse
    {
        public string Message { get; init; }

        public bool Success { get; set; }

    }
}

