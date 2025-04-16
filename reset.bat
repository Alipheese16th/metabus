@echo off
git reset --mixed HEAD~1
if errorlevel 1 (
    echo --------------- Git Reset FAIL ---------------
    pause
    exit /b 1
) else (
    echo --------------- Git Reset SUCCES ---------------
    pause
)