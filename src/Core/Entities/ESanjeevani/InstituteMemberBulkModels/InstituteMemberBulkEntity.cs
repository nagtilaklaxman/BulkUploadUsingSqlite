namespace Core.Entities.ESanjeevani.InstituteMemberBulkModels
{
    public class InstituteMemberBulkEntity : BulkEntity
    {
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


        public string SubMenuNames { get; set; } // comma seperated menu names


        public string AssignedInstituteID { get; set; }


        public string UserName { get; } // this should be calculated based on userNameCreation logic

        public string UserDistrictShortCode { get; set; }
    }
}

