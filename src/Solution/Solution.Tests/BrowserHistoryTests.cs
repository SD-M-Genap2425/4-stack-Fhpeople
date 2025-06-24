using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.BrowserHistory; // Make sure to use the correct namespace

namespace Solution.Tests
{
    [TestClass]
    public class BrowserHistoryTests
    {
        [TestMethod]
        public void KunjungiHalaman_AddPages_HistoryUpdatedCorrectly()
        {
            var historyManager = new HistoryManager();
            historyManager.KunjungiHalaman("google.com");
            historyManager.KunjungiHalaman("example.com");

            Assert.AreEqual("example.com", historyManager.LihatHalamanSaatIni(), "Current page should be 'example.com'.");
        }

        [TestMethod]
        public void Kembali_GoBackToPreviousPage_Success()
        {
            var historyManager = new HistoryManager();
            historyManager.KunjungiHalaman("google.com");
            historyManager.KunjungiHalaman("example.com");
            var previousPage = historyManager.Kembali();

            Assert.AreEqual("google.com", previousPage, "Should return to 'google.com'.");
        }

        [TestMethod]
        public void Kembali_NoPreviousPage_ReturnsNoPreviousPageMessage()
        {
            var historyManager = new HistoryManager();
            historyManager.KunjungiHalaman("google.com");
            var result = historyManager.Kembali();

            Assert.AreEqual("Tidak ada halaman sebelumnya.", result, "Should indicate no previous page.");
        }

        [TestMethod]
        public void LihatHalamanSaatIni_ViewCurrentPage_ReturnsCorrectPage()
        {
            var historyManager = new HistoryManager();
            historyManager.KunjungiHalaman("stackoverflow.com");

            Assert.AreEqual("stackoverflow.com", historyManager.LihatHalamanSaatIni(), "Current page should be 'stackoverflow.com'.");
        }

        [TestMethod]
        public void TampilkanHistory_AfterVisitingMultiplePages_ShowsAllPages()
        {
            var historyManager = new HistoryManager();
            historyManager.KunjungiHalaman("google.com");
            historyManager.KunjungiHalaman("example.com");

            // This is an example of how to test output, but in practice, you might test the internal state or use an interface to capture output.
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                historyManager.TampilkanHistory();

                var expected = string.Join(Environment.NewLine, new[] { "example.com", "google.com" }) + Environment.NewLine;
                Assert.AreEqual(expected, sw.ToString(), "Should display all visited pages in order.");
            }
        }
    }
}