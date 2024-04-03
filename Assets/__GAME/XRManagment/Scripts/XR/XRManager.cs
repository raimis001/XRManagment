using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRManager : MonoBehaviour
{
    public static Action OnXrStarted;
    public static bool XrStarted = false;

    [SerializeField]
    InputAction trackingAction;

    private void OnEnable()
    {
        trackingAction.Enable();
    }

    IEnumerator Start()
    {
        while (!XrStarted)
        {
            yield return null;
            if (trackingAction.ReadValue<int>() > 0)
                XrStarted = true;
        }

        yield return null;
        OnXrStarted.Invoke();
    }
}
