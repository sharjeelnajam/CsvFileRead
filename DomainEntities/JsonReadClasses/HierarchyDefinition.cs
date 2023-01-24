using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.JsonReadClass
{
    public class HierarchyDefinition
    {
        public string _id { get; set; }
        public int Level { get; set; }
        public string Label { get; set; }
        public bool EnableLocations { get; set; }
        public bool EnableMicroLocations { get; set; }
        public bool EnablePositions { get; set; }
        public bool EnableEmployees { get; set; }
        public bool EnableAccountUsers { get; set; }
        public bool EnablePunches { get; set; }
        public bool EnableJob { get; set; }
        public string MessageForDisablePunches { get; set; }
    }
   
}
