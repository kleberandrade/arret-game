using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneAfterTime : MonoBehaviour
{
    public string m_NextScene;

    public float m_Time;

    private void Start()
    {
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(m_Time);
        SceneManager.LoadScene(m_NextScene);
    }
}
