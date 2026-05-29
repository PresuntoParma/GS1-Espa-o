using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Step 2")]
    [SerializeField] private Animator[] doorsStep2;
    [SerializeField] private GameObject[] wires;

    private int repairedWires = 0;


    [Header("Step 3")]
    [SerializeField] private Animator[] doorsStep3;


    private int currentStep = 1;

    public void NextLevel()
    {
        //Avança a etapa do level
        currentStep++;
        UnlockDoors();
    }

    public void WireRepaired()
    {
        repairedWires++;

        if (repairedWires == wires.Length)
            NextLevel();
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
            case 4:
                FinishLevel();
                break;
        }
    }

    private void FinishLevel()
    {
        //Ir para tela de fim de jogo
        SceneManager.LoadScene("SCN_Level01");
    }
}
