using ClinicSystem.Privilage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("PatientProcess")]
    public class PatientProcess
    {
        public int Id { get; set; }

        public int PatientProfileId { get; set; }

        public PatientProfile patient { get; set; }

        public int ProcessTypeId { get; set; }

        public ProcessType processType { get; set; }

        public int? InsurancePackageId { get; set; }

        public InsurancePackage insurancePackage { get; set; }

        public DateTime ProcessDateTime { get; set; }

        public float InsuranceDiscount { get; set; }

        [Column(TypeName = "money")]
        public decimal ProcessOriginalPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? OperationActualPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal OriginalTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalAfterDiscount { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FollowupAppointment { get; set; }

        public CheifComplaint cheifComplaint { get; set; }

        public ICollection<MedicalDiagnosis> diagnoses { get; set; }

        public ICollection<Drugs> drugs { get; set; }

        //[ForeignKey("FollowupId")]
        public Followup followupF { get; set; }

        //[ForeignKey("ExaminationId")]
        public Followup followupE { get; set; }

        public string DoctorId { get; set; }

        public ExtendIdentityUser extendidentityuser { get; set; }

        public ICollection<LaboratoryInvestigation> laboratoryInvestigations { get; set; }

        public ICollection<PatientProcessOperation> patientProcessOperations { get; set; }

        public ICollection<RadioGraphicExamination> radioGraphicExaminations { get; set; }

        public PreAppointment preAppointment { get; set; }
    }
}
