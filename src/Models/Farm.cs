using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models
{
    public class Farm
    {
        public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();
        public List<PlowingField> PlowingFields { get; } = new List<PlowingField>();
        public List<NaturalField> NaturalFields { get; } = new List<NaturalField>();

        /*
            This method must specify the correct product interface of the
            resource being purchased.
         */
        public void PurchaseResource<T>(IResource resource, int index)
        {
            Console.WriteLine(typeof(T).ToString());
            switch (typeof(T).ToString())
            {
                case "Cow":
                    GrazingFields[index].AddResource((IGrazing)resource);
                    break;
                default:
                    break;
            }
        }

        public void AddGrazingField(GrazingField field)
        {
            GrazingFields.Add(field);
        }

        public void AddPlowingField(PlowingField field)
        {
            PlowingFields.Add(field);
        }
        public void AddNaturalField(NaturalField field)
        {
            NaturalFields.Add(field);
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            GrazingFields.ForEach(gf => report.Append(gf));
            PlowingFields.ForEach(gf => report.Append(gf));
            NaturalFields.ForEach(gf => report.Append(gf));


            return report.ToString();
        }
    }
}