
create procedure LämnaIn @ID int,@ExemplarID varchar(255)
as 
update Orders
set LämnadesIn = getdate()
WHERE OrdersID = @ID

update Exemplar 
set Status_Exemplar = 'Tillgänglig'
where Indificationsvärde  = @ExemplarID 

