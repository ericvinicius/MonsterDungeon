using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rig;

    public float direction_x;
    public float direction_y;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direction_x = Input.GetAxis("Horizontal");
        direction_y = Input.GetAxis("Vertical");

        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void FixedUpdate() {
        rig.velocity = new Vector2(direction_x * speed, direction_y * speed);
        //rig.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
