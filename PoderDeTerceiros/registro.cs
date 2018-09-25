using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoderDeTerceiros
{
	class registro
	{
		public int id { get; set; }
		public int est { get; set; }
		public int emit { get; set; }
		public string item { get; set; }
		public DateTime dtMovto { get; set; }
		public int seq { get; set; }
		public int ser { get; set; }
		public string num { get; set; }
		public string natur { get; set; }
		public double qtd { get; set; }
		public double saldo { get; set; }
		public double valor { get; set; }
		public string mens { get; set; }

		public override string ToString()
		{
			string str = est + "|" + emit + "|" + item + "|" + dtMovto + "|" + seq + "|" + ser + "|" + num + "|" + natur + "|" + qtd + "|" + valor + "|" + mens;
			return str;
		}
	}
}
