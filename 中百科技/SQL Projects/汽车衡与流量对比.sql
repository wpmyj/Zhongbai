--select * from stockNote
--select * from indent
select 
a.inputdate as 日期,
b.no as 车牌号码,
e.name as 沥青名称,
f.model as 规格型号,
a.suttle as 称重数量,
a.flowmetervalue 流量数量,
a.flowmetervalue - a.suttle as 差异量,
(a.flowmetervalue - a.suttle)/a.suttle as 误差率
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