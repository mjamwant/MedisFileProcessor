using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedisFileProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare variables
            string FileHead;
            string CustNum;
            string PurcNum;
            String FileFoot;
            int Chop;


            string orderfile = System.IO.File.ReadAllText(@"C:\Users\michael.jamwant\Documents\Projects\Kroll Ordering - Magento\MEDIS.ORD");

            //The variable chop is used to measure out the length until we hit the delimiter + sign, then we can use that number to put substrings into the 
            //appropriate variables and truncate the orderfile string. This block chops off the File Header
            Chop = orderfile.IndexOf("+");
            FileHead = orderfile.Substring(0, Chop);
            orderfile = orderfile.Remove(0, Chop + 1);

            //This block chops off the customer number string and removes it from the orderfile string
            Chop = orderfile.IndexOf("+");
            CustNum = orderfile.Substring(0, Chop);
            orderfile = orderfile.Remove(0, Chop + 1);

            //This block chops off the purchase order number string and removes it from the orderfile string
            Chop = orderfile.IndexOf("+");
            PurcNum = orderfile.Substring(0, Chop);
            orderfile = orderfile.Remove(0, Chop + 1);

            //Trim whitespace off PO
            PurcNum = PurcNum.TrimEnd();

            //This block chops off the file footer string and removes it from the orderfile string
            Chop = orderfile.IndexOf("+AAAAAAAAAA+");
            FileFoot = orderfile.Remove(0, Chop);
            orderfile = orderfile.Remove(Chop, 12);

            System.Console.WriteLine(FileHead);
            System.Console.WriteLine(CustNum);
            System.Console.WriteLine(PurcNum);
            System.Console.WriteLine(FileFoot);
            System.Console.WriteLine(orderfile);

            //Get the number of items
            int ttlitems;
            string[] itemcount;
            itemcount = orderfile.Split('+');
            ttlitems = (itemcount.Length);
            System.Console.WriteLine(ttlitems);

            //Put Items into List
            List<string> itemsList = orderfile.Split('+').ToList();
            System.Console.WriteLine(itemsList);

            foreach(string item in itemsList)

            {
                System.Console.WriteLine(item);
            }

            //Additional Notes: If adding an ability to remove or add items from a file, any item search should include the leading + in the search string, in order to ensure
            //a false early match does not occur with the trailing 5 numbers of an item number followed by the first digit of the quantity performs a fal

        }
    }
}
