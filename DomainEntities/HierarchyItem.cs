using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class HierarchyItem
    {
        [Key]
        public string Id { get; set; }
      //  public string SampleId { get; set; }
        public string Label { get; set; }
        public string HierarchyDefinitionId { get; set; }
        public string ParentId { get; set; }
        public string CostCenter { get; set; }
        public string ExternalId { get; set; }
        public string ExternalId2 { get; set; }

        /// <summary>
        /// inherited GeoLocation class
        /// </summary>
        //public bool IsLocation { get; set; }
        //public bool IsMicroLocation { get; set; }
        //public LocationDocument Location { get; set; }
        //public MicroLocationDocument MicroLocation { get; set; }
        //public bool DisableLocationException { get; set; } = false;
       // public List<string> PositionIds { get; set; }
        public List<Position> Position { get; set; }
        /// <summary>
        /// Ids to get to root hierarchy.
        /// </summary>
      //  public List<string> HierarchyList { get; set; }
    //    public HierarchyItemSettings HierarchyItemSettings { get; set; }
        /// <summary>
        /// Used by export to name file with friendly name.
        /// </summary>
        public string PayrollExportName { get; set; }

        /// <summary>
        /// Linked user Ids used contrain access of user to certain hierarchy items.
        /// </summary>
       // public List<string> LinkedUserIds { get; set; }
        /// <summary>
        /// Linked Employee Ids used to contrain employees to certain hierarchy items when punching in/out.
        /// </summary>
      //  public List<string> LinkedEmployeeIds { get; set; }
        public bool Active { get; set; } = true;
        /// <summary>
        /// this filed is old. we will not use it anymore
        /// </summary>
      //  public List<string> ApprovedIPAddresses { get; set; } = new List<string>();
        /// <summary>
        /// need to prevent a Hierarchy location to be updated by connector
        /// </summary>
        public bool UserModified { get; set; }
        /// <summary>
        /// Used by mobile.
        /// </summary>
        public int Type { get; set; } = 0; //0= hierarchy, 1 = job, 2 = phase
    }
}
