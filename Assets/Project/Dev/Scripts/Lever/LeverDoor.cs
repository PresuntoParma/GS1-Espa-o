using UnityEngine;

public class LeverDoor : LeverBase
{
    [SerializeField] private Animator door;

    protected override void Activate(bool i)
    {
        base.Activate(i);
        if (i)
        {
            door.SetTrigger("pOpen");

        }

    }

}
