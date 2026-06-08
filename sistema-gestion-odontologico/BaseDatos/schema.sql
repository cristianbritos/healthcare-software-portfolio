-- ============================================================
-- SCHEMA DE DEMO - Sistema de Gestión Odontológica
-- Datos completamente ficticios para fines de portfolio
-- ============================================================

-- ----------------
-- OBRAS SOCIALES
-- ----------------
CREATE TABLE ObrasSociales (
    id          INT PRIMARY KEY IDENTITY,
    codigo      VARCHAR(10)  NOT NULL UNIQUE,
    nombre      VARCHAR(100) NOT NULL,
    alicuota    DECIMAL(5,2) NOT NULL DEFAULT 0,   -- porcentaje
    activa      BIT          NOT NULL DEFAULT 1
);

-- ----------------
-- SOCIOS / PROFESIONALES
-- ----------------
CREATE TABLE Socios (
    id              INT PRIMARY KEY IDENTITY,
    matricula       VARCHAR(20)  NOT NULL UNIQUE,
    apellido_nombre VARCHAR(150) NOT NULL,
    cuit            VARCHAR(20),
    cuota_social    DECIMAL(10,2) NOT NULL DEFAULT 0,
    seguro          DECIMAL(10,2) NOT NULL DEFAULT 0,
    alicuota        DECIMAL(5,2)  NOT NULL DEFAULT 0,
    activo          BIT           NOT NULL DEFAULT 1
);

-- ----------------
-- PACIENTES
-- ----------------
CREATE TABLE Pacientes (
    id              INT PRIMARY KEY IDENTITY,
    nro_dni         VARCHAR(15)  NOT NULL,
    apellido_nombre VARCHAR(150) NOT NULL,
    telefono        VARCHAR(30),
    domicilio       VARCHAR(200),
    localidad       VARCHAR(100),
    fecha_nac       DATE,
    nro_beneficiario VARCHAR(30),
    id_obra_social  INT REFERENCES ObrasSociales(id),
    activo          BIT NOT NULL DEFAULT 1
);

-- ----------------
-- PERÍODOS
-- ----------------
CREATE TABLE Periodos (
    id          INT PRIMARY KEY IDENTITY,
    anio        INT  NOT NULL,
    mes         INT  NOT NULL CHECK (mes BETWEEN 1 AND 12),
    descripcion AS (CAST(anio AS VARCHAR) + '-' + RIGHT('0' + CAST(mes AS VARCHAR), 2)) PERSISTED,
    cerrado     BIT  NOT NULL DEFAULT 0,
    UNIQUE (anio, mes)
);

-- ----------------
-- FACTURACIÓN
-- ----------------
CREATE TABLE Facturas (
    id              INT PRIMARY KEY IDENTITY,
    id_periodo      INT  NOT NULL REFERENCES Periodos(id),
    id_socio        INT  NOT NULL REFERENCES Socios(id),
    id_obra_social  INT  NOT NULL REFERENCES ObrasSociales(id),
    id_paciente     INT  REFERENCES Pacientes(id),
    fecha           DATE NOT NULL DEFAULT GETDATE(),
    importe         DECIMAL(12,2) NOT NULL DEFAULT 0,
    observaciones   VARCHAR(500)
);

-- ----------------
-- LIQUIDACIONES
-- ----------------
CREATE TABLE Liquidaciones (
    id              INT PRIMARY KEY IDENTITY,
    id_periodo      INT  NOT NULL REFERENCES Periodos(id),
    nro_liquidacion INT  NOT NULL,
    fecha           DATE NOT NULL DEFAULT GETDATE(),
    UNIQUE (id_periodo, nro_liquidacion)
);

CREATE TABLE LiquidacionDetalle (
    id                  INT PRIMARY KEY IDENTITY,
    id_liquidacion      INT NOT NULL REFERENCES Liquidaciones(id),
    id_socio            INT NOT NULL REFERENCES Socios(id),
    cuota_social        DECIMAL(10,2) NOT NULL DEFAULT 0,
    seguro              DECIMAL(10,2) NOT NULL DEFAULT 0,
    ing_brutos          DECIMAL(10,2) NOT NULL DEFAULT 0,
    total_facturado     DECIMAL(10,2) NOT NULL DEFAULT 0,
    total_liquidado     DECIMAL(10,2) NOT NULL DEFAULT 0
);

-- ============================================================
-- STORED PROCEDURES
-- ============================================================

-- Facturación por período y profesional
CREATE OR ALTER PROCEDURE sp_FacturacionPorPeriodo
    @id_periodo     INT,
    @id_socio       INT = NULL   -- NULL = todos los socios
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        f.id,
        p.descripcion       AS periodo,
        s.apellido_nombre   AS profesional,
        s.matricula,
        os.nombre           AS obra_social,
        pac.apellido_nombre AS paciente,
        pac.nro_beneficiario,
        f.fecha,
        f.importe
    FROM Facturas f
    JOIN Periodos       p   ON f.id_periodo     = p.id
    JOIN Socios         s   ON f.id_socio        = s.id
    JOIN ObrasSociales  os  ON f.id_obra_social  = os.id
    LEFT JOIN Pacientes pac ON f.id_paciente     = pac.id
    WHERE f.id_periodo = @id_periodo
      AND (@id_socio IS NULL OR f.id_socio = @id_socio)
    ORDER BY s.apellido_nombre, f.fecha;
END;
GO

-- Total facturado por socio en un período
CREATE OR ALTER PROCEDURE sp_TotalFacturadoPorSocio
    @id_periodo INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        s.matricula,
        s.apellido_nombre,
        COUNT(f.id)       AS cantidad_facturas,
        SUM(f.importe)    AS total_facturado
    FROM Socios s
    LEFT JOIN Facturas f ON s.id = f.id_socio AND f.id_periodo = @id_periodo
    WHERE s.activo = 1
    GROUP BY s.id, s.matricula, s.apellido_nombre
    ORDER BY s.apellido_nombre;
END;
GO

-- Liquidar un socio en un período
CREATE OR ALTER PROCEDURE sp_LiquidarSocio
    @id_liquidacion INT,
    @id_socio       INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @liq_id     INT = @id_liquidacion;
    DECLARE @periodo_id INT;

    SELECT @periodo_id = id_periodo FROM Liquidaciones WHERE id = @liq_id;

    DECLARE @total_fact DECIMAL(12,2);
    SELECT @total_fact = ISNULL(SUM(importe), 0)
    FROM Facturas
    WHERE id_periodo = @periodo_id AND id_socio = @id_socio;

    DECLARE @cuota   DECIMAL(10,2),
            @seguro  DECIMAL(10,2),
            @alicuota DECIMAL(5,2);

    SELECT @cuota    = cuota_social,
           @seguro   = seguro,
           @alicuota = alicuota
    FROM Socios WHERE id = @id_socio;

    DECLARE @ing_brutos   DECIMAL(10,2) = @total_fact * @alicuota / 100;
    DECLARE @total_liquidado DECIMAL(10,2) = @total_fact - @cuota - @seguro - @ing_brutos;

    INSERT INTO LiquidacionDetalle
        (id_liquidacion, id_socio, cuota_social, seguro, ing_brutos, total_facturado, total_liquidado)
    VALUES
        (@liq_id, @id_socio, @cuota, @seguro, @ing_brutos, @total_fact, @total_liquidado);
END;
GO

-- ============================================================
-- DATOS DE DEMO (ficticios)
-- ============================================================

INSERT INTO ObrasSociales (codigo, nombre, alicuota) VALUES
('APOS',  'APOS (100%)',           3.0),
('OSDE',  'OSDE',                  2.5),
('SWISS', 'Swiss Medical',         2.5),
('PAMI',  'PAMI',                  0.0);

INSERT INTO Socios (matricula, apellido_nombre, cuit, cuota_social, seguro, alicuota) VALUES
('MAT-001', 'González, Roberto Carlos',  '20-11111111-1', 5000.00, 800.00, 3.0),
('MAT-002', 'Fernández, María Laura',    '27-22222222-2', 5000.00, 800.00, 3.0),
('MAT-003', 'Rodríguez, Juan Pablo',     '20-33333333-3', 5000.00, 800.00, 3.0);

INSERT INTO Pacientes (nro_dni, apellido_nombre, telefono, localidad, nro_beneficiario, id_obra_social) VALUES
('11222333', 'Pérez, Ana Belén',      '3826-400001', 'Chamical', 'BEN-0001', 1),
('44555666', 'López, Carlos Eduardo', '3826-400002', 'Chamical', 'BEN-0002', 1),
('77888999', 'Martínez, Sofía',       '3826-400003', 'La Rioja',  'BEN-0003', 2);

INSERT INTO Periodos (anio, mes) VALUES (2024, 1), (2024, 2), (2024, 3);
