Login-Register with AES Encryption C#
---------------------------------------

This project is a user management system with login and registration with AES encryption. This application is designed using a service-oriented architecture (Web) and a (Web API) in.NET Framework 4.8 with the.NET coding standard.

Documentation:
----------------

   Login -- Navigate to home page after successful login
   ------------------------------------------------------

a. User credentials to be validated b. Display appropriate error message if used tries to login with invalid credentials

SCREENSHOT LOGIN:
![login](https://github.com/user-attachments/assets/8e020467-9993-4113-adfc-d81f55eebf0a)


  Register-- Navigate to user registration page
    ---------------------------------------------

User registration page -- Create a registration page
-----------------------------------------------------------

    The registration page to be designed, fields as follows

a. Name b. Email ID c. Gender d. Password e. Re-enter password

    User registration page -- Validations
    -------------------------------------

a. Name should have only alphabets (Min length – 3 and Max length 75) b. Should allow only valid email format. c. Password length should be 8 to 12 character long and contains 1 uppercase, 1 Special character and 1 numeric. d. Password should be encrypted in database. Use AES256 algorithm for encryption and decryption.

SCREENSHOT REGISTER:

![Register](https://github.com/user-attachments/assets/50b505f2-96fd-42fb-9f08-832bfd1908ca)

    Home page:
    ------------
  

a. Edit action -Enable edit option only for the user who had logged in current session. Edit icon should read-only for the other users available in the datatable. Email ID field to be read-only

SCREENSHOT HOME PAGE:


![MainPage](https://github.com/user-attachments/assets/aa7c723e-f6a2-4170-a908-770068616c36)



Tech Stack
------------
IDE and RDBMS:
-----------------

.NET FRAMEWORK 4.8

SQL SERVER 2019

VISUAL STUDIO 2022

Technologies:
----------------

ASP.NET MVC 4.0

ASP.NET WEB API

Entity Framework - Code first

Bootstrap

Javascript- AJAX
