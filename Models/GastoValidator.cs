using System;
using System.Collections.Generic;
using System.Text;
using Sismeio.Interfaces;
using Sismeio.Base;
using System.Threading.Tasks;
using FluentValidation;

namespace Sismeio.Models
{
    class GastoValidator : AbstractValidator<Gasto>
    {
        public GastoValidator()
        {
            RuleFor(x => x.Valor).NotEmpty().WithMessage("O campo valor é obrigatório. Favor Preencher");
            RuleFor(x => x.Data).NotEmpty().WithMessage("O campo data é obrigatório. Favor Preencher");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("O campo descrição é obrigatório. Favor Preencher");
            RuleFor(x => x.Caixa).NotEmpty().WithMessage("O campo caixa é obrigatório. Favor Preencher");
        }
    }
    
    
    
}
