using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour

    
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        { 
            SceneManager.LoadScene("Game Over"); 
        }
        else if (collision.gameObject.tag == "Breakable")
        {         
            FindObjectOfType<Level>().BlockDestroy();
            Destroy(collision.gameObject);
        }
    }
}

