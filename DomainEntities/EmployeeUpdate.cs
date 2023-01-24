using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class EmployeeUpdate
    {
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// Employee Id from UltiPro
        /// </summary>
        public string IntegrationId { get; set; }
        public long TicksSinceChange { get; set; }

        /// <summary>
        /// When false, user will no longer be able to punch in/out.
        /// </summary>
        public bool Active { get; set; } = true;
        /// <summary>
        /// Employee is allowed to punch from a personal device (vs just use self service settings)
        /// </summary>
        public bool AllowPunchFromPersonalDevice { get; set; } = true;
        /// <summary>
        /// User Email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User password.
        /// </summary>
        [IgnoreDataMember]
        public string Password { get; set; }
        /// <summary>
        /// Use to update password.
        /// </summary>
        public string PasswordUpdate { get; set; }
        /// <summary>
        /// User role used to manage permissions within the Findd platform.
        /// </summary>
       // public UserRole UserRole { get; set; }
        /// <summary>
        /// Assigned user role controlling user access and permissions.
        /// </summary>
        public string UserRoleId { get; set; }
        /// <summary>
        /// User first name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// User last name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// External identifier mapping the Findd user to an external system, such as payroll, time and labor managment, or job managment.
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Pin alphanumeric used to punch in when device is in clock mode
        /// </summary>
        public string ClockPin { get; set; }
        /// <summary>
        /// Biometric settings specific to the user if overriding the account-level biometric settings
        /// </summary>
        //public BiometricSettings BiometricSettings { get; set; } //Override account level settings if not null
        ///// <summary>
        ///// Depricated. Use ContactInfo instead. 
        ///// </summary>
        //public Address Address { get; set; }
        ///// <summary>
        ///// List of FaceSpaces representing the entire biometric space for the user. 
        ///// </summary>
        //[BsonIgnoreIfNull, BsonIgnoreIfDefault]
        //public List<FaceSpace> FaceSpaces { get; set; }
        /// <summary>
        /// List of location ids.
        /// </summary>
      //  [BsonIgnoreIfNull, BsonIgnoreIfDefault]
      //  public List<string> LocationIds { get; set; }
        /// <summary>
        /// Base64 string representation of user profile image
        /// </summary>
      //  [BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public string ProfileImage { get; set; }
        /// <summary>
        /// User profile image id
        /// </summary>
     //   [BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public string ProfileImageID { get; set; }	// gridfs link
        /// <summary>
        /// Constructed url amazon simple storage server
        /// </summary>
     //   [BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public string ProfileImageS3Url { get; set; }
        /// <summary>
        /// The datetime the user first create facespaces and trained the biometric
        /// </summary>
      //  [BsonIgnoreIfNull, BsonIgnoreIfDefault]
        public System.DateTime? BiometricTrainingDate { get; set; }
        /// <summary>
        /// Flag to indicate whether a user is marked as deleted. 
        /// </summary>
        public bool Deleted { get; set; }
        /// <summary>
        /// Flag to indicate whether or not a user is an account user.
        /// </summary>
        public bool AccountUser { get; set; } = false;
        /// <summary>
        /// Flag to indigate whether or not the user is an employee user. 
        /// </summary>
        public bool IsEmployee { get; set; } = true;

        /// <summary>
        /// Administrator user id assigned to the employee for tasks like I9.
        /// </summary>
        public string AssignedAccountUserId { get; set; }
        /// <summary>
        /// Optional I9 status document providing visibility into the process.
        /// </summary>
      //  public I9StatusDocument I9Status { get; set; }
        /// <summary>
        /// Work Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Default Hierarchy item id. it define the employee punch hierarchies
        /// </summary>
        public string DefaultHierarchyItemId { get; set; }
        /// <summary>
        /// Default Hierarchy item Name
        /// </summary>
        public string DefaultHierarchyItemName { get; set; }
        /// <summary>
        /// Punch Permission Hierarchy Item id.  it's a Default Punch hierarchy for employee
        /// </summary>
        public string DefaultPunchHierarchyId { get; set; }
        /// <summary>
        /// Punch Permission Hierarchy Item id. it define the employee punch hierarchies
        /// </summary>
        public string OrganizationHierarchyId { get; set; }
        /// <summary>
        /// Hierarchy id used to organize payroll.
        /// </summary>
        public string PayrollHierarchyItemId { get; set; }
        /// <summary>
        /// Payroll Hierarchy item Name
        /// </summary>
        public string PayrollHierarchyName { get; set; }
        /// <summary>
        /// Default employee position id.
        /// </summary>
        public string DefaultPositionId { get; set; }
        /// <summary>
        /// Ids to get to root hierarchy.
        /// </summary>
       // public List<string> HierarchyList { get; set; }
        //[BsonIgnore, IgnoreDataMember]
        //public List<UserTimecardStatus> UserTimecardStatuses { get; set; }
        ///// <summary>
        ///// User timecards.
        ///// </summary>
        //[BsonIgnore]
        //public List<ObjectTimecardDocument> Timecards { get; set; }
        ///// <summary>
        ///// Used in timecard grouping and calculations
        ///// </summary>
        //[BsonIgnore]
        public string PayGroupId { get; set; }

        /// <summary>
        /// User punch coaching settings
        /// </summary>
        //public UserPunchCoaching UserPunchCoaching { get; set; }
        /// <summary>
        /// Employee pay rate. Employee position pay rate will override employee pay rate.
        /// </summary>
        public double PayRate { get; set; }
        /// <summary>
        /// Employee bill rate. Employee position bill rate will override employee bill rate. 
        /// </summary>
        public double BillRate { get; set; }
        /// <summary>
        /// Overtime factor. Employee position overtime factor will override employee overtime factor.
        /// </summary>
        public double OvertimeBillFactor { get; set; }
        /// <summary>
        /// Doubletime factor. Employee double time factor will override employee double time factor. 
        /// </summary>
        public double DoubleTimeBillFactor { get; set; }
        /// <summary>
        /// Miscellaneous field #1 
        /// </summary>
        public string Field1 { get; set; }
        /// <summary>
        /// Miscellaneous field #2 
        /// </summary>
        public string Field2 { get; set; }
        /// <summary>
        /// Miscellaneous field #3 
        /// </summary>
        public string Field3 { get; set; }
        /// <summary>
        /// Miscellaneous field #4 
        /// </summary>
        public string Field4 { get; set; }
        /// <summary>
        /// List of positions assigned to the user. 
        /// </summary>
        /// 
    //    [HasNoKey]
        public List<Position> Position { get; set; }
        /// <summary>
        /// Shallow link of the position from hierarchy item.
        /// </summary>
     //   public List<string> LinkedPositionIds { get; set; } 
        /// <summary>
        /// User assigned hierarchy Ids used to limit access to employee/user.
        /// </summary>
       //   public List<string> LinkedHierarchyIds { get; set; }
        /// <summary>
        /// Account Id user is attached to.
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// Employee accruals. 
        /// </summary>
      //  public List<EmployeeAccrual> Accruals { get; set; } = new List<EmployeeAccrual>();
        /// <summary>
        /// Used to determine innactive user changes
        /// </summary>
        public long TicksSinceInactivePropsChange { get; set; }
        /// <summary>
        /// Used to determine active user changes
        /// </summary>
        public long TicksSinceActivePropsChange { get; set; }
        public bool PasswordHashed { get; set; } = false;
        /// <summary>
        /// Known user images used for comparison by secondary algorithm
        /// S3 image ids
        /// </summary>
        //  [BsonIgnoreIfNull, BsonIgnoreIfDefault]
      //   public List<string> RecognitionIds { get; set; }
        ///// <summary>
        ///// Employee Hire Date
        ///// </summary>
        public DateTime? HireDate { get; set; }
        ///// <summary>
        ///// Employee Termination Date
        ///// </summary>
        public DateTime? TerminationDate { get; set; }
        public bool FullTime { get; set; }
        public bool Agency { get; set; }
        [IgnoreDataMember]
        public string SSOToken { get; set; }

        /// <summary>
        /// If set to true connector won't update the user
        /// </summary>
        public bool UserModified { get; set; }

        /// <summary>
        /// Supervisor user id, primarially tasked with workforce approvals like time and leave
        /// </summary>
        public string SupervisorId { get; set; }
        /// <summary>
        /// Supervisor during recruiting and onboarding.
        /// </summary>
        public string RecruiterSupervisorId { get; set; }
        /// <summary>
        /// HR Compliance supervisor
        /// </summary>
        public string ComplianceSupervisorId { get; set; }
        /// <summary>
        /// Post-hire client account manager supervisor
        /// </summary>
        public string AccountManagerSupervisorId { get; set; }
        /// <summary>
        /// Payroll supervisor
        /// </summary>
        public string PayrollSupervisorId { get; set; }


        //TODO: Cached names, need updated on user name update
        public string SupervisorName { get; set; }
        public string RecruiterSupervisorName { get; set; }
        public string ComplianceSupervisorName { get; set; }
        public string AccountManagerSupervisorName { get; set; }
        public string PayrollSupervisorName { get; set; }
        /// <summary>
        /// Used in auto-scheduling to give priority to the higher weight
        /// </summary>
        public int ScheduleWeight { get; set; }
        /// <summary>
        /// Settings determining the notifications that are to be sent.
        /// </summary>
      //  public UserNotificationSettings NotificationSettings { get; set; }

        /// <summary>
        /// List of schedule preferences from now into the future. Old preferences are purged. 
        /// </summary>
     //   public List<SchedulePreference> SchedulePreferences { get; set; } = new List<SchedulePreference>();

     //   public ObjectAudit ObjectAudit { get; set; } = new ObjectAudit();

        public string FinddPrivacyAgreementAcknowledgedId { get; set; }
        public string EmployerPrivacyAgreementAcknowledgedId { get; set; }
     //   public List<UserPrivacyAgreementAcknowledgement> UserPrivacyAgreementAcknowledgements { get; set; } = new List<UserPrivacyAgreementAcknowledgement>();
        /// <summary>
        /// Default employee Job id.
        /// </summary>
        public string DefaultJobId { get; set; }
        /// <summary>
        /// Default employee Job name.
        /// </summary>
        public string DefaultJobName { get; set; }
        /// <summary>
        /// Default employee phase id.
        /// </summary>
        public string DefaultPhaseId { get; set; }
        /// <summary>
        /// Default employee phase name.
        /// </summary>
        public string DefaultPhaseName { get; set; }
        public bool RequirePhase { get; set; }
        public string SelectedUserFilter { get; set; }
        public string SelectedPeopleFilter { get; set; }
        public string SelectedCandidateFilter { get; set; }
        //public List<PeopleFilter> PeopleFilters { get; set; } = new List<PeopleFilter>();
        //public List<CredentialFilter> CredentialFilters { get; set; } = new List<CredentialFilter>();
        //public List<UserFilter> UserFilters { get; set; } = new List<UserFilter>();
        public double? WeeklyHours { get; set; }
        public double? DailyHours { get; set; }

        public string OvertimeRuleGroupId { get; set; }

        //[BsonIgnore]
        //public OvertimeRuleGroup OvertimeRuleGroup { get; set; }

        ///// <summary>
        ///// Supervisor expclicit type to access job
        ///// </summary>
        //public SuepervisorJobExplicitTypes JobExplicitTypes { get; set; } = SuepervisorJobExplicitTypes.All;
        ///// <summary>
        ///// Supervisor expclicit access jobIds
        ///// </summary>
        //[BsonIgnoreIfDefault, BsonIgnoreIfNull]
    //    public List<string> ExplicitJobIds { get; set; }
        /// <summary>
        /// Employee's date of birth
        /// </summary>
      //  [BsonIgnoreIfNull]
        public DateTime? DateOfBirth { get; set; }


       // [BsonExtraElements]
      //  public Dictionary<string, dynamic> CatchAll { get; set; }
    }
}

