@ECHO OFF

SET InputFile=%1

SET OutputFile=%2

@ECHO *********************************************

@ECHO YUI Compressor For CSS 

@ECHO Compiling : '%InputFile%'

@ECHO *********************************************

CALL "C:\worek\java\jdk1.6.0_30\bin\java.exe" -jar "C:\Projekty\domiporta-rw\trunk\Minification\yuicompressor-2.4.7\build\yuicompressor-2.4.7.jar" --type css -v -o %OutputFile% %InputFile%

@ECHO *********************************************

@ECHO Build Complete

@ECHO *********************************************