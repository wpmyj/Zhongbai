declare @p0 int
declare @p1 int
set @p0 = 14
set @p1 = 14

SELECT [t3].[test], [t3].[id], [t3].[eiId], [t3].[fuelWastage], [t3].[inputMan], [t3].[inputDate], [t3].[remark], [t3].[piId], [t3].[value]
FROM (
    SELECT MAX([t0].[inputDate]) AS [value], [t0].[eiId]
    FROM [dbo].[deepFatConsumeDailyStatisticsDetail] AS [t0]
    GROUP BY [t0].[eiId]
    ) AS [t1]
LEFT OUTER JOIN (
    SELECT 1 AS [test], [t2].[id], [t2].[eiId], [t2].[fuelWastage], [t2].[inputMan], [t2].[inputDate], [t2].[remark], [t2].[piId], [t2].[value]
    FROM [dbo].[deepFatConsumeDailyStatisticsDetail] AS [t2]
    ) AS [t3] 
ON ([t3].[eiId] = @p0) 
AND ([t3].[inputDate] = [t1].[value]) 
AND ((([t1].[eiId] IS NULL) AND ([t3].[eiId] IS NULL)) OR (([t1].[eiId] IS NOT NULL) AND ([t3].[eiId] IS NOT NULL) AND ([t1].[eiId] = [t3].[eiId])))


SELECT [t0].[id], [t0].[eiId], [t0].[fuelWastage], [t0].[inputMan], [t0].[inputDate], [t0].[remark], [t0].[piId], [t0].[value]
FROM [dbo].[deepFatConsumeDailyStatisticsDetail] AS [t0]
WHERE ([t0].[eiId] = @p0) AND ([t0].[inputDate] = ((
    SELECT MAX([t1].[inputDate])
    FROM [dbo].[deepFatConsumeDailyStatisticsDetail] AS [t1]
    WHERE [t1].[eiId] = @p1
    )))

select a.* from deepFatConsumeDailyStatisticsDetail a
join (select eiid,max(b.inputdate) as date from  deepFatConsumeDailyStatisticsDetail b where b.eiid = 14 group by b.eiid ) c on a.eiid = c.eiid
where a.eiid = 14 and inputdate = c.date