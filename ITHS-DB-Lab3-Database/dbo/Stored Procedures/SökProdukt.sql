
create procedure SökProdukt @SökNamn varchar(255)
as 
select LåneProdukt 
from Products with(index(idx_ProduktNamn))
where LåneProdukt like @SökNamn



