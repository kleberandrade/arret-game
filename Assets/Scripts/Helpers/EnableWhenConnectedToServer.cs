using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ANET.Networking;

public class EnableWhenConnectedToServer : INetworkBehaviour {

    public override void Start()
    {
        base.Start();
        if (Networking.Instance)
        {
            if (Networking.Instance.IO.IsConnected)
            {
                GetComponent<Button>().interactable = true;
            }
        }
    }

    public override void OnServerConnected()
    {
        GetComponent<Button>().interactable = true;
    }
}
