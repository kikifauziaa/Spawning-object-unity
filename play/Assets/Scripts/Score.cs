using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Score : MonoBehaviour
{
	public Text scoreText;
	public int buahValue;

	private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore ();
    }

    void OnTriggerEnter2D () {
    	score += buahValue;
    	UpdateScore ();
    }

   void UpdateScore () {
   	scoreText.text = "Score:\n" + score;
   }
}
