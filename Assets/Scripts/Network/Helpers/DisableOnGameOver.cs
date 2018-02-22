using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ANET.Networking;

public class DisableOnGameOver : INetworkBehaviour {

    public override void OnGameOver(JSONObject payload)
    {
        gameObject.SetActive(false);
    }
}
