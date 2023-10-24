using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class DynamicInteger<T>
{
    private static StringBuilder stringBuilder = new StringBuilder();
    private static BigInteger Ten = new BigInteger(10);
    private static BigInteger Two = new BigInteger(2);
    private static char Peridot = '.';
    private static char Percent = ';';

    // Z
    private (dynamic, dynamic) Center = (BigInteger.Zero, BigInteger.Zero);
    private dynamic [ ] A = Array.Empty<dynamic>(); // PeddleRight: Positive, Right Top, Down Left, Red, Eight
    private dynamic [ ] C = Array.Empty<dynamic>(); // BurnNodules: Negative, Bottom, Up Right, Blue, Ten
    private dynamic [] D = Array.Empty<dynamic>();

    private (BigInteger, BigInteger) Ratio = (BigInteger.Zero, BigInteger.Zero);

    public DynamicInteger ( T X , T Y )
    {
        ((BigInteger, BigInteger), (BigInteger, BigInteger)) Dt = Cross ( X , Y );
        A = [ Dt.Item2.Item1 , Dt.Item2.Item2 ];
        C = [ Dt.Item1.Item1 , Dt.Item1.Item2 ];
    }

    public T R ( int Dimension )
    {
        return ( T ) A.GetValue ( Dimension )!;
    }

    public void R ( int Dimension , T Quantify )
    {
        A.SetValue ( Quantify , Dimension );
    }

    public T B ( int Dimension )
    {
        return ( T ) C.GetValue ( Dimension )!;
    }

    public void B ( int Dimension , T Quantify )
    {
        C.SetValue ( Quantify , Dimension );
    }

    public void CLR ( )
    {
        A = Array.Empty<dynamic> ( );
    }

    public void CLB ( )
    {
        C = Array.Empty<dynamic> ( );
    }

    public void CLD ( )
    {
        D = Array.Empty<dynamic> ( );
    }

    public (BigInteger, BigInteger, BigInteger) Median ( BigInteger R , BigInteger B )
    {
        BigInteger Remainder = R + B;
        BigInteger Quotient = BigInteger.Zero;
        try
        {
            while ( ( Remainder = Remainder - Two ) >= Two )
            {
                Quotient++;
            }
            if ( Remainder == BigInteger.Zero )
            {
                Quotient++;
            }
        } catch { }
        return (Quotient, Remainder, Two);
    }

    public static TimeSpan Time ( )
    {
        return TimeSpan.FromTicks ( TimeOnly.FromDateTime ( DateTime.Now.ToLocalTime ( ) ).ToTimeSpan ( ).Ticks );
    }

    public static (BigInteger,BigInteger) Fraction ( string Decimal )
    {
        stringBuilder.Clear ( );
        string[] Front = Decimal.Split(Peridot);
        string[] Back = new[]{string.Empty,string.Empty};
        if(Front.LongCount() == 2){
            Back = Front.Last().Split(Percent);
        }
        return (BigInteger.Parse(Front.First()), BigInteger.Parse(Back.FirstOrDefault(string.Empty)));
    }

    public static string Fracture ( BigInteger Numerator , BigInteger Divisor , TimeSpan? PrecisionTimeout = null )
    {
        stringBuilder.Clear ( );
        string Head = "";
        BigInteger Remainder = Numerator;
        BigInteger Quotient = BigInteger.One;
        if ( Remainder - Divisor >= 0 )
        {
            while ( ( Remainder = Remainder - Divisor ) >= Divisor )
            {
                Quotient++;
            }
        }
        else if ( Quotient.Equals ( BigInteger.One ) )
        {
            Quotient = BigInteger.Zero;
        }
        stringBuilder.Append ( Quotient.ToString ( ) );
        stringBuilder.Append ( Peridot );
        Head = stringBuilder.ToString ( );
        stringBuilder.Clear ( );
        if ( ( Remainder - Divisor ) <= Divisor )
        {
            bool Timeout = false;
            bool Bar = false;
            BigInteger Recent = BigInteger.Zero;
            TimeSpan TimeSpace = Time();
            while ( Bar is false && Timeout is false )
            {
                if ( PrecisionTimeout is not null && ( Time ( ).Subtract ( TimeSpace ).TotalNanoseconds > PrecisionTimeout.Value.TotalNanoseconds ) )
                {
                    Timeout = true;
                    break;
                    throw new TimeoutException ( );
                }
                Remainder = BigInteger.Multiply ( Remainder , Ten );
                if ( Remainder - Divisor > 0 )
                {
                    while ( ( Remainder = Remainder - Divisor ) >= Divisor )
                    {
                        Recent++;
                    }
                    if ( Remainder < Divisor && Recent > 0 )
                    {
                        Recent++;
                    }
                }
                if ( Recent > BigInteger.Zero )
                {
                    stringBuilder.Append ( Recent );
                    string Tail = stringBuilder.ToString ( );
                    if ( Tail.Length % 2 == 0 )
                    {
                        int Split = ( Tail.Length ) / 2;
                        if ( Tail.Skip ( Split ).ToArray ( ).AsMemory ( ).Span.StartsWith ( Tail.Take ( Split ).ToArray ( ) ) )
                        {
                            Bar = true;
                            break;
                        }
                    }

                    Recent = BigInteger.Zero;
                }
                else
                {
                    stringBuilder.Append ( BigInteger.Zero );
                }

            }
            if ( Remainder > BigInteger.Zero )
            {
                stringBuilder.Append ( Percent );
                stringBuilder.Append ( Remainder.ToString ( ) );
            }
        }
        return $"{Head}{stringBuilder.ToString ( ).TrimEnd ( BigInteger.Zero.ToString ( ).ToCharArray ( ).Last ( ) )}";
    }

    public ((BigInteger, BigInteger), (BigInteger, BigInteger)) Cross ( T R , T B )
    {
        if ( A.Length == C.Length )
        {
            // These two Ifs allow our relative positioning requirements for logic alignment to be met.
            if ( A.Contains ( R ) || C.Contains ( R ) )
            {
                if ( C.Contains ( B ) || A.Contains ( B ) )
                {
                    CLD ( );
                    BigInteger XR = BigInteger.Abs(BigInteger.Parse(new ReadOnlySpan<char>(R.ToString()!.ToCharArray())));
                    BigInteger YB = BigInteger.Abs(BigInteger.Parse(new ReadOnlySpan<char>(B.ToString()!.ToCharArray())));
                    BigInteger YR = BigInteger.Multiply(XR, BigInteger.MinusOne);
                    BigInteger XB = BigInteger.Multiply(YB, BigInteger.MinusOne);
                    (BigInteger,BigInteger,BigInteger) Length = Median(BigInteger.Abs(BigInteger.Min(YR, XB)), BigInteger.Abs(BigInteger.Max(XR, YB)));
                    D.Append ( Length );
                    return ((XR, YB), (YR, XB));
                }
            }
        }
        return ((BigInteger.Zero, BigInteger.Zero), (BigInteger.Zero, BigInteger.Zero));
    }

    public ((BigInteger, BigInteger, BigInteger), (BigInteger, BigInteger, BigInteger)) MedianWholeQuotientRemainder ( ((BigInteger, BigInteger), (BigInteger, BigInteger)) Pair )
    {
        // Mr_ = ( ( ( Y2 + Y1 ) / 2 ), ( ( X2 + X1 ) / 2 ) )
        return (Median ( Pair.Item1.Item1 , Pair.Item2.Item1 ), Median ( Pair.Item1.Item2 , Pair.Item2.Item2 ));
    }

    public BigInteger Step ( ((BigInteger, BigInteger), (BigInteger, BigInteger)) Pair )
    {
        // S = Rise (R) / Bun (B)
        return BigInteger.Parse ( Fracture ( Rise ( Pair ) , Burn ( Pair ) ) );
    }

    public BigInteger Rise ( ((BigInteger, BigInteger), (BigInteger, BigInteger)) Pair )
    {
        // R = (Y2 - Y1)
        return ( Pair.Item1.Item2 - Pair.Item2.Item2 );
    }

    public BigInteger Burn ( ((BigInteger, BigInteger), (BigInteger, BigInteger)) Pair )
    {
        // B = (X2 - X1)
        return ( Pair.Item1.Item1 - Pair.Item2.Item1 );
    }
}
