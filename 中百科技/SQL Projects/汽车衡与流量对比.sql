--select * from stockNote
--select * from indent
select 
a.inputdate as ����,
b.no as ���ƺ���,
e.name as ��������,
f.model as ����ͺ�,
a.suttle as ��������,
a.flowmetervalue ��������,
a.flowmetervalue - a.suttle as ������,
(a.flowmetervalue - a.suttle)/a.suttle as �����
,a.* 
from stockNote a
left join voitureInfo b on a.viid = b.id
left join indent c on a.iid = c.id
left join material d on c.mid = d.id
left join materialName e on d.mnid = e.id
left join materialModel f on d.mmid = f.id
where a.flowmetervalue is not null
and a.inputDate >= ''
and a.inputDate <= ''
and e.id = '2'
and f.id = ''

select a.id from equmentKind a 
join equipmentName b on a.id = b.ekid
where b.id = 9