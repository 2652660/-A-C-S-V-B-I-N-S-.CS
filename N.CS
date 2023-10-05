namespace A.C;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class N<T> where T : notnull
{
    public static string Space;

    public static class Signatures
    {
        public static Guid Guid = Guid.NewGuid();
        public static (int, int) Alpha = Echo.Tav;
        public static (short, short) Utah = Echo.Shin;
        public static (short, short) Tango = Echo.Vav;
        public static BigInteger Id = BigInteger.Zero;
        public static (TimeSpan, TimeSpan) Bet = Echo.Mem;
        public static (TimeSpan, TimeSpan) Beit = Echo.Mem;
        public static (TimeSpan, TimeSpan) Bethel = Echo.Mem;
        public static string[] Name = Array.Empty<string>();
        public static Memory<(byte, byte)> Romeo = new (byte, byte)[8]{
            Echo.Qof, Echo.Qof,
            Echo.Qof           ,
            Echo.Qof, Echo.Qof,
            Echo.Qof           ,
            Echo.Qof, Echo.Qof
        };
        public static class Echo
        {
            public static (int, int) Tav = (int.MinValue, int.MaxValue);
            public static (short, short) Shin = (short.MinValue, short.MaxValue);
            public static (short, short) Vav = (short.MinValue, short.MaxValue);
            public static (byte, byte) Qof = (byte.MinValue, byte.MaxValue);
            public static (TimeSpan, TimeSpan) Mem = (TimeSpan.MinValue, TimeSpan.MaxValue);
        }
        public static readonly ReadOnlyMemory<char> Space = "(?=\\p{Lu}\\p{Ll})|(?<=\\p{Ll})(?=\\p{Lu})".AsMemory();
        private static StringBuilder stringBuilder = new StringBuilder();

        public static string[] Parse(ReadOnlyMemory<char> UnitName)
        {
            foreach (string UnitElement in UnitName.ToString().Split('.'))
            {
                return Regex.Split(CodeIdentifier.MakeValid(UnitElement), Space.ToString(), RegexOptions.Compiled).Where(A => !string.IsNullOrEmpty(A)).ToArray();
            }
            return Array.Empty<string>();
        }

        public static string Concat(string[] Strings)
        {
            return string.Concat(Strings);
        }

        public static string PascalCase(string[] Camel)
        {
            stringBuilder.Clear();
            foreach (string camel in Camel)
            {
                stringBuilder.Append(CodeIdentifier.MakePascal(camel));
            }
            return stringBuilder.ToString();
        }

        public static string CamelCase(string[] Pascal)
        {

            stringBuilder.Clear();
            stringBuilder.Append(CodeIdentifier.MakeCamel(Pascal.Take(1).Last()));
            foreach (string pascal in Pascal.Skip(1))
            {
                stringBuilder.Append(CodeIdentifier.MakePascal(pascal));
            }
            return stringBuilder.ToString();
        }
    }


    public static Dictionary<BigInteger, string> Names = new Dictionary<BigInteger, string>();
    public static Dictionary<BigInteger, BigInteger[]> NameSpaces = new Dictionary<BigInteger, BigInteger[]>();

    public static Dictionary<BigInteger, TimeSpan> Times = new Dictionary<BigInteger, TimeSpan>();
    public static Dictionary<BigInteger, BigInteger[]> TimeSpaces = new Dictionary<BigInteger, BigInteger[]>();

    public static Dictionary<BigInteger, T> Heads = new Dictionary<BigInteger, T>();
    public static Dictionary<BigInteger, BigInteger[]> HeadSpaces = new Dictionary<BigInteger, BigInteger[]>();

    public N(params T[] H)
    {
        foreach (T E in H)
        {

        }
    }

    public class Name
    {
        public string Log(string On)
        {
            N<T>.Signatures.Id++;
            if (Names.ContainsKey(N<T>.Signatures.Id) is false)
            {
                if (Names.Values.Where(F => F.Equals(On)).LongCount() <= 0)
                {
                    try
                    {
                        Names.Add(N<T>.Signatures.Id, On.ToString());
                        return On;
                    }
                    catch { }
                }
            }
            return string.Empty;
        }

        public HashSet<ReadOnlyMemory<char>> Set()
        {
            HashSet<ReadOnlyMemory<char>> Set = new HashSet<ReadOnlyMemory<char>>();
            foreach (string Label in Names.Values.AsEnumerable())
            {
                Set.Add(Label.AsMemory());
            }
            return Set;
        }
    }

    public class Mark
    {
        private BigInteger Id = BigInteger.MinusOne;
        private bool GetSet = false;
        private bool SetSet = false;

        public BigInteger Get(TimeSpan? timeSpan = null)
        {
            BigInteger TimeSpaceId = BigInteger.MinusOne;
            if (timeSpan == null)
            {
                timeSpan = TimeOnly.FromDateTime(DateTime.Now).ToTimeSpan();
            }
            N<T>.Signatures.Id++;
            if (Times.ContainsKey(N<T>.Signatures.Id) is false)
            {
                try
                {
                    BigInteger TimeSpanId = N<T>.Signatures.Id;
                    Times.Add(N<T>.Signatures.Id, (TimeSpan)timeSpan);
                    TimeSpaceId = N<T>.Signatures.Id++;
                    TimeSpaces.Add(TimeSpaceId, new BigInteger[] { TimeSpanId });
                    return TimeSpaceId;
                }
                catch { }
            }
            return TimeSpaceId;
        }

        public TimeSpan Spance()
        {
            object Map = TimeSpaces[Id].ElementAtOrDefault(2);
            if (default(BigInteger).Equals(Map))
            {
                TimeSpan Start = Times[TimeSpaces[Id].ElementAtOrDefault(0)];
                TimeSpan End = Times[TimeSpaces[Id].ElementAtOrDefault(1)];
                if (default(BigInteger).Equals(End))
                {
                    Set();
                }
                End = Times[TimeSpaces[Id].ElementAtOrDefault(1)];
                TimeSpan Difference = Start - End;
                if (Difference.Nanoseconds > 0)
                {
                    return Difference;
                }
            }
            return Times[TimeSpaces[Id].ElementAtOrDefault(2)];
        }

        public HashSet<ReadOnlyMemory<char>> Set()
        {
            HashSet<ReadOnlyMemory<char>> Set = new HashSet<ReadOnlyMemory<char>>();
            foreach (string Label in Names.Values.AsEnumerable())
            {
                Set.Add(Label.AsMemory());
            }
            return Set;
        }
    }
}
