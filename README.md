eCourses is a project that contains Desktop (Windows forms) and Mobile (Xamarin forms) applications with the main goal of watching video lectures of purchased courses at any time. Also, project is using Rest API for communication with database and services with Swagger tool (https://swagger.io/)  for design and documentation.

Some of other functionalities of the eCourses project applications are:

         •	User data management

         •	Review and manage instructor courses

         •	Search and review courses

         •	Display of course details, and the possibility of purchasing a course

         •	Possibility to put the course on the wish list

         •	Insight into transactions after each purchased course

         •	Possibility to review courses

         •	Data review and management by the administrator

         •	Authentication and authorization

         •	Reporting

Remark: Functionalities like searching and buying courses, and watching video lessons of participants are related only to the mobile application, while functionalities such as reporting by the administrator, viewing and managing data by the administrator or creating courses by the instructor would be done exclusively over the desktop applications.

Tools and technologies that I used to create applications are:

         •	C# programming language

         •	ASP .Net Core framework

         •	MS SQL Server

         •	Windows Forms

         •	Xamarin Forms

Other informations and remarks about the functionalities:

Payment courses are implemented using a Stripe payment system (https://stripe.com/), and some of the test cards can be found on: https://stripe.com/docs/testing .

Rating courses are implemented using a Syncfusion rating system (https://www.syncfusion.com/).
         

As for uploading video lessons, they are designed so that to add video lessons you need to use the URL of the video located on one of the cloud solutions such as: https://res.cloudinary.com/dkafrzcco/video/upload/v1618394001/Videos/Motivational_video___This_will_change_your_mind___whatsapp_30_sec_video___gstqeh.mp4  and I used Octane Video Player on Xamarin page to watch those video lessons. 

The newly registered user will take on two roles: Instructor and Student. The application is designed so that the user of the application will be able to buy courses and watch video lessons, but will also have the ability to create and add their own course.

Login credentials

            • Administrator:

              Username: Admin	

              Password: Admin123.

            • Instructor/Student

              Username: Instructor1
              
              Password Instructor1.






