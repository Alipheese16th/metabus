@echo off
git pull origin main
if errorlevel 1 (
    echo --------------- Git Pull FAIL ---------------
    pause
    exit /b 1
) else (
    echo --------------- Git Pull SUCCES ---------------
    pause
)