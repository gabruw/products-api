using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Domain.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed  public class CollectionLength : ValidationAttribute
    {
        private readonly int _minElements;
        public CollectionLength(int minElements)
        {
            _minElements = minElements;
        }

        public override bool IsValid(object value)
        {
            var list = value as ICollection;
            if (list != null)
            {
                return list.Count >= _minElements;
            }

            return false;
        }
    }
}
