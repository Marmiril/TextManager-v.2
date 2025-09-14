# TextManager

TextManager es una aplicación de consola en C# (.NET) que funciona como un gestor de archivos sencillo.  
Permite realizar operaciones básicas sobre archivos de texto y además incluye funciones de codificación y decodificación en Base64.

## Funcionalidades

1. Leer archivo → Muestra en consola el contenido de un archivo existente.  
2. Escribir archivo nuevo → Crea un archivo con el contenido que introduzca el usuario.  
3. Sobrescribir archivo → Sustituye completamente el contenido de un archivo existente.  
4. Modificar (apéndice) → Añade texto al final de un archivo existente sin borrar lo previo.  
5. Borrar archivo → Elimina un archivo tras confirmación del usuario.  
6. Codificar archivo → Convierte el contenido de un archivo a Base64.  
7. Decodificar archivo → Recupera el contenido original de un archivo codificado en Base64.  

## Ejecución

1. Clonar este repositorio:  
   ```bash
   git clone https://github.com/tuusuario/TextManager.git
Abrir la solución en Visual Studio o VS Code.

Compilar el proyecto (Ctrl+Shift+B en Visual Studio).

Ejecutar desde la consola:

bash
Copiar código
dotnet run
Estructura
bash
Copiar código
TextManager/
 ├── Functions/           # Funciones independientes
 │    ├── FileWriter.cs
 │    ├── FileReader.cs
 │    ├── FileOverwriter.cs
 │    ├── FileAppender.cs
 │    ├── FileDeleter.cs
 │    ├── FileEncoder.cs
 │    └── FileDecoder.cs
 ├── FileManag.cs         # Menú principal
 ├── Storage.cs           # Gestión de la carpeta de datos
 ├── Program.cs           # Punto de entrada
 ├── TextManager.csproj
 └── README.md
Notas
Los archivos se guardan en la carpeta:

Copiar código
Documentos/TextManager
Para terminar de escribir contenido, escriba END en una nueva línea.

Para cancelar la operación, escriba CANCEL.