using DomainEntities.JsonReadClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.JsonReadClasses
{
    public class Root
    {
        public List<HierarchyDefinition> HierarchyDefinitions { get; set; }
        public List<HierarchyItems> HierarchyItems { get; set; }
        public List<PositionDefinition> PositionDefinitions { get; set; }
    }
}
