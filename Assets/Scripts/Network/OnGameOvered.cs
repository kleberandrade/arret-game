using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ANET.Networking;

public class OnGameOvered : INetworkBehaviour {

    [SerializeField]
    private GameObject mobileVictoryScreen = null;
    [SerializeField]
    private GameObject mobileDefeatScreen = null;

    [SerializeField]
    private GameObject vrVictoryScreen = null;
    [SerializeField]
    private GameObject vrGameDefeatOverScreen = null;
    [SerializeField]
    private bool debug = true;

    private void OnGUI()
    {
        if (Networking.Instance)
        {
            if (Networking.Instance.Host && debug) // Se for o host pq no nosso caso o host é o quem calcula gameOver
            {
                if (GUI.Button(new Rect(0, 0, 100, 40), "Alien victory."))
                {
                    Networking.Instance.GameOver("vr");
                }

                if (GUI.Button(new Rect(0, (40 * 1) + (10 * 1), 100, 40), "RED victory."))
                {
                    Networking.Instance.GameOver("red");
                }

                if (GUI.Button(new Rect(0, (40 * 2) + (10 * 2), 100, 40), "BLUE victory."))
                {
                    Networking.Instance.GameOver("blue");
                }
            }
        }
    }

    public override void OnGameOver(JSONObject payload)
    {
        Debug.Log("OnGameOver :" + payload);
    }

    public override void OnVictory()
    {
        if (Networking.Instance.Host) // Se for host, é o player VR senão é mobile
        {
            if (vrVictoryScreen)
            {
                vrVictoryScreen.SetActive(true);
            }
        }
        else
        {
            if (mobileVictoryScreen)
            {
                mobileVictoryScreen.SetActive(true);
            }
        }
    }

    public override void OnDefeat()
    {
        if (Networking.Instance.Host) // Se for host, é o player VR senão é mobile
        {
            if (vrGameDefeatOverScreen)
            {
                vrGameDefeatOverScreen.SetActive(true);
            }
        }
        else
        {
            if (mobileDefeatScreen)
            {
                mobileDefeatScreen.SetActive(true);
            }
        }
    }
}
