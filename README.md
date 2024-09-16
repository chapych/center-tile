# Center-Tile
## Web site on containers for city centre calculation


Center-Tile is a project designed to display and calculate the center of a city based on a specific set of conditions.
Currently, only a condition based on pavement material is supported.

# Built With

<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
<img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/Entity_Framework-000?style=for-the-badge&logo=.net&logoColor=white&color=blue"/>
<img src="https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white"/>
<img src="https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white"/>
<img src="https://img.shields.io/badge/TypeScript-007ACC?style=for-the-badge&logo=typescript&logoColor=white"/>
<img src="https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white"/>
<img src="https://img.shields.io/badge/MediatR-blue" width = 80/>
<img src="https://img.shields.io/badge/Carter-pink?logoSize=auto" width = 80/>


# Features
- Browsing the map and beeing able to draw on it
- Sending data suggestions to fill the data
- Data validation
- Docker support

# Future plans
- Admin site
- Attaching media
- The result heat map when data is enough

# Getting started
1. Clone the repo
   ```
   git clone https://github.com/chapych/center-tile/tree/main
   ```
2. Set your database password
   ```
   dotnet user-secrets set "DataSuggestionsDbPassword" "YOUR_PASSWORD"
   ```
3. add YOUR_PASSWORD to .\Services\DataSuggesting\DataSuggesting.API\DataSuggesting.env
3. Run Docker Dekstop
4. Run docker compose command
   ```
   docker-compose up
   ```
