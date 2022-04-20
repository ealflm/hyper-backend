﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TourismSmartTransportation.Data.Models
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            ServiceDetails = new HashSet<ServiceDetail>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; }
    }
}
