--checkupman is not null
declare @cHumanName varchar(50)
declare @cPayoffName varchar(50)
set @cHumanName = '张华'
set @cPayoffName = '张华基本工资'
select d.name as cHumanName,c.name as cPayRollName,sum(money)as realInCome FROM payOffDetail b 
		join payOffGather a on a.id = b.pogid
		join PayrollAdd c on b.paid = c.id
		join personnelInfo d on b.piid = d.id
		left join payOffGather2 e on a.id = e.pogid
	where (b.month = 4 and year(a.date)=2009)
	and e.checkupman is not null
	--and a.name = @cPayoffName
	group by d.name,c.name
union
select d.name,'实际所得',sum(realIncome) from payOffGather a
	join personnelInfo d on a.piId = d.id 	
	left join payOffGather2 e on a.id = e.pogid
	where (month(a.date)=4 and year(a.date)=2009) 	
	and e.checkupman is not null
	--and a.name = @cPayoffName
group by d.name
select * from payOffGather
select * from payOffGather2