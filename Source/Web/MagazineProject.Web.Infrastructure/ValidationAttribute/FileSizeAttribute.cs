namespace MagazineProject.Web.Infrastructure.ValidationAttribute
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    [AttributeUsage(AttributeTargets.Property)]
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int maxSize;

        public FileSizeAttribute(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            return (value as HttpPostedFileBase).ContentLength <= this.maxSize;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("The file size should not exceed {0}", this.maxSize);
        }

        // public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        // {
        // yield return new ModelClientValidationRule
        // {
        // ValidationType = "filesizeattribute",
        // ErrorMessage = this.ErrorMessage
        // };
        // }
        // public  Enumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        // {
        // //string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
        // string errorMessage = ErrorMessageString;

        // // The value we set here are needed by the jQuery adapter
        // ModelClientValidationRule dateGreaterThanRule = new ModelClientValidationRule();
        // dateGreaterThanRule.ErrorMessage = errorMessage;
        // dateGreaterThanRule.ValidationType = "dategreaterthan"; // This is the name the jQuery adapter will use
        // //"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
        // dateGreaterThanRule.ValidationParameters.Add("otherpropertyname", otherPropertyName);

        // yield return dateGreaterThanRule;
        // }
        // public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        // {
        // var modelClientValidationRule = new ModelClientValidationRule
        // {
        // ValidationType = "filesize",
        // ErrorMessage = this.ErrorMessage //Added
        // };

        // modelClientValidationRule.ValidationParameters.Add("param", this.maxSize); //Added
        // return new List<ModelClientValidationRule> { modelClientValidationRule };
        // }
    }
}
