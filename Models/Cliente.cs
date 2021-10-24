using System;

namespace Sismeio.Models
{


	public class Cliente
	{
		/*
		 * Cliente
		 * Codigo -> cod_cli 
		 * Nome -> nome_cli
		 * RG -> rg_cli
		 * CPF -> cpf_cli
		 * DataNascimento -> data_nasc_cli
		 * Sexo -> sexo_cli
		 * Telefone -> telefone_cli
		 * Situação -> situacao_cli
		 * Historico -> historico_cli
		 */



		public int Codigo { get; set; }

		public string Nome { get; set; }

		public string RG { get; set; }

		public string CPF { get; set; }

		public string DataNascimento { get; set; }

		public string Sexo { get; set; }

		public string Telefone { get; set; }


		public string Situacao { get; set; }

		public string Historico { get; set; }


	}
}