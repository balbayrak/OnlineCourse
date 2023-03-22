# OnlineCourse

# How to Use
 After opening Command Prompt, go to the directory where docker-compose file is located and run the code below.
```
 CMD>docker-compose up -d

 ```

 There are endpoints after running program with docker compose.

 
| Api | Address |
| --- | --- |
| CourseProgramApi |  http://localhost:3000/swagger/index.html |
| GatewayApi |    http://localhost:5000|

Api call example urls:

| Api | Address |
| --- | --- |
| Get All Course Programs |   http://localhost:5000/courseprogram/all  |
| Get Course Programs ById |   http://localhost:5000/courseprogram/read/{id}  |
| Get All Courses | http://localhost:5000/course/all |
| Get Course ById |   http://localhost:5000/course/read/{id}  |


