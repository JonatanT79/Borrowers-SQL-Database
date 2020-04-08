
create view FörsenadeInfon
as
select Förnamn, Efternamn, LåneProdukt, Indificationsvärde, LåneDatum, InlämmningsDatum, LämnadesIn,Borttappad, SummaAttBetala
from orders as o
inner join Products as p on o.LåneID = p.ID 
inner join Användare as a on o.CustomerID = a.ID 
inner join exemplar as e on Indificationsvärde = o.ExemplarID
group by  Förnamn, Efternamn, LåneProdukt, Indificationsvärde, LåneDatum, InlämmningsDatum, LämnadesIn,Borttappad, SummaAttBetala

