# PartyMaster 🎉 - Event & Invitation Manager

## 📚 Overview

Welcome to the **PartyMaster app**!  
This app helps you **create and manage parties**, **invite guests via email**, and **track their RSVP responses** easily. The system supports sending email invitations and allows guests to RSVP through a link provided in the email.

---

## 🚀 Features

- ✅ Create and Manage Parties (CRUD operations).
- ✅ Add guests and manage invitations.
- ✅ Send invitation emails directly to guests.
- ✅ Guests can RSVP via email link (Yes/No).
- ✅ Track invitation status:
  - **Invitation Not Sent**
  - **Invitation Sent**
  - **Responded Yes**
  - **Responded No**
- ✅ Party edit and delete options.
- ✅ Dashboard with count of invitations (sent, responded, pending).

---

## 📐 Architecture Diagram

```mermaid
graph TD
    UI["User Interface - Razor Views"] -->|Interacts with| Controllers
    Controllers -->|Handles requests| Models
    Controllers -->|Returns views| UI
    Models -->|Database operations| DB["SQL Server LocalDB"]
    Controllers -->|Send Emails| SMTP["Gmail SMTP Server"]
    Controllers -->|RSVP Links| UI

   ```


## 🛠️ Technologies Used
ASP.NET Core MVC (C#)
Entity Framework Core (Code First + Migrations)
SQL Server LocalDB
Razor Pages/Views
Gmail SMTP for sending email invitations
Bootstrap (for basic styling and responsiveness)


## 📂 Project Structure
- **/Controllers**        --> All Controllers (PartyController, InvitationController, RSVPController)
- **/Models**           --> Data Models (Party, Invitation, Enums)
- **/Views**              --> Razor Views for Pages (Party, Shared, RSVP, Home)
- **/wwwroot**           --> Static Files (CSS, JS)
- **/Migrations**         --> EF Core Database Migrations
- **Program.cs**          --> Application Startup and Services Configuration
- **appsettings.json**    --> Database and SMTP configurations


## ⚙️ How to Setup and Run Locally
1.)  **Clone the Repository**
```bash
git clone https://github.com/Girish0744/PartyMaster.git
```

2.) **Update Connection String**
Open appsettings.json and configure your local SQL Server and SMTP:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\ProjectModels;Database=PartyDBGBhuteja5688;Trusted_Connection=True;MultipleActiveResultSets=true"
},
"Smtp": {
  "Host": "smtp.gmail.com",
  "Port": 587,
  "Username": "your-email@gmail.com",
  "Password": "your-app-password"
}
```

3.) **Run Database Migrations**
```bash
Update-Database
```

4.) **Run the App**
```bash
dotnet run
```

5.) **Open in Browser**
```bash
https://localhost:PORT/
```

## 📧 Email Setup (Important!)
- Create an App Password in Gmail for SMTP access.
- Use that App Password in appsettings.json.
- Email invitations will include an RSVP link for guests to respond.

## 🎉 Usage Flow
- Create a Party → Add Party Details.
- Manage Party → Add Guests.
- Send Invitations → Emails sent with RSVP link.
- Guests Respond → RSVP link (Yes/No).
- Track Status → See live updates of RSVP responses.

## ✨ Sample Screens

- Main Screen

![image](https://github.com/user-attachments/assets/c20d18b5-870b-4c50-b0f1-93ded5b71148)


- All Parties page with Edit/Manage options.

![image](https://github.com/user-attachments/assets/afb442dc-1897-482b-b0ee-be490df376eb)


- Manage Party with invitation summary and RSVP tracking.

![image](https://github.com/user-attachments/assets/3ca4a415-6d85-4442-8acc-a227b4a9b443)


- RSVP form (Yes/No) from email link.

![image](https://github.com/user-attachments/assets/4f717880-eac3-483b-b7c2-6e4f10e5f8b0)


- Thank You page after responding.

  ![image](https://github.com/user-attachments/assets/4998e1da-464e-4236-b104-095dab1b582c)


## 👨‍💻 Author
Girish Bhuteja
- Emial : [Email](girishbhuteja07@gmail.com)

## 🎥 Demo Video

Watch the full demo here: [YouTube Demo](https://youtu.be/xeg00u98xzk)



## 📜 License
This project is for educational purposes and part of Problem Analysis 2 Assignment. All rights reserved.
