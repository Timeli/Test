using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PanelController _panelController;

    public void PauseGame()
    {
        _panelController.AppearResumeButton();
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _panelController.AppearPauseButton();
        Time.timeScale = 1;
    }

    
          
}
