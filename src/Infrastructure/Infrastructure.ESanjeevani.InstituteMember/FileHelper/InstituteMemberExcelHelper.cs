using CSharpFunctionalExtensions;
using Domain.Common.Entities;
using Infrastructure.Common.FileHelper;
using OfficeOpenXml;

namespace Infrastructure.ESanjeevani.InstituteMember.FileHelper
{
    public class InstituteMemberExcelHelper : ExcelHelper<InstituteMemberExcelEntity>
    {
        long maxFileSize = 1024 * 1024 * 15;
        private readonly Dictionary<string, string> _columnPropertyMapping;

        public InstituteMemberExcelHelper()
        {
            var obj = new InstituteMemberExcelEntity();
            _columnPropertyMapping = new Dictionary<string, string>()
            {
                { "HF Name", nameof(obj.HFName) },
                { "HF Phone", nameof(obj.HFPhone) },
                { "HF Type", nameof(obj.HFTypeName) },
                { "NIN", nameof(obj.NIN) },
                { "HF Email", nameof(obj.HFEmail) },
                { "State", nameof(obj.HFStateName) },
                { "District", nameof(obj.HFDistrictName) },
                { "City", nameof(obj.HFCityName) },
                { "Address", nameof(obj.HFAddress) },
                { "PIN", nameof(obj.HFPIN) },
                { "First Name", nameof(obj.UserFirstName) },
                { "Last Name", nameof(obj.UserLastName) },
                { "User Mobile", nameof(obj.UserMobile) },
                { "Gender", nameof(obj.UserGenderName) },
                { "Qualification", nameof(obj.QualificationName) },
                { "Experience (in yrs)", nameof(obj.Experience) },
                { "Dr Reg No", nameof(obj.DRRegNo) },
                { "User Email", nameof(obj.UserEmail) },
                { "Specialization / Designation", nameof(obj.SpecialityName) },
                { "Date of Birth DD-MM-YYYY", nameof(obj.DOB) },
                { "User State", nameof(obj.UserStateName) },
                { "User District", nameof(obj.UserDistrictName) },
                { "User City", nameof(obj.UserCityName) },
                { "User Address ", nameof(obj.UserAddress) },
                { "User PIN", nameof(obj.UserPin) },
                { "User Prefix", nameof(obj.UserPrefix) },
                { "Day and Time (Availability)", nameof(obj.UserAvailableDay) },
                { "FromTime", nameof(obj.UserAvailableFromTime) },
                { "To Time", nameof(obj.UserAvailableToTime) },
                { "Role", nameof(obj.UserRole) },
                { "HF Short Name", nameof(obj.HFShortName) },
                { "Sub Menu", nameof(obj.SubMenuNames) }
            };
        }
        public async override Task<Result<bool, BulkError>> SaveAsync(Stream stream, string filePath)
        {
            if (stream.Length == 0)
            {
                return Errors.File.Empty();
            }
            if (stream.Length > maxFileSize)
            {
                return Errors.File.TooLarge(maxFileSize.ToString());
            }
            return await base.SaveAsync(stream, filePath);
        }
        public override IList<InstituteMemberExcelEntity> Read(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            IList<InstituteMemberExcelEntity> returnList = new List<InstituteMemberExcelEntity>();
            var obj = new InstituteMemberExcelEntity();
            var properties = obj.GetType().GetProperties();
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = excelPack.Workbook.Worksheets[0];
                TrimEmptyRows(ws);

                List<string> excelColumnHeaders = GetExcelColumnHeadersByPassingWS(ws);
                if(_columnPropertyMapping.Any())
                {
                    returnList = GetDataForMappedColumns(ws, excelColumnHeaders, properties);
                }
            }
            return returnList;
        }
        private void TrimEmptyRows(ExcelWorksheet worksheet)
        {
            List<int> emptyRows = new List<int>();
            //loop all rows in a file
            for (int i = worksheet.Dimension.Start.Row; i <=
           worksheet.Dimension.End.Row; i++)
            {
                bool isRowEmpty = true;
                //loop all columns in a row
                for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                {
                    if (worksheet.Cells[i, j].Value != null)
                    {
                        isRowEmpty = false;
                        break;
                    }
                }
                if (isRowEmpty)
                {
                    emptyRows.Add(i);
                }
            }

            if (emptyRows.Count > 0)
            {
                worksheet.DeleteRow(emptyRows[0], emptyRows.Count);
            }
        }
        private List<string> GetExcelColumnHeadersByPassingWS(ExcelWorksheet ws)
        {
            if (ws == null) throw new ArgumentNullException(nameof(ws));
            
            List<string> excelColumnHeaders = new List<string>();
            int actualColumns = ws?.Dimension?.End?.Column ?? 0;
            int consideredColumns = 0;

            if (actualColumns == 0)
                return excelColumnHeaders;

            if (ws?.Dimension == null || ws.Dimension.End == null) return excelColumnHeaders;
            
            foreach (var firstRowCell in ws.Cells[2, 1, 1, ws.Dimension.End.Column])
            {
                string firstColumn = firstRowCell.Text;
                excelColumnHeaders.Add(firstColumn);
                consideredColumns++;
            }

            return excelColumnHeaders;
        }
        private IList<InstituteMemberExcelEntity> GetDataForMappedColumns(ExcelWorksheet ws, List<string> excelColumnHeaders, IEnumerable<System.Reflection.PropertyInfo> properties)
        {
            List<InstituteMemberExcelEntity> returnList = new List<InstituteMemberExcelEntity>();
            for (int rowNum = 3; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var returnObject = new InstituteMemberExcelEntity();

                foreach (var mappedPair in _columnPropertyMapping)
                {
                    if (excelColumnHeaders.Contains(mappedPair.Key))
                    {
                        var excelHeaderColumnIndex = excelColumnHeaders.IndexOf(mappedPair.Key);
                        var property = properties.FirstOrDefault(x => x.Name == mappedPair.Value);
                        var excelCellText = ws.Cells[rowNum, excelHeaderColumnIndex + 1].Text?.Trim();
                        if (property != null)
                        {
                            var value = Convert.ChangeType(excelCellText, property.PropertyType);
                            property.SetValue(returnObject, value);
                        }
                    }
                }
                returnList.Add(returnObject);
            }
            return returnList;
        }
        public override bool Write(IList<InstituteMemberExcelEntity> data, string filePath)
        {
            return base.Write(data, filePath);
        }
    }
}

