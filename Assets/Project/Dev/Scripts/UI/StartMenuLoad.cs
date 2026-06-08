using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuLoad : MonoBehaviour
{
    [Header("Logo Screen")]
    [SerializeField] private Image logoScreenObj;
    [SerializeField] private Image logoObj;
    [SerializeField] private float fadeInOutTime;

    private void Start()
    {
        ShowLogo();
        Time.timeScale = 1f;
        AudioManager.Instance.StopAlarm();
    }

    private void ShowLogo()
    {
        StartCoroutine(FadeIn(logoObj, 1f));
        StartCoroutine(FadeOut(logoObj, fadeInOutTime));
        StartCoroutine(HideObject(logoScreenObj.gameObject, (fadeInOutTime * 2) + 2));
    }

    private IEnumerator FadeIn(Image img, float d = 0)
    {
        yield return new WaitForSeconds(d);
        float alpha = 0f;
        for (float i = 0; i < fadeInOutTime; i += Time.deltaTime)
        {
            alpha += (Time.deltaTime * (255/fadeInOutTime));
            img.color = new Color(255 / 255, 255 / 255, 255 / 255, alpha / 255);
            yield return null;
        }
    }

    private IEnumerator FadeOut(Image img, float d = 0)
    {
        yield return new WaitForSeconds(d);
        float alpha = 255f;
        for (float i = 0; i < fadeInOutTime; i += Time.deltaTime)
        {
            alpha -= (Time.deltaTime * (255 / fadeInOutTime));
            print(alpha);
            img.color = new Color(255 / 255, 255 / 255, 255 / 255, alpha / 255);
            yield return null;
        }
    }

    private IEnumerator HideObject(GameObject obj, float d = 0)
    {
        yield return new WaitForSeconds(d);
        obj.SetActive(false);
    }
}
