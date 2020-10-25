create table Aerodromi (
	id int Identity(1,1),
	sifra char(3) not null,
	naziv char(25) not null,
	grad char(20) not null,
	aktivan bit not null)

create table Aviokompanije (
	id int Identity(1,1),
	sifra char(3) not null,
	naziv char(25) not null,
	aktivan bit not null)

create table Avioni (
	id int Identity(1,1),
	brojLeta int not null,
	sedistaBiznis int not null,
	sedistaEkonomska int not null,
	nazivAviokompanije char(25) not null,
	aktivan bit not null)

create table Karte (
	id int Identity(1,1),
	brojLeta int not null,
	brojSedista char(5) not null,
	nazivPutnika char(25) not null,
	klasaSedista char(9) not null,
	kapija int not null,
	cena money not null,
	aktivan bit not null)

create table Korisnici (
	id int Identity(1,1),
	ime char(15) not null,
	prezime char(15) not null,
	email char(40) not null,
	adresa char(30) not null,
	pol char(6) not null,
	korisnickoIme char(15) not null,
	lozinka char(20) not null,
	tip char(10) not null,
	aktivan bit not null)

create table Letovi (
	id int Identity(1,1),
	sifra char(3) not null,
	pilot char(25) not null,
	brojLeta int not null,
	odrediste char(20) not null,
	destinacija char(20) not null,
	vremePolaska datetime not null,
	vremeDolaska datetime not null,
	cena money not null,
	aktivan bit not null)