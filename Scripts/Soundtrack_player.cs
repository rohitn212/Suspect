using UnityEngine;
using System.Collections;

public class Soundtrack_player : MonoBehaviour {

    public static Soundtrack_player instance = null;

    void Awake ()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }
}
