using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Force : MonoBehaviour
{

    private Rigidbody2D Ball;
    public float force = 0;
    private Rotation Rotation;
    public Image ArrowEnergy;

    // Start is called before the first frame update
    void Start()
    {
        Ball = GetComponent<Rigidbody2D>();
        Rotation = GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlForce();
        ApplyForce();
    }

    private void ApplyForce()
    {
        float x = force * Mathf.Cos(Rotation.zRotation * Mathf.Deg2Rad);
        float y = force * Mathf.Sin(Rotation.zRotation * Mathf.Deg2Rad);

        if (Rotation.canKick)
        {
            Ball.AddForce(new Vector2(x, y));
            Rotation.canKick = false;
        }
    }
    

    private void ControlForce()
    {
        if (Rotation.canRotate)
        {
            float moveX = Input.GetAxis("Mouse X");

            if (moveX < 0)
            {
                ArrowEnergy.fillAmount += 1 * Time.deltaTime;
                force = ArrowEnergy.fillAmount * 1000;
            }

            if (moveX > 0)
            {
                ArrowEnergy.fillAmount -= 1 * Time.deltaTime;
                force = ArrowEnergy.fillAmount * 1000;
            }
        }
    }
}
