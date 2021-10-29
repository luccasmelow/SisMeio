using System;
using System.Collections.Generic;
using System.Text;

namespace Sismeio.Models
{
    class Funcionario
    {


		/*
		 * funcionario
		 * Codigo -> cod_fun
		 * Nome -> nome_fun
		 * RG -> rg_fun
		 * CPF -> cpf_fun
		 * DataNascimento -> data_nasc_fun
		 * Sexo -> sexo_fun
		 * Telefone -> telefone_fun
		 * Setor -> setor_fun
		 * DataAdmissao -> data_admissao_fun
		 */


		
		public int Codigo { get; set; }

		public string Nome { get; set; }
		public string Sexo { get; set; }
		public string RG { get; set; }

		public string CPF { get; set; }

		public DateTime DataNascimento { get; set; }
		public DateTime DataAdmissao { get; set; }

		public string Telefone { get; set; }

		public Double Salario { get; set; }
		public string Setor { get; set; }
		public Endereco Endereco { get; set; }


	}
}
