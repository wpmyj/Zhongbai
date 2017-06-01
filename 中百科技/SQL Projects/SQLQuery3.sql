declare @cHumanName varchar(50)
declare @cPayoffName varchar(50)
set @cHumanName = '�Ż�'
set @cPayoffName = '�Ż���������'
declare @month int
set @month = 4
declare @year int
set @year =2009
select a.id,d.name as cHumanName,c.name as cPayRollName,sum(money)as realInCome,
		case 
			when e.assessor is null then 'δ���'
			else '�����'
		end as AssessState,
		case 
			when e.checkupman is null then 'δ����'
			else '������'
		end as checkupState
		FROM payOffDetail b 
		join payOffGather a on a.id = b.pogid
		join PayrollAdd c on b.paid = c.id
		join personnelInfo d on b.piid = d.id        
        left join payOffGather2 e on a.id = e.pogid
	where (b.month = @month and year(a.date)=@year)    
	and a.name = @cPayoffName  
	group by a.id,d.name,c.name,e.assessor,e.checkupman
union
select a.id,d.name,'ʵ������',sum(realIncome),
	case 
		when e.assessor is null then 'δ���'
		else '�����'
	end as AssessState,
	case 
		when e.checkupman is null then 'δ����'
		else '������'
	end as checkupState
	from payOffGather a
	inner join personnelInfo d on a.piId = d.id 	    
	left join payOffGather2 e on a.id = e.pogid    
	where (month(a.date)=@month and year(a.date)=@year) 	
	and a.name = @cPayoffName 
group by a.id,d.name,e.assessor,e.checkupman

SELECT NAME FROM payOffGather