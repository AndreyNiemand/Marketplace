using System;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MariElMarketplace.Helpers
{
    public static class EnumHelper
    {

		public static string GetDescription(this Enum value)
		{
			var result = string.Empty;

			if (value != null)
			{
				Type type = value.GetType();
				var names = value.ToString()
					.Split(',')
					.Select(v => v.Replace(" ", string.Empty))
					.ToList();
				var descriptionsBuilder = new StringBuilder();

				if (names.Any())
				{
					foreach (var name in names)
					{
						var field = type.GetField(name);
						if (field != null)
						{
							if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
							{
								descriptionsBuilder.Append(attr.Description);
								if (name != names.Last())
								{
									descriptionsBuilder.Append(", ");
								}
							}
						}
					}
				}
				result = descriptionsBuilder.ToString();
			}

			return result;
		}

	}
}
