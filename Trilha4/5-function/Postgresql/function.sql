CREATE OR REPLACE FUNCTION increment(i INT) 
RETURNS INT AS $$
    BEGIN
      RETURN i + 1;
    END;
$$ LANGUAGE plpgsql;
 
SELECT increment(5);


CREATE FUNCTION sum_values(v1 anyelement, v2 anyelement)
RETURNS anyelement AS $$
DECLARE
   resultado ALIAS FOR $0;
BEGIN
   resultado := v1 + v2;
   RETURN resultado;
END;
$$ LANGUAGE plpgsql

SELECT sum_values(10,20);


CREATE OR REPLACE FUNCTION func_voidExample() 
RETURNS void AS $$
    BEGIN
      raise notice 'Essa função nao retorna valor!';
    END;
$$ LANGUAGE plpgsql;

SELECT func_voidExample();
