#Grupo: Snow

#Alunos: Alyne Pereira, Gabriella Batista, Hêmilly Priscila, Luccas Mello, Rodrigo Sullivan, Thiago Marin.

#Requisitos Funcionais:

#Consultar Estoque: Atualizar Produto, Realizar Vendas, Acessar Menu Principal, Controlar Gastos, Cadastrar Cliente, Cadastrar Caixa, Cadastrar Fornecedor, Consultar Caixa
#Consultar Clientes, Cadastrar Funcionário, Consultar Funcionário, Cadastrar Produto, Consultar Vendas, Consultar Compras, Registrar Compra


#Banco de Dados:

create database BD_EQUIPE_SNOW;
use  BD_EQUIPE_SNOW;

#drop database BD_EQUIPE_SNOW;

 #TABELAS -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create table endereco(
cod_end int auto_increment primary key  not null, 
logradouro varchar (200) not null,
bairro varchar(200) not null,
numero int not null,
cep varchar (8) not null,
cidade varchar (200) not null,
estado varchar(2) not null
);

create table funcionario(
cod_fun int auto_increment not null primary key , 
nome_fun varchar (200) not null,
setor_fun varchar(200) not null,
rg_fun  varchar(12) not null,
cpf_fun varchar (11) not null,
data_nasc_fun date not null,
sexo_fun varchar(50) not null,
salario_fun float not null,
telefone_fun varchar (20) not null,
data_admissao_fun date not null,
cod_end_fk int not null,
foreign key (cod_end_fk) references endereco (cod_end)
);

alter table funcionario change sexo_fun sexo_fun varchar(9) after data_nasc_fun;

create table cliente(
cod_cli int auto_increment not null unique, 
nome_cli varchar (200) not null,
rg_cli varchar(12) not null,
cpf_cli varchar (11) not null,
data_nasc_cli date not null,
sexo_cli varchar(200) not null,
telefone_cli varchar (20) not null,
situacao_cli varchar(200) not null,
historico_cli varchar(200),
cod_end_fk int not null,
foreign key (cod_end_fk) references endereco (cod_end)
);

alter table cliente change sexo_cli sexo_cli varchar(9) after data_nasc_cli;

create table produto(
cod_pro int auto_increment not null unique, 
nome_pro varchar (200) not null,
categoria_pro varchar (200) not null,
numeracao_pro int not null,
descricao_pro varchar(200),
estoque_pro int not null, 
data_import date not null,
data_entrega date not null,
marca_prod varchar(200) not null,
quant_pro int not null, 
peso_pro float not null,
preco_pro float not null

);


alter table produto drop column quant_pro; 

create table fornecedor(
cod_for int auto_increment not null primary key , 
nome_for varchar(200) not null,
cnpj_for varchar (14) not null,
cod_end_fk int,
foreign key (cod_end_fk) references endereco (cod_end)
);

create table loja ( 
cod_loj int auto_increment not null primary key, 
nome_loj varchar(200) not null,
cnpj_loj varchar (14) not null, 
cod_end_fk int not null,
foreign key (cod_end_fk) references endereco (cod_end)
);

create table caixa(
cod_cai int auto_increment not null primary key ,
mes_cai varchar(200) not null,
saldo_ant_cai float not null,
saldo_final_cai float not null,
debitos_cai float not null,
creditos_cai float not null
);


create table vendas(
cod_ven int auto_increment not null primary key,
valor_ven float not null,
quantipro_ven int not null,
data_ven date not null,
desconto_ven float,
formapagamento_ven varchar(200) not null,
cod_cli_fk int not null,
cod_fun_fk int not null,
cod_cai_fk int not null,
foreign key (cod_cli_fk) references cliente (cod_cli),
foreign key (cod_fun_fk) references funcionario (cod_fun),
foreign key (cod_cai_fk) references caixa (cod_cai)
);

create table produto_venda(
cod_venpro int not null auto_increment primary key,
cod_pro_fk int not null,
cod_ven_fk int not null,
quantidadepro_ven int not null,
foreign key (cod_pro_fk) references produto (cod_pro),
foreign key (cod_ven_fk) references vendas (cod_ven)
);

create table compras(
cod_com int auto_increment not null primary key,
valor_com float not null,
quantpro_com int not null,
data_com date not null,
frete_com float not null,
cod_for_fk int not null,
data_entreg_com date not null,
cod_cai_fk int not null,
foreign key (cod_for_fk) references fornecedor (cod_for),
foreign key (cod_cai_fk) references caixa (cod_cai)
);

create table produto_compra(
cod_procom int not null auto_increment primary key,
cod_pro_fk int not null,
cod_for_fk int not null,
quantidadepro_com int not null,
foreign key (cod_pro_fk) references produto (cod_pro),
foreign key (cod_for_fk) references fornecedor (cod_for)
);


 create table gastos(
 cod_gas int auto_increment not null primary key ,
 valor_gas float not null,
 data_gas date not null,
 descricao varchar(200),
 cod_cai_fk int,
 foreign key (cod_cai_fk) references caixa (cod_cai)
 );
 
 #PROCEDIMENTOS E GATILHOS -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

delimiter $$

create procedure Inserir_Endereco (id_endereco int, logradouro_end varchar(200), bairro_end varchar(200), numero_end int, cep_end varchar(8), cidade_end varchar(200), estado_end varchar(2))

#Verificar se o endereço é da cidade ou estado

begin

	if(estado_end <> 'RO') then 
    
		insert into endereco(cod_end, logradouro, bairro, numero, cep, cidade, estado) 
		values (id_endereco, logradouro_end, bairro_end, numero_end, cep_end, cidade_end, estado_end);
            
		select 'Endereço de outro estado inserido com sucesso' as Confirmação;
		
    else 
		if (cidade_end <> 'Ouro Preto do Oeste') then
        
			insert into endereco(cod_end, logradouro, bairro, numero, cep, cidade, estado) 
		    values (id_endereco, logradouro_end, bairro_end, numero_end, cep_end, cidade_end, estado_end);
			
			select 'Endereço de outra cidade inserido com sucesso' as Confirmação;
		else 
        
			insert into endereco(cod_end, logradouro, bairro, numero, cep, cidade, estado) 
		    values (id_endereco, logradouro_end, bairro_end, numero_end, cep_end, cidade_end, estado_end);
        
			select 'Endereço da mesma cidade inserido com sucesso' as Confirmação;
		end if;
    end if;
    
end;

$$ delimiter ;
#drop procedure Inserir_Endereco;

#Call -------------------------------------------------------------------------------------------------------------

call Inserir_Endereco (null, 'Rua Santos Dumont', 'Nova Ouro Preto', 785, '76920000', 'Ouro Preto do Oeste', 'RO');
call Inserir_Endereco (null, 'Rua das Flores', 'Cidade Alta', 75, '76920210', 'Cáceres', 'MT');
call Inserir_Endereco (null, 'Rua Maringá', 'Cidade Alta', 556, '76925800', 'São Francisco do Guaporé', 'RO');
call Inserir_Endereco (null, 'Avenida 15 de Novembro', 'liberdade', 56, '76925800', 'Ouro Preto do Oeste', 'RO');
call Inserir_Endereco (null, 'Avenida Daniel Comboni', 'liberdade', 506, '76925800', 'Ouro Preto do Oeste', 'RO');
call Inserir_Endereco (null, 'Avenida Jk', 'Vale das Onças', 1006, '76956300', 'São Paulo', 'SP');
call Inserir_Endereco (null, 'Avenida Principal', 'lírios', 789, '78963200', 'Rio de Janeiro', 'RJ');

select*from Endereco;

 #Funcionário-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

delimiter $$

create procedure Inserir_Funcionario (id_fun int, nome varchar(200), setor varchar(200), rg varchar(12), cpf varchar(11), datanascimen date, sexo varchar(9), salario float, telefone varchar(200), datadmissao date, id_endereco int )

#Verificar se já tem alguém com mesmo cpf e se a fk de endereço existe.

begin

declare verifica_cpf varchar(11);
declare verifica_end int;

set verifica_cpf = (select cpf_fun from funcionario where cpf_fun = cpf);
set verifica_end = (select cod_end from endereco where cod_end = id_endereco);


	if (verifica_cpf is null) then 
    
		if (verifica_end is null) then 
        
			select 'Endereço inexistente' as Erro;
        			            
		else 
			if ( sexo <> 'Feminino') then
            
				insert into funcionario(cod_fun, nome_fun, setor_fun, rg_fun, cpf_fun, data_nasc_fun, sexo_fun, salario_fun, telefone_fun, data_admissao_fun, cod_end_fk)
				values (id_fun, nome, setor, rg, cpf, datanascimen, sexo, salario, telefone, datadmissao, id_endereco) ;
        
				select 'Funcionário inserido com sucesso!' as Confirmação;
                
			else 
            
				insert into funcionario(cod_fun, nome_fun, setor_fun, rg_fun, cpf_fun, data_nasc_fun, sexo_fun, salario_fun, telefone_fun, data_admissao_fun, cod_end_fk)
				values (id_fun, nome, setor, rg, cpf, datanascimen, sexo, salario, telefone, datadmissao, id_endereco) ;
        
				select 'Funcionária inserido com sucesso!' as Confirmação;
                
			end if;
            
		end if;
        
    else 
    
		select 'Erro! CPF já cadastrado' as Erro;
    
    end if;

end;

$$ delimiter ;

#drop procedure Inserir_Funcionario;

#Call ------------------------------------------------------------------------------------------------------------------------------------------------------------

call Inserir_Funcionario (null, 'Alyne Pereira de Oliveira', 'Vendas', '1487566', '04558033244', '2004-03-04', 'Feminino', 1600.0, '992898473', '2021-08-31', 1 );
call Inserir_Funcionario (null, 'Gabriella Batista', 'Marketing', '25677812', '0009365244', '2003-12-23', 'Feminino', 1400.0, '992709413', '2021-07-14', 12 );
call Inserir_Funcionario (null, 'Hêmilly Priscila', 'Marketing', '25698812', '0000365244', '2004-02-18', 'Feminino', 1400.0, '992709412', '2021-07-31', 4);
call Inserir_Funcionario (null, 'Hêmilly Priscila', 'Marketing', '25698819', '0000365244', '2004-02-18', 'Feminino', 1400.0, '992709412', '2021-07-31', 4);
call Inserir_Funcionario (null, 'Luccas Mello', 'Estoque', '1569825', '04226988633', '2002-02-18', 'Masculino', 1500.0, '992909412', '2021-06-04', 3);

select * from funcionario;

 #Cliente -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

delimiter $$

create procedure Inserir_Cliente (Id_cli int, nome varchar(200), rg varchar(12), cpf varchar(11), nascimento date, sexo varchar(9), telefone varchar(20), situacao varchar (200), historico varchar (200), endereco int  )

#Verificar se já tem alguém com mesmo cpf e se a fk de endereço existe.

begin
declare verifica_cpf varchar(11);
declare verifica_end int;

set verifica_cpf = (select cpf_cli from cliente where cpf_cli = cpf);
set verifica_end = (select cod_end from endereco where cod_end = endereco);


	if (verifica_cpf is null) then 
    
		if (verifica_end is null) then 
        
			select 'Endereço inexistente' as Erro;
        			            
		else 
			insert into cliente(cod_cli, nome_cli, rg_cli, cpf_cli, data_nasc_cli, sexo_cli, telefone_cli, situacao_cli, historico_cli, cod_end_fk)
			values (Id_cli, nome, rg, cpf, nascimento, sexo, telefone, situacao, historico, endereco) ;
        
			select 'Cliente inserido com sucesso!' as Confirmação;
		end if;
    else 
    
		select 'Erro! CPF já cadastrado' as Erro;
    
    end if;
end;

$$ delimiter ;

#drop procedure Inserir_Cliente; 

#Call ------------------------------------------------------------------------------------------------------------------------------------------------------------------

call Inserir_Cliente (null, 'Thiago Marin Wolfran', '1562335', '03669855122', '2003-08-29', 'Masculino', '(69) 9.9286-9523', 'Sem débitos', '6 Compras finalizadas', 2 );
call Inserir_Cliente (null, 'Rodrigo Sullivan', '1583335', '04669855122', '2003-07-29', 'Masculino', '(69) 9.9277-9515', '1 débito', '1 Compra Não paga', 5 );
call Inserir_Cliente (null, 'Rodrigo Sullivan', '1583335', '04669855122', '2003-07-29', 'Masculino', '(69) 9.9277-9515', '1 débito', '1 Compra Não paga', 5 );
call Inserir_Cliente (null, 'Marcio Rodrigues', '1587835', '08996322544', '1990-02-28', 'Masculino', '(69) 9.8469-0382', 'Sem débitos', '8 Compras Finalizadas', 19 );

 #Produto -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

delimiter $$

create procedure Inserir_Produto (Id_prod int, nome varchar(200), categoria varchar(200), numeracao int, descricao varchar(200), estoque int, importacao date, entrega date, marca varchar(200), peso float, preco float)

begin

	if(estoque <= 0) then
    
		select 'Estoque negativo' as Erro;
	else 
		
        if(numeracao > 46) then
        
			select 'Verifique a numeração' as Atenção;
            
		else 
        
			insert into produto() values (Id_prod, nome, categoria, numeracao, descricao, estoque, importacao, entrega, marca, peso, preco);
			select ' Produto cadastrado com sucesso' as Confirmação;
            
		end if;
        
	end if;

end;

$$ delimiter ;

#drop procedure Inserir_Produto;


#Call -------------------------------------------------------------------------------------------------------------------------------------------------------------------------

call Inserir_Produto (null, 'Tênis Azul Marinho Adidas', 'Tênis Feminino ', 38, 'Tenis Azul Marinho', 20, '2021-08-05', '2021-08-25', 'Adidas', 700.0, 129.90 );
call Inserir_Produto (null, 'Tênis Verde Militar Marinho Adidas', 'Tênis Masculino ', 48, 'Tenis Verde Militar', 30, '2021-08-05', '2021-08-25', 'Adidas', 700.0, 129.90 );
call Inserir_Produto (null, 'Tênis Verde Militar Marinho Adidas', 'Tênis Masculino ', 42, 'Tenis Verde Militar', 30, '2021-08-05', '2021-08-25', 'Adidas', 700.0, 129.90 );
call Inserir_Produto (null, 'Sapatilha Rosa Molequinha', 'Sapatilha infantil ', 28, 'Sapatilha rosa infantil', 8, '2021-08-05', '2021-08-25', 'Moleca', 700.0, 129.90 );
call Inserir_Produto (null, 'Sapatilha Rosa Molequinha', 'Sapatilha infantil ', 28, 'Sapatilha rosa infantil', 10, '2021-08-05', '2021-08-25', 'Moleca', 700.0, 129.90 );

select*from produto;

 #Fornecedor-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

delimiter $$

create procedure Inserir_Fornecedor (Id_for int, nome varchar(100), cnpj varchar (14), id_endereco int)

BEGIN

declare verifica_cnpj varchar(14);
declare verifica_end int;

set verifica_cnpj = (select cnpj_for from fornecedor where cnpj_for = cnpj);
set verifica_end = (select cod_end from endereco where cod_end = id_endereco);


	if (verifica_cnpj is null) then 
    
		if (verifica_end is null) then 
        
			select 'Endereço inexistente' as Erro;
        			            
		else 
			insert into fornecedor()
			values (Id_for, nome, cnpj, id_endereco) ;
        
			select 'Fornecedor inserido com sucesso!' as Confirmação;
		end if;
    else 
    
		select 'Erro! CNPJ já cadastrado' as Erro;
    
    end if;

end;

$$ delimiter ;

#drop procedure Inserir_Fornecedor;

#Call -------------------------------------------------------------------------------------------------------------------------------------------------------------------------

call Inserir_Fornecedor(null, 'Moleca', '02634597632899', 6);
call Inserir_Fornecedor(null, 'Moleca', '02634598632899', 16);
call Inserir_Fornecedor(null, 'Adidas', '02634597632899', 7);
call Inserir_Fornecedor(null, 'Adidas', '05693245698521', 7);

 #Caixa -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

insert caixa values (null, 'Agosto/2021', 1200.0, 650.0, 800, 250);

delimiter $$

create procedure Inserir_Caixa (Id_Caixa int, mes varchar(200))

begin
declare saldoanterior float;
declare verificames varchar(200);
declare saldo_anterior float;
declare saldo_final float;
declare creditos float;
declare debitos float;

set saldoanterior = (select saldo_final_cai from caixa where cod_cai = (select max(cod_cai) from caixa));
set verificames = (select mes_cai from caixa where mes_cai = mes);
set saldo_anterior = saldoanterior;
set saldo_final = saldoanterior; 
set creditos = saldoanterior;
set debitos = 0.00;

	if (verificames is null) then 
    
		if (saldo_final = 0) then
    
			insert into caixa(cod_cai, mes_cai, saldo_ant_cai, saldo_final_cai, debitos_cai, creditos_cai) values (Id_caixa, mes, saldo_anterior, saldo_final, debitos, creditos);
        
			select 'Caixa inserido com saldo nulo sucesso' as Confirmação;
	        
        else
        
			insert into caixa(cod_cai, mes_cai, saldo_ant_cai, saldo_final_cai, debitos_cai, creditos_cai) values (Id_caixa, mes, saldo_anterior, saldo_final, debitos, creditos);
        
			select 'Caixa inserido com sucesso' as Confirmação;
            
        end if;
	else 
    
		 select 'Caixa já existente! Tente Novamente' as Erro;
        
	end if;
end;

$$ delimiter ;

#drop procedure Inserir_Caixa;

#Call -------------------------------------------------------------------------------------------------------------------------------------------------------------------------

call Inserir_caixa(null, 'Setembro/2021');
call Inserir_caixa(null, 'Agosto/2021');

select * from caixa;

#Compra -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

select*from compras;
DELIMITER $$
create procedure inserir_compra (cod_com int, valor_com float, quantpro_com int, data_com date, frete_com float, cod_for int, data_entreg_com date, cod_cai int)
begin
declare valorfinal float;
set valorfinal = valor_com + frete_com;

insert into Compras()
Values (cod_com, valor_com, quantpro_com , data_com , frete_com , cod_for, data_entreg_com, cod_cai);

END;
$$ DELIMITER ;

#drop procedure inserir_compra;

#Trigger----------------------------------------------------------------------------------------------------------------------------------------------------

DELIMITER $$

create trigger atualizar_pos_compra after insert on compras for each row

begin
	update caixa set debitos_cai = debitos_cai + (new.valor_com + new.frete_com) where cod_cai = new.cod_cai_fk;
end;

$$ DELIMITER ;

#drop trigger atualizar_pos_compra; 

#call---------------------------------------------------------------------------------------------------------------------------------------------------------

call inserir_compra (null, 800.0, 20, '2021-09-01', 50.0, 1,'2021-09-15', 2 );
call inserir_compra (null, 1000.0, 35, '2021-09-01', 80.0, 2,'2021-09-15', 2 );

select*from compras;
select*from caixa;
select*from fornecedor;

#ProdutoCompra -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
select*from produto_compra;
DELIMITER $$
create procedure inserir_produtocompra (cod_procom int, cod_pro int, cod_for int, quantidadepro_com int)
begin
	if ( quantidadepro_com > 0) THEN
		insert into produto_compra (cod_procom, cod_pro_fk, cod_for_fk, quantidadepro_com)
		values (cod_procom, cod_pro, cod_for, quantidadepro_com);
		Select 'Procedimento realizado com sucesso!!' as Confirmação;
	Else 
		Select 'Insira uma quantidade maior que zero!!' as Erro;
    
    end if;
end;
$$ DELIMITER ;

#drop procedure inserir_produtocompra;

#trigger----------------------------------------------------------------------------------------------------------------------------

delimiter $$

create trigger atualizar_estoque after insert on produto_compra for each row

begin
	update produto set estoque_pro = estoque_pro + new.quantidadepro_com where cod_pro = new.cod_pro_fk;
end;

$$ delimiter ;

#call---------------------------------------------------------------------------------------------------------------------------------

call inserir_produtocompra (null, 3, 1,12 );

call inserir_produtocompra (null, 2, 2,5);


select * from produto;
select* from produto_compra;


#Venda -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

select*from vendas;

DELIMITER $$
create procedure inserir_venda (Id_venda int, valor_venda float, total_produtos int, data_venda date, desconto float, pagamento varchar(200), cliente int, funcionario int, caixa int )
begin
declare valor_desconto float;
set valor_desconto = valor_venda - (valor_venda * desconto);

if(total_produtos>0) then
    if (desconto=0) then
		insert into Vendas()
		Values (Id_venda, valor_venda, total_produtos, data_venda, desconto, pagamento, cliente, funcionario, caixa );
		select ' Venda sem desconto inserida com sucesso' as Confirmação;
	else 
		insert into Vendas()
		Values (Id_venda, valor_desconto, total_produtos, data_venda, desconto, pagamento, cliente, funcionario, caixa );
		select ' Venda com desconto inserida com sucesso' as Confirmação;
    end if;
else
select 'Quantidade Inválida' as Erro;
end if;
END;
$$ DELIMITER ;

#drop procedure inserir_venda;

#trigger-----------------------------------------------------------------------------------------------------------------------

delimiter $$

create trigger atualizar_caixa_venda after insert on vendas for each row 

begin

update caixa set creditos_cai = creditos_cai + new.valor_ven where cod_cai = new.cod_cai_fk;
update caixa set saldo_final_cai = (saldo_final_cai + creditos_cai) - debitos_cai where cod_cai = new.cod_cai_fk;
end;

$$ delimiter ;

#drop trigger  atualizar_caixa_venda 

#call-----------------------------------------------------------------------------------------------------------------------
call inserir_venda(null, 400.0, 8, '2020-09-05', 0.2, 'Pix', 2, 1, 2);
call inserir_venda(null, 400.0, 0, '2020-09-05', 0.2, 'Pix', 2, 1, 2);
call inserir_venda(null, 200.0, 5, '2020-09-05', 0.1, 'Pix', 2, 1, 2);
call inserir_venda(null, 200.0, 5, '2020-08-05', 0.1, 'Pix', 2, 1, 1);
select*from caixa;
#Produtovenda -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
DELIMITER $$


create procedure inserir_produtovenda (Id_proven int, produto int, venda int, quantidade int)
begin
declare estoque int;
declare verificapro int;
declare verificaven int;

SET estoque = (select estoque_pro from produto where cod_pro = produto); 
set verificapro = (select cod_pro from produto where cod_pro = produto);
set verificaven = (select cod_ven from vendas where cod_ven = venda);

	if (estoque < quantidade) THEN
		
		Select 'Quantidade inválida! Estoque Insuficiente.' as Erro;
	Else 
    
		if (verificapro is null) then
			Select 'Produto inválido!' as Erro;
		else 
			if(verificaven is null) then
            
				Select 'Venda inválida!' as Erro;
            else
				
				insert into produto_venda ( cod_venpro, cod_pro_fk, cod_ven_fk, quantidadepro_ven)
				values (Id_proven, produto, venda , quantidade );
				Select 'Procedimento realizado com sucesso!!' as Confirmação;
			end if;
		end if;
    
    end if;
end;
$$ DELIMITER ;

#drop procedure inserir_produtovenda;

#trigger----------------------------------------------------------------------------------------------------------------------------

delimiter $$

create trigger atualizar_estoque_venda after insert on produto_venda for each row

begin
	update produto set estoque_pro = estoque_pro - new.quantidadepro_ven where cod_pro = new.cod_pro_fk;
end;

$$ delimiter ;

#drop trigger atualizar_estoque_venda;

#call--------------------------------------------------------------------------------------------------------------------------------

select * from vendas;

call inserir_produtovenda (null, 2, 2, 5);
call inserir_produtovenda (null, 1, 2, 8);

select*from vendas;
select*from produto;

#Loja -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

select*from loja;
DELIMITER $$
CREATE PROCEDURE inserir_loja (cod int, nome varchar(100), codend int, cnpj varchar(14))
begin
declare endereco int;

set endereco= (select cod_end from endereco where cod_end = codend);

	if ( endereco is null ) then
		
		SELECT 'Endereco invalido' AS erro;
			
    else
    
		IF (cnpj = '') THEN
			SELECT 'CNPJ invalido' AS erro;
		Else 
			insert into loja (cod_loj, nome_loj,  cod_end_fk,cnpj_loj)
			values (cod,nome,codend,cnpj);
			Select 'Cadastro concluido' as Confirmação;
		end if;
		
	end if;
    
end;
$$ DELIMITER ;
#drop procedure inserir_loja;
#call----------------------------------------------------------------------------

call inserir_loja (null, 'Meio Preço', 15, '');
call inserir_endereco(null, 'Avenida Daniel Comboni', 'Jk',154, '76920000','Ouro Preto do Oeste', 'RO');
select*from endereco;
call inserir_loja (null, 'Meio Preço', 8, '');
call inserir_loja (null, 'Meio Preço', 8, '06558966355');
select * from loja;


DELIMITER $$
CREATE PROCEDURE inserir_gastos(cod int, valor float, data date, descr varchar(100), codcai int)
begin

declare verificar float;
set verificar = (select cod_cai  from caixa where cod_cai = codcai);

	if (valor > 0) then
		if (verificar is not null) then
			select 'Caixa correspondente inexistente' as erro;
		else 
			insert into gastos() values (cod,valor,data,descr,codcai);
			select 'Valor inserido com sucesso!!' as Confirmação;
		
        end if;
	else 
		select 'Por favor, insira um  valor válido!' as erro;

	end if;

end;
$$ delimiter ;
#drop procedure inserir_gastos;
call inserir_gastos (null,100,'2020-10-10', 'energia', 1);
call inserir_gastos (null,0,'2020-10-10', 'energia', 1);



