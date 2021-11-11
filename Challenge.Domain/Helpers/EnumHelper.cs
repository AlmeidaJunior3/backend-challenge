using System;
using System.Linq;

namespace Challenge.Domain.Helpers
{
    public static class EnumHelper
    {
        public static string LerDescricacaoEnum(this Enum value)
        {            
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(false);
                     
            dynamic displayAttribute = null;

            if (attributes.Any())
                displayAttribute = attributes.ElementAt(0);
                        
            return displayAttribute?.Description ?? string.Empty;
        }
    }
}
