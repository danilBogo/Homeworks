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
    public static class HtmlBuilderExtensions
    {
        public static void GenerateHtmlForm(this HtmlContentBuilder builder, PropertyInfo propertyInfo , object model)
        {
            var id = propertyInfo.Name;
            var display = propertyInfo.GetCustomAttribute<DisplayAttribute>();
            var displayName = display == null ? propertyInfo.Name.SplitFromCamelCase() : display.Name;
            builder.AppendLabel(id, "editor-label", displayName ?? "");
            if (propertyInfo.PropertyType.IsEnum)
                builder.AppendDropDown(Enum.GetNames(propertyInfo.PropertyType), id);
            else
                builder.AppendInput("editor-filed", propertyInfo, model, displayName);
        }

        public  static void AppendLabel(this HtmlContentBuilder builder, string labelName, string divClass,
            string displayName)
        {
            var div = new TagBuilder("div") { Attributes = { { "class", divClass } } };
            var label = new TagBuilder("label") { Attributes = { { "for", labelName } } };
            label.InnerHtml.Append(displayName);
            div.InnerHtml.AppendHtml(label);
            builder.AppendHtml(div);
        }

        public static void AppendInput(this HtmlContentBuilder builder, string divClass,
            PropertyInfo property, object model,string? displayName = null)
        {
            var div = new TagBuilder("div") { Attributes = { { "class", divClass } } };
            var input = GenerateInput(property, model);
            var span = GenerateSpan(property, model, displayName);
            div.InnerHtml.AppendHtml(input);
            div.InnerHtml.AppendHtml(span);
            builder.AppendHtml(div);
        }

        public static TagBuilder GenerateInput(PropertyInfo property, object model)
        {
            var input = new TagBuilder("input")
            {
                Attributes =
                {
                    { "id", property.Name }, { "name", property.Name },
                    { "type", property.PropertyType == typeof(int) ? "number" : "text" },
                    { "class", "v" },
                    { "value", property.GetValue(model)?.ToString() ?? string.Empty }
                }
            };
            return input;
        }

        public static TagBuilder GenerateSpan(PropertyInfo property, object? model,string? displayName = null)
        {
            var errorContent = "";
            var span = new TagBuilder("span");
            var attributes = property.GetCustomAttributes<ValidationAttribute>();
            var isFieldValid = true;
            var indexOfFail = 0;
            var validationAttributes = attributes.ToArray();
            if (validationAttributes.Any())
            {
                foreach (var attribute in validationAttributes)
                {
                    if (!attribute.IsValid(property.GetValue(model)))
                    {
                        isFieldValid = false;
                        break;
                    }
                    indexOfFail++;
                }
            }

            if (!isFieldValid)
            {
                var name = displayName ?? property.Name;
                errorContent = validationAttributes[indexOfFail].ErrorMessage ?? validationAttributes[indexOfFail].FormatErrorMessage(name);
                span.Attributes["class"] = "field-validation-error";
            }
            else
                span.Attributes["class"] = "field-validation-valid";

            span.Attributes["data-valmsg-for"] = property.Name;
            span.InnerHtml.Append(errorContent);
            return span;
        }

        public static void AppendDropDown(this HtmlContentBuilder builder, IEnumerable<string> values, string id)
        {
            var select = GenerateSelect(id);
            var options = GenerateOptions(values);
            foreach (var option in options)
                select.InnerHtml.AppendHtml(option);
            builder.AppendHtml(select);
        }

        public static TagBuilder GenerateSelect(string id)
        {
            return new TagBuilder("select") { Attributes = { { "id", id } } };
        }

        public static IEnumerable<TagBuilder> GenerateOptions(IEnumerable<string> values)
        {
            var options = values.Select(x =>
            {
                var option = new TagBuilder("option") { Attributes = { { "value", x } } };
                option.InnerHtml.AppendHtml(x);
                return option;
            });
            return options;
        }
    }
}