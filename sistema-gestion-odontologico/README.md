# 🦷 G.N.F.M. — Sistema de Gestión para Círculos Odontológicos

> Sistema de escritorio para la gestión integral de facturación, liquidación y administración de socios en organizaciones odontológicas. Desarrollado en C# con arquitectura de 4 capas y SQL Server como motor de base de datos.

**Cliente:** Círculo Odontológico de los Llanos y el Sur · **Versión actual:** 9.0 · **En producción desde:** 2009

---

## 📸 Capturas del Sistema

| Login                               | Facturación a Obras Sociales             |
| ----------------------------------- | ---------------------------------------- |
| ![Login](screenshots/principal.png) | ![Facturación](screenshots/facturar.png) |

| Gestión de Pacientes                    | Liquidación de Socios                    |
| --------------------------------------- | ---------------------------------------- |
| ![Pacientes](screenshots/pacientes.png) | ![Liquidación](screenshots/liquidar.png) |

---

## 🏗️ Arquitectura

El sistema implementa una **arquitectura de 4 capas** que garantiza separación de responsabilidades, mantenibilidad y escalabilidad:

```
┌─────────────────────────────────────┐
│         CAPA DE PRESENTACIÓN        │  Windows Forms (C#)
│   Formularios, controles, UI/UX     │
├─────────────────────────────────────┤
│          CAPA DE NEGOCIO            │  Lógica de facturación,
│   Reglas, validaciones, procesos    │  liquidación y obras sociales
├─────────────────────────────────────┤
│          CAPA DE ACCESO A DATOS     │  ADO.NET + Stored Procedures
│   Repositorios, mapeo de entidades  │
├─────────────────────────────────────┤
│          CAPA DE BASE DE DATOS      │  SQL Server
│   Tablas, vistas, procedimientos    │
└─────────────────────────────────────┘
         ↕ Conexión cliente-servidor en red local
```

---

## ⚙️ Stack Tecnológico

| Componente     | Tecnología                                      |
| -------------- | ----------------------------------------------- |
| Lenguaje       | C# (.NET Framework)                             |
| UI             | Windows Forms                                   |
| Base de datos  | Microsoft SQL Server                            |
| Acceso a datos | ADO.NET + Stored Procedures                     |
| Arquitectura   | 4 capas (Presentación · Negocio · Datos · BD)   |
| Despliegue     | Cliente-Servidor en red local                   |
| Autenticación  | Login por usuario y clave con control de sesión |

---

## 🔧 Funcionalidades Principales

### 🧾 Facturación a Obras Sociales

- Generación de facturas por período y profesional
- Soporte para múltiples obras sociales (APOS, OSDE, etc.)
- Registro de pacientes con DNI, número de beneficiario y obra social
- Impresión de comprobantes y detalles por profesional

### 💰 Liquidación de Socios

- Liquidación mensual con cálculo de cuota social, seguro e ingresos brutos
- Gestión de pagos, débitos y créditos de obras sociales
- Configuración de alícuotas y períodos
- Reportes de totales y detalles por socio

### 👥 Gestión de Pacientes

- ABM completo de pacientes (alta, baja, modificación)
- Filtrado por nombre y obra social
- Historial por beneficiario y matrícula

### 📊 Informes

- Reportes por período, profesional y obra social
- Totales de facturación y liquidación
- Exportación para auditoría

### 🔐 Seguridad

- Autenticación por usuario y clave
- Control de acceso por rol (ADM y otros niveles)
- Estado de conexión al servidor en tiempo real

---

## 💡 Decisiones de Diseño Destacadas

**Arquitectura de 4 capas** permite que el sistema sea mantenible por un equipo pequeño durante años sin deuda técnica acumulada — este sistema lleva más de 15 años en producción activa.

**Stored Procedures en SQL Server** para toda la lógica de negocio crítica (facturación, liquidación), garantizando integridad transaccional y rendimiento en red local.

**Multi-obra social desde el diseño**: el modelo de datos soporta múltiples obras sociales con sus propias alícuotas, códigos y reglas de liquidación sin modificar código.

---

## 📋 Requisitos del Sistema

- Windows 10 / 11
- .NET Framework 4.x
- SQL Server 2014 o superior (Express válido para instalaciones pequeñas)
- Red local para modo cliente-servidor

---

## 📬 Contacto y Consultas

Este sistema es parte del portfolio profesional de **Cristian Tomas Britos**.  
Si necesitás un sistema similar adaptado a tu organización de salud, contactame:

📧 cbritos@unlar.edu.ar  
🔗 [linkedin.com/in/cristiantbritos](https://linkedin.com/in/cristiantbritos)  
💻 [github.com/cristianbritos](https://github.com/cristianbritos)

---

> _Sistema desarrollado y mantenido desde 2009. Actualmente en versión 9.0, refleja más de 15 años de iteración continua basada en las necesidades reales de la organización._
