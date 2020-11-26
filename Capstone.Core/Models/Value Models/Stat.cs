using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Capstone.Core.Models.Value_Models
{
    public class Stat
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public int Value { get; set; }

        public int SavingThrow { get; set; }

        [NotMapped]
        public virtual Dictionary<string, int> DerivativeStats { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// I blame dictionaries and EFCore for not working well together
        /// </summary>
        public string DerivativeStatsXml {
            get
            {
                XmlSerializer xs = new XmlSerializer(typeof(Dictionary<string, int>));
                string ans = string.Empty;
                using (StringWriter sw = new StringWriter())
                {
                    xs.Serialize(sw, DerivativeStatsXml);
                    ans = sw.ToString();
                }
                return ans;
            }
            set
            {
                XmlSerializer xs = new XmlSerializer(typeof(Dictionary<string, int>));
                using (XmlReader xr = XmlReader.Create(value))
                {
                    DerivativeStats = xs.Deserialize(xr) as Dictionary<string, int>;
                }
            }
        }
    }
}
