using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchoolDB_Assignment_EwertonXavier_w2022.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}