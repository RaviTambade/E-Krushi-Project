# E-Krushi Seva

**Document**: System Requirement Specification Document

**Title**: E-KRUSHI SEVA

**Team**: Customer, Business Analyst, Quality Assurance Team, System Analyst

**Objective**:
- This application is made for farmers.
- With the help of this application, farmers find solutions to plant diseases. Also, farmers can purchase various products as per their requirements.

**Scope**:
- The ordering process will be made simpler and more effective for farmers.
- The farmers will be able to examine their order history and may cancel their order. This service will only be accessible in India.

## Overview

- Anyone can use the portal and browse the available products, but in order to make a purchase or place an order, a user needs to log in using their unique email and password. By visiting the registration page, unregistered members can do so. Roles can only be switched by the admin. The default role is "User" when a user registers with the website.
- This proposed system can be used by any naïve users and does not require any educational level, experience, or technical expertise in the computer field. However, it will be of good use if the user has good knowledge of how to operate a computer.

## Functional Requirement

This section provides a requirement overview of the system. Various functional modules that can be implemented by the system will be:

- This system will be accessible for the owner, their employees, registered customers, suppliers, agri-doctors.
- The owner and their employees have all authority to use this application's functionality like registering customers, agri-doctors, and suppliers.
- The users will be accessible for viewing their personal data.

### Admin
- Database management: control the database and keep track of all records of farmers and employee details.
- View all details: view the details of all employees and control the whole system.

### Employee
- Only registered employees can insert, update, and delete products.
- Only employees can register agri-doctors.
- Only employees can register shippers.
- Only employees can register suppliers.
- The employee can manage the registrations of the customers.

### Farmer
- **Registration**: New users can sign up by creating an email ID and password. Registered customers will be able to get help from agri-doctors for crop, soil, and weather-related problems.
- **Login**: Only registered customers can log into the system. Farmers must have a valid login email ID and password to enter the site.
- **View and edit Own Details**: Can view/edit their personal details, payment details, and details about services provided.
- **Choosing and comparing products**: Can view all available products, compare them, and make a choice for purchasing products. Farmers can browse catalogs and choose products. The products chosen can go in the shopping cart. The farmer will be able to add or remove products from the shopping cart. Shopping cart contents will show up as an order when you go through the checkout procedure.
- **Purchasing**: Can purchase any product through a valid account. Online and cash payment is also available for farmers.
- **Giving Feedback to Customer Care**: Can give feedback to the 24X7 Care Service.
- **Logout**: Farmer must log out of the site after purchasing products.

### Visitors
- **Visiting the Site**: Can only visit the site without registration.
- **Register**

### Agri-doctors
- **Farmer Problems and Solution**: Agri doctors can check the problems of the farmers. Agri-doctors help the farmers to solve their questions related to farming.
- **Advice**: They also give proper advice for precision farming to the farmers.
- With the help of our software, farmers can ask their queries to the agri doctors.

### Customer Care
- **Getting Feedback from the Customers**: Responsible for receiving complaints, queries, and feedback from the customers.
- **Providing Solutions to Customers**: Provide feasible solutions to the customers on their complaints and queries.

## Non-functional Requirement

### Performance

- The server must be able to support an unlimited number of devices, i.e., it must place no restrictions on the number of gadgets that can be used simultaneously.
- A limitless amount of active client payments must be supported by the server, and payments must never be lost.

### Security

- Registered farmers will be allowed to place an order.
- Sensitive data will always be transmitted with encryption. The system will internally maintain a secure communication channel between servers (web servers, application servers, database servers).

### Reliability

- The system should be scalable, with the ability to accommodate a large number of users at once.
- The site's response time should be as quick as feasible, and it should be able to load balance the server.

### Availability

- This application is available for 24 hrs anywhere, anytime.

### Maintainability

- A Commercial database software will be used to maintain System data Persistence.
- A readymade Web Server will be installed to host online shopping portal (Web Site) to management server capabilities.
- IT operations team will easily monitor and configure the system using Administrative tools provided by Servers.
- Separate environments will be maintained for the system for isolation in production, testing, and development.

### Portability

- PDA: Portable Device Application
- The system will provide a portable User Interface (HTML, CSS, JS) through which users will be able to access the online E-Krushi portal.
- The system can be deployed to a single server, multi-server, to any OS, Cloud (Azure or AWS or GCP).

### Accessibility

- After authentication, only logged-in users will be able to place an order.
- Through a personalized dashboard, the BOD team will be able to monitor daily, weekly, monthly, and annual business growth.

### Efficiency

- The system will be able to manage all transactions with isolation.

### Safety

- The certified delivery partner should not damage the farm products or tamper with the package.

### Scalability

- Online Krushi portal will be secure from malicious attacks.
- Online Krushi portal functionalities are protected from the outside with proper configuration.
- Online Krushi portal will always be kept updated with the latest antivirus software.
- Business data will be backed up periodically to ensure the safety of data using an incremental backup strategy.
- Role-based security will be applied for Application data and operations accessibility.

## Benefits

- The farmers save time because they are not going to the shop.
- The farmers can order products at the proper time.
- The farmer can order products anytime, anywhere.
