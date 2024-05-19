using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class XRManager : MonoBehaviour
{
    public static Action OnXrStarted;
    public static bool XrStarted = false;

    [SerializeField]
    InputAction trackingAction;


    public static UnityEngine.XR.InputDevice GetDevice(XRNode kind)
    {
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevicesAtXRNode(kind, devices);
        return devices.Count > 0 ? devices[0] : new UnityEngine.XR.InputDevice();
    }

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
