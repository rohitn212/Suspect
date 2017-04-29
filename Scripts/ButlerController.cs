using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButlerController : MonoBehaviour {

	private GUIStyle guiStyle = new GUIStyle ();
	public string message;
	public double qTime;
	private double displayTime;
	bool displayMessage = false;
	public int fontSize;
	private GUIStyle currentStyle = null;
	public int xWidth;
	public int yWidth;
	//public Color textColor = new Color();
	//public Color backColor = new Color;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		displayTime -= Time.deltaTime;
		if (displayTime <= 0.0) {
			displayMessage = false;
		}
	}


	void OnTriggerStay(Collider other){
		if (other.gameObject.CompareTag ("player")) {
			if (Input.GetKeyDown ("space")) {

				displayMessage = true;    
				displayTime = qTime;  
			}
			if (Input.GetKeyDown ("1")) {
				Application.LoadLevel ("Defeat");
			}
			if (Input.GetKeyDown ("2")) {
				Application.LoadLevel ("Defeat");
			}
			if (Input.GetKeyDown ("3")) {
				Application.LoadLevel ("Victory");
			}
			if (Input.GetKeyDown ("4")) {
				Application.LoadLevel ("Defeat");
			}
		}
	}


	void OnGUI () {
		if (displayMessage) {
			/*	guiStyle.fontSize = fontSize;//Update font size
			guiStyle.normal.textColor = Color.black;
			/*GUI newGUI = new GUI ();
			GUI.backgroundColor = Color.white;
			//guiStyle.normal.background = Color.red;
			GUI.Label(new Rect(Screen.width / 2, Screen.height / 3, 400f, 400f), message, guiStyle);

			GUI.backgroundColor = new Color (Screen.width / 2, Screen.height / 3, 400f, 400f);
			GUI.skin.settings.selectionColor = Color.red;
			GUI.Box (new Rect(Screen.width / 2, Screen.height / 3, 100f, 100f), message);
			//GUI.TextArea (new Rect(Screen.width / 2, Screen.height / 3, 400f, 400f), message, guiStyle); */

			InitStyles();
			message = GUI.TextArea (new Rect(Screen.width / 2, Screen.height / 3, xWidth, yWidth), message, currentStyle );

		}
	}
	private void InitStyles()
	{
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.normal.textColor = Color.white;
			currentStyle.alignment = TextAnchor.UpperLeft;
			currentStyle.wordWrap = true;
			currentStyle.fontSize = fontSize; 
			currentStyle.normal.background = MakeTex( 2, 2, Color.black );
		}
	}

	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}

}
