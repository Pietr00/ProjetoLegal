create table Cliente (
id int identity not null,
primary key(id),
nome varchar(100) not null,
cpf varchar(15) not null,
dataDeNascimento varchar(10) not null
)

create table Funcionario(
id int identity not null,
primary key(id),
nome varchar(100) not null,
cpf varchar(15) not null,
dataDeNascimento varchar(10) not null,
conta varchar(20) not null,
salario varchar(15) not null
)