1) Primzahltest

int n = int.Parse(Console.ReadLine());
bool prim = n >= 2;
for (int i = 2; i * i <= n; i++)
{
    if (n % i == 0) { prim = false; }
}
Console.WriteLine(prim ? "prim" : "nicht prim");

2) Palindromtest

string t = Console.ReadLine().Replace(" ", "").ToLower();
bool pal = true;
int i = 0, j = t.Length - 1;
while (i < j)
{
    if (t[i] != t[j]) { pal = false; }
    i++; j--;
}
Console.WriteLine(pal ? "Palindrom" : "kein Palindrom");

3) Fibonacci bis zur Stelle n

int n = int.Parse(Console.ReadLine());
long a = 0, b = 1;
for (int i = 1; i <= n; i++)
{
    Console.Write(a + " ");
    long next = a + b;
    a = b;
    b = next;
}

4) Wortzähler

string text = Console.ReadLine();
int anz = 0;
bool imWort = false;
foreach (char z in text)
{
    if (z == ' ') { imWort = false; }
    else if (!imWort) { anz++; imWort = true; }
}
Console.WriteLine("Wörter: " + anz);

5) Text spiegelverkehrt

string text = Console.ReadLine();
string erg = "";
for (int i = text.Length - 1; i >= 0; i--)
{
    erg = erg + text[i];
}
Console.WriteLine(erg);

6) Größte von 4 Zahlen

int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());
int d = int.Parse(Console.ReadLine());
int max = a;
if (b > max) { max = b; }
if (c > max) { max = c; }
if (d > max) { max = d; }
Console.WriteLine(max);

Die 15 weiteren Aufgaben

7) kgV zweier Zahlen (über den ggT)

int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int x = a, y = b;
while (y != 0) { int r = x % y; x = y; y = r; }   // x = ggT
long kgv = (long)a / x * b;
Console.WriteLine("ggT = " + x + ", kgV = " + kgv);

8) Teiler, Anzahl und Summe

int n = int.Parse(Console.ReadLine());
int anzahl = 0; long summe = 0;
for (int i = 1; i <= n; i++)
{
    if (n % i == 0) { Console.Write(i + " "); anzahl++; summe += i; }
}
Console.WriteLine("\nAnzahl: " + anzahl + ", Summe: " + summe);

9) Armstrong-Zahlen (Ergebnis: 153, 370, 371, 407)

for (int z = 100; z <= 999; z++)
{
    int h = z / 100, t = z / 10 % 10, e = z % 10;
    if (h * h * h + t * t * t + e * e * e == z) { Console.Write(z + " "); }
}

10) Quadratische Gleichung

double a = double.Parse(Console.ReadLine());
double b = double.Parse(Console.ReadLine());
double c = double.Parse(Console.ReadLine());
if (a == 0)
{
    if (b == 0) { Console.WriteLine(c == 0 ? "unendlich viele Lösungen" : "keine Lösung"); }
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
    else { Console.WriteLine("keine reelle Lösung"); }
}

11) Primzahlen bis n (Sieb des Eratosthenes)

int n = int.Parse(Console.ReadLine());
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

12) Binär in Dezimal (10111011 ergibt 187)

string bin = Console.ReadLine();
long wert = 0;
foreach (char c in bin)
{
    wert = wert * 2 + (c - '0');
}
Console.WriteLine(wert);

13) Fünf Zahlen sortieren (Bubblesort)

int[] z = new int[5];
for (int i = 0; i < z.Length; i++) { z[i] = int.Parse(Console.ReadLine()); }
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

14) Caesar-Verschlüsselung („Hallo Welt!" mit k = 3 ergibt „Kdoor Zhow!")

string text = Console.ReadLine();
int k = int.Parse(Console.ReadLine());
string erg = "";
foreach (char c in text)
{
    if (c >= 'a' && c <= 'z') { erg += (char)('a' + ((c - 'a' + k) % 26 + 26) % 26); }
    else if (c >= 'A' && c <= 'Z') { erg += (char)('A' + ((c - 'A' + k) % 26 + 26) % 26); }
    else { erg += c; }
}
Console.WriteLine(erg);

15) Statistik (Mittelwert, Minimum, Maximum, Standardabweichung)

int n = int.Parse(Console.ReadLine());
double[] w = new double[n];
for (int i = 0; i < n; i++) { w[i] = double.Parse(Console.ReadLine()); }
double summe = 0, min = w[0], max = w[0];
foreach (double x in w)
{
    summe += x;
    if (x < min) { min = x; }
    if (x > max) { max = x; }
}
double mittel = summe / n, abw = 0;
foreach (double x in w) { abw += (x - mittel) * (x - mittel); }
Console.WriteLine($"Mittel {mittel:F2}, Min {min}, Max {max}, Std {Math.Sqrt(abw / n):F2}");

16) Pythagoreische Tripel bis n (für n = 20: (3,4,5), (5,12,13), (6,8,10), (8,15,17), (9,12,15), (12,16,20))

int n = int.Parse(Console.ReadLine());
for (int a = 1; a <= n; a++)
{
    for (int b = a + 1; b <= n; b++)
    {
        int q = a * a + b * b;
        int c = (int)Math.Round(Math.Sqrt(q));
        if (c <= n && c * c == q) { Console.WriteLine($"({a}, {b}, {c})"); }
    }
}

17) Taschenrechner

double a = double.Parse(Console.ReadLine());
string op = Console.ReadLine();
double b = double.Parse(Console.ReadLine());
switch (op)
{
    case "+": Console.WriteLine(a + b); break;
    case "-": Console.WriteLine(a - b); break;
    case "*": Console.WriteLine(a * b); break;
    case "/":
        if (b == 0) { Console.WriteLine("Division durch 0"); }
        else { Console.WriteLine(a / b); }
        break;
    default: Console.WriteLine("Unbekannter Operator"); break;
}

18) Zinseszins: Jahre bis zur Verdopplung (1000 € bei 5 % ergeben 15 Jahre)

double start = double.Parse(Console.ReadLine());
double p = double.Parse(Console.ReadLine());
double kapital = start;
int jahre = 0;
while (kapital < 2 * start)
{
    kapital = kapital * (1 + p / 100);
    jahre++;
}
Console.WriteLine(jahre + " Jahre");

19) Tannenbaum aus Sternchen

int n = int.Parse(Console.ReadLine());
for (int i = 1; i <= n; i++)
{
    Console.WriteLine(new string(' ', n - i) + new string('*', 2 * i - 1));
}

20) Anagramm-Test (Listen und Silent)

string w1 = Console.ReadLine().Replace(" ", "").ToLower();
string w2 = Console.ReadLine().Replace(" ", "").ToLower();
char[] a = w1.ToCharArray(), b = w2.ToCharArray();
Array.Sort(a); Array.Sort(b);
Console.WriteLine(new string(a) == new string(b) ? "Anagramme" : "keine Anagramme");

21) Fläche unter x² (Trapezregel) (von 0 bis 1 ergibt etwa 0,3333)

// außerhalb von Main:
static double F(double x) { return x * x; }

// in Main:
double a = double.Parse(Console.ReadLine());
double b = double.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());
double h = (b - a) / n;
double summe = (F(a) + F(b)) / 2;
for (int i = 1; i < n; i++) { summe += F(a + i * h); }
Console.WriteLine(summe * h);

