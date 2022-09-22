
using System.ComponentModel;

namespace GaHealthcareNurses.Entity.Common
{
    public enum EmailTemplateType
    {
        Register,
        Forgot,
        JobInvitation,
        JobApplied,
        JobOffer,
        JobOfferAccept,
        JobOfferReject,
        Referral,
        BuyCourses
    }

    public enum EmailSubjectRole
    {
        Invitation,
        InvitationAccept,
        JobOffer,
        JobOfferAccept,
        JobOfferReject,
        [Description("Reset Password")] ResetPassword,
        [Description("Confirmation Email")] ConfirmationEmail,     
        Reply,
        Refferal,
        BuyCourses 
    }
}
