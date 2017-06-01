--select * from dbo.payrollAdd
--select * from payOffDetail select * from payOffGather --select * from personnelInfo


select d.name as cHumanName,c.name as cPayRollName,sum(money)as realInCome FROM payOffDetail b 
		join payOffGather a on a.id = b.pogid
		join PayrollAdd c on b.paid = c.id
		join personnelInfo d on b.piid = d.id
	where (b.month = 3 and year(a.date)=2009) 
	group by d.name,c.name
union
select c.name,'实际所得',sum(realIncome) from payOffGather a,personnelInfo c
	where (month(a.date)=3 and year(a.date)=2009) and a.piId = c.id
group by c.name

SELECT
a.id,
d.name as cHumanName, 
c.name as cPayRollName,
b.money as mPayRollValue,
a.realInCome as realIncome
FROM payOffGather a
left outer JOIN payOffDetail b on a.piid = b.piid and a.id = b.pogid
join PayrollAdd c on b.paid = c.id
join personnelInfo d on a.piid = d.id
where month(a.date)=3 and year(a.date)=2009 and a.piid=1
group by a.id, d.name, c.name, b.money, a.realInCome
order by d.name,c.name
