# 🏥 N.F.G.M. — Sistema de Administración para Clínica de Segundo Nivel

> Sistema de escritorio para la gestión integral de internación, facturación, pacientes y administración en establecimientos de salud de segundo nivel de complejidad. Desarrollado en C# con arquitectura de 4 capas y SQL Server como motor de base de datos.

**Tipo de cliente:** Clínica privada de segundo nivel · **Versión actual:** 9.0 · **Desarrollado por:** JOB GROUP

---

## 📸 Capturas del Sistema

> ⚠️ Las capturas que se muestran utilizan datos ficticios generados para demo.

| Login                           | Gestión de Pacientes                    |
| ------------------------------- | --------------------------------------- |
| ![Login](screenshots/login.png) | ![Pacientes](screenshots/pacientes.png) |

| Internación — Datos del Paciente            | Internación — Detalle de Prácticas          |
| ------------------------------------------- | ------------------------------------------- |
| ![Internación](screenshots/internacion.png) | ![Facturación](screenshots/facturacion.png) |

---

## 🏗️ Arquitectura

El sistema implementa una **arquitectura de 4 capas** desacoplada, que permite el mantenimiento independiente de cada nivel:

```
┌──────────────────────────────────────────┐
│          CAPA DE PRESENTACIÓN            │  Windows Forms (C#)
│  Formularios MDI, controles, navegación  │
├──────────────────────────────────────────┤
│           CAPA DE NEGOCIO                │  Reglas de internación,
│  Validaciones, cálculos, flujos clínicos │  facturación y cobertura OS
├──────────────────────────────────────────┤
│        CAPA DE ACCESO A DATOS            │  ADO.NET + Stored Procedures
│  Repositorios por módulo, transacciones  │
├──────────────────────────────────────────┤
│         CAPA DE BASE DE DATOS            │  Microsoft SQL Server
│  Tablas, vistas, triggers, procedures    │
└──────────────────────────────────────────┘
              ↕ Cliente-Servidor en red local
              ↕ Control de sesión y bloqueo por usuario
```

---

## ⚙️ Stack Tecnológico

| Componente     | Tecnología                                              |
| -------------- | ------------------------------------------------------- |
| Lenguaje       | C# (.NET Framework)                                     |
| UI             | Windows Forms — interfaz MDI                            |
| Base de datos  | Microsoft SQL Server                                    |
| Acceso a datos | ADO.NET + Stored Procedures                             |
| Arquitectura   | 4 capas                                                 |
| Despliegue     | Cliente-Servidor en red hospitalaria                    |
| Autenticación  | Login por usuario/clave con control de sesión y bloqueo |
| Nomenclador    | Códigos de práctica y diagnóstico (CIE-10)              |

---

## 🔧 Módulos del Sistema

### 👥 Pacientes

- Registro completo: datos personales, obra social, número de afiliado
- Búsqueda por parámetros (nombre, DNI, legajo)
- Historial clínico con médico de cabecera y registro de alergias
- Base de pacientes con más de 7.000 registros en producción

### 🛏️ Internación

- Alta de internación: tipo de ingreso, módulo, diagnóstico CIE-10
- Asignación de habitación, cama y servicio (Clínica, Cirugía, etc.)
- Registro de profesional derivante y receptor
- Datos del familiar responsable
- Seguimiento de prácticas facturables por internación:
  - Prácticas con cobertura OS y cargo al afiliado
  - Medicamentos e insumos
  - Laboratorio
- Cálculo automático de importe OS e importe afiliado por cobertura

### 🧾 Facturación

- Facturación por práctica, período y obra social
- Soporte para múltiples obras sociales con distintos porcentajes de cobertura
- Generación e impresión de comprobantes por internación
- Control de prácticas facturadas vs. pendientes

### ⚙️ Administración

- Configuración de obras sociales, módulos y servicios
- Gestión de profesionales y matrículas
- Parámetros del sistema por institución

### 📦 Módulos y Convenios

- Configuración de módulos de internación (DÍA/CAMA, UCI, etc.)
- Gestión de convenios por obra social con reglas de cobertura específicas

---

## 💡 Decisiones de Diseño Destacadas

**Nomenclador integrado**: el sistema maneja códigos de práctica propios de las obras sociales y diagnósticos CIE-10, permitiendo facturación precisa sin codificación manual por parte del operador.

**Cobertura dual OS/Afiliado**: cada práctica calcula automáticamente el importe a cargo de la obra social y el importe a cargo del afiliado según el porcentaje de cobertura configurado por convenio.

**Control de sesión y bloqueo**: el sistema detecta si hay otro usuario activo en la misma estación y bloquea el acceso, evitando modificaciones concurrentes sobre el mismo registro.

**Módulo de internación orientado al flujo real**: el formulario de internación refleja el circuito clínico real — ingreso → asignación de cama → carga de prácticas → facturación — sin forzar al operador a saltar entre pantallas.

**Arquitectura de 4 capas en red hospitalaria**: el sistema opera en red local con múltiples clientes conectados al mismo SQL Server, con transacciones controladas para garantizar integridad en operaciones concurrentes.

---

## 📋 Requisitos del Sistema

- Windows 10 / 11
- .NET Framework 4.x
- SQL Server 2014 o superior
- Red local para operación multi-usuario

---

## 🗂️ Estructura del Repositorio

```
📦 Clinica-NFGM-Portfolio-Edition
 ┣ 📂 src/
 ┃ ┣ 📂 Presentacion/         # Windows Forms — formularios por módulo
 ┃ ┣ 📂 Negocio/              # Lógica clínica y de facturación
 ┃ ┣ 📂 AccesoDatos/          # Repositorios ADO.NET por entidad
 ┃ ┗ 📂 Entidades/            # Clases del modelo de dominio
 ┣ 📂 BaseDatos/
 ┃ ┣ 📜 schema.sql            # Estructura completa de tablas
 ┃ ┣ 📜 stored_procedures.sql # Procedures de facturación e internación
 ┃ ┗ 📜 datos_demo.sql        # Datos ficticios para demo
 ┣ 📂 screenshots/            # Capturas con datos ficticios
 ┣ 📂 docs/
 ┃ ┗ 📜 arquitectura.md       # Diagrama y decisiones de diseño
 ┣ 📜 README.md
 ┣ 📜 config.example          # Plantilla de conexión sin credenciales
 ┗ 📜 .gitignore
```

---

## 🔐 Nota sobre Privacidad y Datos

Este repositorio es una **Portfolio Edition** del sistema en producción. Todo el código fuente se publica sin datos reales de pacientes. Las capturas utilizan registros ficticios generados específicamente para este repositorio.

El sistema en producción maneja datos sensibles de salud y cumple con los requisitos de confidencialidad establecidos por la institución cliente.

---

## 📬 Contacto

**Cristian Tomas Britos**  
📧 <cbritos@unlar.edu.ar>  
🔗 [linkedin.com/in/cristiantbritos](https://linkedin.com/in/cristiantbritos)  
💻 [github.com/cristianbritos](https://github.com/cristianbritos)

---

> _Sistema en producción activa. Versión 9.0 resultado de años de iteración continua basada en las necesidades reales de la institución._
