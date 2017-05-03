using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voicemail : MonoBehaviour {

	public AudioClip voice;
	private float countdown = 31f;
	private bool voiceMail = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (voiceMail) {
			if (countdown > 0) {
				print (countdown);
				countdown -= Time.deltaTime;
			} else {
				GameObject.FindGameObjectWithTag ("soundtrack").GetComponent<AudioSource> ().Play ();
				countdown += 31f;
				voiceMail = false;
			}
		}
	}

	void addAndPlayAudioClip(AudioClip clip, float volume)	{
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = clip;
		this.GetComponent<AudioSource>().volume = volume;	
		this.GetComponent<AudioSource>().Play();
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.CompareTag ("player")) {
			if (Input.GetKeyDown ("space")) {
				GameObject.FindGameObjectWithTag ("soundtrack").GetComponent<AudioSource> ().Pause ();
				voiceMail = true;
				addAndPlayAudioClip (voice, 0.2f);
			}
		}
	}
}
