using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ANET.Networking;

public class OnDronePlaced : INetworkBehaviour {

    [SerializeField]
    private GameObject m_TowerPrefab = null;

    public override void OnDronePlace(JSONObject payload)
    {
        Vector3 position = new Vector3(
            payload.GetField("x").n,
            payload.GetField("y").n,
            payload.GetField("z").n
        );

        GameObject go = Instantiate(m_TowerPrefab, position, Quaternion.identity) as GameObject;

        go.GetComponent<TransmissionTower>().DroneId = (int) payload.GetField("droneId").n;

        TransmissionTower tower = go.GetComponent<TransmissionTower>();
        if(payload.GetField("color").str.ToString() == "blue")
        {
            tower.m_Color = BuildToClickPoint.Instance.m_BlueColor;
        }
        else
        {
            tower.m_Color = BuildToClickPoint.Instance.m_RedColor;
        }
    }
}
