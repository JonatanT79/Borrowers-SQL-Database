create procedure Registrera @Id int,@CustomerID int,@LåneID int, @ExemplarID varchar(255),
@Lånedatum datetime2,@InlämmningsDatum datetime2, @Borttappad varchar(255),@SummaAttBetala int,
@LånadesUtAv varchar(255),@LämnadesIn varchar(255)

as 
insert into Orders(OrdersID,CustomerID,LåneID,ExemplarID,Lånedatum,InlämmningsDatum,Borttappad,SummaAttBetala,LånadesUtAv,LämnadesIn)
values(@Id,@CustomerID,@LåneID,@ExemplarID,@Lånedatum,@InlämmningsDatum,@Borttappad,@SummaAttBetala,@LånadesUtAv,@LämnadesIn) 

update Exemplar 
set Status_Exemplar = 'Utlånad'
where Indificationsvärde = @ExemplarID

