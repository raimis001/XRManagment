using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

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

    public Vector2 joystick => joystickAction.ReadValue<Vector2>();

    public bool triggerDown => triggerAction.triggered;
    public bool triggerHold => triggerAction.IsPressed();

    public bool gripDown => gripAction.triggered;
    public bool gripHold => gripAction.IsPressed();

    private void OnEnable()
    {
        joystickAction.Enable();
        triggerAction.Enable();
        gripAction.Enable();
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


}
