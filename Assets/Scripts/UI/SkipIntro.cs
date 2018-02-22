using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour {

    [SerializeField]
    private string m_NextScene = "";

    public void SkipIntroScene()
    {
        SceneManager.LoadScene(m_NextScene);
    }
}
