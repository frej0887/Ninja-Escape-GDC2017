using UnityEngine;
using UnityEngine.Audio;
using System.Collections;


public class Lydscript : MonoBehaviour {

	//Array variable kan indeholde flere lydklip
	public AudioClip[] jump;
	//Lyd Klip Variable, kan indeholde et lydklip i sætter 
	public AudioClip Walk;
	//Definere Audio Source vi kalder den Audio(Husk  at sætte den i inspector)
	public AudioSource Audio;

	//Variable der styre volumen kan aendres i inspector
	public float volume;

	//Variabler der styrer maximum og minimum pitch ved hvert hop
	public float minWalkingPitch;
	public float maxWalkingPitch;

	// Use this for initialization
	void Start () {
	
	}
	//Hop funktionen husk den skal vaere public
	public void JumpSound (){
		//vi saetter vores volume variable til den onskede maengde
		volume = 1.0f;
		//Vi vaelger et random tal mellem 0 og antallet af lyde i vores array
		int lyd = Random.Range (0, jump.Length);
		//vi saetter volume niveaut
		Audio.volume = volume;
		//saetter lyd klippet i vores audiosource til, husk det her er et array og derfor skal have [] samt variable indeni
		Audio.clip = jump[lyd];
		//afspiller lyden
		Audio.Play ();
	}

	//Vores gaa lyd funnktion husk den skal vaere public
	public void WalkSound(){
		//vi tjekker om lyden allerede bliver spillet, hvis den gor saa sker den igen ting
		if (!Audio.isPlaying) {
			//hvis den ikke afspiller en lyd saa saetter vi volume niveauet ned
			volume = 0.2f;
			Audio.volume = volume;
			//herefter laver vi en random pitch vaerdi udfra vores variabler
			Audio.pitch = Random.Range (minWalkingPitch, maxWalkingPitch);
			//Vi saetter det rigtige klip og afspiller
			Audio.clip = Walk;
			Audio.Play ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
