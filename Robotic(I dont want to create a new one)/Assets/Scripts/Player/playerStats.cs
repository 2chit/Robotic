using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStats : MonoBehaviour
{
    public short health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "bullet")
        {
            this.health -= collision.gameObject.GetComponent<Bullet>().damage;
            Debug.Log($"Health {this.health}");
            if(this.health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}