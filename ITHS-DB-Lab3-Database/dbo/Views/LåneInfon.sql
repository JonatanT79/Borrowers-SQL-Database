
create view LåneInfon
as

select a.id as KundID, Förnamn, Efternamn, LåneProdukt, Indificationsvärde, Beskrivning,Lånedatum,InlämmningsDatum,UtlånareFörnamn + ' ' + UtlånareEfternamn  as Utlånare   
from Orders as o
inner join Products as p on o.LåneID = p.ID 
inner join Användare as a on o.CustomerID = a.ID 
inner join Exemplar as e on Indificationsvärde = o.ExemplarID
inner join personal pe on pe.ID = o.LånadesUtAv
group by a.id,InlämmningsDatum, Förnamn,Efternamn,LåneProdukt,Indificationsvärde, Beskrivning,Lånedatum,UtlånareFörnamn, UtlånareEfternamn

