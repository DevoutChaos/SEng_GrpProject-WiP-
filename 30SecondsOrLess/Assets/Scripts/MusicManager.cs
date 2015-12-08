using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public GameObject MainMenuMusic;
    bool waitPeriod = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("MainMenuMusic(Clone)") == null)
        {
            if (waitPeriod)
            {
                GameObject music;
                music = Instantiate(MainMenuMusic);
                waitPeriod = false;
                StartCoroutine(Hello());
            }  
        }
	}

    IEnumerator Hello()
    {
        yield return new WaitForSeconds(1);
        waitPeriod = true;
    }
}
