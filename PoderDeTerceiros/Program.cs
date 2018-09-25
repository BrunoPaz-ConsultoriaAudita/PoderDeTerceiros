using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoderDeTerceiros
{
	class Program
	{
		static void Main(string[] args)
		{
			string local = @"C:\Users\TI2\Desktop\Bruno Paz\PoderDeTerceiros\PoderDeTerceiros\PoderDeTerceiros\bin\Debug\batata.txt";
			StreamReader reader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "in.txt");
			StreamWriter writer = new StreamWriter(local);
			int x = 1;
			string line;
			List<string> listaLine = new List<string>();
			while ((line = reader.ReadLine()) != null)
			{
				if(line != "")
				{
					listaLine = line.Substring(0, 32).Split(' ').ToList<string>();
					int val;
					if (int.TryParse(line.Substring(0, 1), out val))
					{
						Console.WriteLine("ok");
					}
				}
				

					
				//
			}
			
			Console.ReadLine();
		}
	}

}
