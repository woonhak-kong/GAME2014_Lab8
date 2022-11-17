using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    
    public PlatformDirection direction;

    [Range(1f, 20f)]
    public float horizontalDistance = 8.0f;
    [Range(1f, 20f)]
    public float horizontalSpeed = 1.0f;
    [Range(1f, 20f)]
    public float verticalDistance = 0.0f;
    [Range(1f, 20f)]
    public float verticalSpeed = 1.0f;

    private Vector2 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        switch(direction)
        {
            case PlatformDirection.HORIZONTAL:
                transform.position = new Vector3(Mathf.PingPong(horizontalSpeed * Time.time, horizontalDistance) + startPoint.x, startPoint.y, 0.0f);
                break;
            case PlatformDirection.VERTICAL:
                transform.position = new Vector3(startPoint.x, Mathf.PingPong(verticalSpeed * Time.time, horizontalDistance) + startPoint.y, 0.0f);
                break;
            case PlatformDirection.DIAGONAL_UP:
                transform.position = new Vector3(
                    Mathf.PingPong(horizontalSpeed * Time.time, horizontalDistance) + startPoint.x,
                    Mathf.PingPong(verticalSpeed * Time.time, horizontalDistance) + startPoint.y, 0.0f);
                break;
            case PlatformDirection.DIAGONAL_DOWN:
                transform.position = new Vector3(
                    Mathf.PingPong(horizontalSpeed * Time.time, horizontalDistance) + startPoint.x,
                    startPoint.y - Mathf.PingPong(verticalSpeed * Time.time, horizontalDistance), 0.0f);
                break;
        }
    }
}
