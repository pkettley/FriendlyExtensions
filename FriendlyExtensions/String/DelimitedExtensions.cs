using System.Text;

namespace FriendlyExtensions.Strings
{
    public static partial class StringExtensions
    {
        public static string GetDelimitedField(this string Str, char Quote, char Delimiter, int FieldNo, out int Index)
        {
            Index = 0;
            StringBuilder result = new StringBuilder();
            int strLen = (Str != null) ? Str.Length : 0;
            if (strLen > 0)
            {
                bool inQuote = false;
                int curField = 0;
                while (Index < strLen)
                {
                    char c = Str[Index];
                    if (c == Quote)
                    {
                        inQuote = (inQuote ? false : true);
                    }
                    else
                    {
                        if ((!inQuote) &&
                            (c == Delimiter))
                        {
                            if (curField++ >= FieldNo)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (curField == FieldNo)
                            {
                                result.Append(c);
                            }
                        }
                    }
                    Index++;
                }
            }
            return result.ToString();
        }

        public static string GetDelimitedField(this string Str, char Quote, char Delimiter, int FieldNo)
        {
            int Index;

            return GetDelimitedField(Str, Quote, Delimiter, FieldNo, out Index);
        }
    }
}