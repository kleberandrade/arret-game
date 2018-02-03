using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using ANET.Networking;

public class OnJoinedRoom : INetworkBehaviour {

    [SerializeField]
    private Text preloadTextMessage = null;

    public override void OnJoinRoom(JSONObject payload)
    {
        // Se start game 
        if (payload.GetField("startgame").b)
        {
            if (preloadTextMessage)
                preloadTextMessage.text = "GAME STARTING";

            SceneManager.LoadSceneAsync("Gameplay");
        }
    }


}
