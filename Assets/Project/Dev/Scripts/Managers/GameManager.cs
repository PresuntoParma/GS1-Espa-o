using System.Collections;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scene Manager")]
    [SerializeField] private LoadSceneManager sceneManager;

    [Header("Step 1")]
    [SerializeField] private float maxTime;

    private float currentTime;
    private Coroutine currentTimer;

    [Header("Step 2")]
    [SerializeField] private Animator[] doorsStep2;
    [SerializeField] private GameObject[] wires;

    private int repairedWires = 0;


    [Header("Step 3")]
    [SerializeField] private Animator[] doorsStep3;


    private int currentStep = 1;

    private void Start()
    {
        currentTime = maxTime;
        currentTimer = StartCoroutine(Timer());
        AudioManager.Instance.PlayGameplayMusic();
        AudioManager.Instance.PlayAmbience();
        AudioManager.Instance.StartAlarm();
    }

    public void NextLevel()
    {
        //Avança a etapa do level
        if (currentStep == 1) StopCoroutine(currentTimer);
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
        sceneManager.LoadScene("SCN_Level01");
    }

    private IEnumerator Timer()
    {
        currentTime -= 1;
        yield return new WaitForSeconds(1f);
        if (currentTime <= 0) GameOverExplosion();
        currentTimer = StartCoroutine(Timer());
    }

    private void GameOverExplosion()
    {
        //Explodir dando game over ain mini goon
        sceneManager.LoadScene("SCN_Level01");
    }
}
