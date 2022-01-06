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

### Changed

- <code>DrawBoxGizmo</code> now uses the center and size its collider instead of <code>Vector3.zero</code> and <code>Vector3.one</code> respectively.

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
