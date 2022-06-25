CREATE FUNCTION [dbo].[GetAccumulatedDepreciation]
(
	@DepreciationMethod nvarchar(10),
	@InitialValue money,
	@MonthsOfDepreciation int,
	@DateOfEntry datetime2,
	@DateOfReference datetime2,
	@DateOfExit datetime2,
	@OperationEntryDate datetime2,
	@IsOperationDepreciation bit
)
RETURNS MONEY
AS
BEGIN
	IF @DepreciationMethod = 'Liniara'
		BEGIN			
			RETURN dbo.CalculateDepreciation_StraightLineMethod(@InitialValue, @MonthsOfDepreciation, @DateOfEntry, @DateOfReference, @DateOfExit, @OperationEntryDate, @IsOperationDepreciation);
		END
	ELSE IF @DepreciationMethod = 'Accelerata'
		BEGIN
			RETURN dbo.CalculateDepreciation_AcceleratedMethod(@InitialValue, @MonthsOfDepreciation, @DateOfEntry, @DateOfReference, @DateOfExit, @OperationEntryDate, @IsOperationDepreciation);
		END
	ELSE IF @DepreciationMethod = 'Degresiva'
		BEGIN
			RETURN dbo.CalculateDepreciation_DegressiveMethod(@InitialValue, @MonthsOfDepreciation, @DateOfEntry, @DateOfReference, @DateOfExit, @OperationEntryDate, @IsOperationDepreciation);
		END

	RETURN -0.1;
END
