--1.
CREATE TABLE Spec(
    id              int             PRIMARY KEY,
    table_name      varchar(50)     NOT NULL,
    column_name     varchar(50)     NOT NULL,
    curMax          int             Not NULL
);

--2.
INSERT INTO Spec(id, table_name, column_name, curMax)
    VALUES(1, 'spec', 'id', 1);

--3. Создаем функцию, формирующую триггер
CREATE OR REPLACE FUNCTION update_spec_curmax()
	RETURNS trigger AS
	$$
	BEGIN
		EXECUTE format('UPDATE spec
		               SET curmax = maxval
		               from (select max(num) as maxval from
		               (select %I as num from %I
                        union
                        select curmax as num from spec where table_name = $1 and column_name = $2) as t) as t1
                where table_name = $1 and column_name = $2;'
	        , quote_ident(tg_argv[1]), quote_ident(tg_argv[0]))
		    USING quote_ident(tg_argv[0]), quote_ident(tg_argv[1]);
		RETURN NULL;
	END;
	$$ LANGUAGE plpgsql;

--4.
CREATE OR REPLACE FUNCTION get_next_number(_table_name varchar, _column_name varchar, out incremented_id integer) AS
    $$
    BEGIN
        IF NOT EXISTS(SELECT * FROM spec where table_name = (_table_name) and column_name = (_column_name)) THEN
            EXECUTE format('SELECT coalesce(max(%I)+1,1) FROM %I',quote_ident(_column_name), quote_ident(_table_name)) INTO incremented_id;
            INSERT INTO Spec(id, table_name, column_name, curMax)
               VALUES(get_next_number('spec', 'id'), (_table_name), (_column_name),incremented_id);
            EXECUTE format('CREATE TRIGGER update_spec_curmax
	                            AFTER INSERT OR UPDATE
	                            ON %I
	                            FOR EACH STATEMENT
                            EXECUTE FUNCTION update_spec_curmax(%I, %I);', quote_ident(_table_name), quote_ident(_table_name), quote_ident(_column_name));
        ELSE
            UPDATE Spec
            SET curMax = curMax+1
            WHERE table_name = (_table_name) and column_name = (_column_name)
            returning curMax into incremented_id;
        END IF;
    END;
    $$ LANGUAGE plpgsql;

--5.
CREATE TABLE test(
    id              int             NOT NULL
);

--6.
INSERT INTO test(id)
    VALUES(10);

--7.
SELECT get_next_number('test', 'id');

--8. Добавляем значение больше максимума в обход процедуре
INSERT INTO test(id)
    VALUES(155);

--9.
SELECT get_next_number('test', 'id');

--10. Добавляем значение меньше максимума
INSERT INTO test(id)
    VALUES(112);

--11.
SELECT get_next_number('test', 'id');

--12. Обновляем одно из значений на число больше максимума
UPDATE test
set id = 200
where id = 112;

--13.
SELECT get_next_number('test', 'id');

--14. Обновляем одно из значений на число меньше максимума
UPDATE test
set id = 112
where id = 200;

--15.
SELECT get_next_number('test', 'id');

--16.
CREATE TABLE test2(
    num_value1              int             NOT NULL,
    num_value2              int             NOT NULL
);

--17.
SELECT get_next_number('test2', 'num_value1');
SELECT * from Spec;

--18.
DROP trigger update_spec_curmax on test;
DROP trigger update_spec_curmax on test2;

--19.
drop function update_spec_curmax();
DROP FUNCTION  get_next_number(_table_name varchar, _column_name varchar);

--20.
DROP TABLE Spec;
DROP TABLE test;
DROP TABLE test2;