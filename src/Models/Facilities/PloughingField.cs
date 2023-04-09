﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Models.Facilities
{
    public class PloughingField : IPlantField
    {
        // Fields
        private Guid _id;
        private readonly int rows;
        private readonly int plantsPerRow;

        // Properties
        public string Name { get; set; }
        public int Capacity { get; }
        public int CurrentAmount { get; set; }

        // Methods
        public void AddResource(IResource plant, int amount)
        {
            if (CurrentAmount + amount > Capacity)
            {
                Console.WriteLine(@"
        This facility does not have the capacity to add that amount of plants.
        Please lower your amount or add another facility.");
            }
            else if (CurrentAmount + amount == Capacity)
            {
                CurrentAmount = CurrentAmount + amount;
                Console.WriteLine("Plants added to field. This field is now at capacity!");
            }
            else
            {
                CurrentAmount = CurrentAmount + amount;
                Console.WriteLine($"Plants added to field. This field is now at {CurrentAmount}/{Capacity} capacity!");
            }
        }

        // Constructor
        public PloughingField(string name)
        {
            _id = Guid.NewGuid();
            Name = name;
            rows = 13;
            plantsPerRow = 5;
            Capacity = rows * plantsPerRow;
            CurrentAmount = 0;
        }
    }
}