using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _resumePanel;

    public void AppearResumeButton()
    {
        _pausePanel.SetActive(false);
        _resumePanel.SetActive(true);
        StartCoroutine(DimmingScene());
    }

    public void AppearPauseButton()
    {
        _resumePanel.SetActive(false);
        _pausePanel.SetActive(true);
    }

    private IEnumerator DimmingScene()
    {
        Image image = _resumePanel.GetComponent<Image>();
        float delta = 0.8f * 1 / 60f;
        float alpha = 0;
        for (int i = 0; i < 60; i++)
        {
            alpha += delta;
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
