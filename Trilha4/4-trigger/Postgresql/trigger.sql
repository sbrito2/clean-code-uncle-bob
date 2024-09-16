--create
CREATE PROCEDURE squared(INOUT x int)
LANGUAGE plpgsql
AS $$
BEGIN
    x := x * x;
END;
$$;

--get
DO $$
DECLARE myNumber int := 4;
BEGIN
  CALL squared(myNumber);
  RAISE NOTICE 'squared = %', myNumber;  -- prints 16
END
$$;

--update
CREATE OR REPLACE PROCEDURE squared(INOUT x int)
LANGUAGE plpgsql
AS $$
BEGIN
    x := x * x;
END;
$$;

--delete
DROP TRIGGER IF EXISTS squared