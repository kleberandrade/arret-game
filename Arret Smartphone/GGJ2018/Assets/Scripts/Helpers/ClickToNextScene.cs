using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToNextScene : MonoBehaviour {

    private bool m_Pressed = false;

    public void Click(string nextScene)
    {
        if (m_Pressed)
            return;

        m_Pressed = true;
        SceneManager.LoadScene(nextScene);
    }
}
