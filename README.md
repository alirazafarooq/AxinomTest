# AxinomTest
# Running the Project 

Since these are two ASP .NET 3.1 Web app core projects so we need a proper setting for the deployment of these applications. But for the sake of ease, I provide you with a simple mechanism to run the project and follow the given steps. 

 

1. Open this solution files in two different visual studio instances. 

1. First run the Axinom solution in one instance and run it using IIS Express. 

2. Second run the receiver solution in another instance of visual studio. 

3. In AppSettings.Json file in this solution there will be a connectionstring for sqlserver. 

3. Change the Data Source and Initial Catalog according to your server configurations. 

4. Make sure both projects have been started and the first page that will open in the browser will be the Swagger UI Page for Axinom projects and receiver will show basic UI with all the extracted zip file information received from Sender project in Axinom solution. 

5. Use can use Swagger UI to send the zip file or files to test the file upload API or you can also you can also postman for the same purpose. 

6. Upon zip file upload it will automatically send the zip file extract content to receiver side using the basic auth (username: password = test: test). 

# References 

# Git Repository: 

This repository is public. You can further communicate with me via email if any additional information is required. Thanks. 

Email: ali.raza.farooq@gmail.com 
