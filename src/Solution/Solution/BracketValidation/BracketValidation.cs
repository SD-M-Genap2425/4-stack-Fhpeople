using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BracketValidation
{
    public class Node
    {
        public char Data;
        public Node Next;

        public Node(char data)
        {
            Data = data;
            Next = null;
        }
    }

    public class BracketValidator
    {
        private Node top;

        public BracketValidator()
        {
            top = null;
        }

        private void Push(char c)
        {
            Node newNode = new Node(c);
            newNode.Next = top;
            top = newNode;
        }

        private char Pop()
        {
            if (IsEmpty())
                return '\0';

            char data = top.Data;
            top = top.Next;
            return data;
        }

        private char Peek()
        {
            return top != null ? top.Data : '\0';
        }

        private bool IsEmpty()
        {
            return top == null;
        }

        public bool ValidasiEkspresi(string ekspresi)
        {
            foreach (char c in ekspresi)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    char topChar = Pop();
                    if (!Pasangan(topChar, c))
                        return false;
                }
            }

            return IsEmpty();
        }

        private bool Pasangan(char buka, char tutup)
        {
            return (buka == '(' && tutup == ')') ||
                   (buka == '{' && tutup == '}') ||
                   (buka == '[' && tutup == ']');
        }
    }
}