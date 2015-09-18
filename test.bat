@echo off
Packages\xunit.runner.console.2.0.0\tools\xunit.console ^
	ContactUs.Facts\bin\Debug\ContactUs.Facts.dll ^
	-parallel all ^
	-html Result.html ^
	-nologo -quiet
@echo on 