# 📊 Progress Panel Submodule (Unity)

A fully **reusable**, **independent**, and **workflow-agnostic** progress display module for Unity projects.  
Designed for use in AR/VR, training workflows, games, productivity apps, and any system that requires visual progress indication.

This module includes:

- A progress bar UI (percentage + visual fill)
- A generic connector for flexible integration
- A full demo scene showing usage
- Prefabs and scripts ready to drag-and-drop into any project

The submodule can be used **standalone**, with **custom logic**, or integrated into any workflow logic by calling simple public API methods.

---

## 📦 Contents of the Package

```
ProgressPanel/
│
├── Prefabs/
│   └── ProgressPanel.prefab
│
├── Scripts/
│   ├── ProgressPanel.cs
│   ├── GenericProgressConnector.cs
│   └── ProgressPanelDemo.cs
│
├── Scenes/
│   └── ProgressPanel_Demo.unity
│
└── UI/              (optional icons/fonts used by prefab)
└── README.md
```

---

# 🌟 Key Features

### ✔ Fully Reusable & Modular  
No dependencies on any project-specific logic.  
Just call the public methods and the UI updates instantly.

### ✔ Clean UI with Progress Bar + Percentage  
A professional, modern UI displaying both:

- Visual fill amount  
- Percentage text (`0%` → `100%`)

### ✔ Initialization Support  
Define how many steps or units of progress the panel will show.

### ✔ Real-Time Progress Updates  
Update the progress at any time through a simple API call.

### ✔ Generic Connector  
A flexible, dependency-free connector script that:

- Allows designers to bind events in the Inspector
- Lets developers drive the progress panel from any custom logic
- Provides UnityEvents for easy extension (animations, sounds, etc.)

### ✔ Demo Scene Included  
A complete working sample scene demonstrating initialization, updating, and resetting progress.

### ✔ Lightweight & High Performance  
Minimal code, no allocations, no dependencies, works across mobile/desktop/VR.

---

# 🧩 Components in Detail

## 1️⃣ ProgressPanel.cs  
The **core UI script**.

### Responsibilities:
- Initialize total steps  
- Update fill percentage  
- Update displayed text (`0%`, `25%`, …)  
- Show/Hide the panel  

### Public API:
```csharp
void Initialize(int totalSteps);
void UpdateProgress(int completedSteps);
void ResetPanel();
void Show();
void Hide();
```

---

## 2️⃣ GenericProgressConnector.cs  
A **workflow-agnostic adapter** that maps your custom events or logic into ProgressPanel calls.

### Contains:
```csharp
public void InitializePanel(int totalSteps);
public void NotifyStepCompleted(int completedSteps);
```

### UnityEvents:
```csharp
IntEvent OnInitialize;
IntEvent OnProgressUpdate;
```

### Purpose:
- Allows integration with ANY custom system  
- Lets designers trigger initialization/progress from UnityEvents  
- Keeps module reusable and decoupled  

---

## 3️⃣ ProgressPanelDemo.cs  
A simple controller used only inside the included demo scene.

### Demonstrates:
- Initializing with a set number of steps  
- Updating progress when "Next" or "Previous" buttons are pressed  
- Resetting the entire progress panel  

### Helps users understand:
- How to call the API  
- How the connector works  
- How to integrate into custom logic  

---

# 🎬 Demo Scene: `ProgressPanel_Demo.unity`

Included to help new users immediately understand how to:

- Instantiate the progress panel
- Initialize it using `InitializePanel(int)`
- Update progress using `NotifyStepCompleted(int)`
- Reset the entire UI

### Buttons added in the demo scene:
| Button | Function |
|--------|----------|
| **Next** | Increase progress by 1 |
| **Prev** | Decrease progress by 1 |
| **Reset** | Reset progress to 0 |

Perfect for onboarding new developers.

---

# 🔧 How to Use the Module in Your Project

## Step 1 — Drag the Prefab Into Your Canvas  
Simply drag:

```
ProgressPanel/Prefabs/ProgressPanel.prefab
```

into your UI Canvas.

This gives you a ready-to-use progress bar UI.

---

## Step 2 — Add the Generic Progress Connector  
Add the script `GenericProgressConnector.cs` to any GameObject.

Assign:

```
ProgressPanel → (your ProgressPanel prefab instance)
```

Now your project can call:

```csharp
connector.InitializePanel(steps);
connector.NotifyStepCompleted(completedSteps);
```

---

## Step 3 — Drive the Progress From Your Logic  
Example usage in ANY script:

```csharp
public GenericProgressConnector connector;

void Start()
{
    connector.InitializePanel(10);   // there are 10 steps/items
}

void Update()
{
    // Example: simulate completion
    if (Input.GetKeyDown(KeyCode.Space))
    {
        completed++;
        connector.NotifyStepCompleted(completed);
    }
}
```

Works with ANY workflow since the API is universal.

---

# 🧠 Design Philosophy

This module was built with **maximum reusability** in mind:

### ✔ UI and Logic are separated  
`ProgressPanel` is pure UI.  
`GenericProgressConnector` is pure adapter.

### ✔ Zero dependency on workflow classes  
You can plug this UI into:

- Games  
- Interactive training modules  
- Step-based processes  
- UI forms  
- AR instructions  
- Mini-games  
- Download/processing indicators  

### ✔ Simple and extendable  
UnityEvents let you add animations, sounds, or transitions without touching script code.

---

# 🚀 Example: Add Progress to Your Workflow

Here is how a new developer can drive progress:

```csharp
public class MyTaskSystem : MonoBehaviour
{
    public GenericProgressConnector connector;
    int total = 8;
    int completed = 0;

    void Start()
    {
        connector.InitializePanel(total);
    }

    public void MarkStepDone()
    {
        completed++;
        connector.NotifyStepCompleted(completed);
    }
}
```

Nothing else needed.  
No dependencies.  
Just call the connector and UI responds.

---

# 📁 Package Structure Overview

```
ProgressPanel/
│
├── Prefabs/
│   └── ProgressPanel.prefab
│
├── Scripts/
│   ├── ProgressPanel.cs
│   ├── GenericProgressConnector.cs
│   └── ProgressPanelDemo.cs
│
├── Scenes/
│   └── ProgressPanel_Demo.unity
│
├── UI/
│   └── (optional fonts, icons, backgrounds)
│
└── README.md
```

---

# 🔍 FAQ

### Q: Does this module depend on any workflow?  
**A: No.** It is fully independent.

### Q: Can this show any kind of progress?  
Yes — steps, tasks, downloads, processes, etc.

### Q: How do I update progress?  
Call:
```csharp
connector.NotifyStepCompleted(int);
```

### Q: How do I reset?  
Call:
```csharp
connector.InitializePanel(totalSteps);
```

---

# 🏁 Conclusion

The Progress Panel module is:

- ✔ Reusable  
- ✔ Independent  
- ✔ Easy to integrate  
- ✔ Demo-ready  
- ✔ Extendable  

Drop it into any Unity project and start visualizing progress instantly.
