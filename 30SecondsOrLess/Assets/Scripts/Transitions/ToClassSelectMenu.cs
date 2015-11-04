using UnityEngine;
using System.Collections;

public class ToClassSelectMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toClassSelect()
    {
        Application.LoadLevel("ClassSelectMenu");
    }
}
