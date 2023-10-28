namespace AnionICation . OArkie
{
  using System;
  using System . Linq;
  using System . Text;

  public struct Oak ( )
  {
    public byte[ ] [ ] [ ] fore = new byte[ ] [ ] [ ] { };
    public byte [ ] tare = new byte[]{ };
    public Encoding code = Encoding . UTF8;
    public static bool Scale<T> ( ref T [ ] aray , long count )
    {
      count = count + aray . GetLength ( 0 );
      Array . Resize ( ref aray , ( int ) count );
      return aray . LongCount ( ) . Equals ( count );
    }
    public static bool Place<T> ( ref T [ ] aray , T oar )
    {
      long length = aray.LongCount() - 1;
      if ( Scale<T> ( ref aray , 1 ) )
      {
        length = aray . LongCount ( ) - 1;
        aray . SetValue ( oar , length );
        return Equal<T> ( ref aray , length , oar );
      }
      return false;
    }
    public static bool Equal<T> ( ref T [ ] ARay , long pal , T oar )
    {
      if( oar is not null)
      {
        return oar . Equals ( ARay [ pal ] );
      }
      return ( ARay [ pal ] is null );
    }
    public static byte [ ] [ ] Sigil ( char? signature = null , char? digit = null , Encoding? encoding = default )
    {
      char oak;
      byte oar;
      string sign = string.Empty;
      byte [ ] thread  = new byte [ ] { }, number = new byte [ ] { };
      byte [ ] [ ] rune = new byte [ 2 ] [ ] { thread , number };
      if (encoding is null )
      {
        encoding = Encoding . UTF8;
      } 
      if ( signature is not null )
      {
        oak = ( char ) signature;
        sign = Convert.ToString( oak );
        thread = encoding . GetBytes ( sign );
        rune [ 0 ] = thread;
      }
      if ( digit is not null )
      {
        oar = ( byte ) digit;
        number = [ oar ];
        rune [ 1 ] = number;
      }
      return rune;
    }
    public void Parse ( string arity , Encoding? codex = default )
    {
      if ( codex is null )
      {
        codex = Encoding . UTF8;
      }
      arity = arity . Trim ( );
      using ( ThreadStream stringStream = new ThreadStream ( arity ) )
      {
        using ( BinaryReader binaryReader = new BinaryReader ( stringStream , codex ) )
        {
          long index = -1, posit = -1, depth = 0, length = fore.LongCount() - 1;
          EnumOar last = EnumOar . Empty;
          char chr;
          while ( binaryReader . PeekChar ( ) is not -1 && Char . IsWhiteSpace ( chr = binaryReader . ReadChar ( ) ) is false )
          {
            EnumOar current = EnumOar . Empty;
   
            if ( Char . IsDigit ( chr ) )
            {
              if ( posit <= length )
              {
                Place<byte [ ] [ ]> ( ref fore , Sigil ( null , chr , codex ) );
                posit++;
              }
              else
              {
                Place<byte> ( ref ( fore [ posit ] [ 1 ] ) , ( byte ) chr );
              }
              Console . WriteLine ( $"Digit: {depth} 0x{( byte ) chr}={chr} " );
            }
            else
            {
              Place<byte [ ] [ ]> ( ref fore , Sigil ( chr , null , codex ) );
              posit++;
              Console . WriteLine ( $"Symbol: {posit} 0x{( byte ) chr}={chr} " );
            }
            index++;
          }
        }
      }
    }
    

    public override string ToString ( )
    {
      StringBuilder stringBuilder = new StringBuilder();
      StringBuilder subStringBuilder = new StringBuilder();
      foreach ( byte [ ] [ ] rune in fore )
      {
        foreach ( byte [ ] isay in rune )
        {
          subStringBuilder . Clear ( );
          foreach ( byte i in isay )
          {
            char chr = ( char ) i;
            if ( Char . IsDigit ( chr ) is false )
            {
              subStringBuilder . Clear ( );
              subStringBuilder . Append ( this . code . GetString ( isay ) );
              break;
            }
            subStringBuilder . Append ( chr );
          }
          stringBuilder . Append ( subStringBuilder . ToString ( ) );
        }
      }
      return stringBuilder . ToString ( );
    }
  }
}
