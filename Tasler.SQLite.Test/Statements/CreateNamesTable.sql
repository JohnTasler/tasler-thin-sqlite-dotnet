CREATE TABLE Names
(
 id INTEGER PRIMARY KEY AUTOINCREMENT
,firstName TEXT
,lastName TEXT
,modified DATETIME DEFAULT (julianday('now'))
);
