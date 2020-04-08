SET IDENTITY_INSERT Roller on;
insert into roller(ID,[Nuvarande Roll], Rättnivå, DåvarandeJobb)
select
5,'Global Admin', 'Ingen makt', 'Resource Adminz'
WHERE  NOT EXISTS (SELECT * FROM Roller WHERE Id = 5)

insert into roller(ID,[Nuvarande Roll], Rättnivå, DåvarandeJobb)
select
6,'Resource Admin', 'Ingen makt', 'Resource Adminz'
WHERE  NOT EXISTS (SELECT * FROM Roller WHERE Id = 6)

insert into roller(ID,[Nuvarande Roll], Rättnivå, DåvarandeJobb)
select
7,'Loan Admin', 'Ingen makt', 'Resource Adminz'
WHERE  NOT EXISTS (SELECT * FROM Roller WHERE Id = 7)

insert into roller(ID,[Nuvarande Roll], Rättnivå, DåvarandeJobb)
select
8,'Borrower','Ingen makt','Loan Admin'
WHERE  NOT EXISTS (SELECT * FROM Roller WHERE Id = 8)

SET IDENTITY_INSERT Roller off;
