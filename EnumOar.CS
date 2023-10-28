using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AnionICation. OArkie
{
  public enum EnumOar
  {
    [Description("Empty")]
    Empty,
    [Description("Single Symbol")]
    Symbol,
    [Description("Single Letter")]
    Character,
    [Description("Sequence of Digits")]
    Number,
    [Description("Sequence of Letters")]
    Thread,
    [Description("Sequence of Punctuations")]
    Punctuate,
    [Description("Sequence of Separators")]
    Separate,
    [Description("Quotient of Thread by Pascal and Camel Form")]
    Token,
    [Description("Sequence of White Spaces")]
    Space,
    [Description("Product of Symbol and Tail-Factor Number")]
    Integer,
    [Description("Product of Integer and Tail-Factor Integer")]
    Constant,
    [Description("Product of Letter and Tail-Factor Integer")]
    Identifier
  }
}