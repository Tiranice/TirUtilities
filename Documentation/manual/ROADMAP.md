# Roadmap <!-- omit in toc -->

Last Updated:  Sep 18, 2021

## Key <!-- omit in toc -->

⚪ Planned
🔵 Research
🟢 Active Work
🟠 Complete

- [1. Phases](#1-phases)
  - [1.1. Alpha](#11-alpha)
  - [1.2. Beta](#12-beta)
  - [1.3. Release](#13-release)
- [2. Future Releases](#2-future-releases)
  - [2.1. Alpha 10 Signal Refactor](#21-alpha-10-signal-refactor)
  - [2.2. Alpha 11 Full UI System Rewrite/Refactor](#22-alpha-11-full-ui-system-rewriterefactor)
  - [2.3. Alpha 12 Level System Refactor](#23-alpha-12-level-system-refactor)
- [3. Alpha Features](#3-alpha-features)
  - [3.1. Scriptable Object Event System](#31-scriptable-object-event-system)
  - [3.2. Core Generics](#32-core-generics)
  - [3.3. UI](#33-ui)
  - [3.4. State Management](#34-state-management)
  - [3.5. Editor](#35-editor)
  - [3.6. Detection](#36-detection)
  - [3.7. Serialization](#37-serialization)
- [4. Beta Features](#4-beta-features)
  - [At Least 80% Test Coverage](#at-least-80-test-coverage)
  - [4.1. Integrations](#41-integrations)
- [5. Release Features](#5-release-features)
  - [5.1. Demos](#51-demos)

---

## 1. Phases

### 1.1. Alpha

v0.0.0-alpha.x.x

The alpha phase will focus on getting features into the package.

### 1.2. Beta

v0.x.x

The beta phase will focus on getting full test coverage of features, fully documenting all scripts, and writing the manual.

### 1.3. Release

vx.x.x-alpha.x
vx.x.x-beta.x
vx.x.x

The release versions will focus on creating examples including a full game—a simple platformer or the like—that shows off the package's features.

---

## 2. Future Releases

### 2.1. Alpha 10 Signal Refactor

🟢 Refactor signals to use an interface and base class.
> Refactor code so that signals can be made more generic. (if that's even possible with scriptable objects)
> ISignal interface.

🟢 More public API features on signals.

⚪ Manual section for signals.
> I plan to include examples from my projects where I've used signals to decouple and simplify various systems.  It's nice to make a UI and not have to worry about what code is reading the text from an input field; InputFieldSignalMan awwwwaaaayyyyyy 🐱‍🏍.

### 2.2. Alpha 11 Full UI System Rewrite/Refactor

⚪ Second pass on Menu State Machine and Menu Pages
> This will require a second pass on and test coverage of the state machine in Core.

⚪ VR compatible main menu template.

⚪ Popover Message Box

⚪ Worldspace Message Box

⚪ Message Box Sequencer

⚪ Rect Size Fitter

### 2.3. Alpha 12 Level System Refactor

⚪ More fully featured loading screen.
> Making it more than just a black screen.

⚪ More public API features.
> The level loader will have a static event that sends the current progress of the load.

---

## 3. Alpha Features

In order of priority.

### 3.1. Scriptable Object Event System

🟢 Signals
> A scriptable object based event system.

### 3.2. Core Generics

⚪ Factories
> I frequently find myself needing to create objects from code by loading resources or creating scriptable object assets.  Having a generic factory class would be an enormous help.

⚪ Commands

⚪ State Machine

🔵 Singleton MonoBehaviour
> I'm sick of writing these over and over, so I'm going to make one that actually works correctly as a monobehaviour.
>
> DontDestroyOnLoad inspector toggle.
>
> Destroys all other game objects, keeping the one with the highest instanceID—the most recently created I think—in the hierarch root.
>
> And some other stuff...

### 3.3. UI

⚪ UI Grid Layout Group

⚪ Flex UI Size Fitter
> Basically dead simple flex box for normal Unity UI.

### 3.4. State Management

🔵 Application State Machine
> This will control the game's play/pause state as well as keeping track of what should happen when the is in a menu vs. when it is in the normal game.

⚪ Menu State Machine

⚪ Level Management

### 3.5. Editor

⚪ Hierarchy Dividers
> Customizable dividers that describe what should be underneath themselves.

⚪ For Every Collider a Gizmo

### 3.6. Detection

⚪ Trigger Volumes

⚪ Camera Sensors

⚪ Actor Sensors

### 3.7. Serialization

🔵 Save System
> A system to create save files using Odin Serializer.

---

## 4. Beta Features

### At Least 80% Test Coverage

⚪ Core

⚪ Signals

⚪ UI

⚪ State

⚪ Editor

⚪ Detection

⚪ Serialization

### 4.1. Integrations

⚪ [DOTween (HOTween v2)](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676) integration.

⚪ [Odin Inspector](https://odininspector.com/) integration.

⚪ Modular Imports.

---

## 5. Release Features

### 5.1. Demos

⚪ For Every Feature a Demo Scene

⚪ Complete Example Game

⚪ Released Free on the Asset Store & itch.io

⚪ Do Magic
> 🧙‍♀️🧙‍♂️
