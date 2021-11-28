using System.Collections.Generic;
using System.Xml.Serialization;

namespace WebAppAspNetMvcImportXml.Models
{
    [XmlRoot("Book")]
    public class XmlBook
    {
        /// <summary>
        /// Название
        /// </summary>    
        [XmlElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// ISBN
        /// </summary>  
        [XmlElement("Isbn")]
        public string Isbn { get; set; }

        /// <summary>
        /// Год издания книги
        /// </summary>  
        [XmlElement("Year")]
        public int Year { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>  
        [XmlElement("Cost")]
        public decimal Cost { get; set; }

        /// <summary>
        /// Тип валюты
        /// </summary> 
        [XmlElement("CurrencyTypeId")]
        public int CurrencyTypeId { get; set; }

        /// <summary>
        /// Жанр
        /// </summary> 
        [XmlElement("GenreId")]
        public int GenreId { get; set; }


        ///// <summary>
        ///// Авторы
        ///// </summary> 
        [XmlArray("Authors")]
        [XmlArrayItem(typeof(XmlAuthor), ElementName = "Author")]
        public virtual List<XmlAuthor> Authors { get; set; }

        ///// <summary>
        ///// Языки
        ///// </summary> 
        [XmlArray("Languages")]
        [XmlArrayItem(typeof(XmlLanguage), ElementName = "Language")]
        public virtual List<XmlLanguage> Languages { get; set; }

        /// <summary>
        /// Архивная запись
        /// </summary>  
        [XmlElement("IsArchive")]
        public bool IsArchive { get; set; }

        /// <summary>
        /// Описание
        /// </summary>    
        [XmlElement("Annotation")]
        public string Annotation { get; set; }

        /// <summary>
        /// Обложка книги
        /// </summary>    
        [XmlElement("BookImage")]
        public XmlBookImage BookImage { get; set; }

    }
}