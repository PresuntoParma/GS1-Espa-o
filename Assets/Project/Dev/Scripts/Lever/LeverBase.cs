using UnityEngine;

public class LeverBase : MonoBehaviour
{
    private HingeJoint hinge;

    public bool active;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    private void Update()
    {
        CheckRotation();
        print(hinge.limits.max - 15f);

        if (active)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    protected virtual void CheckRotation()
    {
        Activate(hinge.angle >= hinge.limits.max - 15f);
    }

    protected virtual void Activate(bool i)
    {
        active = i;
    }
}
