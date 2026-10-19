using System;

public static class EventHandler
{
    public static event Action EndVFXEvent;
    public static void CallEndVFXEvent()
    {
        EndVFXEvent?.Invoke();
    }

    public static event Action<bool> EnableOulineEvent;
    public static void CallEnableOulineEvent(bool isActive)
    {
        EnableOulineEvent?.Invoke(isActive);
    }
}
