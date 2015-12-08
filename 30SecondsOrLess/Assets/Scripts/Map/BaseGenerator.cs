using UnityEngine;
using System.Collections;

/**
 * This class creates the base for the map to be generated
 * 
 */
public class BaseGenerator : MonoBehaviour {
	public bool renderImmediate = true;
	private TerrainMap terrainMap = null;



	public int MapWidth{
		get{
			if(terrainMap == null) terrainMap = GetComponent<TerrainMap>();
			return terrainMap.Map.GetLength(0);
		}
	}

	public int MapHeight{
		get{
			if(terrainMap == null) terrainMap = GetComponent<TerrainMap>();
			return terrainMap.Map.GetLength(1);
		}
	}

	public int [,] CurrentMap {
		get{
			if(terrainMap == null) terrainMap = GetComponent<TerrainMap>();
			return terrainMap.Map;
		}
		set{
			if(terrainMap == null) terrainMap = GetComponent<TerrainMap>();
			terrainMap.Map = value;
		}
	}

	public void Render(){
		TerrainRenderer terrainRenderer = GetComponent<TerrainRenderer>();
		terrainRenderer.ClearImmediate();
		terrainRenderer.Render();
	}


}
