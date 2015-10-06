using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //Declarations
    public Vector2 myLocation;
    public Vector2 mousePosition;
    public Vector2 touchPosition;
    public Vector2 localSelectPos;

    // Use this for initialization
	void Start () {
        myLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            Debug.DrawLine(this.transform.position, touchPosition);
            Debug.Log("My Location: " + myLocation + "TouchPos: " + touchPosition);

        }
        else if (Input.GetButton("Fire1"))
        {
            mousePosition = Input.mousePosition;
            localSelectPos = mousePosition;
            Debug.DrawLine(myLocation, localSelectPos, Color.yellow, 2, true);
            Debug.Log("My Location: " + myLocation + "MousePos: " + localSelectPos);
        }
	}
}
