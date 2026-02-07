# ChampRune 🏆

**ChampRune** is a powerful, lightweight Windows application designed for League of Legends players who want to optimize their gameplay by automatically importing the best runes and summoner spells directly from [U.GG](https://u.gg).

## ✨ Key Features

-   🚀 **API-Based Auto-Import**: Directly apply runes to your League client using the LCU (League Client Update) API. No mouse clicks needed!
-   🖱️ **Classic Click-Automation**: Intelligent fallback to mouse-click automation if API import is unavailable.
-   🛠️ **Smart Rune Detection**: Automatically detects the champion you're looking at on U.GG and shows the corresponding runes.
-   🔮 **Summoner Spell Support**: One-click import for optimal summoner spells.
-   🖼️ **Champion Preview**: Visual confirmation of the selected champion with high-quality icons.
-   🌓 **Theme Support**: Customizable UI themes to match your style.
-   🔄 **Lobby & Champ Select Detection**: Dynamically tracks your game phase (Lobby, Champ Select, etc.).

## 🚀 How it Works

ChampRune bridges the gap between web-based data and your game client:
1.  **Data Sourcing**: Scrapes the latest high-winrate builds from U.GG for any champion.
2.  **LCU Integration**: Uses the official League Client API (via PoniLCU) to communicate with your running game.
3.  **One-Click Application**: When you press "Import", it maps rune names to numerical IDs and sends them directly to your active rune page.

## 📥 Installation

1.  Download the latest release from [tutorialeu.ro](https://tutorialeu.ro).
2.  Extract the archive and run `ChampRune.exe`.
3.  Ensure your League of Legends client is running.

## 🎮 How to Use

1.  **Open the App**: Launch ChampRune before or during your game.
2.  **Search Champion**: Use the search bar or champion list to find your champion.
3.  **Import**:
    -   Check **"Auto Import via API"** for the fastest experience (highly recommended).
    -   Click the **"Import"** button.
4.  **Verification**: Your runes and spells will be updated instantly in the League client.

## 🛠️ Technologies Used

-   **Language**: C# (.NET Framework 4.8)
-   **UI**: Windows Forms
-   **Browser Integration**: CefSharp (Chromium Embedded Framework)
-   **HTML Parsing**: HtmlAgilityPack
-   **LCU API**: PoniLCU & Newtonsoft.Json
-   **Data Source**: U.GG

## ⚠️ Requirements

-   Windows 10/11
-   League of Legends Client
-   .NET Framework 4.8 or higher

## 🔗 Links

-   **Website**: [https://tutorialeu.ro](https://tutorialeu.ro)
-   **YouTube**: [TutorialEu YouTube](https://youtube.com/tutorialeu)

---
## Legal Disclaimer

ChampRune isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
