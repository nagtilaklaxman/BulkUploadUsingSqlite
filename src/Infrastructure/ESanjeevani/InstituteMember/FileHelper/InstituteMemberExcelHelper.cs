using Infrastructure.FileHelper;

namespace Infrastructure.ESanjeevani.InstituteMember.FileHelper
{
    public class InstituteMemberExcelHelper : ExcelHelper<InstituteMemberExcelEntity>
    {
        long maxFileSize = 1024 * 1024 * 15;
        public override Task<bool> SaveAsync(Stream stream, string filePath)
        {
            if (stream.Length > maxFileSize)
            {
                return Task.FromResult(false);
            }
            return base.SaveAsync(stream, filePath);
        }
        public override IList<InstituteMemberExcelEntity> Read(string filePath)
        {
            return base.Read(filePath);
        }
        public override bool Write(IList<InstituteMemberExcelEntity> data, string filePath)
        {
            return base.Write(data, filePath);
        }
    }

    public class InstituteMemberExcelEntity
    {
        /// Institute Data

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

        public string HFEmail { get; set; }

        /// User Data


        public string UserFirstName { get; set; }


        public string UserLastName { get; set; }


        public string UserMobile { get; set; }


        public int UserGenderName { get; set; }


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


        public string SubMenuNames { get; set; } // comma seperated menu names


        public string AssignedInstituteID { get; set; }

    }
}

