using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ANET.Networking;

public class ServerStatus : INetworkBehaviour {

    [SerializeField]
    private Color defaultColor = Color.yellow;
    [SerializeField]
    private Color failedColor = Color.red;
    [SerializeField]
    private Color connectedColor = Color.green;

    [SerializeField]
    private Image serverStatusSign = null;

    private Text text = null;
    private string format = null;

    public override void Start()
    {
        base.Start();
        text = GetComponent<Text> ();
        format = (text != null) ? text.text : "Server Status: {0}";
        text.text = string.Format(format, "Connecting");

        if (Networking.Instance)
        {
            if (Networking.Instance.IO)
            {
                if (Networking.Instance.IO.IsConnected)
                {
                    StatusConnected();
                }
            }
        }
    }

    private void StatusConnected()
    {
        if (text)
        {
            text.text = string.Format(format, "OK");
        }

        if (serverStatusSign)
        {
            serverStatusSign.color = connectedColor;
        }
    }

    public override void OnServerConnected()
    {
        StatusConnected();
    }
}
