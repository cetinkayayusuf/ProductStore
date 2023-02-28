# ProductStore

About Project:
- .Net 6
- MySql
- Basic Onion Architecture
- CQRS Pattern (MediatR package)
- InMemoryCaching (Scrutor package)
    - Used To Cache GetAllCategories
- Notification
    - When a user completes a product collection => A notification saved to Database
- Authentication => JWT
-Soap Entegrasyonu
- Used to get country flag url for user countries
----

How to run Project ?
- Database =>
  - If you use Docker => in mysql folder,
    there is a docker-compose file, 
  - Or else, you set your own mysql db with these settings
    - port=3306
    - database=productstore 
    - user=root
    - password=superadmin

- WebApi =>
  - run 'dotnet build' in src folder
  - and run 'dotnet watch' in src/ProductStore.WebApi

- It is recommended to use postman or smilar tools,
  - due to jwt token configuration error in swagger ui, calls made from swagger ui wont work
  - request models could be seen in swagger ui

Note: Admin user credential could be seen from ProductStore/src/ProductStore.WebAPI/appsettings.json

----

What is not done or partially done
- Authorization (Not works)
- Filters and Search options
- User access restriction to tables or resources
- Unit Test
- Akis Testi
    
