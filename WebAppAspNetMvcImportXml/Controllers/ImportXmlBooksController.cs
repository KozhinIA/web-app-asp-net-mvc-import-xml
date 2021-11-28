using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using WebAppAspNetMvcImportXml.Models;

namespace WebAppAspNetMvcImportXml.Controllers
{
    public class ImportXmlBooksController : Controller
    {
        private readonly string _key = "123456Qq";
        [HttpGet]
        public ActionResult Index()
        {
            var model = new ImportXmlBookViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Import(ImportXmlBookViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var file = new byte[model.FileToImport.InputStream.Length];
            model.FileToImport.InputStream.Read(file,0, (int)model.FileToImport.InputStream.Length);

            XmlSerializer xml = new XmlSerializer(typeof(List<XmlBook>));
            var books = (List<XmlBook>)xml.Deserialize(new MemoryStream(file));
            var db = new LibraryContext();

            foreach (var book in books)
            {
                db.Books.Add(new Book()
                {
                    Annotation = book.Annotation,
                    Cost = book.Cost,
                    CreateAt = DateTime.Now,
                    CurrencyTypeId = book.CurrencyTypeId,
                    GenreId = book.GenreId,
                    IsArchive = book.IsArchive,
                    Isbn = book.Isbn,
                    Year = book.Year,
                    Name = book.Name,
                    BookImage = book.BookImage == null ? null : new BookImage()
                    {
                        ContentType = book.BookImage.ContentType,
                        Data = Convert.FromBase64String(book.BookImage.Data),
                        FileName = book.BookImage.FileName
                    },
                    Key = _key
                });

                db.SaveChanges();
            }

            return RedirectPermanent("/Books/Index");
        }

        public ActionResult GetExample()
        {
            return File("~/Content/Files/ImportXmlBooksExample.xml", "application/xml", "ImportXmlBooksExample.xml");
        }

    }
}