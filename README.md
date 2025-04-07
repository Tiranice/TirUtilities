# ![TirUtilities Icon](Documentation/images/TirUtilities-128x128-Icon.png) ![TirUtilities Wordmark](Documentation/images/TirUtilities-wordmark-2x.png)

[Documentation Site](https://tiranice.github.io/TirUtilities/)

[Roadmap](https://tiranice.github.io/TirUtilities/articles/ROADMAP.html)

## Description

TirUtilities is a set of generally useful utilities that I carry around between projects.

Unity 2021.3 or newer

## Features

### Signals

`Signals` are the primary feature of this package.  These are [Scriptable Objects](https://docs.unity3d.com/2021.3/Documentation/Manual/class-ScriptableObject.html) which hold a [Unity Action](https://docs.unity3d.com/2021.3/Documentation/ScriptReference/Events.UnityAction.html).  These were originally intended as a way for scripts in different scenes to talk to each other.  Now I most often use them as a way to decuple my code, add modularity, and create enum-like objects.

To go along with these, I have made [Unity Events](https://docs.unity3d.com/2021.3/Documentation/Manual/UnityEvents.html) for each of the `Signal` types.

Below is an example usage:

```csharp
using TirUtilities;
using TirUtilities.Extensions;
using TirUtilities.Signals;

using TMPro;

using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [Header("UI Refs")]
    [SerializeField] private RectTransform _interactionPanel;
    [SerializeField] private TMP_Text _interactionText;

    private IInteractable _interactable;

    [Header("Signals")]
    [SerializeField] private BoolSignal _playerInteractSignal;
    [SerializeField] private GameObjectSignal _cameraLookSignal;

    private void Awake()
    {
        if (_playerInteractSignal.NotNull())
            _playerInteractSignal.AddReceiver(InteractInputReceiver);
        
        if (_cameraLookSignal.NotNull())
            _cameraLookSignal.AddReceiver(CameraLookReceiver);
    }

    // Always make sure you remove receivers.  These objects remember
    // their state across scene loads, so will try to use persistent
    // listeners that no longer exists if you don't remove them.
    private void OnDestroy()
    {
        if (_playerInteractSignal.NotNull())
            _playerInteractSignal.RemoveReceiver(InteractInputReceiver);

        if (_cameraLookSignal.NotNull())
            _cameraLookSignal.RemoveReceiver(CameraLookReceiver);
    }

    private void CameraLookReceiver(GameObject target)
    {
        _interactionPanel.gameObject.SetActive(target.NotNull());

        if (target.IsNull())
        {
            _interactionText.SetText(string.Empty);
            return;
        }

        if (!target.TryGetComponent(out _interactable) || !_interactable.CanInteract) return;
        _interactionText.SetText($"E  {_interactable.InteractionType}");
    }


    //...

    private void InteractInputReceiver(bool value)
    {
        if (!_interactionPanel.gameObject.activeSelf || !value || _interactable.IsNull()) 
            return;

        _interactable.Interact();
        _interactionPanel.gameObject.SetActive(false);
    }
}
```

### The Rest

- Transparent colored materials (because I find myself wanting them contently)
- Helpful attributes such as:
  - `DisplayOnly` which locks a field that is serialized to the inspector.
  - `ScenePath` which lets you turn a string field in the inspector into a scene asset reference.
  - `ShowIf` which shows the decorated field in the inspector only if the given condition is true.
  - `TagField` which turns the decorated string into the tag selection dropdown.  (If you MUST use tags, this will save you from typos.)
- `Core` Features:
  - Enumerated Unity Messages
  - A slew of typed `UnityEvent` definitions.  (I got sick of writing `public class PlayerPositionEvent : UnityEvent<Vector3> { }` all the time.)
  - Generic pattern classes such as a state machine (of dubious quality) and a `MonoBehaviour` singleton.
  - All of Unity's rich text colors as value types.
  - A logger that does some call stack investigation to report what class called the method it's called from.  (Doesn't work on WebGL, obviously)
- Extension methods for `UnityEvent`, `IReadonlyList`, `LayerMask`, `List`, `Object`, `Rigidbody`, `Vector2`, and `Vector3`.
- Gizmo components that can be used to draw almost any collider in the scene view.
  - Unity doesn't have a cylinder or capsule collider gizmo, so I've had to make my own.  It's... very experimental.
- `Runtime` Features:
  - `ApplicationStateMachine` that only really controls play/pause behavior at the moment.
  - A script that makes things spin.  You'd be surprised how often I need that.
  - `CameraLookEvents` that reports the result of a sphere cast from the main camera.
  - A player controller that unites the features of Unity's starter asset controllers.
  - A mouse utility that contains the logic I use most, such as getting getting objects with a mouse click.
  - A layer based trigger volume.
  - A level management system that makes switching between complex scene setups faster and easier.
  - Several UI things that make me sad when I look at them.  They'll be getting a second pass in alpha 11.
- Script templates with regions and a header that documents the script name, project name, author name, company name, creation date, update date, and inserts a namespace.

## Usage

1. Open the unity package and import.
2. Go to `Project Settings/TirUtilities` and set the author name.
3. If you want to move the project folder to another directory, you must change the home folder path in the settings.
