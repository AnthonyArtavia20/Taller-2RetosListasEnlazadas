## Retos Listas Enlazadas -DSA

### ¿Cómo usar?

##### Se  descargan los archivos aquí disponibles y posterior se abre la carpeta en VisualStudioCode, luego desde la terminal, ya sea desde powershell, cmd o bien desde la misma terminal powershell de visual ejecutar la siguiente serie de comandos:

- ###Si se desea ejecutar las pruebas unitarias:
##### 1) Se deberá realizar la navegación a la carpeta de "ProgramTest" para poder ejecutar el comando "Dotnet Test"

`PS c:\users\Usuario\CarpetaSolucion\ProgramTest> dotnet Test`

Esto  ejecuta el archivo que contiene las pruebas unitarias y solo puede ser ejecutado estando dentro de la capeta del proyecto de Tests.

- ###Si se desea ejecutar el archivo de Consola(Program):
##### 1) Similarmente se deberá navegar por los archivos, pero esta vez a la carpeta "Program", dicha carpeta contiene el ejecutable del poryecto tipo Consola, creado para hacer preubas de implementación.
`PS c:\users\Usuario\CarpetaSolucion\Program> dotnet run`


## ¿Cómo funciona este programa?
##### Este programa está hecho en el lenguaje de programación c# en .NET8 utilizando MSTest para crear pruebas unitarias.

El objetivo principal de este programa radica en mejorar las habilidades de resolución de problemas con estructuras de datos tales como Listas enlazadas, además de la implementación de algunos métodos útilies para la misma resolución de los problemas citados en la descripción de este proyecto.

CarpetaPrincipal

│

├── Program

│   └── program.cs

│

├── ProgramTest

│   └── UnitTest1.cs

│

└── miLibreriaDeClases

│  ├── DoubleNodo.cs

│  ├── IList.cs

│  ├── ListaDoble.cs

│		├── SortDirection.cs

│  └── miLibreriaDeClases.cs

- `Program`: Contiene el programa ejecutable principal.
- `ProgramTest`: Contiene las pruebas unitarias del proyecto.
- `miLibreriaDeClases`: Contiene las clases e interfaces que implementan las listas enlazadas y sus operaciones.
