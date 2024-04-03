using UnityEngine;

public class ExampleInteractor : MonoBehaviour
{
    [SerializeField]
    Material[] materials;   


    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void HandEnter(XRHand hand, XRInteractor interactor)
    {
        rend.material = materials[1];
    }
    public void HandExit(XRHand hand, XRInteractor interactor)
    {
        rend.material = materials[0];
    }
    public void HandStay(XRHand hand, XRInteractor interactor)
    {
        rend.material = hand.triggerDown ? materials[2] : materials[1];
    }
}
