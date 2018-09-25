using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
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

			writer.WriteLine("INSERT INTO [dbo].[poderTerceiroTemp]([id],[Est],[Emit],[Item],[DtMovto],[Seq],[Ser],[Numero],[Natur],[NossaQtde],[Saldo],[Valor],[Mens])");
			writer.WriteLine("VALUES ");

			int cont = 1;
			while ((line = reader.ReadLine()) != null)
			{
				if(line != ""&&line.Length>=128)
				{
					
					int val = 0;
					if (int.TryParse(line.Substring(0, 1), out val) && (int.Parse(line.Substring(0, 1)) == 5))
					{
						if (val == -1)
						{
							writer.WriteLine(",");
							
						}
						else
						{
							val = -1;
						}
						Registro registro = new Registro();
						Console.WriteLine("ok");
						listaLine = line.Substring(0, 32).Split(' ').ToList<string>();
						removeEspaco(listaLine);
						registro.est = listaLine[0];
						registro.emit = listaLine[1];
						registro.item = listaLine[2];
						if (listaLine.Count > 3)
						{
							for(int i = 3; i < listaLine.Count; i++)
							{
								registro.item += " " + listaLine[i];
							}
						}
						listaLine = line.Substring(32).Split(' ').ToList<string>();
						removeEspaco(listaLine);
						string data = listaLine[0];
						int dia = int.Parse(data.Split('/')[0]);
						int mes = int.Parse(data.Split('/')[1]);
						int ano = int.Parse("20" + data.Split('/')[2]);
						registro.dtMovto = new DateTime(ano,mes,dia);
						listaLine = line.Substring(40, 14).Split(' ').ToList<string>();
						removeEspaco(listaLine);
						registro.seq = listaLine[0];
						registro.ser = (listaLine.Count == 1?"":listaLine[1]);
						listaLine = line.Substring(54).Split(' ').ToList<string>();
						removeEspaco(listaLine);
						registro.num = listaLine[0];
						registro.natur = listaLine[1];
						registro.qtd = formataNum(listaLine[2]);
						registro.saldo = formataNum(listaLine[3]);
						registro.valor = formataNum(listaLine[4]);
						registro.mens = listaLine[5];
						if (listaLine.Count > 6)
						{
							for (int i = 6; i < listaLine.Count; i++)
							{
								registro.mens += " " + listaLine[i];
							}
						}
						Console.WriteLine(registro.ToString());
						writer.WriteLine(registro.insertValues(cont));
						cont++;
						
					}

					if (line.Contains("Ret"))
					{
						writer.WriteLine(",");
						Registro registro = new Registro();
						Console.WriteLine("ret ok");
						listaLine = line.Substring(32).Split(' ').ToList<string>();
						removeEspaco(listaLine);
						string data = listaLine[0];
						int dia = int.Parse(data.Split('/')[0]);
						int mes = int.Parse(data.Split('/')[1]);
						int ano = int.Parse("20" + data.Split('/')[2]);
						registro.dtMovto = new DateTime(ano, mes, dia);
						listaLine = line.Substring(40, 14).Split(' ').ToList<string>();
						removeEspaco(listaLine);
						registro.seq = listaLine[0];
						registro.ser = (listaLine.Count == 1 ? "" : listaLine[1]);
						listaLine = line.Substring(54).Split(' ').ToList<string>();
						removeEspaco(listaLine);
						registro.num = listaLine[0];
						registro.natur = listaLine[1];
						registro.qtd = formataNum(listaLine[2]);
						registro.saldo = formataNum(listaLine[3]);
						registro.valor = formataNum(listaLine[4]);
						registro.mens = listaLine[5];
						if (listaLine.Count > 6)
						{
							for (int i = 6; i < listaLine.Count; i++)
							{
								registro.mens += " " + listaLine[i];
							}
						}
						Console.WriteLine(registro.ToString());
						writer.WriteLine(registro.insertValues(cont-1));
						cont++;
					}
					
				}
				

					
				//
			}

			writer.Flush();
			Console.ReadLine();
		}

		static void removeEspaco(List<string> _in)
		{
			_in.RemoveAll(x=>x == "");
		}

		static double formataNum(string str)
		{
			double num = -1;
			str = str.Replace(".","");
			str = str.Replace(',', '.');
			num = double.Parse(str,CultureInfo.InvariantCulture);
			return num;
		}
	}

}
