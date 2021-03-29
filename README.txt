FOR succesful run set connection string or you can use Lottery-demo connection string name for using.
LotteryDemoBackend\LotteryDemoBackend\appsettings.Development.json

MIGRATION will be run automaticly at first run. As well check if db is connect.

if you want you can run migration to db manually but first you need set connection string in
LotteryDemoBackend\LotteryDemo.Database\appsettings.json

THEN run in same project run dotnet ef database update

You can run app in docker compose
docker compose up


or start by using batchfile start.bat