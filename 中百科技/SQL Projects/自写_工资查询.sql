select * from payOffDetail select * from payOffGather
select b.* ,c.realincome from personnelInfo a
right join 
	(select 
	a.paid,
	b.name,
	sum(a.money) as cRollValue
	,c.name as cHumanName
	,c.id as cHumanID
	from payOffDetail a
	left join PayrollAdd b on a.paid=b.id
	left join personnelInfo c on a.piid = c.id
	where a.month=3
	group by paid,b.name,c.name,c.id
	) as b on a.name=b.cHumanName
left join
	(
	select a.piid,sum(a.realincome)as realincome from payOffGather a 
	where month(date)=3
	group by a.piid
	) as c on b.cHumanID=c.piid
order by chumanid
