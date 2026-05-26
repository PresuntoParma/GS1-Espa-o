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
        print(hinge.angle);
    }

    protected virtual void CheckRotation()
    {
        Activate(hinge.angle >= 75f);
    }

    protected virtual void Activate(bool i)
    {
        active = i;
    }
}
