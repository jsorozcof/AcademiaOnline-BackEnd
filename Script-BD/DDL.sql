-- Eliminar la base de datos si existe
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'AcademiaOnlineBD')
DROP DATABASE AcademiaOnlineBD;
GO

-- Crear la base de datos
CREATE DATABASE AcademiaOnlineBD;
GO

USE AcademiaOnlineBD;
GO

-- Tabla de Estudiantes
CREATE TABLE TbEstudiantes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(100) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Programa_Creditos INT NOT NULL CHECK (Programa_Creditos <= 9) -- Máximo 3 materias * 3 créditos
);
GO

-- Tabla de Materias
CREATE TABLE TbMaterias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(100) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Creditos INT DEFAULT 3 CHECK (Creditos = 3)
);
GO

-- Tabla de Profesores
CREATE TABLE TbProfesores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);
GO

-- Tabla de Programas de Crédito
CREATE TABLE TbProgramas_Credito (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Total_Creditos INT NOT NULL
);
GO

-- Relación entre estudiante y programa de créditos
CREATE TABLE TbEstudiante_Programa (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Estudiante_Id INT NOT NULL,
    Programa_Id INT NOT NULL,
    CONSTRAINT UQ_Estudiante UNIQUE (Estudiante_Id),
    CONSTRAINT FK_Estudiante FOREIGN KEY (Estudiante_Id) REFERENCES TbEstudiantes(Id),
    CONSTRAINT FK_Programa FOREIGN KEY (Programa_Id) REFERENCES TbProgramas_Credito(Id)
);
GO

-- Relación muchos a muchos entre profesores y materias
CREATE TABLE TbProfesor_Materia (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Profesor_Id INT NOT NULL,
    Materia_Id INT NOT NULL,
    CONSTRAINT UQ_Profesor_Materia UNIQUE (Profesor_Id, Materia_Id),
    CONSTRAINT FK_Profesor FOREIGN KEY (Profesor_Id) REFERENCES TbProfesores(Id),
    CONSTRAINT FK_Materia FOREIGN KEY (Materia_Id) REFERENCES TbMaterias(Id)
);
GO

-- Relación muchos a muchos entre estudiantes y materias
CREATE TABLE TbEstudiante_Materia (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Estudiante_Id INT NOT NULL,
    Materia_Id INT NOT NULL,
    CONSTRAINT UQ_Estudiante_Materia UNIQUE (Estudiante_Id, Materia_Id),
    CONSTRAINT FK_EstudianteMateria_Estudiante FOREIGN KEY (Estudiante_Id) REFERENCES TbEstudiantes(Id),
    CONSTRAINT FK_EstudianteMateria_Materia FOREIGN KEY (Materia_Id) REFERENCES TbMaterias(Id)
);
GO