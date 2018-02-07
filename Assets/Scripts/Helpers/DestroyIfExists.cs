using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SocketIO;
using ANET.Networking;

public class DestroyIfExists : MonoBehaviour 
{
	private void Start () 
	{
        if (Networking.Instance)
        {
            if (Networking.Instance.IO)
            {
                Destroy(gameObject);
            }
            else
            {
                Networking.Instance.IO = GetComponent<SocketIOComponent> ();
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
