CREATE FUNCTION [dbo].[CalculateDepreciation_DegressiveMethod]
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

	--DECLARE @MonthlyDepreciation money = @InitialValue / @MonthsOfDepreciation;
	DECLARE @MonthsSinceEntry int = DATEDIFF(M, @DateOfEntry, @DateOfReference);
	DECLARE @YearsSinceEntry int = DATEDIFF(YEAR, @DateOfEntry, @DateOfReference);
	DECLARE @MonthsBetweenEntryAndExit int = DATEDIFF(M, @DateOfEntry, @DateOfExit);


	------------------------------------------

	DECLARE @MonthsSinceTheMonthOfEntry int;

	SET @MonthsSinceTheMonthOfEntry = @MonthsSinceEntry - @YearsSinceEntry * 12 ;

	IF @MonthsSinceEntry >= 12 AND @MonthsSinceTheMonthOfEntry = 0
		BEGIN
			SET @MonthsSinceTheMonthOfEntry = 12;
		END
	-----------------------------------------


	DECLARE @DepreciationDegressiveRate decimal(10, 6);
	DECLARE @DepreciationStraightLineRate decimal(10, 6) = CAST(@MonthsOfDepreciation AS decimal(8, 4)) / 12 / 100;

	IF @MonthsOfDepreciation <= (5 * 12)
		BEGIN
			SET @DepreciationDegressiveRate = 1.5 * @DepreciationStraightLineRate;
		END
	ELSE IF @MonthsOfDepreciation > (5 * 12) AND @MonthsOfDepreciation <= (10 * 12)
		BEGIN
			SET @DepreciationDegressiveRate = 2 * @DepreciationStraightLineRate;
		END
	ELSE
		BEGIN
			SET @DepreciationDegressiveRate = 2.5 * @DepreciationStraightLineRate;
		END

	-- for operation depreciation calculation

	IF (@IsOperationDepreciation = 1)
		BEGIN
			DECLARE @MonthsOfDepreciationLeft int = @MonthsOfDepreciation - DATEDIFF(M, @DateOfEntry, @OperationEntryDate);
			--SET @MonthlyDepreciation = @InitialValue / @MonthsOfDepreciationLeft;
			--SET @MonthsSinceEntry = DATEDIFF(M, @OperationEntryDate, @DateOfReference);
			--SET @MonthsOfDepreciation = @MonthsOfDepreciationLeft;
			--SET @MonthsBetweenEntryAndExit = DATEDIFF(M, @OperationEntryDate, @DateOfExit);
		END
	-----------------------------------------
	ELSE
		BEGIN
			IF @DateOfExit IS NULL
				BEGIN
					IF @MonthsSinceEntry < @MonthsOfDepreciation
						BEGIN

							--IF @MonthsSinceEntry = 12 AND @YearsSinceEntry = 1
							--	BEGIN
							--		RETURN (@InitialValue * @DepreciationDegressiveRate)
							--	END


							DECLARE @cnt int = 0;
							WHILE @cnt < @YearsSinceEntry
							BEGIN
								SET @InitialValue = @InitialValue - ((((@InitialValue * @DepreciationDegressiveRate)) / 12) * CAST(@MonthsSinceTheMonthOfEntry AS decimal(10, 6)));
									
								SET @cnt = @cnt + 1;
							END;	
	
							RETURN (((@InitialValue * @DepreciationDegressiveRate)) / 12) * CAST(@MonthsSinceTheMonthOfEntry AS decimal(10, 6));
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
							RETURN 0;--@MonthlyDepreciation * @MonthsBetweenEntryAndExit
						END
					ELSE
						BEGIN
							RETURN @InitialValue;
						END
				END	
		END

	RETURN -0.00;
END