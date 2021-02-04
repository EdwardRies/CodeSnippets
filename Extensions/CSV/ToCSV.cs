using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTH.Extensions
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Generators a CSV String
        /// Columns are generated in the order of the class properties
        /// Non-Numeric columns are encapulated with quotes
        /// Any column containing a double quote will be escaped to two double quotes
        /// CrLf is added to the end of each line
        /// </summary>
        /// <param name="list">Accepts any IEnumerable<T>.</param>
        /// <param name="limitColumns">Optional Parameter: Limit output to comma delimited list. No spaces before or after commas</param>
        /// <param name="addHeader">Optional Parameter: Specifies where a header should be generated based on the column names</param>
        /// <param name="dateFormat">Optional Parameter: Allows DateTime.ToString formatting. Applies to all date fields</param>
        /// <returns>A string output of a CSV file generated from the IEnumerable<T></returns>
        public static string ToCSV<T>(this IEnumerable<T> list, string limitColumns = "", bool addHeader = false, string dateFormat = "")
        {
            var csvString = string.Empty;

            if (!list.Any())
                return csvString;
            var requiredColumns = !string.IsNullOrEmpty(limitColumns)
                    ? limitColumns.Split(',') : null;

            if (addHeader)
            {
                foreach (var property in list.First().GetType().GetProperties())
                {
                    if (requiredColumns.Any() && !requiredColumns
                        .Contains(property.Name, StringComparer.OrdinalIgnoreCase))
                        continue;
                    csvString += $"\"{property.Name.Replace("\"", "\"\"")}\",";
                }
                csvString = $"{csvString.TrimEnd(',')}\r\n";
            }

            var csvStringBuilder = new StringBuilder();
            foreach (T line in list)
            {
                foreach (var property in line.GetType().GetProperties())
                {
                    if (requiredColumns.Any() && !requiredColumns
                        .Contains(property.Name, StringComparer.OrdinalIgnoreCase))
                        continue;

                    var value = property.GetValue(line, null).ToString().Replace("\"", "\"\""); ;
                    value = !string.IsNullOrEmpty(dateFormat) && IsDate(value) ? GetDate(value, dateFormat) : value;

                    var column = value.ToString().All(char.IsNumber) ? $"{value}" : $"\"{value}\"";
                    csvStringBuilder.Append($"{column},");
                }

                csvString += csvStringBuilder.ToString();
                if (csvString.Any())
                    csvString = $"{csvString.TrimEnd(',')}\r\n";
                csvStringBuilder.Clear();
            }

            return csvString;
        }

        private static bool IsDate(string input)
        {
            return DateTime.TryParse(input, out _);
        }

        private static string GetDate(string input, string dateFormat)
        {
            DateTime.TryParse(input, out DateTime dt);

            return dt.ToString(dateFormat);
        }

    }
}
