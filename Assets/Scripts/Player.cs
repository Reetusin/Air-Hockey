using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;

    private Camera cam;
    private Vector3 worldPos;
    private Rigidbody2D rb;
    private float halfScreenX;

    void Start()
    {
        cam = Camera.main;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        halfScreenX = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;
    }

    
    void Update()
    {
        worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        worldPos.x = Mathf.Clamp(worldPos.x, halfScreenX, Mathf.Infinity);
        //transform.position = worldPos;
    }

    //physics update
    private void FixedUpdate()
    {
        //MoveTowards - moves a point current towards target point
        var destination = Vector3.MoveTowards(transform.position, worldPos, speed * Time.fixedDeltaTime);

        rb.MovePosition(destination);
    }
}
