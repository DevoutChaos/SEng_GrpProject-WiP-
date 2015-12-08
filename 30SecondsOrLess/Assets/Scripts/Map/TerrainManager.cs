using UnityEngine;
using System.Collections;
/**
 *Manages the map generation scene, responsible for making the map and putting 
 *the player and enemy on the map
 */
public class TerrainManager : MonoBehaviour {
	public Transform terrain;
	public Transform player; //the player 
	public Transform enemy; //the enemy
	public int noOfenemies; //the number of enemies 
	public GameObject gameMaster; // the game master responsible for deciding winner on each level
	public GameMaster gM; 
	
	void Awake(){
	
	}
	//runs at the start of each level
	void Start () {
		//generate the cave 
		GenerateCave();

		noOfenemies = 1;

		if (gameMaster == null) {
			gameMaster = GameObject.FindGameObjectWithTag ("GM");
		} 
		if (gameMaster != null) {
			gM = gameMaster.GetComponent<GameMaster>();
		}
		if (gM != null) {
			gM.enemiesRemaining = noOfenemies;
		}
	
	}

	//Generate a cave for the map 
	public void GenerateCave(){
		CaveGenerator caveGenerator = terrain.GetComponent<CaveGenerator> ();
		caveGenerator.Generate ();
	

		CaveGenerator.Point? point = caveGenerator.FindNearestSpace (caveGenerator.CurrentMap, new CaveGenerator.Point (0, 0));//Find nearest clear point to bottom corner of map
		if (point.HasValue){
			player.position = new Vector3 (point.Value.x, point.Value.y, 0) + terrain.position;//Terrain transform may not be at zero so map coordinates will be offset by its position
		}	
		ArrayList points = caveGenerator.FindSpotForEnemy(caveGenerator.CurrentMap);
		int size = points.Count;
		int loc = Random.Range(0, size);
		CaveGenerator.Point? enemLocation = (CaveGenerator.Point)points[loc];
		enemy.position = new Vector3 (enemLocation.Value.x, enemLocation.Value.y, 0) + terrain.position;

	
	}
}


