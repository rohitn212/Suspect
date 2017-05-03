using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {
	public Text textArea;
	public Text flashingText;
	public string[] strings;
	public float speed = 0.1f;
	public AudioClip type;
	public AudioClip bell;

	int stringIndex = 0;
	int characterIndex = 0; 
	// Use this for initialization
	void Start () {
		StartCoroutine(DisplayTimer());
		StartCoroutine(BlinkText());
	}

	IEnumerator BlinkText()	{
		while(true)	{
			flashingText.text = "";
			yield return new WaitForSeconds(.8f);
			flashingText.text = "Press space to skip";
			yield return new WaitForSeconds(.8f);
		}
	}

	IEnumerator DisplayTimer()	{
		while(true)	{
			yield return new WaitForSeconds(speed);
			if(characterIndex > strings[stringIndex].Length)
			{
				continue;
			}
			textArea.text = strings[stringIndex].Substring(0, characterIndex);
			characterIndex++;
			addAndPlayAudioClip(type, 0.1f);
		}
	}

	void addAndPlayAudioClip(AudioClip clip, float volume)	{
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = clip;
		this.GetComponent<AudioSource>().volume = volume;	
		this.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(stringIndex > 10)	{
			Application.LoadLevel("livingroom");
		}
		if(Input.GetKeyDown(KeyCode.Space))	{
			if(characterIndex < strings[stringIndex].Length)	{
				characterIndex = strings[stringIndex].Length;
				addAndPlayAudioClip(bell, 0.3f);
			}
			else if(stringIndex < strings.Length)	{
				stringIndex++;
				characterIndex = 0;
			}
		}
	}
}
