using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Sismeio.Models
{
    class CaixaValidator : AbstractValidator<Caixa>
    {
        public CaixaValidator()
        {
            RuleFor(x => x.Mes).NotEmpty().WithMessage("O campo mês é obrigatório. Favor Preencher");
            RuleFor(x => x.SaldoAnt).NotEmpty().WithMessage("O campo saldo anterior é obrigatório. Favor Preencher");
            RuleFor(x => x.SaldoFin).NotEmpty().WithMessage("O campo saldo final é obrigatório. Favor Preencher");
            RuleFor(x => x.Debitos).NotEmpty().WithMessage("O campo debitos é obrigatório. Favor Preencher");
            RuleFor(x => x.Creditos).NotEmpty().WithMessage("O campo creditos é obrigatório. Favor Preencher");
        }
    }



}
