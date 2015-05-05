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
            return string.Format("The file size should not exceed {0}MB", (this.maxSize/(1024*1024)));
        }
        //TODO:Client Validation
    }
}
