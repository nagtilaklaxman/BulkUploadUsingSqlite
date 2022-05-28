using System;
using Core.Entities;

namespace Core.ESanjeevani.InstituteMember.ViewModels
{
    public class InstituteMemberBulkEntityVM
    {
        public int Id { get; set; }

        public string HFName { get; set; }


        public string HFShortName { get; set; }


        public string HFPhone { get; set; }

        public int HFTypeName { get; set; }

        public string NIN { get; set; }

        public int HFStateName { get; set; }

        public int HFDistrictName { get; set; }

        public int HFCityName { get; set; }



        public string HFAddress { get; set; }


        public string HFPIN { get; set; }

        /// User Data


        public string UserFirstName { get; set; }


        public string UserLastName { get; set; }


        public string UserMobile { get; set; }


        public int UserGender { get; set; }


        public int QualificationName { get; set; }


        public string Experience { get; set; }


        public string DRRegNo { get; set; }


        public string UserEmail { get; set; }


        public int SpecialityName { get; set; }


        public string DOB { get; set; }


        public int UserStateName { get; set; }

        public int UserDistrictName { get; set; }

        public int UserCityName { get; set; }

        public string UserAddress { get; set; }


        public string UserPin { get; set; }


        public string UserPrefix { get; set; }


        public string UserAvailableDay { get; set; }


        public string UserAvailableFromTime { get; set; }


        public string UserAvailableToTime { get; set; }


        public string UserRole { get; set; }


        public string SubMenuNames { get; set; }

        // Dont know detail about this. need to check
        public string AssignedInstituteID { get; set; }

        public bool HasError { get; set; } = false;

    }
    public class BulkEntityValidationVM
    {
        public int BulkEntityId { get; set; }
        public string PropertyName { get; set; }
        public string ErrorMessge { get; set; }
    }
    public class EditInstituteMemberBulkEntityVM
    {
        public int Id { get; set; }

        /// Institute Data

        public string HFName { get; set; }


        public string HFShortName { get; set; }


        public string HFPhone { get; set; }

        public int HFTypeId { get; set; }

        public string NIN { get; set; }

        public int HFStateId { get; set; }

        public int HFDistrictId { get; set; }

        public int HFCityId { get; set; }



        public string HFAddress { get; set; }


        public string HFPIN { get; set; }

        /// User Data


        public string UserFirstName { get; set; }


        public string UserLastName { get; set; }


        public string UserMobile { get; set; }


        public int UserGenderId { get; set; }


        public int QualificationId { get; set; }


        public string Experience { get; set; }


        public string DRRegNo { get; set; }


        public string UserEmail { get; set; }


        public int SpecialityId { get; set; }


        public string DOB { get; set; }


        public int UserStateId { get; set; }

        public int UserDistrictId { get; set; }

        public int UserCityId { get; set; }

        public string UserAddress { get; set; }


        public string UserPin { get; set; }


        public string UserPrefix { get; set; }


        public string UserAvailableDay { get; set; }


        public string UserAvailableFromTime { get; set; }


        public string UserAvailableToTime { get; set; }


        public string UserRole { get; set; }


        public string SubMenuNames { get; set; } //comma seperated Ids of menu


        public string AssignedInstituteID { get; set; }
    }
}

