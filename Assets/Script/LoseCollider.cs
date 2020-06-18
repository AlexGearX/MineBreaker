using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;




public class LoseCollider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HealthText;
    [SerializeField] int NumberOfHeart = 3;
    Ball ball;
    int LoseBall = 0;

    void Start()
    {
        HealthText.text = NumberOfHeart.ToString();
        ball = FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            LoseBall++;

            if (NumberOfHeart == LoseBall)
            {
                HealthText.text = (" ").ToString();
                SceneManager.LoadScene("Game Over"); 
            }
            else
            {
                HealthText.text = (NumberOfHeart - LoseBall).ToString();
                ball.backHasStared();


            }
        }
        else if (collision.gameObject.tag == "Breakable")
        {         
            FindObjectOfType<Level>().BlockDestroy();
            Destroy(collision.gameObject);
        }
    }
}

