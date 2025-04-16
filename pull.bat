git pull origin main
if errorlevel 1 (
    echo ---------------Git Pull 실패---------------
    pause
    exit /b 1
) else (
    echo ---------------Git Pull 완료---------------
    pause
)