public static char[] InValidIdentifiers(int ini = 0, int fin = 128)
{
    StringBuilder stringBuilder = new StringBuilder();
    for(;ini<fin;ini++)
    {
        stringBuilder.Append(Convert.ToChar(ini));
    }
    return CodeIdentifier.MakeValid(stringBuilder.ToString()).Distinct().ToArray()!;
}
