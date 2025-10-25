Projeto: Ordem de Serviço Automotivo (ASP.NET Core MVC)

Nomes e RMs:
Fabio H S Eduardo - RM560416
Gabriel WU Castro - RM560410
Renato Kenji Sugaki - RM559810

Descrição:
Aplicação simples para controle de ordens de serviço sem uso de banco de dados (armazenamento em memória). 
Implementa CRUD via browser (Create, Read, Update, Delete)
e pesquisa por cliente/veículo/placa.

Características implementadas:
- ASP.NET Core MVC (.NET 6)
- Modelo: `OrdemServico` com vários tipos de dados (DateTime, Enum, string, decimal)
- Repositório in-memory: `InMemoryOrdemServicoRepository` registrado como singleton
- Controller: `OrdemServicosController` com Index (search), Details, Create, Edit, Delete (com confirmação)
- TagHelper personalizado: `StatusBadgeTagHelper` para exibir badges de status
- Views Razor usando Bootstrap (via CDN)
- Confirmação de remoção em `Delete` view

Como abrir e rodar (Visual Studio 2022):
1. Abra o Visual Studio 2022.
2. Abra a pasta `C:\Users\grana\Desktop\OrdemServicoApp` (File -> Open -> Folder).
3. Se preferir, execute `dotnet build` e `dotnet run` na pasta do projeto via PowerShell.

Exemplo via PowerShell (executar na pasta que contém a pasta `OrdemServicoApp` ou diretamente dentro dela):
```powershell
cd C:\Users\grana\Desktop\OrdemServicoApp
dotnet build .\OrdemServicoApp.csproj
dotnet run --project .\OrdemServicoApp.csproj
```

Empacotamento para entrega:
- Para garantir que `Debug` e `Release` estejam presentes, execute antes:
```powershell
dotnet build .\OrdemServicoApp.csproj -c Debug
dotnet build .\OrdemServicoApp.csproj -c Release
```
- Em seguida compacte a pasta inteira (inclua `bin` e `obj`) usando o Explorador do Windows ou PowerShell:
```powershell
Compress-Archive -Path .\ -DestinationPath ..\OrdemServicoApp_Submissao.zip -Force
```

Estrutura de arquivos:
- /OrdemServicoApp/OrdemServicoApp.csproj - projeto
- /OrdemServicoApp/Program.cs - configuração mínima e DI
- /OrdemServicoApp/Controllers/OrdemServicosController.cs
- /OrdemServicoApp/Models/OrdemServico.cs
- /OrdemServicoApp/Models/StatusOrdem.cs
- /OrdemServicoApp/Data/ - repositório e interface
- /OrdemServicoApp/TagHelpers/ - StatusBadgeTagHelper
- /OrdemServicoApp/Views/ - Views Razor e Shared Layout
- /OrdemServicoApp/wwwroot/ - assets estáticos
