# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

- Added:  New features.
- Changed:  Changes in existing functionality.
- Deprecated:  Once-stable features removed in upcoming releases.
- Removed:  Deprecated features removed in this release.
- Fixed:  Any bug fixes.
- Security:  Invite users to upgrade in case of vulnerabilities.

## [Unreleased]

### Added

- `TirLogger.LogCall(string remarks, UnityEngine.Object context)` which appends the remarks string to the end of the message.
- `LevelData.LevelName`
- `LevelLoadSignal`
  - You can now access a signal's `LevelData`.
- `LevelSystem`
  - You can now access the last signal emitted.
  - `ReloadLastLevel()` reemits the last signal.
- Color materials
- `ListExtensions`
  - `int NextIndexInRange(int current, int shift)` Returns an index shifted by the given amount.
- `ObjectExtensions`
  - Adds logging to `IsNull` and `NotNull`.

## [v0.0.0-alpha-10.114]

See the commit logs for all changes.  I got lazy and stopped updating this.

### Added

- Setting the patch version in the export tool creates a version file.
- <code>LevelSystem</code> now has a method, <code>TryLoadMainMenu</code>, that emits a signal assigned in the inspector.
- <code>TirLogger</code>
  - Now accepts a context <code>Object</code>.
  - Color properties for the class, method, and context logs.
- <code>UnityRichTextColors</code> contains static properties for each color supported by Unity's rich text interpreter.
  - This are represented by a <code>RichTextColor</code> readonly struct.

### Changed

- <code>DrawBoxGizmo</code> now uses the center and size its collider instead of <code>Vector3.zero</code> and <code>Vector3.one</code> respectively.
- <code>DrawForwardGizmo</code> line range now goes from 1.0f to 50.0f.
- <code>TirGizmos</code> capsule gizmo logic has been massively refactored.
- <code>LevelSystem</code> is now a <code>MonoSingleton</code>.

### Fixed

- Typos in <code>DrawColliderGizmo</code>.
- <code>DrawColliderGizmo</code> no longer throws a null ref when not given a collider.
- <code>MenuPageInspector</code> no longer fuses the path name and file name when creating a <code>MenuState</code> with the inspector button.
- Possible null refs in <code>ApplicationStateMachine</code> when not supplied with play or pause signals.
- <code>RouterButton</code> now correctly removes level load listeners instead of adding more... <sub>god damn typos</sub>.
- <code>RouterButton</code> now caches its button in <code>OnValidate</code> even if it is not null.
  - This change fixes a bad reference that occurs when copy/pasting the component.
- Adds missing <code>null</code> checks to <code>LevelData</code> and <code>LevelLoader</code>.

## [v0.0.0-alpha.10.4]

### Added

- Script templates for PropertyAttributes and PropertyDrawers.
- ShowIf Attribute
  - Decorate a field with <code>[ShowIf(string targetName, object targetValue)]</code>.  This field will only be drawn in the inspector if the given target equals the target value.
- <code>ApplicationStateMachine</code> has additional documentation.
- <code>RouterButton</code> MonoBehaviour
  - Provides a quick way to route to various common actions.
    - Load a level by calling <code>LevelLoadSignal.Emit</code>
    - Quit or toggle the game's paused state with an <code>ApplicationStateMachine</code>
      - <code>ApplicationStateMachine.QuitGame</code>
      - <code>ApplicationStateMachine.TogglePaused</code>
    - Change the active menu page with <code>MenuStateMachine.TransitionTo(MenuState)</code>

### Fixed

- Experimental build tool now correctly saves its editor prefs.
