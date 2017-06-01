select 
a.pId as '��Ʒ��ʶ',a.mId as '���ϱ�ʶ',a.eiId as '�豸��ʶ',
case 
	when a.pid is not null then pk.sort
	when a.mid is not null then mk.sort
end as '��������',
b.no as '����ޱ��',
case 
	when a.pid is not null then g.name
	when a.mid is not null then f.name
end as '��������',
case 
	when a.pid is not null then pm.model
	when a.mid is not null then mm.model
end as '����ͺ�',
b.diameter as '��ֱ��',b.height as '���Ӹ߶�',b.kind as '������ʽ',c.value as 'Һλ�߶�',
case 
	when a.pid is not null and e.density is null then 1
	when a.pid is not null and e.density is not null then cast(e.density as float)
	when a.mid is not null and d.density is null then 1
	when a.mid is not null and d.density is not null then cast(d.density as float)
end as '�����ܶ�', d.density as '�����ܶ�',e.density as '��Ʒ�ܶ�',
getdate() as '����',
0.0 as '�洢����',
psl.suttle1 as '��Ʒ�����',
msl.quantity1 as '���Ͽ����',
case 
	when a.pid is not null then psl.suttle1
	when a.mid is not null then msl.quantity1
end as '���ۿ��',
0.0 as '���',
0.0 as '�����'
from liquidMatterStockList a
join equipmentInformation b on a.eiid = b.id
left join liquidPositionHistory c on a.lpnid = c.lpnid
left join material d on a.mid = d.id
left join materialName f on d.mnid = f.id
left join materialModel mm on d.mmid = mm.id
left join product e on a.pid = e.id
left join productName g on e.pnid = g.id
left join productModel pm on e.pmid=pm.id
left join productStockList psl on a.pid = psl.pid
left join materialStockList msl on a.mid = msl.mid
left join productKind pk on g.pkid = pk.id
left join materialKind mk on f.mkid = mk.id
join (select lpnid,max(date) as date from liquidPositionHistory group by lpnid) mmm on a.lpnid = mmm.lpnid and c.date = mmm.date


select * from liquidPositionHistory
