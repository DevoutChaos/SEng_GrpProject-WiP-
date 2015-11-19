using UnityEngine;
using System.Collections;

public class TerrainMap : MonoBehaviour {
	private int [,] map;
	public int mapWidth=30;
	public int mapHeight=20;

	public int [,] Map{
		get{
			if(map == null) map = new int[mapWidth,mapHeight];
			return map;
		}
		set{
			map = value;
		}
	}

	public void Reset(){
		map = null;
	}
}
