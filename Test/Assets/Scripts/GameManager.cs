using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PanelController _panelController;
    [SerializeField] private GameObject _bodyPrefab;
    [SerializeField] private Body _body;

    Vector3 vector3 = new Vector3(15f, 0.85f, 10.09f);

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void ToStartPos()
    {
        _body.transform.position = vector3;
    }

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

    private void OnEnable()
    {
        _body.ReachedFinish += ReloadScene;
        _body.Died += ToStartPos;
    }

    private void OnDisable()
    {
        _body.ReachedFinish -= ReloadScene;
        _body.Died -= ToStartPos;
    }

}
