using Integration.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Repository.Dummies
{
    public class DrugsConsumedRepositoryDummy
    {
        private List<DrugConsumed> drugsConsumed = new List<DrugConsumed>();

        public DrugsConsumedRepositoryDummy()
        {
            drugsConsumed.Add(new DrugConsumed("Brufen", 98, new DateTime(2021, 11, 14)));
            drugsConsumed.Add(new DrugConsumed("Palitrex", 65, new DateTime(2021, 11, 14)));
            drugsConsumed.Add(new DrugConsumed("Amoksicilin", 45, new DateTime(2021, 11, 14)));
            drugsConsumed.Add(new DrugConsumed("Sinacilin", 43, new DateTime(2021, 11, 14)));
            drugsConsumed.Add(new DrugConsumed("Andol", 67, new DateTime(2021, 11, 14)));
            drugsConsumed.Add(new DrugConsumed("Panadol", 65, new DateTime(2021, 11, 14)));
            drugsConsumed.Add(new DrugConsumed("Panklav", 36, new DateTime(2021, 11, 14)));

            drugsConsumed.Add(new DrugConsumed("Brufen", 76, new DateTime(2021, 11, 15)));
            drugsConsumed.Add(new DrugConsumed("Palitrex", 56, new DateTime(2021, 11, 15)));
            drugsConsumed.Add(new DrugConsumed("Amoksicilin", 54, new DateTime(2021, 11, 15)));
            drugsConsumed.Add(new DrugConsumed("Sinacilin", 34, new DateTime(2021, 11, 15)));
            drugsConsumed.Add(new DrugConsumed("Andol", 87, new DateTime(2021, 11, 15)));
            drugsConsumed.Add(new DrugConsumed("Panadol", 67, new DateTime(2021, 11, 15)));
            drugsConsumed.Add(new DrugConsumed("Panklav", 33, new DateTime(2021, 11, 15)));

            drugsConsumed.Add(new DrugConsumed("Brufen", 78, new DateTime(2021, 11, 16)));
            drugsConsumed.Add(new DrugConsumed("Palitrex", 66, new DateTime(2021, 11, 16)));
            drugsConsumed.Add(new DrugConsumed("Amoksicilin", 48, new DateTime(2021, 11, 16)));
            drugsConsumed.Add(new DrugConsumed("Sinacilin", 44, new DateTime(2021, 11, 16)));
            drugsConsumed.Add(new DrugConsumed("Andol", 56, new DateTime(2021, 11, 16)));
            drugsConsumed.Add(new DrugConsumed("Panadol", 75, new DateTime(2021, 11, 16)));
            drugsConsumed.Add(new DrugConsumed("Panklav", 39, new DateTime(2021, 11, 16)));

            drugsConsumed.Add(new DrugConsumed("Brufen", 105, new DateTime(2021, 11, 17)));
            drugsConsumed.Add(new DrugConsumed("Palitrex", 66, new DateTime(2021, 11, 17)));
            drugsConsumed.Add(new DrugConsumed("Amoksicilin", 42, new DateTime(2021, 11, 17)));
            drugsConsumed.Add(new DrugConsumed("Sinacilin", 54, new DateTime(2021, 11, 17)));
            drugsConsumed.Add(new DrugConsumed("Andol", 77, new DateTime(2021, 11, 17)));
            drugsConsumed.Add(new DrugConsumed("Panadol", 64, new DateTime(2021, 11, 17)));
            drugsConsumed.Add(new DrugConsumed("Panklav", 38, new DateTime(2021, 11, 17)));

            drugsConsumed.Add(new DrugConsumed("Brufen", 78, new DateTime(2021, 11, 18)));
            drugsConsumed.Add(new DrugConsumed("Palitrex", 66, new DateTime(2021, 11, 18)));
            drugsConsumed.Add(new DrugConsumed("Amoksicilin", 87, new DateTime(2021, 11, 18)));
            drugsConsumed.Add(new DrugConsumed("Sinacilin", 56, new DateTime(2021, 11, 18)));
            drugsConsumed.Add(new DrugConsumed("Andol", 45, new DateTime(2021, 11, 18)));
            drugsConsumed.Add(new DrugConsumed("Panadol", 56, new DateTime(2021, 11, 18)));
            drugsConsumed.Add(new DrugConsumed("Panklav", 76, new DateTime(2021, 11, 18)));

            drugsConsumed.Add(new DrugConsumed("Brufen", 93, new DateTime(2021, 11, 19)));
            drugsConsumed.Add(new DrugConsumed("Palitrex", 62, new DateTime(2021, 11, 19)));
            drugsConsumed.Add(new DrugConsumed("Amoksicilin", 49, new DateTime(2021, 11, 19)));
            drugsConsumed.Add(new DrugConsumed("Sinacilin", 46, new DateTime(2021, 11, 19)));
            drugsConsumed.Add(new DrugConsumed("Andol", 72, new DateTime(2021, 11, 19)));
            drugsConsumed.Add(new DrugConsumed("Panadol", 60, new DateTime(2021, 11, 19)));
            drugsConsumed.Add(new DrugConsumed("Panklav", 34, new DateTime(2021, 11, 19)));

            drugsConsumed.Add(new DrugConsumed("Brufen", 97, new DateTime(2021, 11, 20)));
            drugsConsumed.Add(new DrugConsumed("Palitrex", 62, new DateTime(2021, 11, 20)));
            drugsConsumed.Add(new DrugConsumed("Amoksicilin", 39, new DateTime(2021, 11, 20)));
            drugsConsumed.Add(new DrugConsumed("Sinacilin", 46, new DateTime(2021, 11, 20)));
            drugsConsumed.Add(new DrugConsumed("Andol", 77, new DateTime(2021, 11, 20)));
            drugsConsumed.Add(new DrugConsumed("Panadol", 60, new DateTime(2021, 11, 20)));
            drugsConsumed.Add(new DrugConsumed("Panklav", 38, new DateTime(2021, 11, 20)));
        }

        public List<DrugConsumed> GetAll()
        {
            return drugsConsumed;
        }
    }
}
