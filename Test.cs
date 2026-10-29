

        // 1) Prüfe, ob eine Zahl eine Primzahl ist.
        static void Primzahltest()
        {
            int n = LeseInt("Zahl: ");
            bool prim = n >= 2;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) { prim = false; }
            }
            Console.WriteLine(n + (prim ? " ist eine Primzahl." : " ist keine Primzahl."));
        }

        // 2) Prüfe, ob ein Text ein Palindrom ist (Leerzeichen und Groß/Klein egal).
        static void Palindromtest()
        {
            string t = LeseText("Text: ").Replace(" ", "").ToLower();
            bool pal = true;
            int i = 0, j = t.Length - 1;
            while (i < j)
            {
                if (t[i] != t[j]) { pal = false; }
                i++; j--;
            }
            Console.WriteLine(pal ? "Palindrom." : "Kein Palindrom.");
        }

        // 3) Gib die Fibonacci-Folge bis zur Stelle n aus (long reicht bis n = 92).
        static void Fibonacci()
        {
            int n = LeseInt("Bis zur Stelle n (max. 92): ");
            if (n > 92) { Console.WriteLine("Zu groß für long."); return; }
            long a = 0, b = 1;
            for (int i = 1; i <= n; i++)
            {
                Console.Write(a + " ");
                long next = a + b;
                a = b;
                b = next;
            }
            Console.WriteLine();
        }

        // 4) Zähle die Wörter eines Textes.
        static void Wortzaehler()
        {
            string text = LeseText("Text: ");
            int anz = 0;
            bool imWort = false;
            foreach (char z in text)
            {
                if (z == ' ') { imWort = false; }
                else if (!imWort) { anz++; imWort = true; }
            }
            Console.WriteLine("Wörter: " + anz);
        }

        // 5) Gib einen Text spiegelverkehrt aus.
        static void Spiegeln()
        {
            string text = LeseText("Text: ");
            string erg = "";
            for (int i = text.Length - 1; i >= 0; i--) { erg = erg + text[i]; }
            Console.WriteLine(erg);
        }

        // 6) Bestimme die größte von vier Zahlen.
        static void Groesste4()
        {
            int a = LeseInt("a: "), b = LeseInt("b: "), c = LeseInt("c: "), d = LeseInt("d: ");
            int max = a;
            if (b > max) { max = b; }
            if (c > max) { max = c; }
            if (d > max) { max = d; }
            Console.WriteLine("Größte Zahl: " + max);
        }

        // ============================================================
        //  7-21  WEITERE AUFGABEN
        // ============================================================

        // 7) ggT (Euklid) und kgV zweier Zahlen.
        static void KgV()
        {
            int a = LeseInt("a: "), b = LeseInt("b: ");
            int x = Math.Abs(a), y = Math.Abs(b);
            while (y != 0) { int r = x % y; x = y; y = r; }
            Console.WriteLine("ggT = " + x);
            if (x == 0) { Console.WriteLine("kgV nicht definiert"); return; }
            long kgv = (long)Math.Abs(a) / x * Math.Abs(b);
            Console.WriteLine("kgV = " + kgv);
        }

        // 8) Alle Teiler einer Zahl, ihre Anzahl und ihre Summe.
        static void Teiler()
        {
            int n = LeseInt("Zahl: ");
            int anzahl = 0; long summe = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) { Console.Write(i + " "); anzahl++; summe += i; }
            }
            Console.WriteLine();
            Console.WriteLine("Anzahl: " + anzahl + ", Summe: " + summe);
        }

        // 9) Alle dreistelligen Armstrong-Zahlen (Summe der Ziffern hoch 3 = Zahl).
        static void Armstrong()
        {
            for (int z = 100; z <= 999; z++)
            {
                int h = z / 100, t = z / 10 % 10, e = z % 10;
                if (h * h * h + t * t * t + e * e * e == z) { Console.Write(z + " "); }
            }
            Console.WriteLine();
        }

        // 10) Löse ax² + bx + c = 0.
        static void Quadratisch()
        {
            double a = LeseDouble("a: "), b = LeseDouble("b: "), c = LeseDouble("c: ");
            if (a == 0)
            {
                if (b == 0) { Console.WriteLine(c == 0 ? "Unendlich viele Lösungen." : "Keine Lösung."); }
                else { Console.WriteLine("x = " + (-c / b)); }
            }
            else
            {
                double d = b * b - 4 * a * c;
                if (d > 0)
                {
                    Console.WriteLine("x1 = " + (-b + Math.Sqrt(d)) / (2 * a));
                    Console.WriteLine("x2 = " + (-b - Math.Sqrt(d)) / (2 * a));
                }
                else if (d == 0) { Console.WriteLine("x = " + (-b / (2 * a))); }
                else { Console.WriteLine("Keine reelle Lösung."); }
            }
        }

        // 11) Alle Primzahlen bis n mit dem Sieb des Eratosthenes.
        static void Sieb()
        {
            int n = LeseInt("Obergrenze: ");
            if (n < 2) { Console.WriteLine("Keine Primzahlen."); return; }
            bool[] istPrim = new bool[n + 1];
            for (int i = 2; i <= n; i++) { istPrim[i] = true; }
            for (int i = 2; i * i <= n; i++)
            {
                if (istPrim[i])
                {
                    for (int j = i * i; j <= n; j += i) { istPrim[j] = false; }
                }
            }
            for (int i = 2; i <= n; i++)
            {
                if (istPrim[i]) { Console.Write(i + " "); }
            }
            Console.WriteLine();
        }

        // 12) Binärzahl (als Text) in Dezimalzahl umwandeln.
        static void BinaerNachDezimal()
        {
            string bin = LeseText("Binärzahl: ");
            long wert = 0;
            foreach (char c in bin)
            {
                if (c != '0' && c != '1') { Console.WriteLine("Keine Binärzahl."); return; }
                wert = wert * 2 + (c - '0');
            }
            Console.WriteLine("Dezimal: " + wert);
        }

        // 13) Fünf Zahlen mit Bubblesort sortieren.
        static void Bubblesort()
        {
            int[] z = new int[5];
            for (int i = 0; i < z.Length; i++) { z[i] = LeseInt("Zahl " + (i + 1) + ": "); }
            for (int i = 0; i < z.Length - 1; i++)
            {
                for (int j = 0; j < z.Length - 1 - i; j++)
                {
                    if (z[j] > z[j + 1])
                    {
                        int tmp = z[j]; z[j] = z[j + 1]; z[j + 1] = tmp;
                    }
                }
            }
            foreach (int x in z) { Console.Write(x + " "); }
            Console.WriteLine();
        }

        // 14) Caesar-Verschlüsselung mit Schlüssel k (auch negativ).
        static void Caesar()
        {
            string text = LeseText("Text: ");
            int k = LeseInt("Schlüssel: ");
            string erg = "";
            foreach (char c in text)
            {
                if (c >= 'a' && c <= 'z') { erg += (char)('a' + ((c - 'a' + k) % 26 + 26) % 26); }
                else if (c >= 'A' && c <= 'Z') { erg += (char)('A' + ((c - 'A' + k) % 26 + 26) % 26); }
                else { erg += c; }
            }
            Console.WriteLine(erg);
        }

        // 15) Mittelwert, Minimum, Maximum, Standardabweichung.
        static void Statistik()
        {
            int n = LeseInt("Anzahl der Werte: ");
            if (n <= 0) { Console.WriteLine("Mindestens ein Wert nötig."); return; }
            double[] w = new double[n];
            for (int i = 0; i < n; i++) { w[i] = LeseDouble("Wert " + (i + 1) + ": "); }
            double summe = 0, min = w[0], max = w[0];
            foreach (double x in w)
            {
                summe += x;
                if (x < min) { min = x; }
                if (x > max) { max = x; }
            }
            double mittel = summe / n, abw = 0;
            foreach (double x in w) { abw += (x - mittel) * (x - mittel); }
            Console.WriteLine($"Mittel {mittel:F2}, Min {min}, Max {max}, Std.abw. {Math.Sqrt(abw / n):F2}");
        }

        // 16) Alle pythagoreischen Tripel (a < b < c <= n).
        static void Pythagoras()
        {
            int n = LeseInt("Obergrenze für c: ");
            for (int a = 1; a <= n; a++)
            {
                for (int b = a + 1; b <= n; b++)
                {
                    int q = a * a + b * b;
                    int c = (int)Math.Round(Math.Sqrt(q));
                    if (c <= n && c * c == q) { Console.WriteLine($"({a}, {b}, {c})"); }
                }
            }
        }

        // 17) Taschenrechner mit + - * /.
        static void Taschenrechner()
        {
            double a = LeseDouble("Zahl 1: ");
            string op = LeseText("Operator (+ - * /): ");
            double b = LeseDouble("Zahl 2: ");
            switch (op)
            {
                case "+": Console.WriteLine(a + b); break;
                case "-": Console.WriteLine(a - b); break;
                case "*": Console.WriteLine(a * b); break;
                case "/":
                    if (b == 0) { Console.WriteLine("Division durch 0 nicht möglich."); }
                    else { Console.WriteLine(a / b); }
                    break;
                default: Console.WriteLine("Unbekannter Operator."); break;
            }
        }

        // 18) Nach wie vielen Jahren verdoppelt sich ein Kapital bei p % Zinsen?
        static void Zinseszins()
        {
            double start = LeseDouble("Startkapital: ");
            double p = LeseDouble("Zinssatz in %: ");
            if (start <= 0 || p <= 0) { Console.WriteLine("Werte müssen positiv sein."); return; }
            double kapital = start;
            int jahre = 0;
            while (kapital < 2 * start)
            {
                kapital = kapital * (1 + p / 100);
                jahre++;
            }
            Console.WriteLine(jahre + " Jahre");
        }

        // 19) Tannenbaum aus Sternchen.
        static void Tannenbaum()
        {
            int n = LeseInt("Höhe: ");
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string(' ', n - i) + new string('*', 2 * i - 1));
            }
        }

        // 20) Sind zwei Wörter Anagramme?
        static void Anagramm()
        {
            string w1 = LeseText("Wort 1: ").Replace(" ", "").ToLower();
            string w2 = LeseText("Wort 2: ").Replace(" ", "").ToLower();
            char[] a = w1.ToCharArray(), b = w2.ToCharArray();
            Array.Sort(a); Array.Sort(b);
            Console.WriteLine(new string(a) == new string(b) ? "Anagramme." : "Keine Anagramme.");
        }

        // 21) Fläche unter f(x) = x² von a bis b mit der Trapezregel.
        static double F(double x) { return x * x; }
        static void Trapez()
        {
            double a = LeseDouble("a: "), b = LeseDouble("b: ");
            int n = LeseInt("Anzahl Trapeze: ");
            if (n <= 0) { Console.WriteLine("n muss positiv sein."); return; }
            double h = (b - a) / n;
            double summe = (F(a) + F(b)) / 2;
            for (int i = 1; i < n; i++) { summe += F(a + i * h); }
            Console.WriteLine("Fläche ≈ " + summe * h);
        }

        // ============================================================
        //  22-27  AUFGABEN AUS DEN PROBEKLAUSUREN
        // ============================================================

        // 22) Vollkommene Zahlen (Summe der echten Teiler = Zahl) bis n.
        static void Vollkommen()
        {
            int n = LeseInt("Suche bis: ");
            for (int z = 2; z <= n; z++)
            {
                int summe = 0;
                for (int t = 1; t < z; t++)
                {
                    if (z % t == 0) { summe += t; }
                }
                if (summe == z) { Console.Write(z + " "); }
            }
            Console.WriteLine();
        }

        // 23) Satzanalyse: Wörter, Zeichen, Buchstaben, Leerzeichen, längstes Wort.
        static void Satzanalyse()
        {
            string satz = LeseText("Satz: ");
            int woerter = 0, buchstaben = 0, leer = 0;
            bool imWort = false;
            foreach (char c in satz)
            {
                if (c == ' ') { leer++; imWort = false; }
                else
                {
                    if (!imWort) { woerter++; imWort = true; }
                    if (char.IsLetter(c)) { buchstaben++; }
                }
            }
            string laengstes = "";
            foreach (string w in satz.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (w.Length > laengstes.Length) { laengstes = w; }
            }
            Console.WriteLine($"Zeichen: {satz.Length}, Wörter: {woerter}, Buchstaben: {buchstaben}, Leerzeichen: {leer}");
            Console.WriteLine("Längstes Wort: " + laengstes);
        }

        // 24) Preisrechner: Menge x Einzelpreis, Rabatt 5 % ab 100 EUR, 10 % ab 500 EUR.
        static void Preisrechner()
        {
            double einzel = LeseDouble("Einzelpreis in EUR: ");
            int menge = LeseInt("Menge: ");
            double brutto = einzel * menge;
            double rabatt = 0;
            if (brutto >= 500) { rabatt = 0.10; }
            else if (brutto >= 100) { rabatt = 0.05; }
            double endpreis = brutto * (1 - rabatt);
            Console.WriteLine($"Preis: {brutto:F2} EUR, Rabatt: {rabatt * 100:F0} %, zu zahlen: {endpreis:F2} EUR");
        }

        // 25) Zahlenraten: Computer wählt 1-100, Spieler rät, Hinweise, Versuche zählen.
        static void Zahlenraten()
        {
            Random rnd = new Random();
            int geheim = rnd.Next(1, 101);
            int versuche = 0, tipp;
            do
            {
                tipp = LeseInt("Dein Tipp (1-100): ");
                versuche++;
                if (tipp < geheim) { Console.WriteLine("Zu klein."); }
                else if (tipp > geheim) { Console.WriteLine("Zu groß."); }
            } while (tipp != geheim);
            Console.WriteLine("Richtig in " + versuche + " Versuchen!");
        }

        // 26) Textanalyse: Vokale, Ziffern, Text ohne Leerzeichen.
        static void Textanalyse()
        {
            string text = LeseText("Text: ");
            int vokale = 0, ziffern = 0;
            string ohne = "";
            foreach (char c in text)
            {
                if ("aeiouäöüAEIOUÄÖÜ".IndexOf(c) >= 0) { vokale++; }
                if (char.IsDigit(c)) { ziffern++; }
                if (c != ' ') { ohne += c; }
            }
            Console.WriteLine($"Vokale: {vokale}, Ziffern: {ziffern}");
            Console.WriteLine("Ohne Leerzeichen: " + ohne);
        }

        // 27) Alle Primzahlen bis n, deren Quersumme ebenfalls prim ist.
        static bool IstPrim(int n)
        {
            if (n < 2) { return false; }
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) { return false; }
            }
            return true;
        }
        static int QuersummeVon(int n)
        {
            int s = 0;
            while (n > 0) { s += n % 10; n /= 10; }
            return s;
        }
        static void PrimQuersumme()
        {
            int n = LeseInt("Obergrenze: ");
            for (int z = 2; z <= n; z++)
            {
                if (IstPrim(z) && IstPrim(QuersummeVon(z))) { Console.Write(z + " "); }
            }
            Console.WriteLine();
        }

        // ============================================================
        //  28-57  30 NEUE AUFGABEN
        // ============================================================

        // 28) Fakultät n! mit long; melde Überlauf ab n = 21.
        static void Fakultaet()
        {
            int n = LeseInt("n (0-20): ");
            if (n < 0 || n > 20) { Console.WriteLine("Nur 0 bis 20 (sonst Überlauf bei long)."); return; }
            long f = 1;
            for (int i = 2; i <= n; i++) { f *= i; }
            Console.WriteLine(n + "! = " + f);
        }

        // 29) Quersumme einer Zahl.
        static void Quersumme()
        {
            int n = Math.Abs(LeseInt("Zahl: "));
            Console.WriteLine("Quersumme: " + QuersummeVon(n));
        }

        // 30) Ziffern einer Zahl in umgekehrter Reihenfolge (123 wird 321).
        static void ZahlUmdrehen()
        {
            int n = Math.Abs(LeseInt("Zahl: "));
            long erg = 0;
            while (n > 0)
            {
                erg = erg * 10 + n % 10;
                n /= 10;
            }
            Console.WriteLine("Umgedreht: " + erg);
        }

        // 31) Schaltjahr: durch 4 teilbar, aber nicht durch 100, außer durch 400.
        static void Schaltjahr()
        {
            int j = LeseInt("Jahr: ");
            bool schalt = (j % 4 == 0 && j % 100 != 0) || j % 400 == 0;
            Console.WriteLine(j + (schalt ? " ist ein Schaltjahr." : " ist kein Schaltjahr."));
        }

        // 32) 600-mal würfeln und die Häufigkeit jeder Augenzahl ausgeben.
        static void WuerfelHaeufigkeit()
        {
            Random rnd = new Random();
            int[] h = new int[7];
            for (int i = 0; i < 600; i++) { h[rnd.Next(1, 7)]++; }
            for (int a = 1; a <= 6; a++) { Console.WriteLine(a + ": " + h[a]); }
        }

        // 33) Dezimalzahl in Binär umwandeln (Division durch 2, Reste rückwärts).
        static void DezimalNachBinaer()
        {
            int n = LeseInt("Zahl (>= 0): ");
            if (n < 0) { Console.WriteLine("Nur nicht-negative Zahlen."); return; }
            if (n == 0) { Console.WriteLine("0"); return; }
            string bin = "";
            while (n > 0)
            {
                bin = (n % 2) + bin;
                n /= 2;
            }
            Console.WriteLine(bin);
        }

        // 34) Primfaktorzerlegung (60 = 2 * 2 * 3 * 5).
        static void Primfaktoren()
        {
            int n = LeseInt("Zahl (>= 2): ");
            if (n < 2) { Console.WriteLine("Mindestens 2."); return; }
            string erg = "";
            int f = 2;
            while (n > 1)
            {
                if (n % f == 0)
                {
                    erg += (erg == "" ? "" : " * ") + f;
                    n /= f;
                }
                else { f++; }
            }
            Console.WriteLine(erg);
        }

        // 35) Potenz a^n ohne Math.Pow (schnelles Potenzieren durch Quadrieren).
        static void Potenz()
        {
            long basis = LeseInt("Basis: ");
            int exp = LeseInt("Exponent (>= 0): ");
            if (exp < 0) { Console.WriteLine("Nur Exponenten >= 0."); return; }
            long ergebnis = 1;
            while (exp > 0)
            {
                if (exp % 2 == 1) { ergebnis *= basis; }
                basis *= basis;
                exp /= 2;
            }
            Console.WriteLine("Ergebnis: " + ergebnis);
        }

        // 36) Ägyptische Multiplikation: a*b durch Verdoppeln und Halbieren.
        static void Aegyptisch()
        {
            int a = LeseInt("a: "), b = LeseInt("b (>= 0): ");
            if (b < 0) { Console.WriteLine("b muss >= 0 sein."); return; }
            long summe = 0, x = a;
            while (b > 0)
            {
                if (b % 2 == 1) { summe += x; }
                x *= 2;
                b /= 2;
            }
            Console.WriteLine("Produkt: " + summe);
        }

        // 37) Collatz-Folge: gerade /2, ungerade *3+1 bis 1. Schritte zählen.
        static void Collatz()
        {
            long n = LeseInt("Startzahl (>= 1): ");
            if (n < 1) { Console.WriteLine("Mindestens 1."); return; }
            int schritte = 0;
            Console.Write(n);
            while (n != 1)
            {
                n = n % 2 == 0 ? n / 2 : 3 * n + 1;
                Console.Write(" " + n);
                schritte++;
            }
            Console.WriteLine();
            Console.WriteLine("Schritte: " + schritte);
        }

        // 38) Kleines Einmaleins bis 10 als Tabelle.
        static void Einmaleins()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write((i * j).ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }

        // 39) Prozent in Notenpunkte (0-15): ab 95 % 15 Punkte, dann je 5 % ein Punkt weniger,
        //     unter 20 % 0 Punkte. (Vereinfachtes Schema für Übungszwecke.)
        static void Notenpunkte()
        {
            double prozent = LeseDouble("Erreichte Prozent: ");
            int punkte;
            if (prozent < 20) { punkte = 0; }
            else if (prozent >= 95) { punkte = 15; }
            else { punkte = 1 + (int)((prozent - 20) / 5); }
            if (punkte > 15) { punkte = 15; }
            Console.WriteLine("Notenpunkte: " + punkte);
        }

        // 40) Tabelle Celsius -> Fahrenheit von -10 bis 40 in 10er-Schritten.
        static void Temperatur()
        {
            for (int c = -10; c <= 40; c += 10)
            {
                double f = c * 9.0 / 5 + 32;
                Console.WriteLine($"{c,4} °C = {f,5:F1} °F");
            }
        }

        // 41) Zahlen einlesen bis 0; Summe, Anzahl und Mittelwert der geraden Zahlen.
        static void GeradeSumme()
        {
            int summe = 0, anzahl = 0, z;
            do
            {
                z = LeseInt("Zahl (0 beendet): ");
                if (z != 0 && z % 2 == 0) { summe += z; anzahl++; }
            } while (z != 0);
            if (anzahl == 0) { Console.WriteLine("Keine geraden Zahlen."); }
            else { Console.WriteLine($"Summe {summe}, Anzahl {anzahl}, Mittel {(double)summe / anzahl:F2}"); }
        }

        // 42) Groß- und Kleinbuchstaben vertauschen (Hallo wird hALLO).
        static void Schreibung()
        {
            string text = LeseText("Text: ");
            string erg = "";
            foreach (char c in text)
            {
                if (char.IsUpper(c)) { erg += char.ToLower(c); }
                else if (char.IsLower(c)) { erg += char.ToUpper(c); }
                else { erg += c; }
            }
            Console.WriteLine(erg);
        }

        // 43) Wie oft kommt ein Buchstabe im Text vor (Groß/Klein egal)?
        static void BuchstabeZaehlen()
        {
            string text = LeseText("Text: ").ToLower();
            string b = LeseText("Buchstabe: ").ToLower();
            if (b.Length != 1) { Console.WriteLine("Bitte genau einen Buchstaben."); return; }
            int anz = 0;
            foreach (char c in text)
            {
                if (c == b[0]) { anz++; }
            }
            Console.WriteLine("Anzahl: " + anz);
        }

        // 44) Zweitgrößte von n Zahlen (ohne Sortieren).
        static void Zweitgroesste()
        {
            int n = LeseInt("Anzahl (>= 2): ");
            if (n < 2) { Console.WriteLine("Mindestens 2 Zahlen."); return; }
            int[] z = new int[n];
            for (int i = 0; i < n; i++) { z[i] = LeseInt("Zahl " + (i + 1) + ": "); }
            int max = int.MinValue, zweit = int.MinValue;
            foreach (int x in z)
            {
                if (x > max) { zweit = max; max = x; }
                else if (x > zweit && x != max) { zweit = x; }
            }
            if (zweit == int.MinValue) { Console.WriteLine("Alle Zahlen gleich, keine zweitgrößte."); }
            else { Console.WriteLine("Zweitgrößte: " + zweit); }
        }

        // 45) Binäre Suche in einem sortierten Array.
        static void BinaereSuche()
        {
            int[] a = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            Console.WriteLine("Array: " + string.Join(" ", a));
            int ziel = LeseInt("Gesuchte Zahl: ");
            int links = 0, rechts = a.Length - 1, pos = -1;
            while (links <= rechts && pos == -1)
            {
                int mitte = (links + rechts) / 2;
                if (a[mitte] == ziel) { pos = mitte; }
                else if (a[mitte] < ziel) { links = mitte + 1; }
                else { rechts = mitte - 1; }
            }
            Console.WriteLine(pos == -1 ? "Nicht gefunden." : "Gefunden an Index " + pos);
        }

        // 46) Dezimalzahl (1-3999) in römische Zahl.
        static void Roemisch()
        {
            int n = LeseInt("Zahl (1-3999): ");
            if (n < 1 || n > 3999) { Console.WriteLine("Außerhalb des Bereichs."); return; }
            int[] wert = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] sym = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            string erg = "";
            for (int i = 0; i < wert.Length; i++)
            {
                while (n >= wert[i])
                {
                    erg += sym[i];
                    n -= wert[i];
                }
            }
            Console.WriteLine(erg);
        }

        // 47) Quadratwurzel nach Heron (Näherungsverfahren) bis zur Genauigkeit 1e-9.
        static void Heron()
        {
            double a = LeseDouble("Zahl (>= 0): ");
            if (a < 0) { Console.WriteLine("Keine reelle Wurzel."); return; }
            if (a == 0) { Console.WriteLine("0"); return; }
            double x = a;
            int schritte = 0;
            while (Math.Abs(x * x - a) > 1e-9)
            {
                x = (x + a / x) / 2;
                schritte++;
            }
            Console.WriteLine($"Wurzel ≈ {x:F6} nach {schritte} Schritten (Math.Sqrt: {Math.Sqrt(a):F6})");
        }

        // 48) Nullstelle von f(x) = x³ - x - 2 im Intervall [1, 2] per Intervallhalbierung.
        static void Halbierung()
        {
            double links = 1, rechts = 2;
            while (rechts - links > 1e-9)
            {
                double m = (links + rechts) / 2;
                double fm = m * m * m - m - 2;
                double fl = links * links * links - links - 2;
                if (fm == 0) { links = rechts = m; }
                else if (fl * fm < 0) { rechts = m; }
                else { links = m; }
            }
            Console.WriteLine("Nullstelle ≈ " + ((links + rechts) / 2).ToString("F6"));
        }

        // 49) Zahlenpyramide (1 / 12 / 123 ...).
        static void Zahlenpyramide()
        {
            int n = LeseInt("Höhe (1-9): ");
            if (n < 1 || n > 9) { Console.WriteLine("Nur 1 bis 9."); return; }
            for (int i = 1; i <= n; i++)
            {
                string zeile = "";
                for (int j = 1; j <= i; j++) { zeile += j; }
                Console.WriteLine(zeile);
            }
        }

        // 50) Schachbrettmuster aus # und Leerzeichen.
        static void Schachbrett()
        {
            int n = LeseInt("Größe: ");
            for (int z = 0; z < n; z++)
            {
                string zeile = "";
                for (int s = 0; s < n; s++)
                {
                    zeile += (z + s) % 2 == 0 ? "#" : " ";
                }
                Console.WriteLine(zeile);
            }
        }

        // 51) Wechselgeld in möglichst wenigen Münzen/Scheinen (Beträge in Cent).
        static void Wechselgeld()
        {
            int cent = LeseInt("Betrag in Cent: ");
            if (cent < 0) { Console.WriteLine("Betrag muss >= 0 sein."); return; }
            int[] stueck = { 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };
            foreach (int s in stueck)
            {
                int anz = cent / s;
                if (anz > 0)
                {
                    Console.WriteLine(anz + " x " + (s >= 100 ? (s / 100) + " EUR" : s + " Cent"));
                    cent %= s;
                }
            }
        }

        // 52) Sekunden in Stunden:Minuten:Sekunden.
        static void Uhrzeit()
        {
            int sek = LeseInt("Sekunden: ");
            if (sek < 0) { Console.WriteLine("Nur positive Werte."); return; }
            int h = sek / 3600, m = sek % 3600 / 60, s = sek % 60;
            Console.WriteLine($"{h:D2}:{m:D2}:{s:D2}");
        }

        // 53) BMI aus Gewicht (kg) und Größe (m) mit Einordnung.
        static void Bmi()
        {
            double kg = LeseDouble("Gewicht in kg: ");
            double m = LeseDouble("Größe in m: ");
            if (kg <= 0 || m <= 0) { Console.WriteLine("Werte müssen positiv sein."); return; }
            double bmi = kg / (m * m);
            string kat;
            if (bmi < 18.5) { kat = "Untergewicht"; }
            else if (bmi < 25) { kat = "Normalgewicht"; }
            else if (bmi < 30) { kat = "Übergewicht"; }
            else { kat = "starkes Übergewicht"; }
            Console.WriteLine($"BMI: {bmi:F1} ({kat})");
        }

        // 54) Passwort prüfen: mind. 8 Zeichen, Großbuchstabe, Kleinbuchstabe, Ziffer.
        static void Passwort()
        {
            string pw = LeseText("Passwort: ");
            bool gross = false, klein = false, ziffer = false;
            foreach (char c in pw)
            {
                if (char.IsUpper(c)) { gross = true; }
                if (char.IsLower(c)) { klein = true; }
                if (char.IsDigit(c)) { ziffer = true; }
            }
            bool ok = pw.Length >= 8 && gross && klein && ziffer;
            Console.WriteLine(ok ? "Passwort ist stark genug." : "Zu schwach (8+ Zeichen, Groß, Klein, Ziffer nötig).");
        }

        // 55) Schere, Stein, Papier gegen den Computer.
        static void ScherePapier()
        {
            string[] namen = { "Schere", "Stein", "Papier" };
            Console.WriteLine("0 = Schere, 1 = Stein, 2 = Papier");
            int du = LeseInt("Deine Wahl: ");
            if (du < 0 || du > 2) { Console.WriteLine("Ungültig."); return; }
            int pc = new Random().Next(0, 3);
            Console.WriteLine("Computer: " + namen[pc]);
            if (du == pc) { Console.WriteLine("Unentschieden."); }
            else if ((du + 1) % 3 == pc) { Console.WriteLine("Du verlierst."); }   // Stein schlägt Schere usw.
            else { Console.WriteLine("Du gewinnst."); }
        }

        // 56) 3x3-Matrix einlesen, Hauptdiagonale, Nebendiagonale und Gesamtsumme.
        static void Matrix()
        {
            int[,] m = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++) { m[i, j] = LeseInt($"m[{i},{j}]: "); }
            }
            int haupt = 0, neben = 0, gesamt = 0;
            for (int i = 0; i < 3; i++)
            {
                haupt += m[i, i];
                neben += m[i, 2 - i];
                for (int j = 0; j < 3; j++) { gesamt += m[i, j]; }
            }
            Console.WriteLine($"Hauptdiagonale: {haupt}, Nebendiagonale: {neben}, Gesamtsumme: {gesamt}");
        }

        // 57) Einfache Textkompression: aaabbc wird a3b2c1.
        static void Kompression()
        {
            string t = LeseText("Text: ");
            if (t.Length == 0) { Console.WriteLine("Leer."); return; }
            StringBuilder sb = new StringBuilder();
            int anz = 1;
            for (int i = 1; i <= t.Length; i++)
            {
                if (i < t.Length && t[i] == t[i - 1]) { anz++; }
                else
                {
                    sb.Append(t[i - 1]).Append(anz);
                    anz = 1;
                }
            }
            Console.WriteLine(sb.ToString());
        }
