using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RestartManager : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject restartPanel;
    public static RestartManager instance;

    private void Start()
    {
        instance = this;
    }
    public void StartRestart()
    {
        canvasGroup.interactable = false;
        restartPanel.SetActive(true);
        canvasGroup.DOFade(0, 1f);
    }

    public void Restart()
    {
        restartPanel.SetActive(false);
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        
        canvasGroup.interactable = true;
        LevelLoader.currentLevel = 1;
        LevelLoader.instance.CreateLevel();

        yield return new WaitForSeconds(0.3f);

        canvasGroup.DOFade(1, 0.2f);
    }
}
