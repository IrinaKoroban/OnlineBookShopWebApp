using AutoMapper;
using OnLineShop.Db.Interfaces;
using OnLineShopWebApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OnLineShopWebApplication.Helpers
{
    public class EnumHelper
    {

		public static string GetDisplayName(Enum enumValue)
        {
			return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }

    }
}
