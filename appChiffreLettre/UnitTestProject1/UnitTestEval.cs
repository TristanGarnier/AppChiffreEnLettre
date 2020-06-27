using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CLConversionChiffreLettre;

namespace TestProject1
{
    [TestClass]
    public class UnitTestEval
    {
        //		methodes de test de l'énoncé
        //      18,1256789 -> dix-huit et treize centièmes
        [TestMethod]
        public void TestMethodBtr18_1256789()
        {
            Assert.AreEqual("dix-huit et treize centièmes", EnToutesLettres.NombreEnLettres(18.1256789));
        }
        //		methodes de test de l'énoncé
        //      18,1234 -> dix-huit et douze centièmes
        [TestMethod]
        public void TestMethodBtr18_1234()
        {
            Assert.AreEqual("dix-huit et douze centièmes", EnToutesLettres.NombreEnLettres(18.1234));
        }
        //      18,123 -> dix-huit et douze centièmes 
        [TestMethod]
        public void TestMethodBtr18_123()
        {
            Assert.AreEqual("dix-huit et douze centièmes", EnToutesLettres.NombreEnLettres(18.123));
        }
        //      18,1235 -> dix-huit et cent vingt-quatre millièmes
        [TestMethod]
        public void TestMethodBtr18_125()
        {
            Assert.AreEqual("dix-huit et treize centièmes", EnToutesLettres.NombreEnLettres(18.125));
        }
        //      18,12 -> dix-huit et douze centièmes
        [TestMethod]
        public void TestMethodBtr18_12()
        {
            Assert.AreEqual("dix-huit et douze centièmes", EnToutesLettres.NombreEnLettres(18.12));
        }
        //      123 -> cent vingt-trois
        [TestMethod]
        public void TestMethodBtr123()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(123D);
            Assert.AreEqual("cent vingt-trois", valeurATester );
        }
        
        //		18,1234 -> dix-huit euros et douze centimes
        [TestMethod]
        public void TestMethodBtrE18_1234()
        {
            Assert.AreEqual("dix-huit euros et douze centimes", EnToutesLettres.NombreEnLettres(18.1234, EnToutesLettres.Monnaie.Euro));
        }
        //      18,123 -> dix-huit euros et douze centimes
        [TestMethod]
        public void TestMethodBtrE18_12()
        {
            Assert.AreEqual("dix-huit euros et douze centimes", EnToutesLettres.NombreEnLettres(18.12, EnToutesLettres.Monnaie.Euro));
        }
        //      18,1 -> dix-huit euros et dix centimes
        [TestMethod]
        public void TestMethodBtrE18_10()
        {
            Assert.AreEqual("dix-huit euros et dix centimes", EnToutesLettres.NombreEnLettres(18.10, EnToutesLettres.Monnaie.Euro));
        }
        //      123 -> cent vingt-trois euros
        [TestMethod]
        public void TestMethodBtrE123()
        {
            Assert.AreEqual("cent vingt-trois euros", EnToutesLettres.NombreEnLettres(123M, EnToutesLettres.Monnaie.Euro));
        }
        //		18,1234 en euros -> dix-huit euros et douze centimes
        [TestMethod]
        public void TestMethodBtrEu18_1234()
        {
            Assert.AreEqual("dix-huit euros et douze centimes", EnToutesLettres.NombreEnLettres(18.1234, EnToutesLettres.Monnaie.Euro));
        }
        //		18,1234 en livres -> dix-huit livres et douze pence
        [TestMethod]
        public void TestMethodBtrL18_1234()
        {
            Assert.AreEqual("dix-huit livres et douze pence", EnToutesLettres.NombreEnLettres(18.1234, EnToutesLettres.Monnaie.Livre));
        }

        //      18,123 en dollars -> dix-huit dollars et douze cents
        [TestMethod]
        public void TestMethodBtrD18_123()
        {
            Assert.AreEqual("dix-huit dollars et douze cents", EnToutesLettres.NombreEnLettres(18.1234, EnToutesLettres.Monnaie.Dollar));
        }
        //      18,123 en livre -> dix-huit livres et douze pence
        [TestMethod]
        public void TestMethodBtrL18_123()
        {
            Assert.AreEqual("dix-huit livres et douze pence", EnToutesLettres.NombreEnLettres(18.1234, EnToutesLettres.Monnaie.Livre));
        }
        [TestMethod]
        public void TestMethodBtrL18_01()
        {
            Assert.AreEqual("dix-huit livres et un penny", EnToutesLettres.NombreEnLettres(18.01, EnToutesLettres.Monnaie.Livre));
        }        // n'importe quel type numérique supporté
        [TestMethod]
        public void TestMethodBtrF12_123()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(12.123F);
            Assert.AreEqual("douze et douze centièmes", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtrM12_123()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(12.123M);
            Assert.AreEqual("douze et douze centièmes", valeurATester);
        }
        // autres tests
        [TestMethod]
        public void TestMethodBtr0()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(0D);
            Assert.AreEqual("zéro", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtrM100()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(-100D);
            Assert.AreEqual("moins cent", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtr100()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(100D);
            Assert.AreEqual("cent", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtr200()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(200D);
            Assert.AreEqual("deux cents", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtr80()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(80D);
            Assert.AreEqual("quatre-vingts", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtr81()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(81D);
            Assert.AreEqual("quatre-vingt-un", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtr79()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(79D);
            Assert.AreEqual("soixante-dix-neuf", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtr95()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(95D);
            Assert.AreEqual("quatre-vingt-quinze", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtr1234567891()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(1234567891D);
            Assert.AreEqual("un milliard deux cent trente-quatre millions cinq cent soixante-sept mille huit cent quatre-vingt-onze", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr5600152000()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(5600152000D);
            Assert.AreEqual("cinq milliards six cent millions cent cinquante-deux mille", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr10milliards()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(10000000000D);
            Assert.AreEqual("dix milliards", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtr12_1()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(12.1);
            Assert.AreEqual("douze et un dixième", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr12_2()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(12.2);
            Assert.AreEqual("douze et deux dixièmes", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr12_01()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(12.01);
            Assert.AreEqual("douze et un centième", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr12_12()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(12.12);
            Assert.AreEqual("douze et douze centièmes", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtr12_001()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(12.001);
            Assert.AreEqual("douze", valeurATester);
        }

        [TestMethod]

        public void TestMethodBtr0_15()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(0.15);
            Assert.AreEqual("zéro et quinze centièmes", valeurATester);
        }
        
        [TestMethod]
        public void TestMethodBtr12_02Euro()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(12.02, EnToutesLettres.Monnaie.Euro);
            Assert.AreEqual("douze euros et deux centimes", valeurATester);
        }

        [TestMethod]
        public void TestMethodBtr12_10Euro()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(12.10, EnToutesLettres.Monnaie.Euro);
            Assert.AreEqual("douze euros et dix centimes", valeurATester);
        }
        
        [TestMethod]
        public void TestMethodBtr312()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(312D);
            Assert.AreEqual("trois cent douze", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr111()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(111D);
            Assert.AreEqual("cent onze", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr101()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(101D);
            Assert.AreEqual("cent un", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr136()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(136D);
            Assert.AreEqual("cent trente-six", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr171()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(171D);
            Assert.AreEqual("cent soixante et onze", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr120()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(120D);
            Assert.AreEqual("cent vingt", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr30()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(30D);
            Assert.AreEqual("trente", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtrMoinsDix()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(-10D);
            Assert.AreEqual("moins dix", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr17()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(17D);
            Assert.AreEqual("dix-sept", valeurATester);
        }
        
        [TestMethod]
        public void TestMethodBtr17et1penny()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(17.01D, EnToutesLettres.Monnaie.Livre);
            Assert.AreEqual("dix-sept livres et un penny", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr17et12pence()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(17.12D, EnToutesLettres.Monnaie.Livre);
            Assert.AreEqual("dix-sept livres et douze pence", valeurATester);
        }
        
        [TestMethod]
        public void TestMethodBtr1000()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(1000D);
            Assert.AreEqual("mille", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr1001()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(1001D);
            Assert.AreEqual("mille un", valeurATester);
        }
        [TestMethod]
        public void TestMethodBtr2000()
        {
            String valeurATester = EnToutesLettres.NombreEnLettres(2000D);
            Assert.AreEqual("deux mille", valeurATester);
        }
    }
}
