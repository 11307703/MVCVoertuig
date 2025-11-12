using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Options;
using MVCVoertuig.Models;

namespace MVCVoertuig.CustomValidations
{
    public class CustomBouwjaarValidation : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var list = new List<ModelValidationResult>();

            int bouwJaar = 0;

            if (int.TryParse(context.Model.ToString(), out bouwJaar))
            {
                if (bouwJaar < 1900 || bouwJaar > DateTime.Now.Year)
                {
                    list.Add(new ModelValidationResult("", $"Bouwjaar moet tussen 1900 en {DateTime.Now.Year} liggen"));
                }
                else
                {
                    list.Add(new ModelValidationResult("","Geen geldig bouwjaar"));
                }
            }
            return list;

        }
    }
}
