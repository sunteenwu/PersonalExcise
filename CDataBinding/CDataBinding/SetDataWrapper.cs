using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CDataBinding
{
     //public Set(string ImageSize,string setImageRarity)
        //{
        //     setImageUrl = String.Format("http://gatherer.wizards.com/Handlers/Image.ashx?type=symbol&set={0}&size={1}&rarity={2}",  gathererCode,  ImageSize, setImageRarity);
        //    // setImageUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?size=medium&name=U&type=symbol";
        //     setImageUrl=String.Format("http://gatherer.wizards.com/Handlers/Image.ashx?size={0}&name={1}&type=symbol",ImageSize,setImageRarity);
        //}
    [DataContract]
    public class Set
    {
        public Set(string ImageSize, string setImageRarity)
        {
            setImageUrl = String.Format("http://gatherer.wizards.com/Handlers/Image.ashx?type=symbol&set={0}&size={1}&rarity={2}", gathererCode, ImageSize, setImageRarity);  
        }
        [DataMember(Name = "setImageUrl")]
        public string setImageUrl { get; set; }
        [DataMember(Name = "code")]
        public string code { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "type")]
        public string type { get; set; }
        [DataMember(Name = "border")]
        public string border { get; set; }
        [DataMember(Name = "mkm_id")]
        public int mkm_id { get; set; }
        [DataMember(Name = "booster")]
        public IList<object> booster { get; set; }
        [DataMember(Name = "mkm_name")]
        public string mkm_name { get; set; }
        [DataMember(Name = "releaseDate")]
        public string releaseDate { get; set; }
        [DataMember(Name = "gathererCode")]
        public string gathererCode { get; set; }
        [DataMember(Name = "magicCardsInfoCode")]
        public string magicCardsInfoCode { get; set; }
        [DataMember(Name = "block")]
        public string block { get; set; }
        [DataMember(Name = "oldCode")]
        public string oldCode { get; set; }
        [DataMember(Name = "onlineOnly")]
        public bool? onlineOnly { get; set; }
    }

    [DataContract]
    public class SetDataWrapper
    {
        [DataMember(Name = "sets")]
        public IList<Set> sets { get; set; }
    }
}
