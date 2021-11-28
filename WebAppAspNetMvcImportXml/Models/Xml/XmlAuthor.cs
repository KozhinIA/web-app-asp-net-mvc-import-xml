using System.Xml.Serialization;

namespace WebAppAspNetMvcImportXml.Models
{
    [XmlRoot("Author")]
    public class XmlAuthor
    {
        /// <summary>
        /// Id
        /// </summary> 
        [XmlElement("Id")]
        public int Id { get; set; }
    }
}