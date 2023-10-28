using System;
using System.Collections.Generic;
using System . Drawing;
using System.Linq;
using System . Runtime . ConstrainedExecution;
using System.Text;

namespace AnionICation. OArkie
{
    public struct Oar
    {
        private object[] Oary = new object[] { };
        private EnumOar Isai { get; set; } = EnumOar.Empty;
        private byte[] Oars { get; set; } = new byte[] { };

        public Oar() { }

        public Oar(EnumOar Isai)
        {
            this.Isai = Isai;
        }

        public Oar(EnumOar Isai, byte[] Oars)
        {
            this.Isai = Isai;
            this.Oars = Oars;
        }

        public Oar(EnumOar Isai, Oar oar)
        {
            this.Isai = oar.Isai;
            this.Oars = oar.Oars;
        }

        public Oar(EnumOar Isai, Oar[] oar)
        {
            Oar ray = oar.FirstOrDefault(new Oar
            {
                Isai = this.Isai,
                Oars = this.Oars
            });
            this.Isai = ray.Isai;
            this.Oars = ray.Oars;
            Oar[] Ray = oar.Skip(1).ToArray();
            foreach (Oar ARay in Ray)
            {
                Place(ARay, ref Oary);
            }
        }

        public EnumOar Is()
        {
            return this.Isai;
        }

        public byte[] A()
        {
            return this.Oars;
        }

        public Oar An(int Index)
        {
            return (Oar)Oary[Index];
        }

        public EnumOar Is(int Index)
        {
            return this.An(Index).Is();
        }

        public byte[] A(int Index)
        {
            return this.An(Index).A();
        }

        public static bool Place(Oar oar, ref object[] ray)
        {
            long index = 0, count = ray.LongCount();
            object[] Ray;
            if (count < 1)
            {
                ray = [oar];
                return true;
            }
            else
            {
                Ray = new object[count + 1];
                for (; index < count; index++)
                {
                    Ray[index] = ray[index];
                }
                Ray[count] = oar;
                ray = Ray;
                return true;
            }
        }

  public static Oar Type(EnumOar Where, byte [ ] Head, char Tail )
    {
      byte Tailer = (byte)Tail;
      byte[] Tailor = null!;
      EnumOar enumOar = EnumOar.Empty;
      if ( Char . IsLetterOrDigit ( Tail ) )
      {
        if ( Char . IsLetter ( Tail ) )
        {
          if ( Where . Equals ( EnumOar . Thread ) || Where . Equals ( EnumOar . Character ) || Where . Equals ( EnumOar . Identifier ) )
          {
            enumOar = EnumOar . Thread; // Add Tail to Head
            Tailor = new byte [ ] { 0x00 };
          } else
          {
            enumOar = EnumOar . Character; // Tail Stands-alone after Head
          }
        } else
        {
          if ( Where . Equals ( EnumOar . Number ) || Where . Equals ( EnumOar . Constant ) || Where . Equals ( EnumOar . Empty ) )
          {
            enumOar = EnumOar . Constant; // Add Tail to Head
          } else if ( Where . Equals ( EnumOar . Symbol ) || Where . Equals ( EnumOar . Integer ) || Where . Equals ( EnumOar . Punctuate ) || Where . Equals ( EnumOar . Separate ) )
          {
            enumOar = EnumOar . Integer; // Add Tail to Head
          } else if ( Where . Equals ( EnumOar . Character ) || Where . Equals ( EnumOar . Thread ) || Where . Equals ( EnumOar . Token ) || Where . Equals ( EnumOar . Identifier ) )
          {
            enumOar = EnumOar . Identifier; // Add Tail to Head
          } else
          {
            enumOar = EnumOar . Number; // Tail Stands-alone after Head
          }
          if(enumOar.Equals(EnumOar.Number) is false)
          {
            Tailor = new byte [ ] { 0x00 };
          }
        }
      } else
      {
        // Unless Same char Type is repeating.
        if ( Char . IsSymbol ( Tail ) )
        {
          enumOar = EnumOar . Symbol; // Tail Stands-alone after Head
        } else if ( Char . IsSeparator ( Tail ) )
        {
          enumOar = EnumOar . Separate; // Tail Stands-alone after Head
        } else if ( Char . IsPunctuation ( Tail ) )
        {
          enumOar = EnumOar . Punctuate; // Tail Stands-alone after Head
        } else if ( Char . IsWhiteSpace ( Tail ) )
        {
          enumOar = EnumOar . Space; // Tail Stands-alone after Head
        }
        if ( Where . Equals ( enumOar ) )
        {
          Tailor = new byte [ ] { 0x00 };
        }
      }
      if(Tailor is not null )
      {
        Tailor = new byte [ ] { };
        foreach(byte head in Head)
        {
          Oak . Place<byte> ( ref ( Tailor ) , 0 );
          Tailor [ Tailor . LongCount ( ) - 1 ] = head;
        }
        Oak . Place<byte> ( ref ( Tailor ) , Tailer );
        return new Oar ( enumOar , Tailor );
      }
      Tailor = new byte [ ] { Tailer };
      return new Oar ( enumOar , Tailor );
    }

    public static explicit operator object[](Oar oar)
    {
      return new object[] {
        oar.Isai,
        oar.Oars
      };
    }
  }
}