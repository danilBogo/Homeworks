using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Homework9.Services
{
    public static class ExpressionExtensions
    {
        public static string GetUrlWithPluses(this string url)
        {
            return url.Replace(" ", "+");
        }
    }
}