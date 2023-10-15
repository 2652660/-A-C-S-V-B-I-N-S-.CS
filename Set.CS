using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;B

namespace VINE
{
    // Value Identity Name Enumeration
    public class Set
    {
        public static BigInteger Id = BigInteger.MinusOne;
        public Dictionary<string, BigInteger> Entity = new();
        public Dictionary<BigInteger, BigInteger> Entities = new();

        public BigInteger Increment()
        {
            return Set.Id++;
        }

        public void Identify(BigInteger name, BigInteger? value = null)
        {
            if(value is not null)
            {
                try
                {
                    this.Entities.Add(name, value.Value);
                }
                catch { }
                if (true)
                {
                    try
                    {
                        this.Entities.Add(value.Value, name);
                    }
                    catch { }
                }
            }
        }

        public BigInteger Quantify(string name)
        {
            BigInteger Id = this.Identity(name);
            if(Id.Equals(BigInteger.MinusOne))
            {
                try
                {
                    this.Entity.Add(name, Id = this.Increment());
                }
                catch { }
            }
            return Id;
        }

        public BigInteger Identity(string name)
        {
            try
            {
                if (this.Entity.ContainsKey(name) is false)
                {
                    return this.Entity[name];
                }
            }
            catch { }
            return BigInteger.MinusOne;
        }

        public string Identity(BigInteger name)
        {
            if (this.Entity.ContainsValue(name))
            {
                try
                {
                    return this.Entity.Where(id => id.Value.Equals(name)).First().Key;
                }
                catch { }
            }
            return string.Empty;
        }

        public BigInteger Add(string name, params object[] members)
        {
            BigInteger id = this.Quantify(name);
            if(!id.Equals(BigInteger.MinusOne))
            {
                foreach (object member in members)
                {
                    string Member = (member as string)!;
                    if (this.Identity(Member).Equals(BigInteger.MinusOne))
                    {
                        BigInteger Entity = this.Quantify(Member);
                        this.Identify(id, Entity);
                    }
                }
            }
            return id;
        }

        public void Add(string[] names, params object[][] elements)
        {
            BigInteger id = BigInteger.MinusOne;
            foreach(string name in names)
            {
                BigInteger identity = BigInteger.Zero;
                foreach (object[] members in elements)
                {
                    foreach (object member in members)
                    {
                        foreach (object[] periods in elements.Except(members))
                        {
                            foreach (object period in periods)
                            {
                                if (period.Equals(member) is false)
                                {
                                    this.Add((member as string)!, (period as string)!);
                                }
                            }
                        }
                        if (id.Equals(identity))
                        {
                            this.Add(name, (member as string)!);
                        }
                    }
                    identity++;
                }
                id++;
            }
        }
    }
}
