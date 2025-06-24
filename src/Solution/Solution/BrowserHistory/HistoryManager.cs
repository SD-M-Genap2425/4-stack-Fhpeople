using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BrowserHistory
{
    public class Halaman
    {
        public string URL { get; set; }

        public Halaman(string url)
        {
            URL = url;
        }
    }

    public class Node
    {
        public Halaman Data { get; set; }
        public Node Next { get; set; }

        public Node(Halaman data)
        {
            Data = data;
            Next = null;
        }
    }

    public class Stack
    {
        private Node top;

        public Stack()
        {
            top = null;
        }

        public void Push(Halaman halaman)
        {
            Node newNode = new Node(halaman);
            newNode.Next = top;
            top = newNode;
        }

        public Halaman Pop()
        {
            if (IsEmpty()) return null;

            Halaman data = top.Data;
            top = top.Next;
            return data;
        }

        public Halaman Peek()
        {
            return top != null ? top.Data : null;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public void Tampilkan()
        {
            Node current = top;
            while (current != null)
            {
                Console.WriteLine($"{current.Data.URL}"); // hilangkan index
                current = current.Next;
            }
        }
    }

    public class HistoryManager
    {
        private Stack history = new Stack();

        public void KunjungiHalaman(string url)
        {
            Halaman halamanBaru = new Halaman(url);
            history.Push(halamanBaru);
            Console.WriteLine($"Mengunjungi halaman: {url}");
        }

        public string Kembali()
        {
            if (history.IsEmpty())
            {
                Console.WriteLine("Tidak ada halaman untuk kembali.");
                return null;
            }

            history.Pop();

            Halaman halamanSebelumnya = history.Peek();

            if (halamanSebelumnya == null)
            {
                Console.WriteLine("Tidak ada halaman sebelumnya.");
                return "Tidak ada halaman sebelumnya.";
            }

            Console.WriteLine("Kembali ke halaman sebelumnya...");
            return halamanSebelumnya.URL;
        }

        public string LihatHalamanSaatIni()
        {
            Halaman current = history.Peek();
            return current?.URL ?? "Tidak ada halaman saat ini.";
        }

        public void TampilkanHistory()
        {
            history.Tampilkan();
        }
    }
}