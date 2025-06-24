using Solution.BracketValidation;
using Solution.BrowserHistory;
using Solution.Palindrome;

namespace Solution;

internal class Program
{
    static void Main(string[] args)
    {
        // Browser history
        HistoryManager browser = new HistoryManager();
        browser.KunjungiHalaman("google.com");
        browser.KunjungiHalaman("example.com");
        browser.KunjungiHalaman("stackoverflow.com");
        Console.WriteLine($"Halaman saat ini: {browser.LihatHalamanSaatIni()}");
        browser.Kembali();
        Console.WriteLine($"Halaman saat ini: {browser.LihatHalamanSaatIni()}");
        browser.TampilkanHistory();

        // Bracket validator
        BracketValidator validator = new BracketValidator();
        string ekspresiValid1 = "[{}](){}";
        string ekspresiValid2 = "([]{[]})[]{{}()}";
        string ekspresiInvalid1 = "(]";
        string ekspresiInvalid2 = "([)]";
        string ekspresiInvalid3 = "{[}";
        Console.WriteLine($"Ekspresi '{ekspresiValid1}' valid? {validator.ValidasiEkspresi(ekspresiValid1)}");
        Console.WriteLine($"Ekspresi '{ekspresiValid2}' valid? {validator.ValidasiEkspresi(ekspresiValid2)}");
        Console.WriteLine($"Ekspresi '{ekspresiInvalid1}' valid? {validator.ValidasiEkspresi(ekspresiInvalid1)}");
        Console.WriteLine($"Ekspresi '{ekspresiInvalid2}' valid? {validator.ValidasiEkspresi(ekspresiInvalid2)}");
        Console.WriteLine($"Ekspresi '{ekspresiInvalid3}' valid? {validator.ValidasiEkspresi(ekspresiInvalid3)}");

        //Palindrome Checker
        string[] test = 
        {
            "Kasur ini rusak",
            "Ibu Ratna antar ubi",
            "Hello World"
        };

        foreach (var str in test)
        {
            bool hasil = PalindromeChecker.CekPalindrom(str);
            Console.WriteLine($"Input: \"{str}\" => Palindrom? {hasil}");
        }
    }
}