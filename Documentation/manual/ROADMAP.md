# Roadmap <!-- omit in toc -->

Last Updated:  Sep 13, 2021

## Key <!-- omit in toc -->

⚪ Planned
🔵 Research
🟢 Active Work
🟠 Complete

- [1. Future Releases](#1-future-releases)
  - [1.1. Alpha 10 Signal Refactor](#11-alpha-10-signal-refactor)
  - [1.2. Alpha 11 Full UI System Rewrite/Refactor](#12-alpha-11-full-ui-system-rewriterefactor)
  - [1.3. Alpha 12 Big Huge Manual Writeup](#13-alpha-12-big-huge-manual-writeup)
  - [1.4. Alpha 13 Level System Manual and Refactor](#14-alpha-13-level-system-manual-and-refactor)
- [2. Alpha Features](#2-alpha-features)
  - [2.1. Detection](#21-detection)
  - [2.2. Editor](#22-editor)
  - [2.3. UI](#23-ui)
  - [2.4. State Management](#24-state-management)
  - [2.5. Serialization](#25-serialization)
  - [2.6. Core Generics](#26-core-generics)
- [3. Beta Features](#3-beta-features)
  - [3.1. Demos](#31-demos)
  - [3.2. Integrations](#32-integrations)
- [4. Release Features](#4-release-features)

---

## 1. Future Releases

### 1.1. Alpha 10 Signal Refactor

🟢 Full test coverage of signal system.
> Every signal will have full test coverage.
> Refactor code so that signals can be made more generic.
> ISignal interface.

🟢 More public API features on signals.

⚪ Manual section for signals.
> I plan to include examples from my projects where I've used signals to decouple and simplify various systems.  It's nice to make a UI and not have to worry about what code is reading the text from an input field; InputFieldSignalMan awwwwaaaayyyyyy 🐱‍🏍.

### 1.2. Alpha 11 Full UI System Rewrite/Refactor

⚪ Second pass on Menu State Machine and Menu Pages
> This will require a second pass on and test coverage of the state machine in Core.

⚪ VR compatible main menu template.

⚪ Popover Message Box

⚪ Worldspace Message Box

⚪ Message Box Sequencer

⚪ Rect Size Fitter

### 1.3. Alpha 12 Big Huge Manual Writeup

⚪ Attributes

⚪ Detection

⚪ Extensions

⚪ Gizmos

⚪ Mouse Utility

⚪ Resources

⚪ State Machine

### 1.4. Alpha 13 Level System Manual and Refactor

⚪ Complete test coverage of the level system.

⚪ Write a full manual for the level system.

⚪ More fully featured loading screen.
> Images loaded from streaming assets or set in the inspector.

⚪ More public API features.
> The level loader will have a static event that sends the current progress of the load.

---

## 2. Alpha Features

### 2.1. Detection

⚪ Trigger Volumes

⚪ Camera Look Events

⚪ Actor Look Events

### 2.2. Editor

⚪ Hierarchy Dividers
> Customizable dividers that describe what should be underneath themselves.

⚪ For Every Collider a Gizmo

### 2.3. UI

⚪ UI Grid Layout Group

⚪ Flex UI Size Fitter
> Basically dead simple flex box for normal Unity UI.

### 2.4. State Management

🔵 Application State Machine
> This will control the game's play/pause state as well as keeping track of what should happen when the is in a menu vs. when it is in the normal game.

⚪ Menu State Machine

⚪ Level Management

### 2.5. Serialization

🔵 Save System
> A system to create save files using Odin Serializer.

### 2.6. Core Generics

⚪ Commands

⚪ Factories
> I frequently find myself needing to create objects from code by loading resources or creating scriptable object assets.  Having a generic factory class would be an enormous help.

🔵 Singleton MonoBehaviour
> I'm sick of writing these over and over, so I'm going to make one that actually works correctly as a monobehaviour.
>
> DontDestroyOnLoad inspector toggle.
>
> Destroys all other game objects, keeping the one with the highest instanceID—the most recently created I think—in the hierarch root.
>
> And some other stuff...

🟢 Signals
> A scriptable object based event system.

⚪ State Machine

---

## 3. Beta Features

### 3.1. Demos

⚪ For Every Feature a Demo Scene

### 3.2. Integrations

⚪ [DOTween (HOTween v2)](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676) integration.

⚪ [Odin Inspector](https://odininspector.com/) integration.

⚪ Modular Imports.

---

## 4. Release Features

⚪ Complete Example Game

⚪ Released Free on the Asset Store

⚪ Do Magic
> 🧙‍♀️🧙‍♂️
