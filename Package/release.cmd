"..\..\oqtane.framework\oqtane.package\nuget.exe" pack Tres.Smss.Module.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
