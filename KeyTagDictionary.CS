namespace VINE
{
	using System;
	using System . Collections . Generic;
	using System . Linq;
	using System . Numerics;
	using System . Text;
	using System . Text . Json;
	using System . Threading . Tasks;

	public class KeyTagDictionary
	{
		public BigInteger Identifier = BigInteger.Zero;
		public Dictionary<string, string> KeyIdentity = new Dictionary<string, string>();
		public Dictionary<string, List<string>> IdentityGroup = new Dictionary<string, List<string>>();

		public KeyTagDictionary ( )
		{}

		public BigInteger Identify ( string Key )
		{
			BigInteger Identity = this. Identity ( Key );
			try
			{
				this . Identifier += 1;
				this . KeyIdentity . Add ( Key , this . Identifier . ToString ( ) );
				Identity = this . Identifier;
			} catch { }
			return Identity;
		}

		public BigInteger Identity ( string Key )
		{
			BigInteger Identity = BigInteger . MinusOne;
			if ( this . KeyIdentity . ContainsKey ( Key ) )
			{
				try
				{
					Identity = BigInteger . Parse ( this . KeyIdentity [ Key ] );
				} catch { }
			}
			return Identity;
		}

		public string Identity ( BigInteger Key )
		{
			string Identity = string.Empty;
			if ( this . KeyIdentity . ContainsValue ( Key . ToString ( ) ) )
			{
				try
				{
					Identity = this . KeyIdentity . Where ( i => i . Value == Key . ToString ( ) ) . ToArray ( ) . First ( ) . Key;
				} catch { }
			}
			return Identity;
		}

		public void KeyTags ( string Key , params string [ ] Tags )
		{
			BigInteger keyIdentity = this . Identify ( Key );
			if ( keyIdentity . Equals ( BigInteger . MinusOne ) is false )
			{
				foreach ( string Tag in Tags )
				{
					BigInteger tagIdentity = this . Identify ( Tag );
					if ( this . IdentityGroup . ContainsKey ( keyIdentity . ToString ( ) ) )
					{
						this . IdentityGroup [ keyIdentity . ToString ( ) ] . Add ( tagIdentity . ToString ( ) );
					} else
					{
						this . IdentityGroup . Add ( keyIdentity . ToString ( ) , new List<string> ( new [ ] { tagIdentity . ToString ( ) } ) );
					}
					if ( this . IdentityGroup . ContainsKey ( tagIdentity . ToString ( ) ) )
					{
						this . IdentityGroup [ tagIdentity . ToString ( ) ] . Add ( keyIdentity . ToString ( ) );
					} else
					{
						this . IdentityGroup . Add ( tagIdentity . ToString ( ) , new List<string> ( new [ ] { keyIdentity . ToString ( ) } ) );
					}
				}
			}
		}

		public List<string> Tags ( string Key )
		{
			List<string> Tags = new List<string>();
			BigInteger keyIdentity = this . Identity ( Key );
			if ( keyIdentity . Equals ( BigInteger . MinusOne ) is false )
			{
				foreach ( string tagIdentity in this . IdentityGroup [ keyIdentity . ToString ( ) ] )
				{
					string Tag = this . Identity ( BigInteger.Parse(tagIdentity ));
					if ( string . IsNullOrEmpty ( Tag ) is false )
					{
						Tags . Add ( Tag );
					}
				}
			}
			return Tags;
		}
	}
}
