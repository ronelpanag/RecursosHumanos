# RecursosHumanos
Proyecto final de Programacion 3, enfocado a un sistema de RRHH, utilizando ASP:NET CORE


MÓDULO DE MANTENIMIENTOS
Este módulo consiste en crear formularios que alimentes sendas tablas.
Empleados.
(Id, Código Empleado, Nombre, Apellido, Teléfono, Departamento, Cargo, Fecha ingreso,
Salario, Estatus (Activo/Inactivo))

Departamentos
(Id, Código Departamento, Nombre)

Cargos
(Id, Cargo)

MÓDULO DE PROCESOS

En este módulo se van a configurar algunos procesos o acciones. Vale decir que estos procesos
o acciones son registrados en respectivas tablas

Cálculo de nómina

Calcular el monto total de la nómina, sumando el salario de los empleados activos y
presentando el total, para que sea visto y validado por la persona encargada.
Almacenar en una tabla nominas la siguiente información:
(Id, Año, Mes, Monto Total)

Salida de empleados
Inactivar a un determinado empleado, y almacenar la información en una tabla salidas
(Empleado, Tipo salida (Renuncia, Despido, Desahucio), Motivo, Fecha Salida)

Vacaciones:
Registrar las vacaciones que tome un empleado.
(Empleado, Desde, Hasta, Correspondiente a: (año), Comentarios) 

Permisos
Registrar los permisos que tome un empleado.
(Empleado, Desde, Hasta, Comentarios)

Licencias
Registrar las licencias que tome un empleado.
(Empleado, Desde, Hasta, Motivo, Comentarios)


MÓDULO DE INFORMES
En este módulo se elegirá el tipo de informe a generar para presentar listas de datos en vistas

Nóminas:
Con este informe se busca visualizar todas las nóminas de un año especificado, o bien
visualizar la correspondiente a un mes en específico

Empleados Activos
Aquí buscamos visualizar a los empleados activos de la empresa, con opción de verlos todos, o
de filtrar por nombre o por departamento. (Incluir ambos filtros)

Empleados inactivos
Visualizar todos los empleados que han salido de la empresa

Departamentos
Listar los departamentos creados

Cargos
Listar los cargos creados

Entradas de empleados por mes
Visualizar las entradas (empleados creados, ingresados) en un mes determinado por el usuario

Salida de empleados por mes
Visualizar las entradas (empleados creados, ingresados) en un mes determinado por el usuario

Permisos
Visualizar los permisos tomados por determinado empleado (a elegir por parte del usuario) 
