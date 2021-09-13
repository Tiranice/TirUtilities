# TirUtilities

[Documentation Site](https://tiranice.github.io/TirUtilities/)

[Roadmap](https://tiranice.github.io/TirUtilities/manual/ROADMAP.html)

## Description

TirUtilities is a set of generally useful utilities that I carry around between projects.

## Features

- A mouse utility that contains the logic I use most—such as getting getting objects with a mouse click.
- A generic state machine.
  - A menu state machine for switching between various canvases in a screen or camera space UI.
  - An application control system that sets the play/pause/quit state of the application.
- A layer based trigger volume.
- Gizmo componenets that can be used to draw almost any collider in the scene view.
  - Unity doesn't have a cylinder or capsole collider gizmo, so I've had to make my own.  It's... very experimental.
- A level managment system that makes switching between complex scene setups faster and easier.
- A scriptable object based event system.
- Several UI things that make me sad when I look at them.  They'll be getting a second pass in alpha 11.
- Script templates with regions and a header that documents the script name, project name, author name, componey name, creation date, update date, and inserts a namespace.

## Usage

1. Open the unity package and import.
  1.1. AutoRotate.cs is not compatable with Unity 2019 yet. Everything else should work fine.  If not, that's what issues are for.
2. Go to Project Settings/TirUtilites and set the author name.
3. If you want to move the project folder to another director, make sure that you change the home folder path in the settings.
