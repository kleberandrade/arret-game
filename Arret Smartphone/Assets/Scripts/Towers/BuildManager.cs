using UnityEngine;

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
		GameObject go = Instantiate (m_TowerPrefab, position, Quaternion.identity) as GameObject;
		TransmissionTower tower = go.GetComponent<TransmissionTower> ();
		tower.m_Color = color;

		return go.GetComponent<Transform> ();
	}

	public void DestroyTower(Vector3 position)
	{
		if (OnTowerDestroy != null)
			OnTowerDestroy (position);
	}
}
