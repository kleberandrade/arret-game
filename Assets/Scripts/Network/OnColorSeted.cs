using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ANET.Networking;

public class OnColorSeted : INetworkBehaviour {

    public override void OnColorSet(JSONObject payload)
    {
        Debug.Log(payload.GetField("color").str.ToString());
        Networking.Instance.PlayerColor = payload.GetField("color").str.ToString();
    }
}
