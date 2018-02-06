using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ANET.Networking;

public class GameplayLoaded : INetworkBehaviour {

    override public void Start()
    {
        base.Start();
        if(Networking.Instance)
            Networking.Instance.GameplaySceneLoaded(); // notifica o sv que terminei de carregar a cena de gameplay
    }

    public override void OnGameplayLoaded(JSONObject payload)
    {
        // Se o game comecou
        if (payload.GetField("start").b)
        {
            Debug.Log("Bugiga!");
            TransmissionTower.IdReset(); // reseta os ids dos drones pois comecou nova partida
            // TO-DO: Fazer alguma coisa pra indicar que o game comecou
        }
    }
}
