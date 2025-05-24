USE AcademiaOnlineBD;

INSERT INTO TbEstudiantes (Codigo, Nombre, Email, Programa_Creditos) VALUES 
('A1110','Lionel Messi', 'liomessi@hotmail.com', 9), 
('A1112','María González','mgonzalez@gmail.com', 9), 
('A1113','Jamez Rodríguez','crodriguez2000@gmail.com', 9), 
('A1114','Ana Martínez','anitachiquita@gmail.com', 9), 
('A1115','Cristiano Ronaldo','cronaldo-m@gmail.com', 9);

-- Insertar materias (10 en total)
INSERT INTO TbMaterias (Codigo, Nombre, Creditos) VALUES 
('C3698541','Matematicas Fudamentales', 3), 
('C3698542','Economia Colombiana', 3), 
('C3698543','Cálculo (Diferencial e Integral)', 3), 
('C3698544','Ezpreción Oral y Escrita', 3), 
('C3698545','Fisica', 3), 
('C3698546','Automatas Inteligentes', 3), 
('C3698547','Fundamentos de Programación', 3), 
('C3698548','Ingeniería del Software Avanzada', 3), 
('C3698549','Inteligencia Artificial e Ing. Conocimiento', 3), 
('C3698550','Metodología de la Investigación', 3);

INSERT INTO TbProfesores (Nombre) VALUES 
('Faber Orozco'), 
('Angie Medina'), 
('Diomedez Diaz'), 
('Melissa Peralta Martinez'), 
('Michael Jackson');

-- Relacionar profesores con materias (2 materias cada uno)
INSERT INTO TbProfesor_Materia (Profesor_Id, Materia_Id) VALUES
(1, 1), (1, 2),
(2, 3), (2, 4),
(3, 5), (3, 6),
(4, 7), (4, 8),
(5, 9), (5, 10);

-- Insertar un programa de crédito (9 créditos)
INSERT INTO TbProgramas_Credito (Nombre, Total_creditos) VALUES
('Programa Universitario Básico', 9);

-- Asociar a los estudiantes al programa de crédito
INSERT INTO TbEstudiante_Programa (Estudiante_Id, Programa_Id) VALUES
(1, 1),
(2, 1),
(3, 1);

INSERT INTO TbEstudiante_Materia (Estudiante_Id, Materia_Id) VALUES
(1, 1),
(1, 3),
(1, 5),

(2, 2),
(2, 4),
(2, 6),

(3, 7),
(3, 3),
(3, 9);