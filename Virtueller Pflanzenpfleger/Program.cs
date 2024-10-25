using System; // Importiert den Namespace für grundlegende Systemfunktionen
using System.Timers; // Importiere den richtigen Namespace für System.Timers.Timer

public class Plant
{
    // Eigenschaften und Methoden der Pflanze
    public string Name { get; set; } // Der Name der Pflanze
    public int WaterLevel { get; set; } = 70; // Wasserlevel der Pflanze, standardmäßig auf 70 gesetzt
    public int SunlightLevel { get; set; } = 70; // Sonnenlichtlevel der Pflanze, standardmäßig auf 70 gesetzt
    public int NutrientLevel { get; set; } = 70; // Nährstofflevel der Pflanze, standardmäßig auf 70 gesetzt
    public int WeedLevel { get; set; } = 0; // Unkrautlevel der Pflanze, standardmäßig auf 0 gesetzt
    public int GrowthStage { get; set; } = 0; // Wachstum der Pflanze, standardmäßig auf 0 gesetzt
    public int PusteblumenCount { get; private set; } = 0; // Zähler für Pusteblumen, nur innerhalb der Klasse änderbar

    // Erfolge
    public bool WaterAchievement { get; private set; } = false; // Erfolg für Wasserlevel
    public bool SunlightAchievement { get; private set; } = false; // Erfolg für Sonnenlichtlevel
    public bool NutrientAchievement { get; private set; } = false; // Erfolg für Nährstofflevel
    public bool WeedAchievement { get; private set; } = false; // Erfolg für Unkrautlevel

    // Methode zum Gießen der Pflanze
    public void Water()
    {
        WaterLevel += 20; // Erhöhe das Wasserlevel um 20
        Console.WriteLine($"{Name} wurde gegossen. Aktuelles Wasserlevel: {WaterLevel}"); // Ausgabe des aktuellen Wasserlevels
        CheckAchievements(); // Überprüfe, ob Erfolge erreicht wurden
    }

    // Methode, um der Pflanze Sonnenlicht zu geben
    public void GiveSunlight()
    {
        SunlightLevel += 20; // Erhöhe das Sonnenlichtlevel um 20
        Console.WriteLine($"{Name} hat Sonnenlicht erhalten. Aktuelles Lichtlevel: {SunlightLevel}"); // Ausgabe des aktuellen Sonnenlichtlevels
        CheckAchievements(); // Überprüfe, ob Erfolge erreicht wurden
    }

    // Methode zum Düngen der Pflanze
    public void Fertilize()
    {
        NutrientLevel += 20; // Erhöhe das Nährstofflevel um 20
        Console.WriteLine($"{Name} wurde gedüngt. Aktuelles Düngerlevel: {NutrientLevel}"); // Ausgabe des aktuellen Nährstofflevels
        CheckAchievements(); // Überprüfe, ob Erfolge erreicht wurden
    }

    // Methode zum Entfernen von Unkraut
    public void RemoveWeeds()
    {
        WeedLevel = 0; // Setze das Unkrautlevel auf 0
        Console.WriteLine("Das Unkraut wurde entfernt."); // Ausgabe, dass das Unkraut entfernt wurde
        CheckAchievements(); // Überprüfe, ob Erfolge erreicht wurden
    }

    // Methode für das Wachstum der Pflanze
    public void Grow()
    {
        // Überprüfe, ob die Bedingungen für das Wachstum erfüllt sind
        if (WaterLevel >= 100 && SunlightLevel >= 100 && NutrientLevel >= 50 && WeedLevel == 0)
        {
            GrowthStage++; // Erhöhe die Wachstumsstufe um 1
            Console.WriteLine($"{Name} ist auf Wachstumsstufe {GrowthStage} gewachsen."); // Ausgabe der neuen Wachstumsstufe
            CelebrateGrowth(); // Feiere das Wachstum

            // Setze die Werte nach dem Wachstum zurück
            WaterLevel = 40;
            SunlightLevel = 40;
            NutrientLevel = 40;
            WeedLevel = 0;
        }
        else
        {
            // Ausgabe, wenn die Pflege nicht ausreicht
            Console.WriteLine($"{Name} braucht mehr Pflege. (Wasser >= 100, Licht >= 100, Dünger >= 50, Unkraut entfernen)");
        }
    }

    // Methode zur Feier des Wachstums
    private void CelebrateGrowth()
    {
        // Feiere das Wachstum je nach Wachstumsstufe
        switch (GrowthStage)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Yellow; // Setze die Schriftfarbe auf Gelb
                Console.WriteLine($"Herzlichen Glückwunsch! {Name} ist ein kleiner Sprössling!"); // Ausgabe der ersten Wachstumsstufe
                Console.ResetColor(); // Setze die Schriftfarbe zurück
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow; // Setze die Schriftfarbe auf Gelb
                Console.WriteLine($"Super! {Name} hat nun die erste Stufe erreicht und ist eine junge Pflanze!"); // Ausgabe der zweiten Wachstumsstufe
                Console.ResetColor(); // Setze die Schriftfarbe zurück
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Yellow; // Setze die Schriftfarbe auf Gelb
                Console.WriteLine($"Fantastisch! {Name} hat die zweite Stufe erreicht und wächst kräftig!"); // Ausgabe der dritten Wachstumsstufe
                Console.ResetColor(); // Setze die Schriftfarbe zurück
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Yellow; // Setze die Schriftfarbe auf Gelb
                Console.WriteLine($"Toll! {Name} ist jetzt eine ausgewachsene Pflanze!"); // Ausgabe der vierten Wachstumsstufe
                Console.ResetColor(); // Setze die Schriftfarbe zurück
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Yellow; // Setze die Schriftfarbe auf Gelb
                Console.WriteLine($"Unglaublich! {Name} hat die höchste Wachstumsstufe erreicht und blüht wunderschön!"); // Ausgabe der fünften Wachstumsstufe
                Console.ResetColor(); // Setze die Schriftfarbe zurück
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Yellow; // Setze die Schriftfarbe auf Gelb
                Console.WriteLine($"{Name} hat bereits die maximale Wachstumsstufe erreicht."); // Ausgabe, wenn die maximale Wachstumsstufe erreicht wurde
                Console.ResetColor(); // Setze die Schriftfarbe zurück
                break;
        }
    }

    // Methode zum Anzeigen des Status der Pflanze
    public void Status()
    {
        Console.WriteLine($"Pflanze: {Name}, Wasser: {WaterLevel}, Sonnenlicht: {SunlightLevel}, Nährstoffe: {NutrientLevel}, Unkrautlevel: {WeedLevel}, Wachstumsstufe: {GrowthStage}, Pusteblumen: {PusteblumenCount}"); // Ausgabe des Status der Pflanze
    }

    // Methode, um zu überprüfen, ob die Pflanze tot ist
    public bool IsDead()
    {
        return WaterLevel <= 0 || SunlightLevel <= 0 || NutrientLevel <= 0; // Überprüfe, ob die Pflanze tot ist
    }

    // Methode, um Erfolge zu überprüfen
    private void CheckAchievements()
    {
        // Überprüfe, ob die Erfolge erreicht wurden
        if (WaterLevel >= 250 && !WaterAchievement)
        {
            WaterAchievement = true; // Setze den Erfolg auf true
            Console.WriteLine("Checkliste: Wasser ist auf 250! Oh je, pass auf, dass du keinen Wasserschaden bekommst!"); // Ausgabe des Erfolgs
        }
        if (SunlightLevel >= 250 && !SunlightAchievement)
        {
            SunlightAchievement = true; // Setze den Erfolg auf true
            Console.WriteLine("Checkliste: Licht ist auf 250! Deine Pflanze könnte ein Sonnenbad nehmen!"); // Ausgabe des Erfolgs
        }
        if (NutrientLevel >= 250 && !NutrientAchievement)
        {
            NutrientAchievement = true; // Setze den Erfolg auf true
            Console.WriteLine("Checkliste: Dünger ist auf 250 ! Deine Pflanze könnte ein Nährstoff-Boost benötigen!"); // Ausgabe des Erfolgs
        }
        if (WeedLevel == 0 && !WeedAchievement)
        {
            WeedAchievement = true; // Setze den Erfolg auf true
            Console.WriteLine("Checkliste: Kein Unkraut mehr! Deine Pflanze könnte sich jetzt frei entwickeln!"); // Ausgabe des Erfolgs
        }
    }

    // Methode, um Pusteblumen hinzuzufügen
    public void AddPusteblumen(int count)
    {
        PusteblumenCount += count; // Erhöhe die Anzahl der Pusteblumen um den angegebenen Wert
    }

    // Methode, um Pusteblumen zu entfernen
    public void RemovePusteblumen(int count)
    {
        if (PusteblumenCount >= count) // Überprüfe, ob genug Pusteblumen vorhanden sind
        {
            PusteblumenCount -= count; // Entferne die angegebene Anzahl an Pusteblumen
        }
        else
        {
            Console.WriteLine("Nicht genug Pusteblumen!"); // Ausgabe, wenn nicht genug Pusteblumen vorhanden sind
        }
    }
}

class Program
{
    private static System.Timers.Timer weatherTimer; // Timer für das Wetter
    private static System.Timers.Timer weedTimer; // Timer für das Unkraut
    private static Plant myPlant; // Die Pflanze
    private static Random random = new Random(); // Zufallszahlengenerator
    private static string currentWeather = "sonnig"; // Aktuelles Wetter

    static void Main(string[] args)
    {
        myPlant = new Plant { Name = "Meine Pflanze" }; // Erstelle eine neue Pflanze

        weatherTimer = new System.Timers.Timer(20000); // Erstelle einen Timer für das Wetter
        weatherTimer.Elapsed += ChangeWeather; // Führe die Methode ChangeWeather aus, wenn der Timer abläuft
        weatherTimer.AutoReset = true; // Setze den Timer auf AutoReset
        weatherTimer.Start(); // Starte den Timer

        weedTimer = new System.Timers.Timer(30000); // Erstelle einen Timer für das Unkraut
        weedTimer.Elapsed += GrowWeeds; // Führe die Methode GrowWeeds aus, wenn der Timer abläuft
        weedTimer.AutoReset = true; // Setze den Timer auf AutoReset
        weedTimer.Start(); // Starte den Timer

        Console.WriteLine("Virtueller Pflanzenpfleger gestartet!"); // Ausgabe, dass der Pflanzenpfleger gestartet wurde
        Console.WriteLine("Befehle: '1' für Wasser, '2' für Licht, '3' für Dünger, '4' für Unkraut, '5' für Status, '6' für Wachstum, '7' für Checkliste, '8' für Shop, 'x' für Beenden"); // Ausgabe der verfügbaren Befehle

        while (true) // Endlose Schleife
        {
            var key = Console.ReadKey(true).Key; // Lese die nächste Taste ein

            switch (key) // Überprüfe die eingegebene Taste
            {
                case ConsoleKey.D1:
                    myPlant.Water(); // Gieße die Pflanze
                    break;
                case ConsoleKey.D2:
                    myPlant.GiveSunlight(); // Gib der Pflanze Sonnenlicht
                    break;
                case ConsoleKey.D3:
                    myPlant.Fertilize(); // Düng die Pflanze
                    break;
                case ConsoleKey.D4:
                    myPlant.RemoveWeeds(); // Entferne das Unkraut
                    break;
                case ConsoleKey.D5:
                    myPlant.Status(); // Zeige den Status der Pflanze an
                    break;
                case ConsoleKey.D6:
                    myPlant.Grow(); // Lasse die Pflanze wachsen
                    break;
                case ConsoleKey.D7:
                    ShowChecklist(); // Zeige die Checkliste an
                    break;
                case ConsoleKey.D8:
                    Shop(); // Öffne den Shop
                    break;
                case ConsoleKey.X:
                    Console.WriteLine("Programm wird beendet."); // Ausgabe, dass das Programm beendet wird
                    return; // Beende das Programm
            }

            if (myPlant.IsDead()) // Überprüfe, ob die Pflanze tot ist
            {
                Console.WriteLine($"{myPlant.Name} ist verdorrt!"); // Ausgabe, dass die Pflanze tot ist
                weatherTimer.Stop(); // Stoppe den Wetter-Timer
                weedTimer.Stop(); // Stoppe den Unkraut-Timer
                break; // Beende die Schleife
            }

            CheckPlantStatus(); // Überprüfe den Status der Pflanze
        }
    }

    private static void ChangeWeather(object source, ElapsedEventArgs e)
    {
        int weatherChance = random.Next(0, 3); // Zufallszahl zwischen 0 und 2

        switch (weatherChance) // Überprüfe die Zufallszahl
        {
            case 0:
                currentWeather = "sonnig"; // Setze das Wetter auf sonnig
                Console.ForegroundColor = ConsoleColor.Green; // Setze die Schriftfarbe auf Grün
                Console.WriteLine("Das Wetter ist sonnig."); // Ausgabe des Wetters
                Console.ResetColor(); // Setze die Schriftfarbe zurück
                break;
            case 1:
                currentWeather = "bewölkt"; // Setze das Wetter auf bewölkt
                Console.ForegroundColor = ConsoleColor.Green; // Setze die Schriftfarbe auf Grün
                Console.WriteLine("Das Wetter ist bewölkt."); // Ausgabe des Wetters
                Console.ResetColor(); // Setze die Schriftfarbe zurück
                break;
            case 2:
                currentWeather = "regnerisch"; // Setze das Wetter auf regnerisch
                Console.ForegroundColor = ConsoleColor.Green; // Setze die Schriftfarbe auf Grün
                Console.WriteLine("Es regnet."); // Ausgabe des Wetters
                Console.ResetColor(); // Setze die Schriftfarbe zurück
                break;
        }
    }

    private static void GrowWeeds(object source, ElapsedEventArgs e)
    {
        myPlant.WeedLevel += 10; // Erhöhe das Unkrautlevel um 10
        Console.ForegroundColor = ConsoleColor.Red; // Setze die Schriftfarbe auf Rot
        Console.WriteLine("Unkraut wächst! Aktueller Unkrautlevel: " + myPlant.WeedLevel); // Ausgabe des Unkrautlevels
        Console.ResetColor(); // Setze die Schriftfarbe zurück

        if (random.Next(0, 100) < 80) // 80% Chance, dass Pusteblumen droppen
        {
            int pusteblumenCount = random.Next(10, 41); // Zufallszahl zwischen 10 und 40
            myPlant.AddPusteblumen(pusteblumenCount); // Füge Pusteblumen hinzu
            Console.WriteLine($"Pusteblumen sind gewachsen! Aktuelle Anzahl: {myPlant.PusteblumenCount}"); // Ausgabe der Pusteblumen
        }
    }

    private static void CheckPlantStatus()
    {
        myPlant.WaterLevel -= 5; // Reduziere das Wasserlevel um 5

        if (currentWeather == "sonnig") // Überprüfe das Wetter
        {
            myPlant.SunlightLevel += 5; // Erhöhe das Sonnenlichtlevel um 5
        }
        else if (currentWeather == "bewölkt")
        {
            myPlant.SunlightLevel -= 2; // Reduziere das Sonnenlichtlevel um 2
        }
        else if (currentWeather == "regnerisch")
        {
            myPlant.WaterLevel += 20; // Erhöhe das Wasserlevel um 20
            CheckForTornado(); // Überprüfe, ob ein Tornado auftritt
        }

        myPlant.NutrientLevel -= 2; // Reduziere das Nährstofflevel um 2

        if (myPlant.IsDead()) // Überprüfe, ob die Pflanze tot ist
        {
            Console.WriteLine($"{myPlant.Name} ist verdorrt!"); // Ausgabe, dass die Pflanze tot ist
            weatherTimer.Stop(); // Stoppe den Wetter-Timer
            weedTimer.Stop(); // Stoppe den Unkraut-Timer
        }
    }

    private static void CheckForTornado()
    {
        int tornadoChance = random.Next(0, 100); // Zufallszahl zwischen 0 und 99
        if (tornadoChance < 20) // 20% Chance, dass ein Tornado auftritt
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ein Tornado ist aufgetreten! Game Over!"); // Ausgabe, dass ein Tornado auftritt
            Console.ResetColor();
            myPlant.WaterLevel = 0; // Setze das Wasserlevel auf 0
            myPlant.SunlightLevel = 0; // Setze das Sonnenlichtlevel auf 0
            myPlant.NutrientLevel = 0; // Setze das Nährstofflevel auf 0
            myPlant.WeedLevel = 100; // Setze das Unkrautlevel auf 100
        }
    }

    private static void ShowChecklist()
    {
        Console.WriteLine("Checkliste:"); // Ausgabe der Checkliste
        if (myPlant.WaterAchievement)
        {
            Console.WriteLine("Achievement: Oh je, pass auf, dass du keinen Wasserschaden bekommst!"); // Ausgabe des Erfolgs
        }
        if (myPlant.SunlightAchievement)
        {
            Console.WriteLine("Achievement: Solarium, deine Pflanze könnte ein Sonnenbad nehmen!"); // Aus gabe des Erfolgs
        }
        if (myPlant.NutrientAchievement)
        {
            Console.WriteLine("Achievement: Booster, deine Pflanze könnte ein Nährstoff-Boost benötigen!"); // Ausgabe des Erfolgs
        }
        if (myPlant.WeedAchievement)
        {
            Console.WriteLine("Achievement: Unkrautheld, deine Pflanze könnte sich jetzt frei entwickeln!"); // Ausgabe des Erfolgs
        }
    }

    private static void Shop()
    {
        Console.WriteLine("Willkommen im Shop!"); // Ausgabe, dass der Shop geöffnet wurde
        Console.WriteLine("Du hast aktuell " + myPlant.PusteblumenCount + " Pusteblumen."); // Ausgabe der Pusteblumen
        Console.WriteLine("1. Wasser-Boost (10 Pusteblumen)"); // Ausgabe der ersten Option
        Console.WriteLine("2. Sonnenlicht-Boost (15 Pusteblumen)"); // Ausgabe der zweiten Option
        Console.WriteLine("3. Dünger-Boost (20 Pusteblumen)"); // Ausgabe der dritten Option
        Console.WriteLine("4. Zurück zum Hauptmenü"); // Ausgabe der vierten Option

        var key = Console.ReadKey(true).Key; // Lese die nächste Taste ein

        switch (key) // Überprüfe die eingegebene Taste
        {
            case ConsoleKey.D1:
                if (myPlant.PusteblumenCount >= 10) // Überprüfe, ob genug Pusteblumen vorhanden sind
                {
                    myPlant.RemovePusteblumen(10); // Entferne 10 Pusteblumen
                    myPlant.WaterLevel += 50; // Erhöhe das Wasserlevel um 50
                    Console.WriteLine("Wasser-Boost erfolgreich erworben!"); // Ausgabe, dass der Boost erfolgreich erworben wurde
                }
                else
                {
                    Console.WriteLine("Nicht genug Pusteblumen!"); // Ausgabe, dass nicht genug Pusteblumen vorhanden sind
                }
                break;
            case ConsoleKey.D2:
                if (myPlant.PusteblumenCount >= 15) // Überprüfe, ob genug Pusteblumen vorhanden sind
                {
                    myPlant.RemovePusteblumen(15); // Entferne 15 Pusteblumen
                    myPlant.SunlightLevel += 50; // Erhöhe das Sonnenlichtlevel um 50
                    Console.WriteLine("Sonnenlicht-Boost erfolgreich erworben!"); // Ausgabe, dass der Boost erfolgreich erworben wurde
                }
                else
                {
                    Console.WriteLine("Nicht genug Pusteblumen!"); // Ausgabe, dass nicht genug Pusteblumen vorhanden sind
                }
                break;
            case ConsoleKey.D3:
                if (myPlant.PusteblumenCount >= 20) // Überprüfe, ob genug Pusteblumen vorhanden sind
                {
                    myPlant.RemovePusteblumen(20); // Entferne 20 Pusteblumen
                    myPlant.NutrientLevel += 50; // Erhöhe das Nährstofflevel um 50
                    Console.WriteLine("Dünger-Boost erfolgreich erworben!"); // Ausgabe, dass der Boost erfolgreich erworben wurde
                }
                else
                {
                    Console.WriteLine("Nicht genug Pusteblumen!"); // Ausgabe, dass nicht genug Pusteblumen vorhanden sind
                }
                break;
            case ConsoleKey.D4:
                Console.WriteLine("Zurück zum Hauptmenü"); // Ausgabe, dass der Shop geschlossen wird
                break;
        }
    }
}