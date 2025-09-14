README (ES)
TextManager

TextManager es una aplicación de consola en C# (.NET) para gestionar y transformar archivos de texto locales. Trabaja dentro de la carpeta de usuario Documentos/TextManager y ofrece lectura, escritura, modificación, codificación/decodificación Base64 y un conjunto de utilidades de texto (buscar, reemplazar, contar palabras/letras/líneas, mayúsculas/minúsculas, invertir, quitar espacios extra, cifrado César, dividir, unir, etc.).

Requisitos

.NET 8 SDK (o superior)

Windows, Linux o macOS

Compilación y ejecución
cd TextManager/TextManager
dotnet build
dotnet run

Carpeta de datos

Los archivos se guardan en:

Documentos/TextManager


(Se crea automáticamente si no existe).

Uso
Menú principal

Al iniciar verás algo como:

BIENVENIDO AL GESTOR DE TEXTOS.
OPCIONES:

1 - Escribir un nuevo texto.
2 - Tratar un texto ya existente.
ESC - Salir.


1 - Escribir un nuevo texto. Crea un archivo nuevo y entra en modo edición.

Termina con END en una línea para finalizar.

Escribe CANCEL para cancelar.

2 - Tratar un texto ya existente. Lista archivos en Documentos/TextManager y permite seleccionar por número o indicando el nombre del archivo.

Acciones sobre un archivo existente

Tras elegir un archivo:

1 - Leer
2 - Sobrescribir
3 - Modificar (añadir al final)
4 - Codificar (Base64)
5 - Decodificar (Base64)
6 - Otras acciones
7 - Borrar.
0 - Volver a la lista de archivos


1 Leer: muestra el contenido.

2 Sobrescribir: reemplaza todo el contenido. Termina con END o cancela con CANCEL.

3 Modificar (añadir al final): añade texto al final. END guarda; CANCEL cancela.

4 / 5 Base64: codifica o decodifica el archivo.

6 Otras acciones: abre un submenú (ver abajo).

7 Borrar: solicita confirmación S/N.

0 Volver: regresa a la lista de archivos.

Otras acciones (submenú)
1 - Buscar palabra.
2 - Contar número de palabras.
3 - Contar número de letras.
4 - Convertir a mayúsculas.
5 - Convertir a minúsculas.
6 - Contar líneas.
7 - Reemplazar palabra.
8 - Invertir palabras.
9 - Invertir texto.
10 - Eliminar espacios extra.
11 - Guardar copia en otro archivo.
12 - Encriptar con algoritmo César.
13 - Dividir archivo en fragmentos.
14 - Unir otro archivo al final.
15 - Contar frecuencia de cada letra/palabra.
0 - Volver al menú anterior.


Notas de comportamiento comunes

Al aplicar transformaciones se muestra una vista previa del TEXTO MODIFICADO y se pregunta:

¿Desea mantener los cambios? (S/N/CANCEL)


S: guarda en el mismo archivo.

N: descarta cambios.

CANCEL: cancela la operación.

END finaliza la entrada de texto en modos de edición.

CANCEL cancela la operación en curso.

En varios prompts, ESC vuelve atrás (por ejemplo, al crear un archivo desde “Escribir un nuevo texto”).

Estructura del proyecto (resumen)
TextManager/
  TextManager.sln
  TextManager/
    Program.cs                 # Punto de entrada
    Storage.cs                 # Gestor de ruta Documentos/TextManager
    fileManager.cs             # Flujo principal y menús activos
    Functions/
      ReadFile.cs              # Leer
      WriteFile.cs             # Crear nuevo (modo edición)
      OverwriteFile.cs         # Sobrescribir
      AppenderFile.cs          # Añadir al final
      DeleteFile.cs            # Borrar (S/N)
      EncodeFile.cs            # Base64 (codificar)
      DecodeFile.cs            # Base64 (decodificar)
      FileSearcher.cs          # Buscar palabra
      ReplaceWord.cs           # Reemplazar palabra
      CountWords.cs            # Contar palabras
      CountLetters.cs          # Contar letras (totales)
      CountLines.cs            # Contar líneas
      ToUpperCase.cs           # MAYÚSCULAS
      ToLowerCase.cs           # minúsculas
      TextInverter.cs          # Invertir texto
      WordsInverter.cs         # Invertir palabras
      SpacesRemover.cs         # Quitar espacios extra
      SaveCopy.cs              # Guardar copia en otro archivo
      CaesarCipher.cs          # Cifrado César (ASCII imprimible)
      SplitText.cs             # Dividir en fragmentos
      JoinText.cs              # Unir/merging
      CountLetter.cs           # Frecuencia de una letra concreta
      Other.cs                 # Submenú “Otras acciones”
      SaveHelper.cs            # Confirmación S/N/CANCEL
      PickFile.cs              # Selector de archivo
      TextCreator.cs           # Alta con nombre + edición


Importante: El código de referencia ejecuta la clase fileManager (minúscula) desde Program.cs.

Buenas prácticas para el repo

Añade un .gitignore para .NET:

bin/
obj/
.vs/
*.user
*.suo

Licencia

Elige una licencia antes de publicar (por ejemplo, MIT).

README (EN)
TextManager

TextManager is a C# (.NET) console app for local plain-text file management and transformations. It operates inside Documents/TextManager and supports reading, writing, appending, Base64 encode/decode, and a set of text utilities (search/replace, word/letter/line counts, upper/lower case, reverse text/words, remove extra spaces, Caesar cipher, split, join, etc.).

Console language: all prompts and menu options are shown in Spanish. In this README we keep them verbatim and add an English explanation.

Requirements

.NET 8 SDK (or newer)

Windows, Linux or macOS

Build & Run
cd TextManager/TextManager
dotnet build
dotnet run

Data folder

Files are stored at:

Documents/TextManager


(Created automatically if missing.)

Usage
Main menu (Spanish prompts kept verbatim)
"BIENVENIDO AL GESTOR DE TEXTOS."
"OPCIONES:"

"1 - Escribir un nuevo texto."      → Create a new file and enter edit mode.
"2 - Tratar un texto ya existente." → Work with an existing file (list & pick).
"ESC - Salir."                      → Exit the application.


"1 - Escribir un nuevo texto."
Edit mode: finish with END on a new line, or CANCEL to abort.

"2 - Tratar un texto ya existente."
Lists files under Documents/TextManager. You can select by index or by typing the file name.

Actions on a selected file
"1 - Leer"                        → Read (display content).
"2 - Sobrescribir"                → Overwrite entire content (use 'END' / 'CANCEL').
"3 - Modificar (añadir al final)" → Append to the file (use 'END' / 'CANCEL').
"4 - Codificar (Base64)"          → Base64-encode the file.
"5 - Decodificar (Base64)"        → Base64-decode the file.
"6 - Otras acciones"              → Open the utilities submenu.
"7 - Borrar."                     → Delete (asks for confirmation S/N).
"0 - Volver a la lista de archivos" → Back to file list.

“Otras acciones” submenu (utilities)
"1 - Buscar palabra."                               → Search a term in text.
"2 - Contar número de palabras."                    → Count words.
"3 - Contar número de letras."                      → Count letters (total).
"4 - Convertir a mayúsculas."                       → Uppercase.
"5 - Convertir a minúsculas."                       → Lowercase.
"6 - Contar líneas."                                → Count lines.
"7 - Reemplazar palabra."                           → Replace word.
"8 - Invertir palabras."                            → Reverse word order.
"9 - Invertir texto."                               → Reverse the whole text.
"10 - Eliminar espacios extra."                     → Trim/reduce extra spaces.
"11 - Guardar copia en otro archivo."               → Save a copy to another file.
"12 - Encriptar con algoritmo César."               → Apply Caesar cipher.
"13 - Dividir archivo en fragmentos."               → Split into N parts.
"14 - Unir otro archivo al final."                  → Merge another file at end.
"15 - Contar frecuencia de cada letra/palabra."     → Letter/word frequency count.
"0 - Volver al menú anterior."                      → Back to previous menu.

Common confirmations & special inputs

After transformations, a preview is shown and the app asks:

"¿Desea mantener los cambios? (S/N/CANCEL)"


S = save, N = discard, CANCEL = abort operation.

END ends multi-line input in edit/append/overwrite modes.

CANCEL aborts the current operation.

Some prompts allow ESC to go back/exit (e.g., naming a new file).

Project layout (summary)
TextManager/
  TextManager.sln
  TextManager/
    Program.cs                 # Entry point
    Storage.cs                 # Documents/TextManager path management
    fileManager.cs             # Active flow & menus used by Program.cs
    Functions/
      ReadFile.cs              # "Leer"
      WriteFile.cs             # "Escribir un nuevo texto." (edit mode)
      OverwriteFile.cs         # "Sobrescribir"
      AppenderFile.cs          # "Modificar (añadir al final)"
      DeleteFile.cs            # "Borrar" (S/N)
      EncodeFile.cs            # Base64 encode
      DecodeFile.cs            # Base64 decode
      FileSearcher.cs          # "Buscar palabra"
      ReplaceWord.cs           # "Reemplazar palabra"
      CountWords.cs            # "Contar número de palabras"
      CountLetters.cs          # "Contar número de letras"
      CountLines.cs            # "Contar líneas"
      ToUpperCase.cs           # "Convertir a mayúsculas"
      ToLowerCase.cs           # "Convertir a minúsculas"
      TextInverter.cs          # "Invertir texto"
      WordsInverter.cs         # "Invertir palabras"
      SpacesRemover.cs         # "Eliminar espacios extra"
      SaveCopy.cs              # "Guardar copia en otro archivo"
      CaesarCipher.cs          # "Encriptar con algoritmo César" (printable ASCII)
      SplitText.cs             # "Dividir archivo en fragmentos"
      JoinText.cs              # "Unir otro archivo al final"
      CountLetter.cs           # Letter frequency for a specific character
      Other.cs                 # "Otras acciones" submenu
      SaveHelper.cs            # S/N/CANCEL confirmation helper
      PickFile.cs              # File selector
      TextCreator.cs           # New file naming + edit


Note: The app uses fileManager (lowercase) as the main coordinator, invoked from Program.cs.

Repo hygiene

Add a .NET .gitignore:

bin/
obj/
.vs/
*.user
*.suo

License

Pick a license before publishing (e.g., MIT).
