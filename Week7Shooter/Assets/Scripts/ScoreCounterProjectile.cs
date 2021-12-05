using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterProjectile : MonoBehaviour
{
    // This script belongs at your gameobject tagged "enemy".

    public Text scoreBoard;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile" || other.gameObject.tag == "Projectile")
        {
            if (scoreBoard.text.Length < 9) // single digit score
            {
                // "Score: " + (The current single digit score at the end of the string + 1)
                scoreBoard.text = "Score: " + (Int32.Parse(scoreBoard.text.Substring(scoreBoard.text.Length -1 ,1)) + 1).ToString();
            }
            else if (scoreBoard.text.Length < 10) // double digit score
            {
                scoreBoard.text = "Score: " + (Int32.Parse(scoreBoard.text.Substring(scoreBoard.text.Length -2, 2)) + 1).ToString();
            }
            else if (scoreBoard.text.Length < 11) // triple digit score
            {
                scoreBoard.text = "Score: " + (Int32.Parse(scoreBoard.text.Substring(scoreBoard.text.Length - 3, 3)) + 1).ToString();
            }
            else
            {
                scoreBoard.text = "Infinity score !!!";
            }
        }
    }
}
