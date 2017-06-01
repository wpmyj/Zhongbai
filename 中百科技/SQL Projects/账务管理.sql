select * from sellProductSettlement --（销售核算表）scid关联sellContract（销售合同表）的id，标明该核算表属于哪个销售合同
select * from sellContract --销售合同表
select * from clientInfo --客户信息外键ciid

select * from dbo.tFundsRecorder