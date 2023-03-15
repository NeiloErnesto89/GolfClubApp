<h1 align="center">ASP.NET Assignment2: Golf Club DB 

<h2 align="center">CA2 Cross-Platform Development </h2>

## **Project Introduction and Brief**

Goal was to write a small web site for a local golf club using ASP.NET
I used Razor Pages (C#) focusing on the CRUD operations.

Some basic rules included - 
"The club’s members are stored with membership number, name, email, sex and
handicap for each player. In addition to adding members, the system should also allow players to
book tee times. Tee time bookings are made in 15 minutes intervals"


### **Manual Test**

>1.	create member
>2.	create booking
>3.	edit member
>4. edit booking
>5. delete member
>6. delete booking
>7. each step check DB update
>8. render ranking table
>9 sort by handicap - ascending and decending 
>10. sort by gender
>11. filter by data (using search)
>12. check validation for time interval (only book on hour, every 15 min e.g. 9.00, 9.15. 9.30)
>13. check validation for member same day booking
>13. check validation for maximum 4 members on one tee time (e.g. joe, john, mary and sally @ 17/03/2023 9.15am)
>13. check validation for trying to book in the past (date and even current day current time)


### **Known Bugs**

>1.	duplication of validation messages
>2.	edit member booking, if changing the member -> error is produced
