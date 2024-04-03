using UnityEngine;
using UnityEngine.Events;

public class XRInteractor : MonoBehaviour
{
    public string ID;

    [SerializeField]
    protected UnityEvent<XRHand, XRInteractor> OnHandEnter;
    [SerializeField]
    protected UnityEvent<XRHand, XRInteractor> OnHandExit;
    [SerializeField]
    protected UnityEvent<XRHand, XRInteractor> OnHandStay;

    private void OnTriggerEnter(Collider other)
    {
        if (!CheckHand(other, out XRHand hand))
            return;

        OnHandEnter.Invoke(hand, this);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!CheckHand(other, out XRHand hand))
            return;

        OnHandExit.Invoke(hand, this);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!CheckHand(other, out XRHand hand))
            return;

        OnHandStay.Invoke(hand, this);
    }

    bool CheckHand(Collider other, out XRHand hand)
    {
        hand = other.GetComponentInParent<XRHand>();
        return hand != null;

    }

}
