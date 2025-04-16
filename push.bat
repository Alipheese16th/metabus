git add .
if errorlevel 1 (
    echo ---------------Git Add 실패---------------
    pause
    exit /b 1
) else (
    echo ---------------Git Add 완료---------------
    pause
)

git commit -m "Git Push %date% %time%"
if errorlevel 1 (
    echo ---------------Git Commit 실패---------------
    pause
    exit /b 1
) else (
    echo ---------------Git Commit 완료---------------
    pause
)

git push -u origin main
if errorlevel 1 (
    echo ---------------Git Push 실패---------------
    pause
    exit /b 1
) else (
    echo ---------------Git Push 완료---------------
    pause
)