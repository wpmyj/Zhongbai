declare @cHumanName varchar(50)
declare @cPayoffName varchar(50)
set @cHumanName = '张华'
set @cPayoffName = '张华基本工资'
declare @month int
set @month = 4
declare @year int
set @year =2009
select d.name as cHumanName,c.name as cPayRollName,sum(money)as realInCome FROM payOffDetail b 
		join payOffGather a on a.id = b.pogid
		join PayrollAdd c on b.paid = c.id
		join personnelInfo d on b.piid = d.id
		join payOffGather2 e on a.id = e.pogid
	where (b.month = @month and year(a.date)=@year) 	
	--and e.checkupman is not null
	group by d.name,c.name
union
select d.name,'实际所得',sum(realIncome) from payOffGather a, personnelInfo d ,payOffGather2 e
	where (month(a.date)=@month and year(a.date)=@year) 	
	and a.id = e.pogid
	and a.piId = d.id 		
	and e.checkupman is not null
	group by d.name

