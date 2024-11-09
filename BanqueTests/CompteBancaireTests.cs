namespace BanqueTests;
using Banque;
[TestClass]
public class CompteBancaireTests
{
    [TestMethod]
    public void VerifierDebitCOmpteCorrect()
    {
        double soldeInitial = 500000;
        double montantDebit = 400000;
        double soldeAttendu = 100000;
        var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

        compte.debiter(montantDebit);

        double soldeObtenu = compte.Balance;
        Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "compte debite incorrectement");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]

    public void DebiterMontantNegatifLeveArgumentOutOfRange()
    {
        var compte = new CompteBancaire("Pr. Abdoulaye Diankha", 500.0);
        compte.debiter(-100.0);

    }

        [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]

    public void DebiterMontantSuperieurSoldeLeveArgumentOutOfRange()
    {
        var compte = new CompteBancaire("Pr. Abdoulaye Diankha", 500.0);
        compte.debiter(700.0);

    }




}