@REM REMOVE /B if you want to run  api in different console window 
start  /B cmd.exe /C "cd E:\E-Krushi-Project\Dotnet\NewAPI\UserRolesManagement & title UserRolesManagement & dotnet run"
start  /B cmd.exe /C "cd E:\E-Krushi-Project\Dotnet\NewAPI\Catalog & title Catalog & dotnet run"


@REM commomservices     
start  /B cmd.exe /C "cd E:\CommonServices\API\Authentication & title Authentication & dotnet run"
start  /B cmd.exe /C "cd E:\CommonServices\API\UsersManagement & title UsersManagement & dotnet run"
@REM start  /B cmd.exe /C "cd E:\CommonServices\API\Banking & title Banking & dotnet run"
start  /B cmd.exe /C "cd E:\CommonServices\API\Corporate & title Corporate & dotnet run"
@REM start  /B cmd.exe /C "cd E:\CommonServices\API\PaymentGateway & title PaymentGateway & dotnet run"



@REM start  /B cmd.exe /C "cd AdminAPI & title AdminAPI & dotnet run"
@REM start  /B cmd.exe /C "cd MerchantsAPI & title MerchantsAPI & dotnet run"
@REM start  /B cmd.exe /C "cd FarmersAPI & title FarmersAPI & dotnet run"