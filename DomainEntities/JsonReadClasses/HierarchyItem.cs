using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.JsonReadClasses
{
    public class HierarchyItems
    {

        public bool IsLocation { get; set; }
        public bool IsMicroLocation { get; set; }
        public object Location { get; set; }
        public object MicroLocation { get; set; }
        public bool DisableLocationException { get; set; }
        public string _id { get; set; }
        public string Label { get; set; }
        public string HierarchyDefinitionId { get; set; }
        public string ParentId { get; set; }
        public string CostCenter { get; set; }
        public string ExternalId { get; set; }
        public object ExternalId2 { get; set; }
        public object PositionIds { get; set; }
        public object Positions { get; set; }
        public object HierarchyItemSettings { get; set; }
        public string PayrollExportName { get; set; }
        public object LinkedUserIds { get; set; }
        public object LinkedEmployeeIds { get; set; }
        public bool Active { get; set; }
        public bool UserModified { get; set; }
        public int Type { get; set; }
    }
}
