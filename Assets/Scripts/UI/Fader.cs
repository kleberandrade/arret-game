using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    [HideInInspector]
	public bool m_Start = false;
    [HideInInspector]
    public float m_FadeDamp = 0.0f;
    [HideInInspector]
    public string m_FadeScene;
    [HideInInspector]
    public float m_Alpha = 0.0f;
    [HideInInspector]
    public Color m_FadeColor;
    [HideInInspector]
    public bool m_IsFadeIn = false;

    //Set callback
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    //Remove callback
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnGUI ()
    {
        if (!m_Start)
			return;
        
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, m_Alpha);
        
		Texture2D myTex;
		myTex = new Texture2D (1, 1);
		myTex.SetPixel (0, 0, m_FadeColor);
		myTex.Apply ();
        
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), myTex);

        if (m_IsFadeIn)
			m_Alpha = Mathf.Lerp (m_Alpha, -0.1f, m_FadeDamp * Time.deltaTime);
		else
			m_Alpha = Mathf.Lerp (m_Alpha, 1.1f, m_FadeDamp * Time.deltaTime);
        
		if (m_Alpha >= 1 && !m_IsFadeIn)
        {
            SceneManager.LoadScene(m_FadeScene);
            DontDestroyOnLoad(gameObject);		
		}
        else if (m_Alpha <= 0 && m_IsFadeIn)
        {
			Destroy(gameObject);		
		}
	}

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        m_IsFadeIn = true;
    }
}
