using System;

namespace Application.Product.Delete
{

   public sealed record DeleteProductCommandResponse
   {
        public string Message { get; init; }

        public bool Success { get; set; }

   }
    
}

