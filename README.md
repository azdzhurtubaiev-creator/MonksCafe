# 🍔 Monk's Cafe

> Console application for managing a cafe bill — KhAI summer practice, group **611п**.

Repository: [azdzhurtubaiev-creator/MonksCafe](https://github.com/azdzhurtubaiev-creator/MonksCafe)

## Features

| # | Menu item | Validation |
|---|-----------|------------|
| 1 | Add Item | description 3–20 chars, price > 0, max **5** items |
| 2 | Remove Item | number within range, `0` to cancel |
| 3 | Add Tip | percentage *(0–100)*, fixed amount, or no tip |
| 4 | Display Bill | Net, Tip, GST (5%), Total |
| 5 | Clear All | resets items and tip |
| 6 | Save to file | file name 1–10 chars |
| 7 | Load from file | restores items **and** tip; missing file → message |

The application **never crashes** on invalid input — every error produces a clear text message (`decimal.TryParse` / `try-catch` everywhere).

## Architecture

- `BillService` — business logic, *independent from UI type*
- `Ui` — console input/output only
- `Program` — entry point with a minimal `Main()` menu loop

## How to run

```bash
dotnet run
```

Example session:

```text
Enter your choice: 1
Enter description: Cheeseburger
Enter price: 13.95
Add item was successful.
```

## Git workflow

- [x] main → develop → my-feature branching (GitFlow)
- [x] one commit per implemented menu item
- [x] merge & branch cleanup, clone & pull demonstrated

## Author

**Dzhurtubaiev Arsen**, group 611п, KhAI
