# 🌐 URLGrabber  
A modern Windows Forms application for browsing websites and grabbing links automatically — built with **.NET 9**, **C#**, and **WebView2**.

---

## 📋 Table of Contents
- [About The Project](#about-the-project)
- [Built With](#built-with)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)
- [Acknowledgments](#acknowledgments)
- [Screenshots](#screenshots)

---

## 💡 About The Project
**URLGrabber** is a simple utility for collecting and managing URLs while browsing the web.  
It uses Microsoft’s **WebView2** to embed a Chromium-based browser directly into the application, allowing you to right-click and capture links instantly.

This project was developed as a lightweight research and productivity tool for quickly saving URLs, organizing them, and exporting them for later use.

---

## 🛠️ Built With
- [Microsoft .NET 9](https://dotnet.microsoft.com/)
- [C#](https://learn.microsoft.com/dotnet/csharp/)
- [Windows Forms (WinForms)](https://learn.microsoft.com/dotnet/desktop/winforms/)
- [Microsoft Edge WebView2](https://learn.microsoft.com/microsoft-edge/webview2/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)

---

## 🚀 Getting Started

### Prerequisites
Before running the project, ensure you have:
- ✅ Windows 10 or newer
- ✅ [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- ✅ [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- ✅ [WebView2 Runtime](https://developer.microsoft.com/en-us/microsoft-edge/webview2/)

### Installation

#### Clone the repository
```bash
git clone https://github.com/!uzupelnij/URLGrabber.git
```

#### Open the project
1. Launch **Visual Studio**
2. Open `UrlGrabber.sln`
3. Build and run (`Ctrl+F5`)

#### Ensure resources are in place
- Place `logo_image.png` and `logo_image.ico` in the same directory as the `.exe`, e.g.:
  ```
  bin\Debug\net9.0-windows\
  ```
- (Optional) In **Project → Properties → Application → Icon and manifest**, select `logo_image.ico` as the app icon.

---

## 🖱️ Usage

1. Run the application — it starts **maximized**.
2. A splash logo will appear if `logo_image.png` is detected.
3. Use the **address bar** to navigate to a website.
4. Click **Go** or press **Enter** to load the page.
5. To enable automatic URL grabbing:
   - Go to **Options → Autograb**
   - Now, right-click any link on the page — it will be captured.
6. All captured links appear in the **TreeView** on the right.
7. You can right-click items in the list to:
   - Add new link manually  
   - Rename a link  
   - Remove a link
8. Use **File → Save / Load / Clear** to manage your URL lists (`urls.txt`).

---

## 🌟 Features

| Feature | Description |
|----------|-------------|
| 🕸️ Embedded Browser | Uses WebView2 for full-featured page navigation |
| 🔗 Auto & Manual Link Grabbing | Capture URLs automatically or on-demand |
| 🗂️ URL TreeView | Organized list with edit, rename, and delete |
| 💾 Persistent Storage | Automatically saves links to `urls.txt` |
| 🪟 Splash Screen | Displays custom `logo_image.png` at startup |
| 🧭 Back & Go Buttons | Easy navigation controls |
| ⚙️ Autograb Toggle | Enable/disable automatic capture |
| 🧰 No external dependencies | Portable .exe — simple to run anywhere |

---

## 🗺️ Roadmap

- [x] Move back button before address bar  
- [x] Remove old toolbar  
- [x] Add splash logo and icon  
- [ ] Add search/filter for saved URLs  
- [ ] Add export to CSV/JSON  
- [ ] Add dark/light theme toggle  
- [ ] Add sorting options in TreeView  
- [ ] Improve UI styling with custom fonts  
- [ ] Build installer using `dotnet publish` + MSIX packaging  

---


## ❤️ Acknowledgments
- [Best-README-Template](https://github.com/othneildrew/Best-README-Template) by Othneil Drew  
- Microsoft for WebView2 & WinForms SDK  
- GitHub community for examples and open-source inspiration  

