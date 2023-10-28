namespace AnionICation
{
  using System;

  public class ThreadStream : MemoryStream, IDisposable
  {
    private StreamWriter streamWriter;

    public ThreadStream ( )
    {
      this . streamWriter = new StreamWriter ( this );
    }

    public ThreadStream ( string Thread ) : this ( )
    {
      this . WriteThread ( Thread );
      this . Rewind ( );
    }

    public void WriteThread ( string Thread )
    {
      this . streamWriter . Write ( Thread );
      this . streamWriter . Flush ( );
    }

    public void Rewind ( )
    {
      this . Position = 0;
    }

    public new void Dispose ( )
    {
      this . streamWriter . Dispose ( );
    }
  }
}
