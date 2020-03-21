﻿using System;
using System.Collections.Generic;

namespace CornNuggets.Entities
{
    public partial class OrderLog
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductQty { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
