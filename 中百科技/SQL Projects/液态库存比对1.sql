select l.pId,l.mId ,l.eiId
,(select quantity1 from materialStockList where mId = l.mId  ) as '���Ͽ����' 
,(select suttle1 from productStockList where pId = l.pId) as '��Ʒ�����'
, l.lpnId as 'Һλ��ID'
,(select diameter from equipmentInformation where id =l.eiId ) as 'ֱ��'
,(select kind from equipmentInformation where id =l.eiId ) as '������ʽ'
,(select value from liquidPositionHistory where id = l.lpnId) as 'Һλ����'
,(select density  from material where id = l.mId) as '�����ܶ�'
,(select density  from product where id = l.mId) as '��Ʒ�ܶ�'
from liquidMatterStockList l
