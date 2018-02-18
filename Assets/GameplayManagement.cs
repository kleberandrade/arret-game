using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManagement : MonoBehaviour {

	public void OnContinueCliked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        this.enabled = false;
    }
}
