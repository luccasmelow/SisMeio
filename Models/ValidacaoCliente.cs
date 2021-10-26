using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Sismeio.Models
{
    class ValidacaoCliente : AbstractValidator<Cliente>
    {
        public ValidacaoCliente()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo Nome é obrigatório.");
            RuleFor(x => x.CPF).NotEmpty().WithMessage("O campo CPF é obrigatório.");

        }
    }
}
