﻿using System.ComponentModel.DataAnnotations;

namespace Licencias.Presentation.Core.Attributes
{
    public class DateValidation : RegularExpressionAttribute
    {
        public DateValidation()
            : base(GetRegex())
        { }

        private static string GetRegex()
        {
            return @"^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$";
        }
    }
}