select 
a.pId as '产品标识',a.mId as '材料标识',a.eiId as '设备标识',
case 
	when a.pid is not null then pk.sort
	when a.mid is not null then mk.sort
end as '材料种类',
b.no as '沥青罐编号',
case 
	when a.pid is not null then g.name
	when a.mid is not null then f.name
end as '沥青名称',
case 
	when a.pid is not null then pm.model
	when a.mid is not null then mm.model
end as '规格型号',
b.diameter as '罐直径',b.height as '罐子高度',b.kind as '罐子样式',c.value as '液位高度',
case 
	when a.pid is not null and e.density is null then 1
	when a.pid is not null and e.density is not null then cast(e.density as float)
	when a.mid is not null and d.density is null then 1
	when a.mid is not null and d.density is not null then cast(d.density as float)
end as '沥青密度', d.density as '材料密度',e.density as '产品密度',
getdate() as '日期',
0.0 as '存储数量',
psl.suttle1 as '产品库存量',
msl.quantity1 as '材料库存量',
case 
	when a.pid is not null then psl.suttle1
	when a.mid is not null then msl.quantity1
end as '理论库存',
0.0 as '差额',
0.0 as '误差率'
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
