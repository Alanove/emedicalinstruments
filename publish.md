# Publish e-medicalcyprus.com as a self-contained Ubuntu app (linux-x64)

From the repo root, on a machine with the .NET 10 SDK:

dotnet publish "e-medicalcyprus.com\e-medicalcyprus.com.csproj" -c Release -r linux-x64 --self-contained true --source https://api.nuget.org/v3/index.json

--source limits this restore to nuget.org. Without it, NuGet also queries the user-level
"SABIS Nuget" feed (https://nuget.sabis.net/nuget). When that host does not resolve,
restore fails with NU1301 even though the Linux runtime packs are on nuget.org.

Output folder:

e-medicalcyprus.com\bin\Release\net10.0\linux-x64\publish\

Copy that whole folder to Ubuntu. The app binary is e-medicalcyprus.com (no separate dotnet host). On the server, once, give the www user ownership and execute:

sudo chown www:www /www/wwwroot/e-medicalcyprus.com/e-medicalcyprus.com
sudo chmod u+x /www/wwwroot/e-medicalcyprus.com/e-medicalcyprus.com

linux-x64 is for normal 64-bit Ubuntu (amd64). Use -r linux-arm64 only if the server is ARM.

This matches Properties/PublishProfiles/FolderProfile.pubxml (net10.0, linux-x64, SelfContained true).
