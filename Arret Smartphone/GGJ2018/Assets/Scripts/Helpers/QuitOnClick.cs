using UnityEngine;

public class QuitOnClick : MonoBehaviour
{
	private bool m_Pressed = false;

    public void Quit()
    {
		if (m_Pressed)
			return;

		m_Pressed = true;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
