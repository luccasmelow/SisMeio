using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace Sismeio.Models
{
    class ProdutoValidator:AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo Nome é obrigatório.");
            RuleFor(x => x.Categoria).NotEmpty().WithMessage("O campo categoria é obrigatório.");
            RuleFor(x => x.Marca).NotEmpty().WithMessage("O campo Marca é obrigatório.");
            RuleFor(x => x.Categoria).NotEmpty().WithMessage("O campo Categoria é obrigatório.");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("O campo Descrição é obrigatório.");
           
            RuleFor(x => x.Peso).NotEmpty().WithMessage("O campo Peso é obrigatório.");
            RuleFor(x => x.Entrega).NotEmpty().WithMessage("O campo Entrega é obrigatório.");
            RuleFor(x => x.Importacao).NotEmpty().WithMessage("O campo Importação é obrigatório.");
            RuleFor(x => x.ValorUnitario).NotEmpty().WithMessage("O campo Valor é obrigatório.");
            
            RuleFor(x => x.ValorEstoque).NotEmpty().WithMessage("O campo Estoque é obrigatório.");
            



        }
    }
}
