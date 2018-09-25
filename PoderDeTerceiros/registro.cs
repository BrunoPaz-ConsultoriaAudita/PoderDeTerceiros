using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoderDeTerceiros
{
	class Registro
	{
		public int id { get; set; }
		public string est { get; set; }
		public string emit { get; set; }
		public string item { get; set; }
		public DateTime dtMovto { get; set; }
		public string seq { get; set; }
		public string ser { get; set; }
		public string num { get; set; }
		public string natur { get; set; }
		public double qtd { get; set; }
		public double saldo { get; set; }
		public double valor { get; set; }
		public string mens { get; set; }

		public override string ToString()
		{
			string str = est + "|" + emit + "|" + item + "|" + dtMovto + "|" + seq + "|" + ser + "|" + num + "|" + natur + "|" + qtd + "|" + saldo + "|" + valor + "|" + mens;
			return str;
		}

		public string insertValues(int cont)
		{
			string str;
			str = "(" + cont + ",'" + est + "','" + emit + "','" + item + "','" + dtMovto.Year + "-" + dtMovto.Month+"-"+dtMovto.Day + "','" + seq + "','" + ser + "','" + num + "','" + natur + "','" + qtd + "','" + saldo + "','" + valor + "','" + mens + "')";
			return str;
		}
	}
}
