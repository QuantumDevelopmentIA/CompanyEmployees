Write-Host "`n========================================" -ForegroundColor Cyan
Write-Host "Building the solution..." -ForegroundColor Cyan
Write-Host "========================================`n" -ForegroundColor Cyan

dotnet build

if ($LASTEXITCODE -ne 0) {
    Write-Host "`nBuild FAILED!" -ForegroundColor Red
    exit 1
}

Write-Host "`n========================================" -ForegroundColor Green
Write-Host "Build SUCCESSFUL!" -ForegroundColor Green
Write-Host "========================================`n" -ForegroundColor Green

Write-Host "Starting the application..." -ForegroundColor Cyan
Write-Host "========================================`n" -ForegroundColor Cyan

dotnet run --project CompanyEmployees\CompanyEmployees.csproj

Write-Host "`nPress any key to exit..." -ForegroundColor Yellow
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
