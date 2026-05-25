@echo off
REM Build the solution
echo.
echo ========================================
echo Building the solution...
echo ========================================
echo.
dotnet build

REM Check if build was successful
if %ERRORLEVEL% NEQ 0 (
    echo.
    echo Build FAILED!
    exit /b 1
)

echo.
echo ========================================
echo Build SUCCESSFUL!
echo ========================================
echo.
echo Starting the application...
echo ========================================
echo.

REM Run the application
dotnet run --project CompanyEmployees\CompanyEmployees.csproj

pause
