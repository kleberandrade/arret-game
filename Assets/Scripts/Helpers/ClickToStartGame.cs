using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToStartGame : MonoBehaviour {

    private bool m_Pressed = false;

    [SerializeField]
    private GameObject menuPanel        = null;

    [SerializeField]
    private GameObject gameModePanel    = null;

    public void Click()
    {
        menuPanel.SetActive(false);
        gameModePanel.SetActive(true);
    }

    public void OldClick(string nextScene)
    {
        if (m_Pressed)
            return;

        m_Pressed = true;
        SceneManager.LoadScene(nextScene);
    }
}
