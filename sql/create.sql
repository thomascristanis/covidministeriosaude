CREATE DATABASE Covid;

Use Covid;

CREATE TABLE ConfigurationSystem(
    ID int IDENTITY(1,1) PRIMARY KEY,
    URL varchar(500),
    ReferenceDate datetime,
    InsertionDate datetime
)

INSERT INTO ConfigurationSystem (URL, ReferenceDate, InsertionDate) VALUES ('https://mobileapps.saude.gov.br/esus-vepi/files/unAFkcaNDeXajurGB7LChj8SgQYS2ptm/799e61729b97d355178f1538a369de59_Download_COVID19_20200407.csv', DATEADD(day, -1, GETDATE()), DATEADD(day, -1, GETDATE()))

SELECT * FROM ConfigurationSystem (NOLOCK) order by 1 desc