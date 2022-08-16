using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    //[SerializeField] TMP_Text scoreText;

    AudioSource aS;
    CamMover scoreInc;

    public int score = 0;

    private void Start()
    {
        scoreInc = FindObjectOfType<CamMover>();
        aS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            scoreInc.IncreaseScore();
            aS.Play();

        }
        
        //Play a sound
    }

    void LoadRewardLevel()
    {
        // if (score > 10) { } put in update
        //Might make game too big
        SceneManager.LoadScene(2);
    }

}
