using UnityEngine;

public class LeverBase : MonoBehaviour
{
    protected HingeJoint hinge;

    public bool active;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    private void Update()
    {
        CheckRotation();

        if (active)
        {
            //Faz com que assim que ativa, a alavanca deixe de ser "Interagivel" e não possa ser desativada
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    protected virtual void CheckRotation()
    {
        //Faz a checagem para ver se a alavanca está girada o suficiente para ser ativada
        Activate(hinge.angle >= hinge.limits.max - 10);
    }

    protected virtual void Activate(bool i)
    {
        active = i;
    }
}
