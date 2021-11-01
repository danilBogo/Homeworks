using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework7.Models
{
    public static class Extensions
    {
        public static IHtmlContent MyEditorForModel(this IHtmlHelper htmlHelper)
        {
            var builder = new HtmlContentBuilder();
            var model = htmlHelper.ViewData.Model;
            model.GetType().GetProperties().ToList().ForEach(propertyInfo => builder.GenerateHtmlForm(propertyInfo, model));
            return builder;
        }
        public  static string SplitFromCamelCase(this string str)
        {
            return Regex.Replace(str, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }
        
    }
}