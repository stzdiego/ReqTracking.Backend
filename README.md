# ReqTrak App

## Alcance del Sistema

ReqTrak es una aplicación web desarrollada para facilitar la visualización y el monitoreo en tiempo real de requerimientos de un equipo de desarrollo. La aplicación está dividida en tres capas principales: un frontend desarrollado en React, una API Rest en .NET y una base de datos en PostgreSQL.

### Funcionalidad

- Visualización de requerimientos y actualización de etapas.
- Creación de registros de seguimiento en tiempo real ("Tracking"), permitiendo a los usuarios ver el estado y cambios en cada requerimiento, incluyendo la fecha y usuario que realizó la modificación.

> **Nota**: La aplicación está diseñada para integrarse con un sistema de requerimientos ya existente, por lo que no incluye funcionalidades para la creación de nuevos requerimientos.

## Tecnologías Utilizadas

### Frontend
- **React**: Librería para la construcción de interfaces de usuario.
- **NodeJS**: Entorno de ejecución para el desarrollo en JavaScript.
- **Netlify**: Plataforma de despliegue.
- **FontAwesome**: Biblioteca de iconos.
- **GitHub**: Repositorio de código fuente.

### Backend
- **.NET 8**: Framework de desarrollo.
- **Docker**: Contenerización y despliegue.
- **EntityFrameworkCore**: ORM para el manejo de la base de datos.

### Base de Datos
- **PostgreSQL**: Base de datos relacional.

## Estructura de Datos Utilizada

ReqTrak emplea una estructura de datos N-ary Tree para gestionar el historial de cambios en cada requerimiento. La elección de esta estructura se basó en los siguientes aspectos:

1. **Agrupación por Requerimiento**: Cada nodo raíz representa un requerimiento específico (*IdReq*), y sus nodos hijos representan los cambios de etapa o estado, permitiendo una organización clara de los cambios asociados a cada requerimiento.
2. **Ordenación por Fecha**: Los nodos hijos de cada requerimiento están ordenados cronológicamente, facilitando el acceso al historial de cambios en un orden temporal preciso.
3. **Flexibilidad**: La estructura permite un número variable de nodos hijos, adaptándose a la cantidad variable de cambios que puede tener cada requerimiento sin restricciones estructurales.

## Anexos

### Recursos de Diseño
- **Figma**: [Enlace al diseño en Figma](https://www.figma.com/design/Hjfezlwx82eVEidLmUphag/ReqTrak?node-id=0-1&t=bDDzabADQ3HsCFxb-1)

### Repositorios
- **Frontend**: [GitHub - ReqTrak Frontend](https://github.com/stzdiego/ReqTrak.Frontend)
- **Backend**: [GitHub - ReqTrak Backend](https://github.com/stzdiego/ReqTracking.Backend)

### Despliegue en Producción
- **Frontend (Netlify)**: [Acceso a la aplicación](https://vocal-croissant-39e524.netlify.app)
- **Backend (AWS)**: [Documentación Swagger API](https://reqtrackapi.siesadev.com/swagger/index.html)

---