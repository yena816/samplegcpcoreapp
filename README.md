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
 
 ![image](https://github.com/yena816/samplegcpcoreapp/assets/42750252/ef3df057-7a9d-40ab-a922-d04b3b381c3b) 

<h3>Best Practices of App Engine</h3>

<p>To ensure that your apps in App Engine run smoothly, there are a few best practices you can follow:</p>

<h4>Choose the Right Environment </h4> 
<p>App Engine offers two environments: Standard and Flexible. Choose the environment that best fits your application's needs. Standard is more opinionated and auto-scales quickly, while Flexible allows more customization.</p>

<h4>Select the Appropriate Language and Runtime</h4>
<p>Choose the programming language and runtime that aligns with your project requirements. App Engine supports multiple languages and runtimes, including Python, Java, Go, Node.js, and others.</p>

<h4>Use Managed Services</h4>
<p>Leverage managed GCP services like Cloud SQL, Cloud Datastore, and Cloud Storage rather than managing your own database or storage solutions. This simplifies operations and provides scalability.</p>

4. **Automatic Scaling:**
   - Configure automatic scaling settings to ensure your application can handle varying levels of traffic. App Engine will automatically scale up or down based on demand.

5. **Versioning:**
   - Use versioning to deploy and manage different versions of your application. This allows you to roll back to a previous version if needed and perform A/B testing.

6. **Traffic Splitting:**
   - When deploying new versions, use traffic splitting to gradually direct a portion of your users to the new version, reducing the risk of issues affecting all users at once.

7. **Security:**
   - Implement security best practices, such as regularly patching your dependencies, using HTTPS for data in transit, and following GCP's Identity and Access Management (IAM) for access control.

8. **Monitoring and Logging:**
   - Set up monitoring and logging using Google Cloud Monitoring and Google Cloud Logging to keep track of your application's performance and detect issues early.

9. **Error Handling and Reporting:**
   - Implement error handling and reporting mechanisms to help you identify and resolve issues quickly. Use tools like Stackdriver Error Reporting.

10. **Resource Management:**
    - Optimize resource usage by adjusting instance classes, concurrency settings, and memory allocation based on your application's requirements. Use App Engine's built-in tools to analyze performance.

11. **Cost Optimization:**
    - Keep an eye on your resource usage and costs. App Engine provides tools to help you understand and optimize your spending. Set budgets and alerts for cost control.

12. **CI/CD Pipeline:**
    - Implement a continuous integration and continuous deployment (CI/CD) pipeline to automate testing and deployment processes. Tools like Cloud Build can be integrated for this purpose.

13. **Version Cleanup:**
    - Regularly clean up old and unused versions of your application to reduce storage costs and complexity.

14. **Documentation:**
    - Maintain comprehensive documentation for your application, including architecture, deployment procedures, and troubleshooting guides.

15. **Backup and Disaster Recovery:**
    - Implement backup and disaster recovery plans to ensure data resilience. This is especially important for mission-critical applications.

16. **Compliance and Regulations:**
    - Ensure your application complies with relevant regulations and security standards. GCP provides resources and services to assist with this.

17. **Performance Optimization:**
    - Continuously optimize your application for performance. Use profiling tools and performance testing to identify bottlenecks and improve response times.

18. **Community and Support:**
    - Join the GCP community and seek support when needed. Google Cloud offers various support plans, including free community support and paid support options.

<p>By following these best practices, you can build, deploy, and maintain robust and cost-effective applications on Google Cloud Platform's App Engine. Keep in mind that specific requirements may vary depending on your application's complexity and use case. Regularly review and update your practices to align with evolving technologies and business needs.</p>

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

<p>The next step is to create the BigQuery database and connect it to the app. BigQuery is a fully managed, serverless, and highly scalable cloud data warehouse and analytics platform. It is designed to handle large volumes of data and enable organizations to perform fast and complex queries on that data using a SQL-like query language, making it a powerful tool for data analysis and business intelligence. With a few simple clicks, you can create a data source, a dataset within that data source, and a table within that dataset called "contacts".  </p>

 ![image](https://github.com/yena816/samplegcpcoreapp/assets/42750252/ce9a444a-f40d-429c-8a9c-2a91c5019401) 
 
<p>After creating the table, a new SQL query is added to the OnPost method in the Contact model code. Now, when the Submit button is clicked, the query runs and inserts a new item into the table that includes the values of firstName, lastName, and message. Note: The credentials to access the database need to be stored securely in Azure Key Vault. See the next section for steps to set up the Key Vault. </p>
<p>To verify that the data submission worked, the following SQL query can be run in the GCP console BigQuery editor: </p>

```
SELECT * FROM `samplegcpapp-381218.sampleappdata.contacts`;
```

![image](https://github.com/yena816/samplegcpcoreapp/assets/42750252/5dc1ab2d-9ccc-48d7-b90e-7271f94e165c)

<h2>Azure Key Vault</h2>
<p>Azure Key Vault is a service that allows you to store your secrets securely. First, you need to create a key vault by using the Azure Portal or the Azure CLI. For this project, the Portal was used. After creating the key vault, you need to add Role Based Access Control capabilities. Then, assign the Key Vault Secrets Reader role to the App Service app using a managed identity. </p>
