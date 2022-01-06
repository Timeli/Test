using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PanelController _panelController;
    [SerializeField] private GameObject _repeatPrefab;
    [SerializeField] private GameObject _bodyPrefab;

    Vector3 startPos = new Vector3(15f, 0.85f, 10.09f);
    private Body _body;
    private RepeatBody _repeatBody;

    private void Start()
    {
        InitBody();
    }

    private void FixedUpdate()
    {
        if (_body != null)
        {
            if (_body.IsDied)
                InitBody();
            if (_body.IsFinish)
                InitRepeatBody();
        }
        if (_repeatBody != null)
        {
            if (_repeatBody.IsFinish)
                ReloadScene();
        }
    }

    private void InitRepeatBody()
    {
        var repeatBody = Instantiate(_repeatPrefab, startPos, Quaternion.identity);
        _repeatBody = repeatBody.GetComponent<RepeatBody>();
    }

    private void InitBody()
    {
        var body = Instantiate(_bodyPrefab, startPos, Quaternion.identity);
        _body = body.GetComponent<Body>();
    }

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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

   

}
