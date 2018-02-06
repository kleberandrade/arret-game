using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ANET.Networking;

public class ClickToDestroy : INetworkBehaviour {

    public LayerMask layer;

    public void OnMouseDown()
    {
        // Debug.Log("OnMouseDown");
        TransmissionTower tt = GetComponent<TransmissionTower>();
        
        // Se o drone for meu eu destruo.. x) 
        // Esse check era pra ser no sv por garantia, 
        // mas.... Vai aqui mesmo depois a gente melhora xD
        if (tt.Mine) 
        {
            int droneId = tt.DroneId;
            tt.Destroy();
            Networking.Instance.DestroyDrone(droneId);
        }
    }

    public override void OnDroneDestroy(JSONObject payload)
    {
        Debug.Log("OnDroneDestroy: "+payload);
        int droneId = (int) payload.GetField("droneId").n;
        TransmissionTower tt = GetComponent<TransmissionTower>();

        if (tt.DroneId == droneId) // Eh o mesmo drone
        {
            tt.Destroy();
        }
    }
}
