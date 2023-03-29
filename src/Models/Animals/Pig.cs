﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models.Animals
{
    public class Pig : IGrazing
    {
        // Fields
        private Guid _id;

        // Properties
        public double FeedPerDay { get; set; }
        public IFacility Location { get; set; }
        public Dictionary<string, double> Product { get; set; }


        // Constructor
        public Pig(GrazingField field)
        {
            _id = Guid.NewGuid();
            FeedPerDay = 3.2;
            Location = field;
            Product = new()
            {
                {"Meat", 8.4}
            };
        }

        // Methods

    }
}