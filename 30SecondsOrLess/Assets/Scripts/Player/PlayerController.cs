using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //Declarations
    public Vector2 myLocation;
    public Vector2 mousePosition;
    public Vector2 touchPosition;
    public Vector2 worldPosition;
    public Vector2 screenPos;
    public float step;
    public string moveDirection;
    bool buttonPress = false;

    // Use this for initialization
	void Start () {
        myLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        myLocation = transform.position;
        step = Time.deltaTime;
        screenPos.x = ((Screen.width / 2) + myLocation.x);
        screenPos.y = ((Screen.height / 2) + myLocation.y);
        /*
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            worldPosition.x = (touchPosition.x - screenPos.x);
            worldPosition.y = (touchPosition.y - screenPos.y);
            Debug.DrawLine(myLocation, worldPosition, Color.yellow);
            Debug.Log("My Location: " + screenPos + "MousePos: " + worldPosition);
        }
         * */
        if (Input.GetButton("Fire1") )
        {
            mousePosition = Input.mousePosition;
            worldPosition.x = (mousePosition.x - screenPos.x);
            worldPosition.y = (mousePosition.y - screenPos.y);
            Debug.DrawLine(myLocation, worldPosition, Color.yellow);
            Debug.Log("My Location: " + screenPos + "MousePos: " + worldPosition);
            transform.position = Vector2.MoveTowards(transform.position, worldPosition, step);
        }
       
        
	}
    public void ButtonPress()
    {
        
        Debug.Log("Hey");
    }
}
