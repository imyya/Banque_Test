namespace Banque;

public class CompteBancaire

{
    private string m_nomClient;
    private double m_solde;
    private bool m_bloque = false;

    private CompteBancaire()
    {
    }

    public CompteBancaire(string nomClient, double solde)
    {
        this.m_nomClient = nomClient;
        this.m_solde = solde;
    }

    public string nomClient
    {
        get { return m_nomClient; }
    }

    public double Balance
    {
        get { return m_solde; }

    }

    public void debiter(double montant)
    {
        if (m_bloque)
        {
            throw new Exception("Compte bloqué");
        }

        if (montant > m_solde)
        {
            throw new ArgumentOutOfRangeException("Montant debite doit etre superieur ou egal au solde disponible");
        }

        if (montant < 0)
        {
            throw new ArgumentOutOfRangeException("Montant debite doit etre positif");
        }

        m_solde -= montant; //ceci est intentionnellement faux
    }

    public void crediter(double montant)
    {
        if (m_bloque)
        {
            throw new Exception("Compte bloque");

        }

        if (montant < 0)
        {
            throw new ArgumentOutOfRangeException("Montant credite doit etre superieur a zero");

        }

        m_solde += montant;
    }

    public void BloquerCompte()
    {
        m_bloque = true;
    }

    private void DebloquerCompte()
    {
        m_bloque = false;
    }

    public static void Main()
    {
        CompteBancaire cb = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);
        cb.crediter(500000);
        cb.debiter(400000);
        Console.WriteLine("Solde disponible egal a F{0}", cb.Balance);

    }


}
