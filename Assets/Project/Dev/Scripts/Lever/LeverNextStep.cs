using UnityEngine;

public class LeverNextStep : LeverBase
{
    [SerializeField] private GameManager gameManager;
    private bool disabled = false;


    protected override void Activate(bool i)
    {
        base.Activate(i);

        if (i && !disabled)
        {
            gameManager.NextLevel();
            disabled = true;
        }
    }
}
