using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class HiringAggrementsViewModel
    {
        public string Id { get; set; }
        public Boolean? AcknowledgementOfPoliciesAndProcedures { get; set; }
        public Boolean? JobDescription { get; set; }
        public Boolean? GahRegulations { get; set; }
        public Boolean? ConfidientiallyStatement { get; set; }
        public Boolean? DeclinationOfInfluenzaVaccination { get; set; }
        public DateTime? DeclinationOfInfluenzaVaccinationFillingDate { get; set; }
        public Boolean? FireOrSafetyProcedure { get; set; }
        public Boolean? CodeOfEthics { get; set; }
        public Boolean? AbuseNeglectAndExploitationPolicy { get; set; }
        public Boolean? ClientCareInEmergency { get; set; }
        public Boolean? CredibleEvidenceOfAbuseStatement { get; set; }
        public DateTime? CredibleEvidenceFillingDate { get; set; }
        public string Witness { get; set; }
        public string NotaryPublic { get; set; }
        public DateTime? CommissionExpiresOn { get; set; }
        public Boolean? HepatitisBSeries { get; set; }
        public Boolean? RefusedToTakeHepatitisBSeriesInPast { get; set; }
        public Boolean? WantToHaveHepatitisBSeries { get; set; }
        public Boolean? AlreadyHapititisBSeriesDone { get; set; }
        public Boolean? PartnershipForHealth { get; set; }
        public Boolean? CnaAndPcaDutiesAndResponsibilities { get; set; }
        public Boolean? DocumentationOfTrainingAndOrientation { get; set; }
    }
}
