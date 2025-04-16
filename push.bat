@echo off
git add .
if errorlevel 1 (
    echo --------------- Git Add FAIL ---------------
    pause
    exit /b 1
) else (
    echo --------------- Git Add SUCCES ---------------
    pause
)

git commit -m "Git Push %date% %time%"
if errorlevel 1 (
    echo --------------- Git Commit FAIL ---------------
    pause
    exit /b 1
) else (
    echo --------------- Git Commit SUCCES ---------------
    pause
)

git push -u origin main
if errorlevel 1 (
    echo --------------- Git Push FAIL ---------------
    pause
    exit /b 1
) else (
    echo --------------- Git Push SUCCES ---------------
    pause
)