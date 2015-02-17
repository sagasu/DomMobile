@ECHO OFF

SET InputFile=%1

SET OutputFile=%2

@ECHO *********************************************

@ECHO Google Closure Compiler with jQuery Support 

@ECHO Compiling : '%InputFile%'

@ECHO *********************************************

CALL "C:\worek\java\jdk1.6.0_30\bin\java.exe" -jar "C:\Projekty\domiporta-rw\trunk\Minification\closureCompiler\compiler.jar" --js %InputFile% --js_output_file %OutputFile% --compilation_level ADVANCED_OPTIMIZATIONS --summary_detail_level 3 --warning_level QUIET --externs "C:\Projekty\domiporta-rw\trunk\Web\Scripts\jquery-1.6.4.js"

@ECHO *********************************************

@ECHO Build Complete

@ECHO *********************************************