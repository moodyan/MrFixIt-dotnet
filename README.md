# Mr Fix-It

#### _App created for Epicodus Independent Project, ASP.NET - Week Three. Practice using ASP.NET MVC with AJAX. August 18th, 2017_

#### By **Alyssa Moody**

## Description

_A web app that manages a repair technician job service._

## Program Specifications

| Description  | Input Example | Output Example |
| ------------- | ------------- | ------------- |
| The program allows all users to view a landing page.  | Home  | "Welcome"  |
| The program allows all users to view an about page.  | /About  | Information on Mr.Fix-It  |
| The program allows all users to view a list of all jobs.  | /Jobs  | Table of jobs with descriptions  |
| The program allows all users to add a new job.  | /Create  | New job form  |
| The program allows all users to register as a user/ and create a worker profile.  | /Register  | --  |
| The program allows workers to login.  | /Login  | --  |
| The program allows workers to view status of jobs  | /Jobs  | Table of jobs with descriptions and status  |
| The program allows workers to claim jobs  | /Jobs  | Are you sure you want to claim this job?  |
| The program allows workers to view all their claimed jobs  | /Workers  | Table of all worker's jobs  |
| The program allows workers to designate one active job  | /Workers  | --  |
| The program allows workers to mark active job completed  | /Workers  | --  |
| The program allows workers to view all their completed jobs  | /Workers/CompletedJobs  | Table of worker's completed jobs  |

## Setup/Installation Requirements

**Requirements**
If you do not have Visual Studio 2017, download [HERE](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15).

If you do not have SSMS, download [HERE](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms).

Cloning From GitHub: Download or clone project repository onto desktop from GitHub.

Open the project in Visual Studio.

**Migrations**
1. In Solution Explorer, right-click the project and choose 'Open in File Explorer' from the context menu.
2. Enter "cmd" in the address bar and press Enter.
3. Enter the following command in the command window:
  - dotnet ef database update
4. Back in VS, click IIS Express at the top of the window. Project should open in a new window in your default browser.

## Known Bugs

_No known bugs._

## Support and contact details

_If you run into any issues or have questions, ideas or concerns, please contact Alyssa Moody at alyssanicholemoody@gmail.com_

## Technologies Used

**Languages:** HTML, CSS, C#, ASP.NET MVC

**IDE:** Visual Studio 2017

**Database Management:** MySQL (SSMS)

### License

*MIT license Agreement*

Copyright (c) 2017 **_Alyssa Moody_*
