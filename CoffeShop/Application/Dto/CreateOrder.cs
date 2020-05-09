using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class CreateOrder
    {
        public Guid Id { get; set; }
        public bool IsOpen { get; set; }
    }
}
