# NbaApi

Short description/explanation of project structure:

Used patterns: generic repository, unit of work, dependecy injection
Database: PosgreSQL(with PgAdmin)
Frameworks:.Net(Core), ORM: Entity Framework

Project is divided in 4 units/layers/projects (all 4 are in the same repo here but should be in separate repos as explained further) -
- NbaApi
- Service
- Model
- Data access layer

This structure would be used for a larger scale project.

1. NbaApi 
- entry point for web app (and other client apps that want to use existing controllers)
- contains controllers with logic for sending/receiving http(s) requests

2. Model
- in separate project to achieve cleaner architecture, less code in one place
- models used in project are separated to DAL models (EF models) and DTO's
- entites fetched from database are mapped to DTO's
- data from incoming requests is mapped to DTO
- idea is to extend DTO models with partial classes that would be created in controllers - in these partial classes would be properties needed for incoming/outgoing requests
- I have planned to do mapping "by hand", no autoMapper or other libraries
- this of course comes with it's downsides like a lot of classes/code, it's more time consuming but far more versatile and much less error prone. This is the approach I would personally use for a larger scale project, while autoMapper would be ok for smaller projects or better to say for simpler mappings 

3. Service
- contains logic needed between controllers and repository classes, object mappers
- separate project, open for direct use of client apps that have their own controllers
- BaseService class is left in project but it should have been deleted

4. DAL
- holds dbContext, migrations and repository classes
- UnitOfWork class has instances of all repository classes
- GenericRepository class has generic database operations defined
- BaseRepository class inherits GenericRepository and implements additional logic needed for database operations
- This is done to achieve the following: every new repository class inherits from BaseRepositoryImpl and has basic CRUD operations implemented by default   
