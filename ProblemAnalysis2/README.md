# PartyMaster 🎉 - Event & Invitation Manager

## 📚 Overview

Welcome to the PartyMaster app! This app helps you manage events and invitations with RSVP tracking.

## 📐 Architecture Diagram

```mermaid
graph TD
    UI[User Interface (Razor Views)] -->|Interacts with| Controllers
    Controllers -->|Handles requests| Models
    Controllers -->|Returns views| UI
    Models -->|Database operations| DB[(SQL Server LocalDB)]
    Controllers -->|Send Emails| SMTP[(Gmail SMTP Server)]
    Controllers -->|RSVP Links| UI
