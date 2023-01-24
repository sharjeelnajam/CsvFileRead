using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class Position
    {
        public string Id { get; set; }
        /// <summary>
        /// Position ID of the copied position.
        /// if it's not null, PositionId should be same with BasePositionId and cannot change Id and Name
        /// </summary>
        public string BasePositionId { get; set; }
        /// <summary>
        /// if position is copied, it's true
        /// </summary>
        public bool Copied { get; set; } = false;
        /// <summary>
        /// When false, position will no longer be available.
        /// </summary>
        public bool Active { get; set; } = true;
        /// <summary>
        /// Hierarchy item this position is attached to. 
        /// </summary>
        public string HierarchyItemId { get; set; }
        /// <summary>
        /// External Id used to map to external system of record.
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// DateTime to allow position. Only used when UseActiveUntilDate is set to true. Once expired, position is marked as inactive.
        /// </summary>
        public DateTime ActiveUntil { get; set; }
        /// <summary>
        /// Set to true to use ActiveUntil property to determine when the position should be marked inactive.
        /// </summary>
        public bool UseActiveUntilDate { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description of the position
        /// </summary>
        public string Description { get; set; }
        public List<EmployeeUpdate> employeeUpdates { get; set; }
        /// <summary>
        /// Cost center 
        /// </summary>
        public string CostCenter { get; set; }
        /// <summary>
        /// List of tasks that can optionally be selected when completing a punch set.
        /// </summary>
       
        /// <summary>
        /// Required list of tasks that must be completed before punching out of a punch set. 
        /// </summary>
      
        /// <summary>
        /// Used when no default payclass is available. 
        /// </summary>
      }
        /// <summary>
        /// color for Schedule
        /// </summary>
    //    public string Color { get; set; }
    //    /// <summary>
    //    /// PayType of Position when no default payclass is available. 
    //    /// </summary>
    //    public string PayTypeId { get; set; }
    //    /// <summary>
    //    /// Default payclass used 
    //    /// </summary>
    //    public PayClass DefaultPayClass { get; set; }
    //    /// <summary>
    //    /// Payclasses defined for this position. Bil rates can be overriden by client and job. Pay rates can be overrideen by employee. 
    //    /// </summary>
    //    public List<PayClass> AvailablePayClasses { get; set; }
    //    /// <summary>
    //    /// If "true", then the position will NOT be sent down to mobile or be available to mobile. This should be in the mobile endpoints only, to avoid the risk of breaking changes elsewhere.
    //    /// </summary> 
    //    public bool HideOnMobile { get; set; } = false;
    //}
}
