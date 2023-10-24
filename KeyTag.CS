using System.Dynamic;
using System.Numerics;

public class KeyTag : DynamicObject {
    private static KeyTag? entity{get;set;}=null;
    private BigInteger id{get;set;}=BigInteger.MinusOne;
    private string key{get;set;}=string.Empty;
    private dynamic? tag{get;set;}=null;
    private Dictionary<BigInteger, dynamic>keys{get;set;}=new(){};
    public Dictionary<BigInteger, List<BigInteger>>tags{get;set;}=new(){};
    public static BigInteger Increment()
    {
        return KeyTag.Entity().id+=1;
    }
    public static KeyTag Entity()
    {
        if(KeyTag.entity is null)
        {
            return KeyTag.entity=new KeyTag();
        }
        return KeyTag.entity;
    }
    public BigInteger Id{
        get{return this.id;}
        set{this.id=value;}
    }
    public string Key{
        get{return this.key;}
        set{this.key=value;}
    }
    public dynamic? Tag{
        get{return this.tag;}
        set{this.tag=value;}
    }
    public KeyTag[] Keys(){
        return this.keys.Values.Where(set=>set.Key.GetType().Equals(typeof(string))&&!set.Tag.GetType().Equals(typeof(KeyTag))).Select(t=>t).Cast<KeyTag>().ToArray();
    }
    public string[] Tags(string Key){
        return ((dynamic)this.keys.Values.Where(set=>set.Key.ToString()==key)).Tags();
    }
    public string[] Tags(){
        return this.keys.Values.Where(set=>set.Key.GetType().Equals(typeof(string))&&!set.Tag.GetType().Equals(typeof(KeyTag))).Select(t=>t.Tag.ToString()).Cast<string>().ToArray();
    }
    public dynamic[] KeyTags(){
        return this.keys.Values.Where(set=>set.Tag.GetType().Equals(typeof(KeyTag))||set.Key.GetType().Equals(typeof(KeyTag))).ToArray();
    }
    public override string ToString()
    {
        if(this.Tag is not null){
            return this.Tag.ToString();
        }
        return "\0";
    }
    public static string ToJSON(KeyTag value)
    {
        return value.ToJSON();
    }
    public override bool TryGetMember(GetMemberBinder binder, out dynamic? result)
    {
        string name = binder.Name;
        result = null;
        KeyValuePair<BigInteger,dynamic>entity=keys.Where(k=>k.Value.Key.Equals(name)).FirstOrDefault(new KeyValuePair<BigInteger,dynamic>(BigInteger.MinusOne,new KeyTag(){Id=Increment(),Key=name}));
        if(entity.Key.Equals(BigInteger.MinusOne)){
            try{
                result = keys[entity.Value.id];
                keys.Add(entity.Value.id,entity.Value);
                return true;
            }catch{return false;}
        }
        if(string.IsNullOrEmpty(entity.Value.Key) is false)
        {
            if(entity.Value.Tag is not null)
            {
                if(entity.Value.Tag.GetType().Equals(typeof(string))){
                    result=entity.Value.ToString();
                    return true;
                }
            }else{
                result = entity.Value.Key;
                return true;
            }
        }
        result = keys[entity.Value.Id];
        return true;
    }
    public override bool TrySetMember(SetMemberBinder binder, dynamic? value)
    {
        string name = binder.Name;
        KeyValuePair<BigInteger,dynamic> keyEntity=keys.Where(k=>k.Value.Key.Equals(name)||(value.GetType().Equals(typeof(string))&&k.Value.Key.Equals(value))).FirstOrDefault(new KeyValuePair<BigInteger,dynamic>(BigInteger.MinusOne,null));
        if(keyEntity.Key.Equals(BigInteger.MinusOne)){
            try{
                dynamic keyTags = new KeyTag(){Id=Increment(),Key=name,Tag=value};
                keys.Add(keyTags.id,keyTags);
                keyEntity=new KeyValuePair<BigInteger,dynamic>(keyTags.Id,keyTags);
            }catch{}
        }
        if(value is not null && value.GetType().Equals(typeof(string)) is false)
        {
            KeyValuePair<BigInteger,List<BigInteger>>keyTag=tags.Where(t=>t.Key.Equals(keyEntity.Value.Id)).FirstOrDefault(new KeyValuePair<BigInteger,List<BigInteger>>(BigInteger.MinusOne,new(){keyEntity.Value.Id,value.Id}));
            if(keyTag.Key.Equals(BigInteger.MinusOne)){
                try{
                    tags.Add(keyTag.Value.First(),new(){keyTag.Value.Last()});
                    tags.Add(keyTag.Value.Last(),new(){keyTag.Value.First()});
                    return true;
                }catch{return false;}
            }else{tags[keyTag.Key].Add(value.Id);}
        }
        return true;
    }
}

public static class KeyTagExtensions
{
    public static string ToJSON(this KeyTag value)
    {
        string keySetValue = string.Empty;
        dynamic[] Keys = value.Keys();
        foreach(dynamic Key in Keys)
        {
            dynamic[] keys= Key.Keys();
            keySetValue += ($"\"{Key.Key}\":{{\"{string.Join(",", Key.ToString())}\"}},");
        }
        dynamic[] KeyTags = value.KeyTags();
        foreach(dynamic KeyTag in KeyTags)
        {
            dynamic[] keys = KeyTag.Keys();
            dynamic[] keyTags = KeyTag.KeyTags();
            string keySubSetValue = string.Empty;
            foreach(dynamic key in keys)
            {
                keySubSetValue += ($"\"{key.Key}\":\"{key.ToString()}\",");
            }
            foreach(dynamic Key in keyTags.DistinctBy(key=>key.Key))
            {
                keySubSetValue += ($"\"{Key.Key}\":[\"{string.Join("\",\"", Key.Tags())}\"],");
            }
            keySetValue += ($"\"{KeyTag.Key}\":{{{keySubSetValue.TrimEnd('"',',')}}}");
        }
        return $"{{{keySetValue.TrimEnd('"',',')}}}";
    }
}
