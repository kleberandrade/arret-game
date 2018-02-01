using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ANET.Networking;

public class ClickToPlayWithVR : MonoBehaviour {

    [SerializeField]
    private GameObject gameModePanel = null;

    [SerializeField]
    private GameObject preloadPanel = null;

    public void Click()
    {
        gameModePanel.SetActive(false);
        preloadPanel.SetActive(true);
        Networking.Instance.MakeMatch(GameMode.VR);
    }
}
