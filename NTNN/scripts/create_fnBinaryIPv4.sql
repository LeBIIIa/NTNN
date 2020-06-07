CREATE OR ALTER FUNCTION dbo.fnBinaryIPv4(@ip AS NVARCHAR(15)) RETURNS BINARY(4)
AS
BEGIN
    DECLARE @bin AS BINARY(4)

    SELECT @bin = CAST( CAST( PARSENAME( @ip, 4 ) AS INTEGER) AS BINARY(1))
                + CAST( CAST( PARSENAME( @ip, 3 ) AS INTEGER) AS BINARY(1))
                + CAST( CAST( PARSENAME( @ip, 2 ) AS INTEGER) AS BINARY(1))
                + CAST( CAST( PARSENAME( @ip, 1 ) AS INTEGER) AS BINARY(1))
    RETURN @bin
END
go