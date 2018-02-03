using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ANET.Networking;

public class OnColorSeted : INetworkBehaviour {

    public override void OnColorSet(JSONObject payload)
    {
        Debug.Log(payload.GetField("color").str.ToString());
        // TO-DO: Atribuir a cor recebida numa variavel global para poder usar posteriormente na cena de Gameplay
    }
}
