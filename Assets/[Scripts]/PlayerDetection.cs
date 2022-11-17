using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public LayerMask CollisionLayerMask;
    public bool playerDetected;
    public bool LOS;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerBehavior>().transform;
        LOS = false;
        playerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            LOS = Physics2D.Linecast(transform.position, playerTransform.position, CollisionLayerMask);
            
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerDetected = false;
            LOS = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = playerDetected ? Color.red : Color.green;

        Gizmos.DrawWireSphere(transform.position, 15.0f);

        if (LOS)
        {
            Gizmos.DrawLine(transform.position, playerTransform.position);
        }

    }
}
