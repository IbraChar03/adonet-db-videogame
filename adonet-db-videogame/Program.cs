namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scegli tra le seguenti opzioni : ");
            Console.WriteLine("Inserisci videogioco");
            Console.WriteLine("Rimuovi videogioco");
            Console.WriteLine("Aggiorna videogioco");
            Console.WriteLine("Cerca videogioco tramite id ");
            Console.WriteLine("Cerca videogiochi");
            Console.WriteLine("Esci");
            Console.Write("Scrivi la tua scelta : ");
            string scelta = Console.ReadLine();
          
                switch(scelta)
                {
                    case "Inserisci videogioco":
                        try
                        {
                            Console.Write("Inserisci nome del videogioco : ");
                            string name = Console.ReadLine();
                            Console.Write("Inserisci riassunto del videogioco : ");
                            string overview = Console.ReadLine();
                            Console.Write("Inserisci data del videogioco (dd/MM/yyy) : ");
                            string date = Console.ReadLine();
                            Console.Write("Inserisci id della software house : ");
                            long softwareHouseId = Convert.ToInt64(Console.ReadLine());
                            VideogameManager.InserisciVideogame(new Videogame(name,overview,date,softwareHouseId));
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    
                        break;
                    case "Rimuovi videogioco":
                    try
                    {
                        Console.Write("Inserisci il nome del videogioco da rimuovere : ");
                        string nomeVideogiocoRim = Console.ReadLine();
                        VideogameManager.RimuoviVideogame(nomeVideogiocoRim);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                  
                        break;
                    case "Aggiorna videogioco":
                    try
                    {
                        Console.Write("Inserisci il nome del videogioco da aggiornare : ");
                        string nomeVideogiocoAgg = Console.ReadLine();
                        Console.Write("Inserisci il nuovo riassunto del videogioco : ");
                        string riassuntoVideogiocoAgg = Console.ReadLine();
                        VideogameManager.AggiornaVideogame(nomeVideogiocoAgg, riassuntoVideogiocoAgg);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                        break;
                    case "Cerca videogioco tramite id":
                    try
                    {
                        Console.Write("Inserisci l`id del videogioco da cercare : ");
                        long idVideogioco = Convert.ToInt64(Console.ReadLine());
                        VideogameManager.GetVideogameById(idVideogioco);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                        break;
                case "Cerca videogiochi":
                    try
                    {
                        Console.Write("Inserisci la parola : ");
                       string parola = Console.ReadLine();
                        VideogameManager.CercaVideogiochi(parola);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case "Esci":
                    Console.Write("Arrivederci");
                        break;
            }
            

        }
    }
}