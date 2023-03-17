DECLARE @mergeError int;
DECLARE @mergeCount int;

SET NOCOUNT ON
SET IDENTITY_INSERT [Food] ON

MERGE INTO [Food] AS Target
USING (VALUES
(1, 'Oua', 1.55, 0.00, 0.13, 0.11),
(2, 'Piept de pui', 1.51, 0.00, 0.29, 0.03),
(3, 'Piept de pui afumat', 1.02, 0.00, 0.20, 0.00),
(4, 'Cartofi', 0.93, 0.22, 0.03, 0.00),
(5, 'Ovaz lidl', 3.72, 0.57, 0.14, 0.00),
(6, 'Test2' ,0 ,0 ,0 ,0 )

) AS Source ([Id],[Name], [Kcal], [Carbs], [Protein], [Fats])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED BY TARGET THEN
INSERT([Id],[Name], [Kcal], [Carbs], [Protein], [Fats])
VALUES(Source.[Id], Source.[Name], Source.[Kcal], Source.[Carbs], Source.[Protein], Source.[Fats]);


SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
IF @mergeError != 0
BEGIN
PRINT 'An error occurred in MERGE for Food. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100));
END
ELSE
BEGIN
PRINT 'Food rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
END

SET IDENTITY_INSERT [Food] OFF
SET NOCOUNT OFF

GO