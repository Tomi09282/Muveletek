using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oof
{
    internal class Muvelet
    {
        int a, b;
        string str;

        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }
        public string STR { get => str; set => str = value; }

        public string Result
        {
            get
            {
                try
                {
                    switch (STR)
                    {
                        case "mod":
                            return (A % B).ToString();
                        case "/":
                            return (A * 1.00 / B).ToString();
                        case "div":
                            return (A / B).ToString();
                        case "-":
                            return (A - B).ToString();
                        case "*":
                            return (A * B).ToString();
                        case "+":
                            return (A + B).ToString();
                        default:
                            return "hiba!";
                    }
                }
                catch (Exception)
                {
                    return "hiba!";
                }
            }
        }

        public Muvelet(string line)
        {
            string[] data = line.Split(' ');
            A = int.Parse(data[0].Trim());
            str = data[1].Trim();
            B = int.Parse(data[2].Trim());
        }

        public override string ToString()
        {
            return $"{A} {STR} {B} = {Result}";
        }
    }
}
