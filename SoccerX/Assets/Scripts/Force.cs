using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Force : MonoBehaviour
{

    private Rigidbody2D Ball;
    private float force = 1000f;
    private Rotation rotation;

    // Start is called before the first frame update
    void Start()
    {
        Ball = GetComponent<Rigidbody2D>();
        rotation = GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyForce();
    }

    private void ApplyForce()
    {
        float x = force * Mathf.Cos(rotation.zRotation * Mathf.Deg2Rad);
        float y = force * Mathf.Sin(rotation.zRotation * Mathf.Deg2Rad);

        if (Input.GetKeyUp(KeyCode.Space))
            Ball.AddForce(new Vector2(x, y));
    }
}
