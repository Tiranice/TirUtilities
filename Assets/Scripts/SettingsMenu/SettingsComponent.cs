using UnityEngine;

public abstract class SettingsComponent : MonoBehaviour
{
    protected abstract void Awake();
    public abstract void Apply<T>(T data) where T : SettingsData;
}
