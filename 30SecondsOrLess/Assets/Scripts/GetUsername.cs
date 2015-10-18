using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetUsername : MonoBehaviour {

    // For initialization
    void Start()
    {
        // Gets the input field component and stored in a variable
        var input = gameObject.GetComponent<InputField>();

        // Create a new submit event and stored in a variable
        var se = new InputField.SubmitEvent();

        // Attach a listener that will call the method whenever the user
        // is done inputting text on the input field
        se.AddListener(SubmitNameAndScore);
        input.onEndEdit = se;       
    }

    // Prints out the username and the score of 0 (hard coded) on
    // the console for testing purposes.
    private void SubmitNameAndScore(string arg0)
    {
        Debug.Log(arg0 + " 0");
    }
}
