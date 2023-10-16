namespace StringExtensions
{
    public class StringExtensions
    {
        private Dictionary<Range, char[]> InvalidIdentifier = new Dictionary<Range, char[]>();

        public static string[] Identifiers (this string Value, int ini = 0, int fin = 128)
        {
            string[] identifiers = new string[]{};
            foreach(string value in Value.ToString()!.Split (
                InvalidIdentifiers(ini, fin),
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
            ))
            {
                identifiers = identifiers.Concat(Regex.Split
                (
                    value.ToString()!,
                    @"(?<!^)(?=[A-Z])"
                )).ToArray();
            }
            return identifiers;
        }

        public static char[] InvalidIdentifiers(int ini = 0, int fin = 128)
        {
            Range charRange = new Range(ini, fin);
            if(InvalidIdentifier.ContainsKey(charRange) is false)
            {
                StringBuilder stringBuilder = new StringBuilder();
                for(;ini<fin;ini++)
                {
                    stringBuilder.Append(Convert.ToChar(ini));
                }
                string charMap = stringBuilder.ToString();
                this.InvalidIdentifier.Add(charRange, charMap.Except(CodeIdentifier.MakeValid(charMap)).Distinct().ToArray()!);
            }
            return this.InvalidIdentifier[charRange];
        }
    }
}
