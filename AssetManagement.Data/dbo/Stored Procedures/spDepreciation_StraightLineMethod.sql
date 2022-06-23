CREATE PROCEDURE [dbo].[spDepreciation_StraightLineMethod]
	@InitialValue money,
	@MonthsOfDepreciation int,
	@DateOfEntry datetime2,
	@DateOfReference datetime2,
	@DateOfExit datetime2
AS
BEGIN
	DECLARE @MonthlyDepreciation money = @InitialValue / @MonthsOfDepreciation;
	DECLARE @MonthsSinceEntry int = DATEDIFF(M, @DateOfEntry, @DateOfReference);
	DECLARE @MonthsBetweenEntryAndExit int = DATEDIFF(M, @DateOfEntry, @DateOfExit);

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
END
