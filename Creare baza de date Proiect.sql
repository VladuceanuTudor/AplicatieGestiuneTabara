-- Crearea bazei de date
CREATE DATABASE TabaraDeVara;
GO

USE TabaraDeVara;

-- Crearea tabelei Parinte
CREATE TABLE Parinte (
    ParinteID INT PRIMARY KEY IDENTITY(1,1),
    Nume NVARCHAR(50) NOT NULL,
    Prenume NVARCHAR(50) NOT NULL,
    Parola NVARCHAR(100) NOT NULL,
    NumarTel NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

-- Crearea tabelei Educator
CREATE TABLE Educator (
    EducatorID INT PRIMARY KEY IDENTITY(1,1),
    Nume NVARCHAR(50) NOT NULL,
    Prenume NVARCHAR(50) NOT NULL,
    Parola NVARCHAR(100) NOT NULL,
    NumarTel NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

-- Crearea tabelei Copil
CREATE TABLE Copil (
    CopilID INT PRIMARY KEY IDENTITY(1,1),
    Nume NVARCHAR(50) NOT NULL,
    Prenume NVARCHAR(50) NOT NULL,
    Varsta INT NOT NULL,
    Parola NVARCHAR(100) NOT NULL,
    EducatorID INT NOT NULL,
    FOREIGN KEY (EducatorID) REFERENCES Educator(EducatorID) ON DELETE NO ACTION
);

-- Crearea tabelei Activitate
CREATE TABLE Activitate (
    ActivitateID INT PRIMARY KEY IDENTITY(1,1),
    Nume NVARCHAR(100) NOT NULL,
    Descriere NVARCHAR(255),
    Data DATE NOT NULL,
    Ora TIME NOT NULL,
    Durata INT NOT NULL,
    EducatorID INT NOT NULL,
    FOREIGN KEY (EducatorID) REFERENCES Educator(EducatorID) ON DELETE NO ACTION
);

-- Crearea tabelei CopilParinte
CREATE TABLE CopilParinte (
    CopilID INT NOT NULL,
    ParinteID INT NOT NULL,
    PRIMARY KEY (CopilID, ParinteID),
    FOREIGN KEY (CopilID) REFERENCES Copil(CopilID) ON DELETE CASCADE,
    FOREIGN KEY (ParinteID) REFERENCES Parinte(ParinteID) ON DELETE CASCADE
);

-- Crearea tabelei CopilActivitate
CREATE TABLE CopilActivitate (
    CopilID INT NOT NULL,
    ActivitateID INT NOT NULL,
    Prezenta BIT NOT NULL DEFAULT 0,
    PRIMARY KEY (CopilID, ActivitateID),
    FOREIGN KEY (CopilID) REFERENCES Copil(CopilID) ON DELETE NO ACTION,
    FOREIGN KEY (ActivitateID) REFERENCES Activitate(ActivitateID) ON DELETE NO ACTION
);



-- Populare tabela Parinte
INSERT INTO Parinte (Nume, Prenume, Parola, NumarTel, Email)
VALUES
('Popescu', 'Ion', 'parola123', '0722123456', 'ion.popescu@gmail.com'),
('Ionescu', 'Maria', 'parola456', '0722987654', 'maria.ionescu@gmail.com'),
('Vasilescu', 'Ana', 'parola789', '0734123456', 'ana.vasilescu@gmail.com'),
('Gheorghiu', 'Mihai', 'parola123', '0745123456', 'mihai.gheorghiu@gmail.com'),
('Dumitrescu', 'Raluca', 'parola456', '0756123456', 'raluca.dumitrescu@gmail.com'),
('Stan', 'Alina', 'parola789', '0766123456', 'alina.stan@gmail.com'),
('Diaconu', 'George', 'parola123', '0776123456', 'george.diaconu@gmail.com'),
('Dragomir', 'Cristina', 'parola456', '0786123456', 'cristina.dragomir@gmail.com'),
('Marinescu', 'Bogdan', 'parola789', '0796123456', 'bogdan.marinescu@gmail.com'),
('Voicu', 'Elena', 'parola123', '0723456789', 'elena.voicu@gmail.com'),
('Filip', 'Adrian', 'parola456', '0733456789', 'adrian.filip@gmail.com'),
('Iliescu', 'Daniela', 'parola789', '0743456789', 'daniela.iliescu@gmail.com'),
('Nastase', 'Ionela', 'parola123', '0753456789', 'ionela.nastase@gmail.com'),
('Barbu', 'Sorin', 'parola456', '0763456789', 'sorin.barbu@gmail.com'),
('Matei', 'Laura', 'parola789', '0773456789', 'laura.matei@gmail.com'),
('Cojocaru', 'Andreea', 'parola123', '0783456789', 'andreea.cojocaru@gmail.com'),
('Radu', 'Victor', 'parola456', '0793456789', 'victor.radu@gmail.com'),
('Serban', 'Ioana', 'parola789', '0724567890', 'ioana.serban@gmail.com'),
('Grigore', 'Marius', 'parola123', '0734567890', 'marius.grigore@gmail.com'),
('Olteanu', 'Silvia', 'parola456', '0744567890', 'silvia.olteanu@gmail.com');

-- Populare tabela Educator
INSERT INTO Educator (Nume, Prenume, Parola, NumarTel, Email)
VALUES
('Georgescu', 'Andrei', 'parolaEducator1', '0745123456', 'andrei.georgescu@gmail.com'),
('Dumitrescu', 'Elena', 'parolaEducator2', '0734567890', 'elena.dumitrescu@gmail.com'),
('Luca', 'Mihail', 'parolaEducator3', '0723456789', 'mihail.luca@gmail.com'),
('Stoica', 'Adriana', 'parolaEducator4', '0733456789', 'adriana.stoica@gmail.com'),
('Radulescu', 'Bogdan', 'parolaEducator5', '0743456789', 'bogdan.radulescu@gmail.com');

-- Populare tabela Copil
INSERT INTO Copil (Nume, Prenume, Varsta, Parola, EducatorID)
VALUES
('Popescu', 'Alex', 10, 'parolaAlex', 1),
('Ionescu', 'Bianca', 12, 'parolaBianca', 1),
('Vasilescu', 'Cristian', 9, 'parolaCristian', 2),
('Marin', 'Andrei', 11, 'parolaAndrei', 3),
('Dumitrescu', 'Larisa', 13, 'parolaLarisa', 3),
('Gheorghe', 'Tudor', 10, 'parolaTudor', 4),
('Stancu', 'Ioana', 8, 'parolaIoana', 4),
('Popa', 'Adrian', 12, 'parolaAdrian', 5),
('Voinea', 'Cristina', 9, 'parolaCristina', 5),
('Neagu', 'Mihai', 10, 'parolaMihai', 1),
('Pavel', 'Anca', 7, 'parolaAnca', 2),
('Petrescu', 'Radu', 8, 'parolaRadu', 3),
('Constantin', 'Ilinca', 11, 'parolaIlinca', 4),
('Stoian', 'Maria', 10, 'parolaMaria', 5),
('Toma', 'George', 9, 'parolaGeorge', 1),
('Dragomir', 'Diana', 12, 'parolaDiana', 2),
('Stanescu', 'Ana', 8, 'parolaAna', 3),
('Filip', 'Victor', 11, 'parolaVictor', 4),
('Pop', 'Elena', 7, 'parolaElena', 5),
('Iliescu', 'Dan', 9, 'parolaDan', 1);

-- Populare tabela CopilParinte
INSERT INTO CopilParinte (CopilID, ParinteID)
VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5),
(6, 6), (7, 7), (8, 8), (9, 9), (10, 10),
(11, 11), (12, 12), (13, 13), (14, 14), (15, 15),
(16, 16), (17, 17), (18, 18), (19, 19), (20, 20);

-- Populare tabela Activitate
INSERT INTO Activitate (Nume, Descriere, Data, Ora, Durata, EducatorID)
VALUES
('Jocuri de echipă', 'Activitate interactivă în aer liber', '2024-12-01', '10:00:00', 120, 1),
('Atelier de desen', 'Atelier creativ pentru copii', '2024-12-02', '14:00:00', 90, 2),
('Curs de gătit', 'Gătit mâncăruri simple și sănătoase', '2024-12-03', '12:00:00', 60, 3),
('Excursie', 'Explorare la un parc național', '2024-12-04', '09:00:00', 240, 4),
('Atelier de teatru', 'Exerciții de actorie și improvizație', '2024-12-05', '15:00:00', 120, 5);

-- Populare tabela CopilActivitate
INSERT INTO CopilActivitate (CopilID, ActivitateID, Prezenta)
VALUES
(1, 1, 1), (2, 1, 0), (3, 2, 1), (4, 2, 1), (5, 3, 0),
(6, 3, 1), (7, 4, 1), (8, 4, 0), (9, 5, 1), (10, 5, 1),
(11, 1, 0), (12, 2, 1), (13, 3, 1), (14, 4, 1), (15, 5, 0),
(16, 1, 1), (17, 2, 0), (18, 3, 1), (19, 4, 1), (20, 5, 1);


INSERT INTO CopilActivitate (CopilID, ActivitateID, Prezenta)
VALUES
(1, 2, 1), (1, 5, 0);

INSERT INTO CopilParinte (CopilID, ParinteID)
VALUES
(3, 1);

ALTER TABLE CopilActivitate
ADD Observatii VARCHAR(255) NULL;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la activitate.'
WHERE CopilID = 1 AND ActivitateID = 1;

UPDATE CopilActivitate
SET Observatii = 'Copilul nu a fost prezent la activitate.'
WHERE CopilID = 2 AND ActivitateID = 1;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la atelierul de desen.'
WHERE CopilID = 3 AND ActivitateID = 2;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la atelierul de desen.'
WHERE CopilID = 4 AND ActivitateID = 2;

UPDATE CopilActivitate
SET Observatii = 'Copilul nu a participat la cursul de gătit.'
WHERE CopilID = 5 AND ActivitateID = 3;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la cursul de gătit.'
WHERE CopilID = 6 AND ActivitateID = 3;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat la excursie.'
WHERE CopilID = 7 AND ActivitateID = 4;

UPDATE CopilActivitate
SET Observatii = 'Copilul nu a participat la excursie.'
WHERE CopilID = 8 AND ActivitateID = 4;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la atelierul de teatru.'
WHERE CopilID = 9 AND ActivitateID = 5;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la atelierul de teatru.'
WHERE CopilID = 10 AND ActivitateID = 5;

UPDATE CopilActivitate
SET Observatii = 'Copilul nu a fost prezent la activitate.'
WHERE CopilID = 11 AND ActivitateID = 1;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la atelierul de desen.'
WHERE CopilID = 12 AND ActivitateID = 2;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la cursul de gătit.'
WHERE CopilID = 13 AND ActivitateID = 3;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat la excursie.'
WHERE CopilID = 14 AND ActivitateID = 4;

UPDATE CopilActivitate
SET Observatii = 'Copilul nu a participat la atelierul de teatru.'
WHERE CopilID = 15 AND ActivitateID = 5;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la activitate.'
WHERE CopilID = 16 AND ActivitateID = 1;

UPDATE CopilActivitate
SET Observatii = 'Copilul nu a fost prezent la atelierul de desen.'
WHERE CopilID = 17 AND ActivitateID = 2;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la cursul de gătit.'
WHERE CopilID = 18 AND ActivitateID = 3;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat la excursie.'
WHERE CopilID = 19 AND ActivitateID = 4;

UPDATE CopilActivitate
SET Observatii = 'Copilul a participat activ la atelierul de teatru.'
WHERE CopilID = 20 AND ActivitateID = 5;


INSERT INTO Activitate (Nume, Descriere, Data, Ora, Durata, EducatorID)
VALUES
('Paintball', 'Activitate competitiva în aer liber', '2025-03-05', '10:45:00', 120, 1);

select * from Activitate

INSERT INTO CopilActivitate (CopilID, ActivitateID, Prezenta)
VALUES
(1, 1004, 0);

select * from Educator

INSERT INTO Educator (Nume, Prenume, Parola, NumarTel, Email)
VALUES
('test', 'test', '1', '1', '1');

-- Crearea bazei de date
CREATE DATABASE TabaraDeVara;
GO

USE TabaraDeVara;

-- Crearea tabelei Parinte
CREATE TABLE Parinte (
    ParinteID INT PRIMARY KEY IDENTITY(1,1),
    Nume NVARCHAR(50) NOT NULL,
    Prenume NVARCHAR(50) NOT NULL,
    Parola NVARCHAR(100) NOT NULL,
    NumarTel NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

-- Crearea tabelei Educator
CREATE TABLE Educator (
    EducatorID INT PRIMARY KEY IDENTITY(1,1),
    Nume NVARCHAR(50) NOT NULL,
    Prenume NVARCHAR(50) NOT NULL,
    Parola NVARCHAR(100) NOT NULL,
    NumarTel NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

-- Crearea tabelei Copil
CREATE TABLE Copil (
    CopilID INT PRIMARY KEY IDENTITY(1,1),
    Nume NVARCHAR(50) NOT NULL,
    Prenume NVARCHAR(50) NOT NULL,
    Varsta INT NOT NULL,
    Parola NVARCHAR(100) NOT NULL,
    EducatorID INT NOT NULL,
    FOREIGN KEY (EducatorID) REFERENCES Educator(EducatorID) ON DELETE NO ACTION
);

-- Crearea tabelei Activitate
CREATE TABLE Activitate (
    ActivitateID INT PRIMARY KEY IDENTITY(1,1),
    Nume NVARCHAR(100) NOT NULL,
    Descriere NVARCHAR(255),
    Data DATE NOT NULL,
    Ora TIME NOT NULL,
    Durata INT NOT NULL,
    EducatorID INT NOT NULL,
    FOREIGN KEY (EducatorID) REFERENCES Educator(EducatorID) ON DELETE NO ACTION
);

-- Crearea tabelei CopilParinte
CREATE TABLE CopilParinte (
    CopilID INT NOT NULL,
    ParinteID INT NOT NULL,
    PRIMARY KEY (CopilID, ParinteID),
    FOREIGN KEY (CopilID) REFERENCES Copil(CopilID) ON DELETE CASCADE,
    FOREIGN KEY (ParinteID) REFERENCES Parinte(ParinteID) ON DELETE CASCADE
);

-- Crearea tabelei CopilActivitate
CREATE TABLE CopilActivitate (
    CopilID INT NOT NULL,
    ActivitateID INT NOT NULL,
    Prezenta BIT NOT NULL DEFAULT 0,
    PRIMARY KEY (CopilID, ActivitateID),
    FOREIGN KEY (CopilID) REFERENCES Copil(CopilID) ON DELETE NO ACTION,
    FOREIGN KEY (ActivitateID) REFERENCES Activitate(ActivitateID) ON DELETE NO ACTION
);



-- Populare tabela Parinte
INSERT INTO Parinte (Nume, Prenume, Parola, NumarTel, Email)
VALUES
('Popescu', 'Ion', 'parola123', '0722123456', 'ion.popescu@gmail.com'),
('Ionescu', 'Maria', 'parola456', '0722987654', 'maria.ionescu@gmail.com'),
('Vasilescu', 'Ana', 'parola789', '0734123456', 'ana.vasilescu@gmail.com'),
('Gheorghiu', 'Mihai', 'parola123', '0745123456', 'mihai.gheorghiu@gmail.com'),
('Dumitrescu', 'Raluca', 'parola456', '0756123456', 'raluca.dumitrescu@gmail.com'),
('Stan', 'Alina', 'parola789', '0766123456', 'alina.stan@gmail.com'),
('Diaconu', 'George', 'parola123', '0776123456', 'george.diaconu@gmail.com'),
('Dragomir', 'Cristina', 'parola456', '0786123456', 'cristina.dragomir@gmail.com'),
('Marinescu', 'Bogdan', 'parola789', '0796123456', 'bogdan.marinescu@gmail.com'),
('Voicu', 'Elena', 'parola123', '0723456789', 'elena.voicu@gmail.com'),
('Filip', 'Adrian', 'parola456', '0733456789', 'adrian.filip@gmail.com'),
('Iliescu', 'Daniela', 'parola789', '0743456789', 'daniela.iliescu@gmail.com'),
('Nastase', 'Ionela', 'parola123', '0753456789', 'ionela.nastase@gmail.com'),
('Barbu', 'Sorin', 'parola456', '0763456789', 'sorin.barbu@gmail.com'),
('Matei', 'Laura', 'parola789', '0773456789', 'laura.matei@gmail.com'),
('Cojocaru', 'Andreea', 'parola123', '0783456789', 'andreea.cojocaru@gmail.com'),
('Radu', 'Victor', 'parola456', '0793456789', 'victor.radu@gmail.com'),
('Serban', 'Ioana', 'parola789', '0724567890', 'ioana.serban@gmail.com'),
('Grigore', 'Marius', 'parola123', '0734567890', 'marius.grigore@gmail.com'),
('Olteanu', 'Silvia', 'parola456', '0744567890', 'silvia.olteanu@gmail.com');

-- Populare tabela Educator
INSERT INTO Educator (Nume, Prenume, Parola, NumarTel, Email)
VALUES
('Georgescu', 'Andrei', 'parolaEducator1', '0745123456', 'andrei.georgescu@gmail.com'),
('Dumitrescu', 'Elena', 'parolaEducator2', '0734567890', 'elena.dumitrescu@gmail.com'),
('Luca', 'Mihail', 'parolaEducator3', '0723456789', 'mihail.luca@gmail.com'),
('Stoica', 'Adriana', 'parolaEducator4', '0733456789', 'adriana.stoica@gmail.com'),
('Radulescu', 'Bogdan', 'parolaEducator5', '0743456789', 'bogdan.radulescu@gmail.com');

-- Populare tabela Copil
INSERT INTO Copil (Nume, Prenume, Varsta, Parola, EducatorID)
VALUES
('Popescu', 'Alex', 10, 'parolaAlex', 1),
('Ionescu', 'Bianca', 12, 'parolaBianca', 1),
('Vasilescu', 'Cristian', 9, 'parolaCristian', 2),
('Marin', 'Andrei', 11, 'parolaAndrei', 3),
('Dumitrescu', 'Larisa', 13, 'parolaLarisa', 3),
('Gheorghe', 'Tudor', 10, 'parolaTudor', 4),
('Stancu', 'Ioana', 8, 'parolaIoana', 4),
('Popa', 'Adrian', 12, 'parolaAdrian', 5),
('Voinea', 'Cristina', 9, 'parolaCristina', 5),
('Neagu', 'Mihai', 10, 'parolaMihai', 1),
('Pavel', 'Anca', 7, 'parolaAnca', 2),
('Petrescu', 'Radu', 8, 'parolaRadu', 3),
('Constantin', 'Ilinca', 11, 'parolaIlinca', 4),
('Stoian', 'Maria', 10, 'parolaMaria', 5),
('Toma', 'George', 9, 'parolaGeorge', 1),
('Dragomir', 'Diana', 12, 'parolaDiana', 2),
('Stanescu', 'Ana', 8, 'parolaAna', 3),
('Filip', 'Victor', 11, 'parolaVictor', 4),
('Pop', 'Elena', 7, 'parolaElena', 5),
('Iliescu', 'Dan', 9, 'parolaDan', 1);

-- Populare tabela CopilParinte
INSERT INTO CopilParinte (CopilID, ParinteID)
VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5),
(6, 6), (7, 7), (8, 8), (9, 9), (10, 10),
(11, 11), (12, 12), (13, 13), (14, 14), (15, 15),
(16, 16), (17, 17), (18, 18), (19, 19), (20, 20);

-- Populare tabela Activitate
INSERT INTO Activitate (Nume, Descriere, Data, Ora, Durata, EducatorID)
VALUES
('Jocuri de echipă', 'Activitate interactivă în aer liber', '2024-12-01', '10:00:00', 120, 1),
('Atelier de desen', 'Atelier creativ pentru copii', '2024-12-02', '14:00:00', 90, 2),
('Curs de gătit', 'Gătit mâncăruri simple și sănătoase', '2024-12-03', '12:00:00', 60, 3),
('Excursie', 'Explorare la un parc național', '2024-12-04', '09:00:00', 240, 4),
('Atelier de teatru', 'Exerciții de actorie și improvizație', '2024-12-05', '15:00:00', 120, 5);

-- Populare tabela CopilActivitate
INSERT INTO CopilActivitate (CopilID, ActivitateID, Prezenta)
VALUES
(1, 1, 1), (2, 1, 0), (3, 2, 1), (4, 2, 1), (5, 3, 0),
(6, 3, 1), (7, 4, 1), (8, 4, 0), (9, 5, 1), (10, 5, 1),
(11, 1, 0), (12, 2, 1), (13, 3, 1), (14, 4, 1), (15, 5, 0),
(16, 1, 1), (17, 2, 0), (18, 3, 1), (19, 4, 1), (20, 5, 1);


INSERT INTO CopilActivitate (CopilID, ActivitateID, Prezenta)
VALUES
(1, 2, 1), (1, 5, 0);

INSERT INTO CopilParinte (CopilID, ParinteID)
VALUES
(3, 1);

--adaugat doar pt Entity Framework:

--alter table CopilParinte add ColForEF int ;

