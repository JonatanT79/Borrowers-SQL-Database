
create view AllCustomer
as
select a.ID, Förnamn, Efternamn, Ålder, r.[Nuvarande Roll], r.Rättnivå, LåneProdukt , Indificationsvärde, Beskrivning, Kategori    
from orders as o
inner join Products as p on o.LåneID = p.ID
inner join Användare as a on o.CustomerID = a.ID 
inner join Roller as r on RollID = r.ID 
inner join exemplar as e on Indificationsvärde = o.ExemplarID

