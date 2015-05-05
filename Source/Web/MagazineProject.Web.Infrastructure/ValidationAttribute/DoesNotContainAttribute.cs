namespace MagazineProject.Web.Infrastructure.ValidationAttribute
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Property)]
    public class DoesNotContainAttribute : ValidationAttribute
    {
        private string word;

        public DoesNotContainAttribute(string word)
        {
            this.word = word;
            this.ErrorMessage = "{0} should not contain the word " + word;
        }

        public override bool IsValid(object value)
        {
            var valueAsString = value as string;
            if (valueAsString == null)
            {
                //have another attribute like:
                //[MinLength()],
                //[MaxLength()]
                //This attribute check only is word contein in property

                return true;
            }

            if (!valueAsString.Contains(this.word))
            {
                return true;
            }

            return false;
        }

        //TODO:Client Validation
    }
}