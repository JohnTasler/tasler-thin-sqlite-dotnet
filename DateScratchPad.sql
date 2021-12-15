CREATE TABLE IF NOT EXISTS t1(
	dt DATETIME
);

-- Values stored as TEXT, INTEGER, INTEGER, REAL, TEXT.
INSERT INTO t1 VALUES(julianday('2017-02-17 21:22:00'));
SELECT dt FROM t1;

-- SELECT julianday('now');

-- SELECT hex(randomblob(16));

DROP TABLE IF EXISTS Names;

CREATE TABLE Names
(
 id INTEGER PRIMARY KEY AUTOINCREMENT
,firstName TEXT
,lastName TEXT
,modified DATETIME
);

INSERT INTO Names
(
 firstName
,lastName
,modified
)
VALUES
(
	'John'
	,'Tasler'
	,julianday('now')
);
