CREATE FUNCTION [dbo].[CalculateDepreciation_AcceleratedMethod]
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
	DECLARE @MonthsSinceEntry int = DATEDIFF(M, @DateOfEntry, @DateOfReference);
	DECLARE @MonthlyDepreciationInTheFirstYear money = (@InitialValue * 0.5) / 12; -- 50% IN THE FIRST YEAR
	DECLARE @MonthlyDepreciationAfterTheFirstYear money = (@InitialValue * 0.5) / @MonthsOfDepreciation - 12;

	--DECLARE @MonthlyDepreciation money = @InitialValue / @MonthsOfDepreciation;
	--DECLARE @MonthsBetweenEntryAndExit int = DATEDIFF(M, @DateOfEntry, @DateOfExit);

	-- for operation depreciation calculation
	--DECLARE @MonthsOfDepreciationLeft int = @MonthsOfDepreciation - DATEDIFF(M, @DateOfEntry, @OperationEntryDate);

	--IF (@IsOperationDepreciation = 1)
	--	BEGIN
	--		SET @MonthlyDepreciation = @InitialValue / @MonthsOfDepreciationLeft;
	--		SET @MonthsSinceEntry = DATEDIFF(M, @OperationEntryDate, @DateOfReference);
	--		SET @MonthsOfDepreciation = @MonthsOfDepreciationLeft;
	--		SET @MonthsBetweenEntryAndExit = DATEDIFF(M, @OperationEntryDate, @DateOfExit);
	--	END
	-----------------------------------------

	IF @DateOfExit IS NULL
		BEGIN
			IF @MonthsSinceEntry < @MonthsOfDepreciation
				BEGIN
					IF @MonthsSinceEntry <= 12
						BEGIN
							RETURN @MonthlyDepreciationInTheFirstYear * @MonthsSinceEntry;
						END
					ELSE
						BEGIN
							RETURN (@MonthlyDepreciationAfterTheFirstYear * (@MonthsSinceEntry - 12)) + (@InitialValue * 0.5);
						END
				END
			ELSE
				BEGIN
					RETURN @InitialValue;
				END
		END
	ELSE -- IF @DateOfExit IS NOT NULL
		BEGIN
			RETURN 0;

		END	

	RETURN -0.1;
END
