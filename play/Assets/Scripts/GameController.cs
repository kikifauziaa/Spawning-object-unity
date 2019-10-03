using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public Camera cam;
   public GameObject buah;
   public float timeLeft;
   public Text timerText;
   public GameObject gameOverText;
   public GameObject restartButton;
   public GameObject exitButton;

   private float maxWidth;

   //Use this for initialization
   void Start () {
   	if (cam == null){
   		cam = Camera.main;
   	}
   	Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
   	Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
   	float buahWidth = buah.GetComponent<Renderer>().bounds.extents.x;
   	maxWidth = targetWidth.x - buahWidth;
   	StartCoroutine (Spawn ());
   	UpdateText ();
   }

   void FixedUpdate () {
   	timeLeft -= Time.deltaTime;
   	if (timeLeft < 0){
   		timeLeft = 0;
   	}
   	UpdateText ();
   }

   IEnumerator Spawn () {
   	yield return new WaitForSeconds (2.0f);
   	while (timeLeft > 0){
   		Vector3 spawnPosition = new Vector3 (
   			Random.Range (-maxWidth, maxWidth),
   			transform.position.y,
   			0.0f
   			);
   		Quaternion spawnRotation = Quaternion.identity;
   		Instantiate (buah, spawnPosition, spawnRotation);
   		yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
   	}
   	 yield return new WaitForSeconds (2.0f);
   	 gameOverText.SetActive (true);
   	 yield return new WaitForSeconds (2.0f);
   	 restartButton.SetActive (true);
   	 exitButton.SetActive(true);
   	 yield return new WaitForSeconds (2.0f);
   }

   void UpdateText () {
   	timerText.text = "Time Left:\n" + Mathf.RoundToInt (timeLeft);
   }
}
