using UnityEngine;

public class LeverNextStep : LeverBase
{
    [SerializeField] private GameManager gameManager;


    protected override void Activate(bool i)
    {
        base.Activate(i);

        if (i)
            gameManager.NextLevel();
    }
}
