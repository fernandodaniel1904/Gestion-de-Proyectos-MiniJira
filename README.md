# 📋 Gestión de Proyectos MiniJira

Aplicación web MVC desarrollada con **ASP.NET Core** para la gestión de proyectos y tareas, implementando patrones de diseño modernos y arquitectura de capas.

## 🎯 Características

✅ **CRUD Completo** - Crear, leer, actualizar y eliminar proyectos y tareas
✅ **Patrón Repository** - Abstracción de acceso a datos
✅ **Entity Framework Core** - ORM con Code-First
✅ **Inyección de Dependencias** - Configuración en Program.cs
✅ **API REST** - Endpoints JSON para proyectos y tareas
✅ **Interfaz Limpia** - Vistas con Bootstrap 5
✅ **Base de Datos SQL Server** - LocalDB integrada

## 📦 Requisitos

- .NET 8.0 o superior
- Visual Studio 2022 o VS Code
- SQL Server (LocalDB incluido con Visual Studio)

## 🚀 Instalación y Configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/Gestion-de-Proyectos-MiniJira.git
cd Gestion-de-Proyectos-MiniJira
```

### 2. Restaurar paquetes NuGet

```bash
dotnet restore
```

### 3. Aplicar migraciones

```bash
dotnet ef database update
```

### 4. Ejecutar la aplicación

```bash
dotnet run
```

La aplicación se abrirá en `https://localhost:7262`

## 📁 Estructura del Proyecto

```
Gestion-de-Proyectos-MiniJira/
├── Controllers/
│   ├── HomeController.cs
│   ├── ProyectosController.cs
│   ├── TareasController.cs
│   ├── ApiProyectosController.cs (REST API)
│   └── ApiTareasController.cs (REST API)
├── Models/
│   ├── Proyecto.cs
│   ├── Tarea.cs
│   └── ErrorViewModel.cs
├── Data/
│   ├── ApplicationDbContext.cs
│   ├── IRepository.cs
│   └── Repository.cs
├── Repositories/
│   ├── IProyectoRepository.cs
│   ├── ProyectoRepository.cs
│   ├── ITareaRepository.cs
│   └── TareaRepository.cs
├── Views/
│   ├── Proyectos/
│   ├── Tareas/
│   └── Home/
├── wwwroot/
├── Program.cs
├── appsettings.json
└── README.md
```

## 🏗️ Arquitectura

El proyecto implementa una arquitectura de **3 capas**:

### 1. **Capa de Presentación (Controllers + Views)**
- Controladores MVC para interfaz web
- Controladores API para endpoints REST
- Vistas Razor con Bootstrap

### 2. **Capa de Lógica de Negocio (Repositories)**
- Patrón Repository Pattern
- Interfaces IProyectoRepository y ITareaRepository
- Implementaciones con métodos asincronos

### 3. **Capa de Datos (Data Context)**
- Entity Framework Core
- ApplicationDbContext
- Migraciones automáticas

## 🗄️ Modelos de Datos

### Proyecto
```csharp
id (int) - Identificador único
nombre (string) - Nombre del proyecto
descripcion (string) - Descripción
fechaCreacion (DateTime) - Fecha de creación
fechaVencimiento (DateTime?) - Fecha límite
estado (EstadoProyecto) - Activo, Pausado, Finalizado
tareas (ICollection<Tarea>) - Relación 1:N
```

### Tarea
```csharp
id (int) - Identificador único
titulo (string) - Título de la tarea
descripcion (string) - Descripción
fechaCreacion (DateTime) - Fecha de creación
fechaVencimiento (DateTime?) - Fecha límite
estado (EstadoTarea) - Por Hacer, En Progreso, Completada
prioridad (Prioridad) - Baja, Media, Alta
proyectoId (int) - Clave foránea
proyecto (Proyecto) - Relación N:1
```

## 📡 API REST Endpoints

### Proyectos
```
GET    /api/aproyectos              - Obtener todos
GET    /api/aproyectos/{id}         - Obtener por ID
POST   /api/aproyectos              - Crear nuevo
PUT    /api/aproyectos/{id}         - Actualizar
DELETE /api/aproyectos/{id}         - Eliminar
```

### Tareas
```
GET    /api/atareas                 - Obtener todas
GET    /api/atareas/{id}            - Obtener por ID
GET    /api/atareas/proyecto/{id}   - Obtener por proyecto
POST   /api/atareas                 - Crear nueva
PUT    /api/atareas/{id}            - Actualizar
DELETE /api/atareas/{id}            - Eliminar
```

## 🔧 Tecnologías Utilizadas

- **ASP.NET Core 8.0**
- **Entity Framework Core 8.0**
- **SQL Server / LocalDB**
- **Bootstrap 5**
- **Razor Pages**
- **C# 12**

## 📝 Notas Importantes

1. **Primera ejecución**: Las migraciones se aplican automáticamente
2. **Base de datos**: Se crea en LocalDB automáticamente
3. **Conexión**: Edita `appsettings.json` para cambiar la conexión
4. **Async/Await**: Todo el acceso a datos es asincrónico

## 👥 Autor

**Estudiante**: Fernando Daniel
**Materia**: Taller de Diseño de Aplicaciones
**Institución**: UDI
**Fecha**: 2026

## 📄 Licencia

Este proyecto es de uso académico.
