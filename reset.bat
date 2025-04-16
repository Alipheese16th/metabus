git reset --mixed HEAD~1
if errorlevel 1 (
    echo ---------------Git Reset 실패---------------
    pause
    exit /b 1
) else (
    echo ---------------Git Reset 완료---------------
    pause
)