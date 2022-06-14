CREATE TABLE [dbo].[USUARIOS](
	[cpf] [nvarchar](450) NOT NULL,
	[nome] [nvarchar](max) NULL,
	[idade] [int] NOT NULL,
	[rg] [nvarchar](max) NULL,
	[data_nasc] [nvarchar](max) NULL,
	[endereco] [nvarchar](max) NULL,
	[cidade] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

INSERT INTO dbo.USUARIOS (nome, idade, cpf, rg, data_nasc, endereco, cidade)
VALUES 
('Fátima Lara Mirella Barros',  41,  '65130399161',  '348538728',  '17/04/1981',  'Rua Darcy Pio',  'Três Lagoas'),
('Marcos Vinicius Bryan Lucas',  22,  '56702688148',  '396739544',  '20/03/2000',  'Rua Eduardo Santos Pereira',  'Campo Grande'),
('Carolina Catarina Lavínia',  53,  '74037505193',  '499174963',  '09/04/1969',  'Rua Cláudio Abramo',  'Campo Grande'),
('Joana Caroline Jennifer',  50,  '26911599148',  '450217504',  '24/05/1972',  'Rua São Gonçalo',  'Campo Grande'),
('Sandra Ayla Aparícia',  25,  '07055705177',  '181780744',  '02/04/1997',  'Avenida Presidente Ernesto Geisel',  'Campo Grande'),
('Isadora Isabel Josefa da Cruz',  69,  '42967138177',  '245758598',  '15/01/1953',  'Rua Betim',  'Campo Grande'),
('Isabella Rosângela Jennifer Teixeira',  35,  '39997202120',  '245037019',  '19/01/1987',  'Rua Nazaré',  'Ponta Porã'),
('Carolina Pietra Beatriz da Silva',  73,  '28848654118',  '299350228',  '14/04/1949',  'Rua Anúncia Salvadora Colman',  'Dourados'),
('Maya Yasmin Nunes',  42,  '91099326150',  '273068027',  '16/02/1980', 'Rua Perciliana Barbosa Ferreira',  'Campo Grande'),
('Luana Marina Alícia Ferreira',  31,  '44487741122',  '199311158',  '12/03/1991',  'Rua Doutor Paulo Galhardi',  'Campo Grande'),
('Roberto Rodrigo Kevin Assunção',  79,  '64541805146',  '242347009',  '06/03/1943',  'Avenida Gury Marques 5464',  'Campo Grande'),
('Sandra Jennifer Alves',  61,  '64460085119',  '502853001',  '07/02/1961',  'Rua João Pedro de Souza 1025',  'Campo Grande'),
('Juan Matheus Campos',  75,  '24002714101',  '439750052',  '26/02/1947',  'Avenida Aeroclube',  'Campo Grande'),
('Manuel Caio Ramos',  20,  '62278217135',  '163711884',  '14/01/2002',  'Rua Iturama',  'Ponta Porã'),
('Débora Teresinha Vitória Cortez',  42,  '50722303173',  '154333773',  '05/01/1980',  'Avenida Jose Villela de Andrade Junior',  'Campo Grande'),
('Alexandre Felipe Cauã Ribeiro',  26,  '37208310190',  '278733682',  '02/01/1996',  'Rua Liberato Leite de Faria Laguecho',  'Dourados'),
('Samuel Fernando Kevin Nascimento',  30,  '87048220139',  '350977082',  '15/05/1992',  'Rua Carmem Bazzano Pedra',  'Campo Grande'),
('Raimunda Stella da Conceição',  47,  '32688173197',  '394001837',  '10/03/1975',  'Avenida Ricardo Brandão',  'Campo Grande'),
('Esther Isabelle Monteiro',  24,  '43289673120',  '231109568',  '24/02/1998',  'Rua Casa Branca',  'Campo Grande'),
('Benjamin Anthony Alexandre Pereira',  78,  '37992875150',  '396853766',  '04/02/1944',  'Rua Álvaro Lins',  'Campo Grande'),
('Arthur Guilherme Moura',  70,  '58278667179',  '111531949',  '07/05/1952',  'Rua José da Silva',  'Campo Grande'),
('Leandro Carlos Eduardo Kaique',  79,  '71992341125',  '385313871',  '05/04/1943',  'Rua Luiz Hilário Campo Leite',  'Campo Grande'),
('Diego César Moraes',  25,  '65542339115',  '272644924',  '26/02/1997',  'Rua Guilherme Rocha',  'Campo Grande');

CREATE TABLE [dbo].[SERVICOS](
	[id] [int] NOT NULL,
	[descricao] [nvarchar](max) NOT NULL,
	[preco] [money] NOT NULL,
 CONSTRAINT [PK_servicos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

insert into servicos values
(1, 'Internet Banda Larga', 123.45),
(2, 'Streaming de Vídeos', 47.65),
(3, 'Audio livros', 9.99),
(4, 'Streaming de Músicas', 15.47)
