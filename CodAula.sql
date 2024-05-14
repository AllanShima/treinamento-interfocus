--Aula sobre Banco de dados utilizando PostgreSQL com o software DBeaver

---- DDL (cria os dados?)

create table alunos(
	codigo integer not null,
	nome varchar(100),
	datanascimento date,
	email varchar(200)
);

create sequence cursos_seq;
create sequence inscricao_seq;

create table cursos(
	id integer not null default nextval('cursos_seq'),
	nome varchar(50),
	descricao text,
	nivel integer not null,
	duracao integer not null,
	primary key (id)
);

insert into cursos(nome, descricao, nivel, duracao)
values('Curso 1', 'Descricao do curso 1 top 10/10 100%', 0 ,8),
	  ('Curso Intermediário', 'Descricao do curso 2 top 10/50 100%', 1 ,80),
	  ('Curso Avançado', 'Descricao do curso Avançado top 2/10 14%', 2 ,40);
	  
select * from cursos

create table inscricao(
	id integer not null default nextval('inscricao_seq'),
	alunocodigo integer,
	cursoid integer,
	data timestamp default now()
);

delete from inscricao where alunocodigo = 100;

alter table inscricao
add constraint fk_inscricao_aluno foreign key (cursoid)
references cursos(id);

insert into inscricao(alunocodigo, cursoid)
values(10, 1),
	  (10, 3),
	  (11, 3),
	  (4, 2),
	  (5, 2);

select * from inscricao

select a.codigo, a.nome, c.nome, i.data from inscricao i
left join alunos a on i.alunocodigo = a.codigo 
left join cursos c on i.cursoid = c.id
order by c.nome;
	 
alter table alunos
add primary key (codigo);

create sequence alunos_seq;

alter table alunos
alter column codigo set default nextval('alunos_seq') 

---- DML (modifica os dados do banco de dados)

insert into alunos(nome, datanascimento, email)
values ('Allan Shinhama', '09-07-2005', 'allanshimanalan@gmail.com'),
	   ('Aluno teste', '01-01-1999', 'alunoteste@email.com'),
	   ('Gustavo Vieira', '25-02-1384', 'gustavoteste@gmail.shit');
	   
select codigo, nome, email, datanascimento from alunos
where codigo >= 2 and email ilike '%.COM%' ---% antes para o ultima string / % depois para a primeira string
order by nome desc, codigo desc 
offset 2
limit 18;

update alunos
set nome = 'Aluno Alterado',
datanascimento = '1998-01-02'
where codigo = 2;

delete from alunos
where codigo = 3;