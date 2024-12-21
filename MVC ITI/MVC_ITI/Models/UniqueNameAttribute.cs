using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace MVC_ITI.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)//chek value is null or not
                return null;
            string NewName = value.ToString(); //convert type value from obj to string by Explicit Cast
            //go to db to search in name ==> Do this name is repeated or not
            ITIContext context = new ITIContext();
            Employee dept= context.Employees.FirstOrDefault(e=> e.Name==NewName);
            if (dept != null)// return obj==not null ==> not valid
            {
                return new ValidationResult("Name Must Be Unique");
            }
           return ValidationResult.Success;
           
        }
    }
}
