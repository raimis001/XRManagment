using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.OpenXR.Input;

public class XRHand : MonoBehaviour
{
    public static XRHand left;
    public static XRHand right;

    public XRNode kind;

    [SerializeField]
    InputAction joystickAction;
    [SerializeField]
    InputAction triggerAction;
    [SerializeField]
    InputAction gripAction;
    [SerializeField]
    InputAction hapticAction;
    [SerializeField]
    InputAction primaryAction;
    [SerializeField]
    InputAction secondaryAction;

    [SerializeField]
    bool legacyHaptics = true;

    public Vector2 joystick => joystickAction.ReadValue<Vector2>();

    public bool triggerDown => triggerAction.triggered;
    public bool triggerHold => triggerAction.IsPressed();

    public bool gripDown => gripAction.triggered;
    public bool gripHold => gripAction.IsPressed();

    public bool primaryDown => primaryAction.triggered;
    public bool primaryHold => primaryAction.IsPressed();

    public bool secondaryDown => secondaryAction.triggered;
    public bool secondaryHold => secondaryAction.IsPressed();



    UnityEngine.XR.InputDevice device;

    private void OnEnable()
    {
        joystickAction.Enable();
        triggerAction.Enable();
        gripAction.Enable();
        hapticAction.Enable();
        primaryAction.Enable();
        secondaryAction.Enable();
    }

    private void Awake()
    {
        if (kind == XRNode.LeftHand)
            left = this;
        if (kind == XRNode.RightHand)
            right = this;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward);
    }

    public void Haptic(float amplitude, float duration, float frequency = 0)
    {
        if (legacyHaptics)
        {
            if (device == null || !device.isValid)
                device = XRManager.GetDevice(kind);

            device.SendHapticImpulse(0, amplitude, duration);
        } else
        {
            XRController controller = kind == XRNode.LeftHand ? XRController.leftHand : XRController.rightHand;
            OpenXRInput.SendHapticImpulse(hapticAction, amplitude, frequency, duration, controller);
        }
    }


}
