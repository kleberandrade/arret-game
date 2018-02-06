using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using ANET.Networking;

public class OnGameAborted : INetworkBehaviour {

    [SerializeField]
    private GameObject connectionLostScreen = null;

	override public void OnGameAbort(JSONObject payload)
    {
        if (connectionLostScreen)
        {
            connectionLostScreen.transform.Find("Message").GetComponent<Text>().text = payload.GetField("errormsg").str;
            connectionLostScreen.SetActive(true);
        }

        SceneManager.LoadSceneAsync("MainMenu");
    }

    public override void OnServerDisconection()
    {
        connectionLostScreen.transform.Find("Message").GetComponent<Text>().text = "Something went wrong! Connection lost. Try again in a few minutes.";
        connectionLostScreen.SetActive(true);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
