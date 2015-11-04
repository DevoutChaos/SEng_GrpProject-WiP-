using UnityEngine;
using System.Collections;

public class Enemy_Health : MonoBehaviour {

	public float max_Health = 100f;
	public float cur_Health = 0f;

	// Use this for initialization
	void Start () {
		cur_Health = max_Health;
		InvokeRepeating ("", 0.5, 0.5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
