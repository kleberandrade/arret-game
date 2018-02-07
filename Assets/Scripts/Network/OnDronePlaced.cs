using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ANET.Networking;

public class OnDronePlaced : INetworkBehaviour {

    public override void OnDronePlace(JSONObject payload)
    {
        Debug.Log("OnDronePlace");
    }
}
