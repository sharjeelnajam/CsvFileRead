using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePayGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeSupervisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employeeUpdatedFile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IntegrationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicksSinceChange = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    AllowPunchFromPersonalDevice = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClockPin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImageID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImageS3Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BiometricTrainingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    AccountUser = table.Column<bool>(type: "bit", nullable: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
                    AssignedAccountUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultHierarchyItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultHierarchyItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultPunchHierarchyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationHierarchyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollHierarchyItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollHierarchyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultPositionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayRate = table.Column<double>(type: "float", nullable: false),
                    BillRate = table.Column<double>(type: "float", nullable: false),
                    OvertimeBillFactor = table.Column<double>(type: "float", nullable: false),
                    DoubleTimeBillFactor = table.Column<double>(type: "float", nullable: false),
                    Field1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicksSinceInactivePropsChange = table.Column<long>(type: "bigint", nullable: false),
                    TicksSinceActivePropsChange = table.Column<long>(type: "bigint", nullable: false),
                    PasswordHashed = table.Column<bool>(type: "bit", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FullTime = table.Column<bool>(type: "bit", nullable: false),
                    Agency = table.Column<bool>(type: "bit", nullable: false),
                    SSOToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserModified = table.Column<bool>(type: "bit", nullable: false),
                    SupervisorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecruiterSupervisorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplianceSupervisorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountManagerSupervisorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollSupervisorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecruiterSupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplianceSupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountManagerSupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollSupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleWeight = table.Column<int>(type: "int", nullable: false),
                    FinddPrivacyAgreementAcknowledgedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerPrivacyAgreementAcknowledgedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultJobId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultJobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultPhaseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultPhaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequirePhase = table.Column<bool>(type: "bit", nullable: false),
                    SelectedUserFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedPeopleFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedCandidateFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeeklyHours = table.Column<double>(type: "float", nullable: true),
                    DailyHours = table.Column<double>(type: "float", nullable: true),
                    OvertimeRuleGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeUpdatedFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HierarchyItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyDefinitionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalId2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollExportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserModified = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HierarchyItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BasePositionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Copied = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    HierarchyItemId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UseActiveUntilDate = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_positions_HierarchyItems_HierarchyItemId",
                        column: x => x.HierarchyItemId,
                        principalTable: "HierarchyItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeUpdatePosition",
                columns: table => new
                {
                    PositionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    employeeUpdatesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUpdatePosition", x => new { x.PositionId, x.employeeUpdatesId });
                    table.ForeignKey(
                        name: "FK_EmployeeUpdatePosition_employeeUpdatedFile_employeeUpdatesId",
                        column: x => x.employeeUpdatesId,
                        principalTable: "employeeUpdatedFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeUpdatePosition_positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeUpdatePosition_employeeUpdatesId",
                table: "EmployeeUpdatePosition",
                column: "employeeUpdatesId");

            migrationBuilder.CreateIndex(
                name: "IX_positions_HierarchyItemId",
                table: "positions",
                column: "HierarchyItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "EmployeeUpdatePosition");

            migrationBuilder.DropTable(
                name: "employeeUpdatedFile");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "HierarchyItems");
        }
    }
}
