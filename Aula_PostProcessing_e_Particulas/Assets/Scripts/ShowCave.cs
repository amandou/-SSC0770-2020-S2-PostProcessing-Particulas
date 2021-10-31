using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShowCave : MonoBehaviour
{
    public GameObject cave;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cave.GetComponent<Tilemap>().color = new Color(255,255,255,0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cave.GetComponent<Tilemap>().color = new Color(255, 255, 255, 255);
        }
    }

 /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cave.GetComponent<Tilemap>().color = new Color(255, 255, 255, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cave.GetComponent<Tilemap>().color = new Color(255, 255, 255, 255);
        }
    }*/
}
