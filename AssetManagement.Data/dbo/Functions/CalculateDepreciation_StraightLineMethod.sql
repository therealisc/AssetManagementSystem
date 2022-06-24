CREATE FUNCTION [dbo].[CalculateDepreciation_StraightLineMethod]
(
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

	DECLARE @MonthlyDepreciation money = @InitialValue / @MonthsOfDepreciation;
	DECLARE @MonthsSinceEntry int = DATEDIFF(M, @DateOfEntry, @DateOfReference);
	DECLARE @MonthsBetweenEntryAndExit int = DATEDIFF(M, @DateOfEntry, @DateOfExit);

	-- for operation depreciation calculation
	DECLARE @MonthsOfDepreciationLeft int = @MonthsOfDepreciation - DATEDIFF(M, @DateOfEntry, @OperationEntryDate);

	IF (@IsOperationDepreciation = 1)
		BEGIN
			SET @MonthlyDepreciation = @InitialValue / @MonthsOfDepreciationLeft;
			SET @MonthsSinceEntry = DATEDIFF(M, @OperationEntryDate, @DateOfReference);
			SET @MonthsOfDepreciation = @MonthsOfDepreciationLeft;
			SET @MonthsBetweenEntryAndExit = DATEDIFF(M, @OperationEntryDate, @DateOfExit);
		END
	-----------------------------------------

	IF @DateOfExit IS NULL
		BEGIN
			IF @MonthsSinceEntry < @MonthsOfDepreciation
				BEGIN
					RETURN @MonthlyDepreciation * @MonthsSinceEntry;
				END
			ELSE
				BEGIN
					RETURN @InitialValue;
				END
		END
	ELSE
		BEGIN
			IF @MonthsBetweenEntryAndExit < @MonthsOfDepreciation
				BEGIN
					RETURN @MonthlyDepreciation * @MonthsBetweenEntryAndExit
				END
			ELSE
				BEGIN
					RETURN @InitialValue;
				END
		END	

	RETURN -0.1;
END
