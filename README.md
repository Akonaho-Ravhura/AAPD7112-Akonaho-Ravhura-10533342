# Municipal Application

A C# Windows Forms desktop application that gives residents of a South African
municipality a digital way to report service delivery issues, submit service
requests, and stay informed about local events and announcements — while giving
municipal admin staff a dashboard to track every report, update its status, and
post comments and photos back to the resident who submitted it.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting the Code](#getting-the-code)
- [How to Compile](#how-to-compile)
- [How to Run](#how-to-run)
- [Troubleshooting](#troubleshooting)
- [How to Use the Programme](#how-to-use-the-programme)
- [Project Structure](#project-structure)
- [Notes / Known Limitations](#notes--known-limitations)

## Prerequisites

Before you can compile or run this project, install the following:

1. **Windows 10 or 11** — this is a Windows Forms application and only runs on
   Windows.
2. **.NET 10 SDK** — download and install from
   [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).
   After installing, confirm it worked by opening a terminal (Command Prompt,
   PowerShell, or Git Bash) and running:

   ```bash
   dotnet --version
   ```

   This should print `10.0.x` or higher. If the command isn't recognised, restart
   your terminal (and machine, if needed) so your `PATH` picks up the new install.
3. **An IDE (optional but recommended):** Visual Studio 2022 (17.14+) or Visual
   Studio 2026, with the **".NET Desktop Development"** workload installed. You can
   add this workload via the Visual Studio Installer if you already have Visual
   Studio, or select it during a fresh install. Alternatively, any editor (e.g.
   VS Code) plus the `dotnet` CLI works fine — Visual Studio is only needed for its
   visual Windows Forms designer.

## Getting the Code

Clone the repository, then move into the project folder:

```bash
git clone <this-repository-url>
cd Municipal-Application
```

(Replace `<this-repository-url>` with the actual GitHub URL once the repo exists.)

## How to Compile

**Option A — Visual Studio**

1. Open `Municipal-Application.slnx` (double-click it, or use `File > Open >
   Project/Solution` in Visual Studio).
2. Wait for Visual Studio to finish restoring NuGet/SDK dependencies (progress
   shows in the status bar).
3. Build the solution via `Build > Build Solution`, or press `Ctrl+Shift+B`.
4. A successful build shows `Build succeeded` in the Output window, with no errors.

**Option B — .NET CLI**

From the project's root folder (the one containing `Municipal-Application.csproj`):

```bash
dotnet build
```

This restores dependencies automatically and compiles the project. You should see:

```
Build succeeded.
    0 Warning(s)
    0 Error(s)
```

The compiled output is written to `bin\Debug\net10.0-windows\`.

## How to Run

**Option A — Visual Studio**

Press `F5` to run with debugging attached, or `Ctrl+F5` to run without debugging.

**Option B — .NET CLI**

From the project's root folder:

```bash
dotnet run
```

This builds the project (if needed) and launches it.

## Troubleshooting

- **"An Application Control policy has blocked this file" / Windows Smart App
  Control blocks the app.** Freshly-compiled, unsigned `.exe` files can be blocked
  by Windows 11's Smart App Control the first time you try to launch them directly
  (e.g. double-clicking `Municipal-Application.exe` in `bin\Debug\net10.0-windows\`,
  or Visual Studio's "Start" button in some configurations). Launching via
  `dotnet run` (CLI) or `F5`/`Ctrl+F5` in Visual Studio avoids this, since the app
  is launched through the trusted `dotnet` host rather than executed directly. If
  you still hit this and need to run the raw `.exe`, you can disable Smart App
  Control via Windows Security > App & browser control > Smart App Control — note
  this is a one-way setting (it cannot be re-enabled without reinstalling Windows),
  so only do this if you understand that trade-off.
- **Build fails with "The process cannot access the file ...Municipal-Application.exe
  because it is being used by another process."** This means a previous run of the
  app is still open. Close the running application window (or end the process via
  Task Manager) and build again.
- **`dotnet` command not found.** The .NET SDK isn't installed, or your terminal
  session started before the SDK finished installing. Reinstall/verify via
  [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download),
  then open a new terminal window.
- **NuGet/SDK restore errors on first build.** Ensure you have an internet
  connection the first time you build, since the .NET SDK may need to download the
  Windows Desktop targeting pack. Subsequent builds work offline.

## How to Use the Programme

### Signing In

On startup you choose a role:

- **Resident** — enter your full name, 13-digit South African ID number, and
  contact number to continue. The ID number is validated (format and check digit)
  and is used as the resident's unique identifier. A valid test ID number is
  `9001015001083`.
- **Municipal Admin** — sign in with the admin credentials below. Use
  **Show/Hide** next to the password field to reveal or mask what you've typed.

Demo admin credentials:

- Username: `admin`
- Password: `Admin123`

### Resident: Main Menu

- **Report Issues** — report a service delivery problem (pothole, water leak, etc.).
- **Submit a Service Request** — request a municipal service (new connection, bin
  collection, indigent support application, etc.).
- **Local Events and Announcements** — view notices posted by the municipality
  (service interruptions, maintenance activity, community notices, progress
  updates).
- **My Reports & Updates** — see every issue/request you've submitted and its
  current status, and open any of them to view the full update timeline (status
  changes, admin comments, and photos posted by the municipality).

#### Reporting an Issue / Submitting a Service Request

1. Fill in the **Title**, **Category**/**Service Type**, **Location**, and
   **Description**/**Request Details**.
2. Optionally attach supporting images or documents via **Add File...**.
3. A progress bar and message at the bottom of the form update live as you complete
   the form, encouraging you to finish your report.
4. Click **Submit**. A confirmation message displays your reference number.
5. Click **Back to Main Menu** at any time to return without submitting.

### Admin: Dashboard

Sign in as **Municipal Admin** to reach a tabbed dashboard:

- **Issues & Service Requests tab** — lists every issue and service request from
  every resident. Select one and click **View / Update** to open its detail screen,
  where you can:
  - Choose a **new status** (`Submitted`, `InProgress`, `Resolved`, `Closed`)
  - Add a **comment**
  - Attach **photos**
  - Click **Post Update** to publish all three together as one timeline entry.
    Residents see this immediately on their **My Reports & Updates** screen.
- **Local Events tab** — view all posted notices, and post a new one (title,
  category, description) for residents to see under **Local Events and
  Announcements**.

Only admins can change an issue/request's status — residents can only view it.

## Project Structure

```
Models/       Domain classes: User, Resident, Admin, Issue, IssueUpdate, LocalEvent,
              RequestType, IssueCategory, ServiceRequestType, IssueStatus,
              LocalEventCategory
Data/         In-memory data storage: IssueRepository, IssueUpdateRepository,
              LocalEventRepository, AdminAccountStore
Validation/   SouthAfricanIdValidator (format + check-digit validation)
Forms/        All Windows Forms screens (LoginForm, MainMenuForm, ReportIssueForm,
              ServiceRequestForm, MyReportsForm, IssueDetailForm, LocalEventsForm,
              AdminDashboardForm) and the shared UiTheme
Program.cs    Application entry point
```

## Notes / Known Limitations

- All data (issues, service requests, updates, events) is currently stored in
  memory only and is not persisted between application runs. Persistence can be
  added by swapping the storage inside the classes in `Data/` for a file or
  database-backed store.
- Resident sign-in does not use a password; the SA ID number plus contact number is
  treated as sufficient identification for this prototype.
