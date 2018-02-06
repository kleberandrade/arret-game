using UnityEngine;

using ANET.Networking;

public class BuildManager : MonoBehaviour 
{
	public delegate void TowerDestroyAction(Vector3 position);
	public static event TowerDestroyAction OnTowerDestroy;

	public static BuildManager Instance;

	public GameObject m_TowerPrefab;

	private void Awake()
	{
		if (Instance != null) {
			Debug.LogError ("BuildManager: existe mais de uma instancia ativa.");
			return;
		}

		Instance = this;
	}
		
	public Transform GetTower(Vector3 position, Color color)
	{
        
        position = Networking.TrunVec(position); // Trunca antes de colocar o drone no mapa assim quando networkar não tem problema do float mutar ao trafegar pela rede
		GameObject go = Instantiate (m_TowerPrefab, position, Quaternion.identity) as GameObject;

        if(Networking.Instance.PlayerColor == "blue")
        {
            go.GetComponent<TransmissionTower>().DroneId = TransmissionTower.LastBlueId += 2;
        }
        else
        {
            go.GetComponent<TransmissionTower>().DroneId = TransmissionTower.LastRedId += 2;
        }

        TransmissionTower tower = go.GetComponent<TransmissionTower> ();
		tower.m_Color = color;

		return go.GetComponent<Transform> (); // Retorna o transform
	}

	public void DestroyTower(Vector3 position)
	{
		if (OnTowerDestroy != null)
			OnTowerDestroy (position);
	}
}
