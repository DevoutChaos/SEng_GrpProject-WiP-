using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Class to hold the tile set that are 
 * been used in the map
 */
[System.Serializable]
public class TileSet {
	public string Name;
	public List<TileData> tileData;

	public Sprite GetSprite(int index){
		return tileData[index].sprite;
	}

	public bool IsBoxCollider(int index){
		return tileData[index].boxCollider;
	}
}
[System.Serializable]
public class TileData {
	public Sprite sprite;
	public bool boxCollider;
	public bool blank;
}
