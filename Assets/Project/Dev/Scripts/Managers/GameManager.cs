using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator[] doorsStep2;
    [SerializeField] private Animator[] doorsStep3;
    private int currentStep = 1;

    public void NextLevel()
    {
        //Avança a etapa do level
        currentStep++;
        UnlockDoors();
    }

    private void UnlockDoors()
    {
        //Checa qual a etapa e desbloqueia as portas para continuar o level
        switch (currentStep)
        {
            case 2:
                for (int i = 0; i < doorsStep2.Length; i++)
                {
                    doorsStep2[i].SetTrigger("pOpen");
                }
                break;
            case 3:
                for (int i = 0; i < doorsStep3.Length; i++)
                {
                    doorsStep3[i].SetTrigger("pOpen");
                }
                break;
        }
    }
}
