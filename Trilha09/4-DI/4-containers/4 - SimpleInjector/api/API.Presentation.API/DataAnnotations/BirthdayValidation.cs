using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PDG.Presentation.API.DataAnnotations
{
    public sealed class BirthdayValidation : ValidationAttribute, IClientModelValidator
    {
        private string PropertyName { get; }

        public string[] ErrorMessageList = {
            "Data de nascimento inválida. A data máxima é o dia de hoje.",
            "Por favor insira uma data válida no formato yyyy-mm-dd.",
            "Campo obrigatório",
        };

        public BirthdayValidation(string propertyName)
        {
            PropertyName  = propertyName ;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {    
            object birthday = validationContext?                
                .ObjectInstance?
                .GetType()?
                .GetProperty(PropertyName)?
                .GetValue(validationContext.ObjectInstance); 

            if (birthday != null)
            {
                if (DateTime.TryParse(birthday.ToString(), out DateTime date))
                {
                    if(date > DateTime.Now)
                        return GetValidationResultErrorMessage(ErrorMessage ?? ErrorMessageList[0], 
                            validationContext?.DisplayName, 
                            PropertyName);
                    
                    if(date < (DateTime.Now.AddYears(-150)))
                        return GetValidationResultErrorMessage(ErrorMessage ?? ErrorMessageList[0], 
                            validationContext?.DisplayName, 
                            PropertyName);
                }
                else
                {
                    return GetValidationResultErrorMessage(ErrorMessage ?? ErrorMessageList[1], 
                        validationContext?.DisplayName);
                }
            }
            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes.Add("data-val","true");
            context.Attributes.Add("data-val-more-than", GetValidationClientErrorMessage(context));
            context.Attributes.Add("data-val-more-than-field", PropertyName);
        }

        private string GetValidationClientErrorMessage(ClientModelValidationContext context)
        {
            var str = (!string.IsNullOrEmpty(ErrorMessage)) ? ErrorMessage : ErrorMessageList[0];
            return string.Format(str, context.ModelMetadata?.GetDisplayName(), PropertyName);
        }

        private ValidationResult GetValidationResultErrorMessage(string message, string param1 = "", string param2 = "")
        {
            return new ValidationResult(string.Format(message, param1, param2));
        }
    }
}