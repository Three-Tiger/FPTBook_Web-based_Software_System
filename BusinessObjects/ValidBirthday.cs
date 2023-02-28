using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class ValidBirthday : ValidationAttribute
	{
		protected override ValidationResult
				IsValid(object value, ValidationContext validationContext)
		{
			DateTime birthDay = Convert.ToDateTime(value);
			if (birthDay < DateTime.Now)
			{
				return ValidationResult.Success;
			}
			else
			{
				return new ValidationResult
					("Birthday can not be greater than current date.");
			}
		}
	}
}
