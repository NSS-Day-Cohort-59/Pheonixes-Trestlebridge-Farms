using System;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseEitherField
    {
        public static void CollectInput(Farm farm, ISeedProducing plant)
        {
            Utils.Clear();
            if (farm.PlowingFields.Count > 0 || farm.NaturalFields.Count > 0)
            {
                for (int i = 0; i < farm.PlowingFields.Count; i++)
                {
                    int plantCount = farm.PlowingFields[i].rows.Count();

                    Console.WriteLine($"{i + 1}. Plowing Field ({plantCount} rows of plants).");
                }

                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    int plantCount = farm.NaturalFields[i].rows.Count();

                    Console.WriteLine($"{i + 1 + farm.PlowingFields.Count}. Natural Field ({plantCount} rows of plants).");
                }

                Console.WriteLine();

                // How can I output the type of plant chosen here?
                Console.WriteLine($"Place the {plant.GetType().Name} where?");

                Console.Write("> ");
                int choice;
                bool stuff = Int32.TryParse(Console.ReadLine(), out choice);

                if (stuff && choice <= farm.PlowingFields.Count())
                {
                    if(farm.PlowingFields[choice-1].Capacity == 0) {
                        Console.WriteLine("Field full come back later");
                        Console.ReadLine();
                    }
                    else {
                        List<ISeedProducing> plantsToPass = new List<ISeedProducing>();
                        plantsToPass.Add(plant);
                        plantsToPass.Add(plant);
                        plantsToPass.Add(plant);
                        plantsToPass.Add(plant);
                        plantsToPass.Add(plant);
                        farm.PlowingFields[choice - 1].AddResource(plantsToPass);
                
                    }
                }
                else if (stuff && choice > farm.PlowingFields.Count() && choice <= farm.PlowingFields.Count() + farm.NaturalFields.Count())
                {
                    if(farm.NaturalFields[choice-1].Capacity == 0) {
                        Console.WriteLine("Field full come back later");
                        Console.ReadLine();
                    }
                    else {
                        List<ISeedProducing> plantsToPass = new List<ISeedProducing>();
                        plantsToPass.Add(plant);
                        plantsToPass.Add(plant);
                        plantsToPass.Add(plant);
                        plantsToPass.Add(plant);
                        plantsToPass.Add(plant);
                        plantsToPass.Add(plant);
                        farm.NaturalFields[choice - 1].AddResource(plantsToPass);
                
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Press enter to return to main menu.  You suck.");
                    Console.ReadLine();
                }

                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                 */
                // farm.PurchaseResource<IGrazing>(plant, choice);
            }
            else
            {
                Console.WriteLine("No plowing fields present.  Please add a plowing field and try again.");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
        }
    }
}