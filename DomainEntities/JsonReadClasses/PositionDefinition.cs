using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities.JsonReadClasses
{
    public class PositionDefinition
    {
        public string _id { get; set; }
        public string BasePositionId { get; set; }
        public bool Copied { get; set; }
        public bool Active { get; set; }
        public object HierarchyItemId { get; set; }
        public object ExternalId { get; set; }
        public bool UseActiveUntilDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CostCenter { get; set; }
        public List<object> OptionalTasks { get; set; }
        public List<object> RequiredTasks { get; set; }
        public object PayInfo { get; set; }
        public object Color { get; set; }
        public string PayTypeId { get; set; }
        public object DefaultPayClass { get; set; }
        public object AvailablePayClasses { get; set; }
        public bool HideOnMobile { get; set; }
    }
}
