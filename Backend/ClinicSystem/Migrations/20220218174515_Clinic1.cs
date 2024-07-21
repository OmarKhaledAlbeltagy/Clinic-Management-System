using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.Migrations
{
    public partial class Clinic1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppointmentTypeName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    ExtendIdentityUserId = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_ExtendIdentityUserId",
                        column: x => x.ExtendIdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenderName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsuranceName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperationName = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessName = table.Column<string>(maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    JobTitle = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientProfile_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsuranceId = table.Column<int>(nullable: false),
                    PackageName = table.Column<string>(maxLength: 200, nullable: true),
                    ExaminationDiscount = table.Column<bool>(nullable: false),
                    ExaminationDiscountRate = table.Column<float>(nullable: true),
                    FollowupDiscount = table.Column<bool>(nullable: false),
                    FollowupDiscountRate = table.Column<float>(nullable: true),
                    OperationDiscount = table.Column<bool>(nullable: false),
                    OperationDiscountRate = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurancePackage_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedicalHistoryNotice = table.Column<string>(maxLength: 10000, nullable: true),
                    PatientProfileId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_PatientProfile_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedicineName = table.Column<string>(maxLength: 300, nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(maxLength: 10000, nullable: true),
                    PatientProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineHistory_PatientProfile_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurgeryHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurgeryName = table.Column<string>(maxLength: 500, nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(maxLength: 10000, nullable: true),
                    PatientProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgeryHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurgeryHistory_PatientProfile_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientProcess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientProfileId = table.Column<int>(nullable: false),
                    ProcessTypeId = table.Column<int>(nullable: false),
                    InsurancePackageId = table.Column<int>(nullable: true),
                    ProcessDateTime = table.Column<DateTime>(nullable: false),
                    InsuranceDiscount = table.Column<float>(nullable: false),
                    ProcessOriginalPrice = table.Column<decimal>(type: "money", nullable: false),
                    OperationActualPrice = table.Column<decimal>(type: "money", nullable: true),
                    OriginalTotal = table.Column<decimal>(type: "money", nullable: false),
                    TotalAfterDiscount = table.Column<decimal>(type: "money", nullable: false),
                    FollowupAppointment = table.Column<DateTime>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true),
                    extendidentityuserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientProcess_InsurancePackage_InsurancePackageId",
                        column: x => x.InsurancePackageId,
                        principalTable: "InsurancePackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientProcess_PatientProfile_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProcess_ProcessType_ProcessTypeId",
                        column: x => x.ProcessTypeId,
                        principalTable: "ProcessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProcess_AspNetUsers_extendidentityuserId",
                        column: x => x.extendidentityuserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientProfileInsurancePackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientProfileId = table.Column<int>(nullable: false),
                    InsurancePackageId = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProfileInsurancePackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientProfileInsurancePackage_InsurancePackage_InsurancePackageId",
                        column: x => x.InsurancePackageId,
                        principalTable: "InsurancePackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProfileInsurancePackage_PatientProfile_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheifComplaint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheifComplaintExplaination = table.Column<string>(maxLength: 10000, nullable: true),
                    PatientProcessId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheifComplaint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheifComplaint_PatientProcess_PatientProcessId",
                        column: x => x.PatientProcessId,
                        principalTable: "PatientProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrugName = table.Column<string>(maxLength: 1000, nullable: true),
                    Dose = table.Column<string>(maxLength: 1000, nullable: true),
                    PatientProcessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drugs_PatientProcess_PatientProcessId",
                        column: x => x.PatientProcessId,
                        principalTable: "PatientProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Followup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    ExaminationId = table.Column<int>(nullable: false),
                    FollowupId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Followup_PatientProcess_ExaminationId",
                        column: x => x.ExaminationId,
                        principalTable: "PatientProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Followup_PatientProcess_FollowupId",
                        column: x => x.FollowupId,
                        principalTable: "PatientProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryInvestigation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvestigationName = table.Column<string>(maxLength: 500, nullable: true),
                    InvestigationNote = table.Column<string>(maxLength: 10000, nullable: true),
                    ResultNote = table.Column<string>(maxLength: 10000, nullable: true),
                    SuggestedLaboratory = table.Column<string>(maxLength: 200, nullable: true),
                    PatientProcessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryInvestigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryInvestigation_PatientProcess_PatientProcessId",
                        column: x => x.PatientProcessId,
                        principalTable: "PatientProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDiagnosis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiagnosisExplaination = table.Column<string>(maxLength: 10000, nullable: true),
                    PatientProcessId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDiagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalDiagnosis_PatientProcess_PatientProcessId",
                        column: x => x.PatientProcessId,
                        principalTable: "PatientProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientProcessOperation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientProcessId = table.Column<int>(nullable: false),
                    OperationId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 10000, nullable: true),
                    OperationOriginalPrice = table.Column<int>(nullable: false),
                    OperationPriceAfterDiscount = table.Column<int>(nullable: false),
                    DoctorId = table.Column<string>(nullable: true),
                    extendidentityuserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProcessOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientProcessOperation_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProcessOperation_PatientProcess_PatientProcessId",
                        column: x => x.PatientProcessId,
                        principalTable: "PatientProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProcessOperation_AspNetUsers_extendidentityuserId",
                        column: x => x.extendidentityuserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    ProcessTypeId = table.Column<int>(nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(nullable: false),
                    Deposit = table.Column<decimal>(type: "money", nullable: false),
                    Notes = table.Column<string>(maxLength: 2000, nullable: true),
                    AppointmentTypeId = table.Column<int>(nullable: false),
                    PatientProcessId = table.Column<int>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true),
                    extendidentityuserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreAppointment_AppointmentType_AppointmentTypeId",
                        column: x => x.AppointmentTypeId,
                        principalTable: "AppointmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreAppointment_PatientProcess_PatientProcessId",
                        column: x => x.PatientProcessId,
                        principalTable: "PatientProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreAppointment_ProcessType_ProcessTypeId",
                        column: x => x.ProcessTypeId,
                        principalTable: "ProcessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreAppointment_AspNetUsers_extendidentityuserId",
                        column: x => x.extendidentityuserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RadioGraphicExamination",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExaminationName = table.Column<string>(maxLength: 500, nullable: true),
                    ExaminationNote = table.Column<string>(maxLength: 10000, nullable: true),
                    ResultNote = table.Column<string>(maxLength: 10000, nullable: true),
                    SuggestedLaboratory = table.Column<string>(maxLength: 200, nullable: true),
                    PatientProcessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioGraphicExamination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadioGraphicExamination_PatientProcess_PatientProcessId",
                        column: x => x.PatientProcessId,
                        principalTable: "PatientProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ExtendIdentityUserId",
                table: "AspNetUsers",
                column: "ExtendIdentityUserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CheifComplaint_PatientProcessId",
                table: "CheifComplaint",
                column: "PatientProcessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_PatientProcessId",
                table: "Drugs",
                column: "PatientProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Followup_ExaminationId",
                table: "Followup",
                column: "ExaminationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Followup_FollowupId",
                table: "Followup",
                column: "FollowupId",
                unique: true,
                filter: "[FollowupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePackage_InsuranceId",
                table: "InsurancePackage",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryInvestigation_PatientProcessId",
                table: "LaboratoryInvestigation",
                column: "PatientProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDiagnosis_PatientProcessId",
                table: "MedicalDiagnosis",
                column: "PatientProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_PatientProfileId",
                table: "MedicalHistory",
                column: "PatientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineHistory_PatientProfileId",
                table: "MedicineHistory",
                column: "PatientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcess_InsurancePackageId",
                table: "PatientProcess",
                column: "InsurancePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcess_PatientProfileId",
                table: "PatientProcess",
                column: "PatientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcess_ProcessTypeId",
                table: "PatientProcess",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcess_extendidentityuserId",
                table: "PatientProcess",
                column: "extendidentityuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcessOperation_OperationId",
                table: "PatientProcessOperation",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcessOperation_PatientProcessId",
                table: "PatientProcessOperation",
                column: "PatientProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProcessOperation_extendidentityuserId",
                table: "PatientProcessOperation",
                column: "extendidentityuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfile_GenderId",
                table: "PatientProfile",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfileInsurancePackage_InsurancePackageId",
                table: "PatientProfileInsurancePackage",
                column: "InsurancePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfileInsurancePackage_PatientProfileId",
                table: "PatientProfileInsurancePackage",
                column: "PatientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PreAppointment_AppointmentTypeId",
                table: "PreAppointment",
                column: "AppointmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreAppointment_PatientProcessId",
                table: "PreAppointment",
                column: "PatientProcessId",
                unique: true,
                filter: "[PatientProcessId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PreAppointment_ProcessTypeId",
                table: "PreAppointment",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreAppointment_extendidentityuserId",
                table: "PreAppointment",
                column: "extendidentityuserId");

            migrationBuilder.CreateIndex(
                name: "IX_RadioGraphicExamination_PatientProcessId",
                table: "RadioGraphicExamination",
                column: "PatientProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryHistory_PatientProfileId",
                table: "SurgeryHistory",
                column: "PatientProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CheifComplaint");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Followup");

            migrationBuilder.DropTable(
                name: "LaboratoryInvestigation");

            migrationBuilder.DropTable(
                name: "MedicalDiagnosis");

            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "MedicineHistory");

            migrationBuilder.DropTable(
                name: "PatientProcessOperation");

            migrationBuilder.DropTable(
                name: "PatientProfileInsurancePackage");

            migrationBuilder.DropTable(
                name: "PreAppointment");

            migrationBuilder.DropTable(
                name: "RadioGraphicExamination");

            migrationBuilder.DropTable(
                name: "SurgeryHistory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "AppointmentType");

            migrationBuilder.DropTable(
                name: "PatientProcess");

            migrationBuilder.DropTable(
                name: "InsurancePackage");

            migrationBuilder.DropTable(
                name: "PatientProfile");

            migrationBuilder.DropTable(
                name: "ProcessType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
