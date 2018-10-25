using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3.Models.EntityFramework;
using TP3.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace UnitTestWS
{
    [TestClass]
    public class UnitTest1
    {
        private FilmRatingsDBContext _context;
        private ComptesController _controller;

        public UnitTest1()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseSqlServer("Server = localhost\\SQLEXPRESS; Database = FilmRatingsDB; Trusted_Connection = True; ");
            _context = new FilmRatingsDBContext(builder.Options);
            _controller = new ComptesController(_context);
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsOkObjectResultResult()
        {
            // Act
            var result = _controller.GetCompteById(1).Result;
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un Compte");
        }

        [TestMethod]
        public async Task GetById_ExistingIdPassed_ReturnsRightItemAsync()
        {
            // Act
            var result = _controller.GetCompteById(1).Result as OkObjectResult;
            // Assert
            var expectedValue = await _context.Compte.SingleOrDefaultAsync(m => m.CompteId == 1);

            Assert.IsInstanceOfType(result.Value, typeof(Compte), "Pas un Compte");
            Assert.AreEqual(expectedValue, (Compte) result.Value, "pas identiques");
        }
        
        [TestMethod]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.GetCompteById(20).Result;
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }
        
        [TestMethod]
        public void Post()
        {
            Compte instance = new Compte();

            instance.CodePostal = "69150";
            instance.Mel = "69150";
            instance.Nom = "Eti";
            instance.Prenom = "Dur";
            instance.Pwd = "12aZer!,";
            instance.Rue = "Vicoe";
            instance.Pays = "France";
            instance.Ville = "Lyon";
            instance.TelPortable = "0123456789";
            
            Random rand = new Random();
            instance.Mel = rand.Next(5, 10000) + "@gmail.com";

            // Act
            var result = _controller.PostCompte(instance).Result;
            // Assert
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult), "Pas un Compte");
        }

    }
}
