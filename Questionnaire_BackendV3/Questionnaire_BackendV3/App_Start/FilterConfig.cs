﻿using System.Web;
using System.Web.Mvc;

namespace Questionnaire_BackendV3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}