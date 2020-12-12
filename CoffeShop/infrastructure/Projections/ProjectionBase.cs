using Domain.Events;
using Framework;
using LiquidProjections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.Projections
{
    class ProjectionBase
    {
        public void SetProjection() {
            var mapBuilder = new EventMapBuilder<DbContext>();

            mapBuilder.Map<OrderCreated> ().As(ctx =>
            {

            });
        }
    }
}
