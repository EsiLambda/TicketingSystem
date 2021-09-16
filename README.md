# Ticketing System with C# windows form
In this repo, we have a ticketing system. Every user can register with the followings:
* First Name (نام)
* Last Name (نام خانوادگی)
* E-Mail Address (ایمیل); Remember that the e-mail address is the user name too.
* Password (رمز عبور)

## An example of registering page
![1](https://user-images.githubusercontent.com/30634010/133598914-46bc3296-8c86-4f58-9071-6a9aa45c8a0d.png)<br/><br/>

## How to see the database?
To see the saved information, we should connect to the local database as follows:<br/><br/>
![2](https://user-images.githubusercontent.com/30634010/133599296-0273d41e-0de9-4964-8a20-fcf359fedbfe.png)<br/><br/>

## Types of users
We have 2 types of users:
* Ordinary User
* Admin User<br/><br/>

#### User Roles
Ordinary users are saved with " RoleID == 1 " and admin users are saved with " RoleID == 2 ". This process should be done manually in table "UserRole". The table is as follows:<br/><br/>
![3](https://user-images.githubusercontent.com/30634010/133668422-37a59d05-69e9-449e-af0f-6539024ece27.png)<br/><br/>

#### Admin Users
As it mentioned before, ordinary users can register in registering page but admin users should be added to database manually in "UserInformation" table by " RoleID == 2". 

## Signing in page
To signing in, each user should input his/her e-mail as username and the password. Depend on user's role, different pages with different accessibilities will be shown. Signing in page is as follows:<br/><br/>
![4](https://user-images.githubusercontent.com/30634010/133670579-b9007cc6-2e27-4d5a-b3f1-3261eb4383d0.png)

## What can ordinary users do?
* Send(ارسال) / Update(ویرایش) / Delete(حذف) a ticket with specifying the topic(موضوع), department(بخش) and importance(اهمیت). An example of this is as follows:<br/><br/>
![5](https://user-images.githubusercontent.com/30634010/133670887-326514e7-6488-4c2a-9e8b-a8010f10ec02.png)<br/><br/>
* See if any of the admins answer the ticket or not. An example of this is as follows:<br/><br/>
![6](https://user-images.githubusercontent.com/30634010/133671496-59129bc0-f6ab-4f99-b9b7-2c0ce52e5cda.png)<br/><br/>

#### What can admin users do?
* Answering the tickets:<br/><br/>
![7](https://user-images.githubusercontent.com/30634010/133672034-8492c4de-9fe5-47be-86df-a95b37ceea34.png)<br/><br/>
* Updating user's password:<br/><br/>
![8](https://user-images.githubusercontent.com/30634010/133672204-232b42d7-8059-405c-9280-0a825f8b43ff.png)<br/><br/>
* Defining / Updating / Deleting new departments:<br/><br/>
![9](https://user-images.githubusercontent.com/30634010/133672347-32113858-7be0-4264-9f87-1c8fd3ff4118.png)
