
create view BorttappadInfon
as
select Förnamn, Efternamn, LåneProdukt, Indificationsvärde, LåneDatum, InlämmningsDatum, Borttappad, SummaAttBetala,LämnadesIn    
from orders as o
inner join Products as p on o.LåneID = p.ID
inner join Användare as a on o.CustomerID = a.ID 
inner join exemplar as e on Indificationsvärde = o.ExemplarID
group by SummaAttBetala, Förnamn, Efternamn, LåneProdukt, Indificationsvärde, LåneDatum, InlämmningsDatum, Borttappad,LämnadesIn

