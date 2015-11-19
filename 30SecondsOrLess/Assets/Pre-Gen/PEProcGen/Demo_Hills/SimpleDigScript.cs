using UnityEngine;
using System.Collections;

public class SimpleDigScript : MonoBehaviour {
	public LayerMask layermask;
	public Transform player;
	public float digDistance = 2f;

	void Update () {
		if(Input.GetMouseButton(0)){
			Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float distance = Vector2.Distance(clickPosition,player.position);
			if(distance < digDistance){
				RaycastHit2D hit = Physics2D.Linecast (clickPosition, clickPosition,layermask);
				if (hit.collider != null){
					hit.transform.gameObject.SetActive(false);
				}
			}
		}
	}
}
