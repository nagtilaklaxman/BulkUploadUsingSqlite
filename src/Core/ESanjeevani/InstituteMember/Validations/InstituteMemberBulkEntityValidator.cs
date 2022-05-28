using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Core.ESanjeevani.InstituteMember.Entities;
using FluentValidation;

namespace Core.ESanjeevani.InstituteMember.Validations
{
    public class InstituteMemberBulkEntityValidator : AbstractValidator<InstituteMemberBulkEntity>
    {
        public InstituteMemberBulkEntityValidator()
        {
            DateTime dt;
            //HF Validation
            RuleFor(x => x.HFName)
                .NotEmpty()
                .WithMessage("HF Name can not be blank !");

            RuleFor(x => x.HFName)
                .Must(t => Regex.IsMatch(t, @"^[\w\s]*$"))
                .When(t => !string.IsNullOrWhiteSpace(t.HFName))
                .WithMessage("Invalid character in HF name!");

            RuleFor(x => x.HFShortName)
                .NotEmpty()
                .WithMessage("HF Short Name can not be blank !");

            RuleFor(x => x.HFShortName)
             .Must(t => Regex.IsMatch(t, @"^[a-zA-Z\s]*$"))
             .When(t => !string.IsNullOrWhiteSpace(t.HFShortName))
             .WithMessage("Invalid character in HF Short Name !");

            RuleFor(x => x.HFPhone)
                .NotEmpty()
                .WithMessage("HF Phone can not be blank !");

            RuleFor(x => x.HFPhone)
                .NotEqual(x => x.UserMobile)
                .WithMessage("HF Phone can not be same as User Mobile !");

            RuleFor(x => x.HFTypeId)
                .NotEmpty()
                .WithMessage("HF Type can not be blank !");

            RuleFor(x => x.NIN)
                .NotEmpty()
                .WithMessage("HF NIN can not be blank !");

            RuleFor(x => x.HFEmail)
                .NotEmpty()
                .WithMessage("HF Email can not be blank !");

            RuleFor(x => x.HFEmail)
                .EmailAddress()
                .When(t => !string.IsNullOrWhiteSpace(t.HFEmail))
                .WithMessage("Invalid HF Email !");

            RuleFor(x => x.HFEmail)
                .NotEqual(x => x.UserEmail)
                .When(t => !string.IsNullOrWhiteSpace(t.HFEmail) && !string.IsNullOrWhiteSpace(t.UserEmail))
                .WithMessage("HF Email can not be same as User Email !");

            RuleFor(x => x.HFStateId)
                .NotEmpty()
                .WithMessage("Invalid HF State Name !");


            RuleFor(x => x.HFDistrictId)
                .NotEmpty()
                .WithMessage("Invalid HF District Name !");

            RuleFor(x => x.HFCityId)
                .NotEmpty()
                .WithMessage("Invalid HF City Name !");

            RuleFor(x => x.HFAddress)
                .NotEmpty()
                .WithMessage("HF Address can not be blank !");

            RuleFor(x => x.HFPIN)
                .NotEmpty()
                .WithMessage("HF PIN can not be blank !");

            //User Validation 
            RuleFor(x => x.UserFirstName)
                .NotEmpty()
                .WithMessage("User First Name can not be blank !");

            RuleFor(x => x.UserLastName)
                .NotEmpty()
                .WithMessage("User Last Name can not be blank !");

            RuleFor(x => x.UserMobile)
                .NotEmpty()
                .WithMessage("User Mobile can not be blank !");

            RuleFor(x => x.UserMobile)
                .Matches("^[0-9]{10}$")
                .When(t => !string.IsNullOrWhiteSpace(t.UserMobile))
                .WithMessage("Invalid User Mobile !");

            RuleFor(x => x.UserGenderId)
                .NotEmpty()
                .WithMessage("User Gender can not be blank!");

            RuleFor(x => x.QualificationId)
                .NotEmpty()
                .WithMessage("User Qualification can not be blank!");

            RuleFor(x => x.UserEmail)
                .NotEmpty()
                .WithMessage("User Email can not be blank !");

            RuleFor(x => x.UserEmail)
                .EmailAddress()
                .When(t => !string.IsNullOrWhiteSpace(t.UserEmail))
                .WithMessage("Invalid User Email !");


            RuleFor(x => x.DOB)
                .NotEmpty()
                .WithMessage("User Date of Birth can not be blank !");

            RuleFor(x => x.DOB)
                .Must(x => DateTime.TryParseExact(x, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                .When(x => !string.IsNullOrWhiteSpace(x.DOB))
                .WithMessage("Invalid Date of Birth it should be in DD-MM-YYYY !");

            RuleFor(x => x.UserStateId)
                .NotEmpty()
                .WithMessage("Invalid User State Name !");

            RuleFor(x => x.UserDistrictId)
              .NotEmpty()
              .WithMessage("Invalid User District Name !");

            RuleFor(x => x.UserCityId)
                .NotEmpty()
                .WithMessage("Invalid User City Name !");

            RuleFor(x => x.SpecialityId)
                 .NotEmpty()
                 .WithMessage("Invalid User Specialization / Designation !");

            RuleFor(x => x.UserAddress)
               .NotEmpty()
               .WithMessage("User Address can not be blank !");

            RuleFor(x => x.UserPin)
                .NotEmpty()
                .WithMessage("User PIN can not be blank !");

            RuleFor(x => x.UserAvailableDay)
                .NotEmpty()
                .WithMessage("Invalid Day and Time (Availability)!");

            RuleFor(x => x.UserAvailableFromTime)
                .NotEmpty()
                .WithMessage("Invalid Availability From Time !");

            RuleFor(x => x.UserAvailableToTime)
                .NotEmpty()
                .WithMessage("Invalid Availability To Time !");

            RuleFor(x => x.UserRole)
                .NotEmpty()
                .WithMessage("Invalid Role!");
        }
    }
}


