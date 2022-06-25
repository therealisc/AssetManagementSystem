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
	DECLARE @MonthsBetweenEntryAndExit int = DATEDIFF(M, @DateOfEntry, @DateOfExit);
	DECLARE @MonthlyDepreciationInTheFirstYear money = (@InitialValue * 0.5) / 12; -- 50% IN THE FIRST YEAR
	DECLARE @MonthlyDepreciationAfterTheFirstYear money = (@InitialValue * 0.5) / @MonthsOfDepreciation - 12;

	-- for operation depreciation calculation
	DECLARE @MonthsOfDepreciationLeft int = @MonthsOfDepreciation - DATEDIFF(M, @DateOfEntry, @OperationEntryDate);

	IF (@IsOperationDepreciation = 1)
		BEGIN
			DECLARE @MonthsSinceOperationEntry int = DATEDIFF(M, @OperationEntryDate, @DateOfReference);
			SET @MonthlyDepreciationInTheFirstYear = (@InitialValue * 0.5) / (12 - (@MonthsSinceEntry - @MonthsSinceOperationEntry)); -- 50% IN THE FIRST YEAR
			SET @MonthlyDepreciationAfterTheFirstYear = (@InitialValue * 0.5) / @MonthsOfDepreciation - 12;
			SET @MonthsOfDepreciation = @MonthsOfDepreciationLeft;
			DECLARE @MonthsBetweenOperationEntryAndExit int = DATEDIFF(M, @OperationEntryDate, @DateOfExit);

			IF @DateOfExit IS NULL
				BEGIN
					IF @MonthsSinceEntry < @MonthsOfDepreciation
						BEGIN
							IF @MonthsSinceEntry <= 12
								BEGIN
									RETURN @MonthlyDepreciationInTheFirstYear * @MonthsSinceOperationEntry;
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
					IF @MonthsBetweenEntryAndExit < @MonthsOfDepreciation
						BEGIN
							IF @MonthsBetweenEntryAndExit <= 12
								BEGIN
									RETURN @MonthlyDepreciationInTheFirstYear * @MonthsBetweenOperationEntryAndExit;
								END
							ELSE
								BEGIN
									RETURN (@MonthlyDepreciationAfterTheFirstYear * (@MonthsBetweenEntryAndExit - 12)) + (@InitialValue * 0.5);
								END
						END
					ELSE
						BEGIN
							RETURN @InitialValue;
						END
				END	

		END
	-----------------------------------------
	ELSE
		BEGIN
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
					IF @MonthsBetweenEntryAndExit < @MonthsOfDepreciation
						BEGIN
							IF @MonthsBetweenEntryAndExit <= 12
								BEGIN
									RETURN @MonthlyDepreciationInTheFirstYear * @MonthsBetweenEntryAndExit;
								END
							ELSE
								BEGIN
									RETURN (@MonthlyDepreciationAfterTheFirstYear * (@MonthsBetweenEntryAndExit - 12)) + (@InitialValue * 0.5);
								END
						END
					ELSE
						BEGIN
							RETURN @InitialValue;
						END
				END
		END

	RETURN -0.1;
END
