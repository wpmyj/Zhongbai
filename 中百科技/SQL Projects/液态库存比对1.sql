select l.pId,l.mId ,l.eiId
,(select quantity1 from materialStockList where mId = l.mId  ) as '材料库存量' 
,(select suttle1 from productStockList where pId = l.pId) as '产品库存量'
, l.lpnId as '液位仪ID'
,(select diameter from equipmentInformation where id =l.eiId ) as '直径'
,(select kind from equipmentInformation where id =l.eiId ) as '罐子样式'
,(select value from liquidPositionHistory where id = l.lpnId) as '液位计数'
,(select density  from material where id = l.mId) as '材料密度'
,(select density  from product where id = l.mId) as '产品密度'
from liquidMatterStockList l
