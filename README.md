# samplegcpcoreapp

<h1>Introduction</h1>
<p>This web based application is an ASP.NET Core application that includes a Contact Form page. This Contact Form allows users to submit a message that gets stored in a BigQuery database. The organization can then use this information in various ways. </p>
<p>There are many use cases for a website Contact Form. One example is a feedback form. The organization can allow users to submit feedback about their services or their websites, which can then allow for the organization to make any changes necessary to improve customer satisfaction. An additional example is for future clients. Users that are interested in the organization's services or products can submit a message and a method of contact so that the organization can respond and potentially acquire new clients/customers. </p>

<h1> Architecture Overview </h1>
<p>Below is the architecture overview of the application.</p>

![Training Architecture - GCP Data Analytics and AIML - v 2 0](https://user-images.githubusercontent.com/42750252/220777306-a1402a3d-d67d-4b3a-a78c-24ce0949d530.png)

<h1>Process</h1>
<h2>Visual Studio</h2>
<p>First, the ASP.NET Core application was created in Visual Studio. The sample template was edited to include a Contact Form page that is accessible by the "Contact" link in the navigation bar. On this page, there are 5 elements: the "Contact Form" title, three text input boxes for First Name, Last Name, and Message, and a "Submit" button. All of these items were created by the HTML code in the Contact view (Contact.cshtml). </p>

![image](https://github.com/yena816/samplegcpcoreapp/assets/42750252/5d73775c-3bb7-4275-9757-ccab9d6f086f) 


<p>The Contact model (Contact.cshtml.cs) is where the code behind the items lie. Here, the code for the OnPost method, which is linked to the Submit button in the view, is included. When the Submit button is pressed, the app should save the text from the input into different variables (firstName, lastName, and message). Then, the model sends those values to the view which displays all the values on the screen once the message is submitted. The following images show the filled out form and what is displayed when the submit button is clicked. </p>

![image](https://github.com/yena816/samplegcpcoreapp/assets/42750252/c5909705-252f-4aad-9b41-ddf17cf55be7) 

![image](https://github.com/yena816/samplegcpcoreapp/assets/42750252/a83292c7-b3b3-4248-a2bc-151ab0116962) 


<p>At this point, the page has no interaction with the cloud. That will be the next step outlined in the next section. </p>

<h2>App Engine</h2>
<p>The next step is to publish the app to GCP App Engine. Google Cloud Platform (GCP) App Engine is a Platform-as-a-Service (PaaS) offering provided by Google for building, deploying, and scaling applications. It allows developers to focus on writing code and building applications without worrying about the underlying infrastructure management. App Engine abstracts away many of the complexities of server provisioning, load balancing, and scaling, making it easier to develop and deploy web applications, APIs, and other services. The application code will be uploaded to App Engine, which will then deploy the code and the infrastructure will be maintained by GCP. App Engine is best for creating apps from scratch. If you are migrating an existing app to App Engine, you have to check if App Engine supports the language, OS dependencies, and architecture of your app. </p>
 
<h3>App Engine Best Practices</h3>

<p>To ensure that your apps in App Engine run smoothly, there are a few best practices you can follow:</p>

<h4>Choose the Right Environment </h4> 
<p>App Engine offers two environments: Standard and Flexible. Choose the environment that best fits your application's needs. Standard is more opinionated and auto-scales quickly, while Flexible allows more customization.</p>

<h4>Select the Appropriate Language and Runtime</h4>
<p>Choose the programming language and runtime that aligns with your project requirements. App Engine supports multiple languages and runtimes, including Python, Java, Go, Node.js, and others.</p>

<h4>Use Managed Services</h4>
<p>Leverage managed GCP services like Cloud SQL, Cloud Datastore, and Cloud Storage rather than managing your own database or storage solutions. This simplifies operations and provides scalability.</p>

<h4>Leverage Automatic Scaling</h4>
<p>Configure automatic scaling settings to ensure your application can handle varying levels of traffic. App Engine will automatically scale up or down based on demand.</p>

<h4>Utilize Versioning</h4>
<p>Use versioning to deploy and manage different versions of your application. This allows you to roll back to a previous version if needed and perform A/B testing.</p>

<h4>Implement Traffic Splitting</h4>
<p>When deploying new versions, use traffic splitting to gradually direct a portion of your users to the new version, reducing the risk of issues affecting all users at once.</p>

<h4>Follow Security Best Practices</h4>
<p>Implement security best practices, such as regularly patching your dependencies, using HTTPS for data in transit, and following GCP's Identity and Access Management (IAM) for access control.</p>

<h4>Leverage Monitoring and Logging</h4>
<p>Set up monitoring and logging using Google Cloud Monitoring and Google Cloud Logging to keep track of your application's performance and detect issues early.</p>

<h4>Handle and Report Errors</h4>
<p>Implement error handling and reporting mechanisms to help you identify and resolve issues quickly. Use tools like Stackdriver Error Reporting.</p>

<h4>Manage Resources</h4>
<p>Optimize resource usage by adjusting instance classes, concurrency settings, and memory allocation based on your application's requirements. Use App Engine's built-in tools to analyze performance.</p>

<h4>Optimize Costs</h4>
<p>Keep an eye on your resource usage and costs. App Engine provides tools to help you understand and optimize your spending. Set budgets and alerts for cost control.</p>

<h4>Use a CI/CD Pipeline</h4>
<p>Implement a continuous integration and continuous deployment (CI/CD) pipeline to automate testing and deployment processes. Tools like Cloud Build can be integrated for this purpose.</p>

<h4>Clean Up Versions</h4>
<p>Regularly clean up old and unused versions of your application to reduce storage costs and complexity.</p>

<h4>Maintain Documentation</h4>
<p>Maintain comprehensive documentation for your application, including architecture, deployment procedures, and troubleshooting guides.</p>

<h4>Apply Backup and Disaster Recovery</h4>
<p>Implement backup and disaster recovery plans to ensure data resilience. This is especially important for mission-critical applications.</p>

<h4>Maintain Compliance and Regulations</h4>
<p>Ensure your application complies with relevant regulations and security standards. GCP provides resources and services to assist with this.</p>

<h4>Optimize Performance</h4>
<p>Continuously optimize your application for performance. Use profiling tools and performance testing to identify bottlenecks and improve response times.</p>

<h3>Steps to Publish App</h3>

<p>Publishing the app to App Engine can either be done directly from Visual Studio, or using the Google Cloud CLI. For the Visual Studio method, you would have to install the Google Cloud Tools for Visual Studio extension (you will need this for the BigQuery step anyway). After installing this extension, make sure to restart Visual Studio for it to start working.</p>
<p>This particular app was deployed through the gcloud CLI. In the terminal, first publish the app using the command: </p> 

```
dotnet publish -c Release 
```

<p>Then, navigate to the publish folder: </p>

```
cd bin/Release/netcoreapp3.1/publish
```

<p>Create an app.yaml file inside the publish folder:</p>

```
env: flex
runtime: aspnetcore
```

<p>Note: To create this yaml file, you can use an online yaml tool, download it, and place it in the publish folder.</p>
<p>Finally, deploy the app to App Engine flexible using the following command: </p>

```
gcloud app deploy --version v0
```

<p>Once the app is published, it can be accessed by clicking on the "default" service under the "Services" tab in App Engine on the GCP console. </p> 

![image](https://github.com/yena816/samplegcpcoreapp/assets/42750252/8f90adcd-6337-4090-a2d7-90dcfe1d5f0e) 


<h2>BigQuery</h2>

<p>The next step is to create the BigQuery database and connect it to the app. BigQuery is a fully managed, serverless, and highly scalable cloud data warehouse and analytics platform. It is designed to handle large volumes of data and enable organizations to perform fast and complex queries on that data using a SQL-like query language, making it a powerful tool for data analysis and business intelligence. </p> 

<h3>BigQuery Best Practices</h3>

<h4>Design Schema</h4>
<p>Use a schema that minimizes the need for joins. Denormalize your data where it makes sense to reduce query complexity and improve performance.</p>
Partitioning and Clustering:

Partition your tables by date or another relevant column to speed up query performance by scanning only necessary data. Consider clustering tables based on frequently filtered columns.
Use of Standard SQL:

Write SQL queries using standard SQL syntax, as it's more powerful and flexible than legacy SQL. It's also compatible with other SQL-based tools and databases.
Table and Data Optimization:

Avoid creating very wide tables with too many columns. Only select and store the columns you need.
Remove duplicates from your data to reduce storage costs.
Compress your data where possible to save on storage costs.
Streaming Data:

Use BigQuery Streaming for real-time data ingestion, but be mindful of streaming costs and consider using batch loading for less time-sensitive data.
Query Optimization:

Write efficient queries that only select the columns and rows needed for analysis.
Use the EXPLAIN statement to understand how queries are executed and identify potential optimizations.
Use the ARRAY data type for repeated data when appropriate to simplify queries.
Use of Wildcards:

Be cautious when using wildcard table references (e.g., *) in queries, as they can lead to inefficient query execution. Limit their use when possible.
Optimize Joins:

Minimize the use of joins, especially on large tables. Use denormalization, nested and repeated fields, and nested queries to reduce the need for joins.
Cost Management:

Set up budget alerts to monitor and control your BigQuery costs.
Use cost-effective storage options like long-term storage for historical data.
Experiment with different query options and use the query cost estimator to optimize query costs.
Concurrency Control:

Adjust concurrency settings to match your workload. Over-provisioning can lead to higher costs, while under-provisioning can lead to query delays.
Data Access Control:

Implement proper access controls using Google Cloud Identity and Access Management (IAM) to restrict who can access and modify your data and queries.
Data Lifecycle Management:

Define and implement data retention policies to automatically delete or archive data that is no longer needed.
Error Handling and Monitoring:

Set up error handling and monitoring to track query errors, job failures, and long-running queries. Use Stackdriver for monitoring and alerts.
Documentation and Naming Conventions:

Maintain comprehensive documentation for your datasets, tables, and queries. Follow consistent naming conventions to make it easier to manage and collaborate on projects.
Performance Optimization:

Regularly analyze and optimize your data and queries for performance. Tools like BigQuery's Query Optimization tool can help.
Training and Collaboration:

Ensure your team is trained in BigQuery best practices and encourages collaboration among data engineers, analysts, and data scientists.
Backup and Disaster Recovery:

Implement backup and recovery strategies for critical data to prevent data loss in case of unexpected incidents.

<h3>Steps to Implement BigQuery</h3>

<p>With a few simple clicks, you can create a data source, a dataset within that data source, and a table within that dataset called "contacts".  </p>

 ![image](https://github.com/yena816/samplegcpcoreapp/assets/42750252/ce9a444a-f40d-429c-8a9c-2a91c5019401) 
 
<p>After creating the table, a new SQL query is added to the OnPost method in the Contact model code. Now, when the Submit button is clicked, the query runs and inserts a new item into the table that includes the values of firstName, lastName, and message. Note: The credentials to access the database need to be stored securely in Azure Key Vault. See the next section for steps to set up the Key Vault. </p>
<p>To verify that the data submission worked, the following SQL query can be run in the GCP console BigQuery editor: </p>

```
SELECT * FROM `samplegcpapp-381218.sampleappdata.contacts`;
```

![image](https://github.com/yena816/samplegcpcoreapp/assets/42750252/5dc1ab2d-9ccc-48d7-b90e-7271f94e165c)

<h2>Azure Key Vault</h2>
<p>Azure Key Vault is a service that allows you to store your secrets securely. First, you need to create a key vault by using the Azure Portal or the Azure CLI. For this project, the Portal was used. After creating the key vault, you need to add Role Based Access Control capabilities. Then, assign the Key Vault Secrets Reader role to the App Service app using a managed identity. </p>
