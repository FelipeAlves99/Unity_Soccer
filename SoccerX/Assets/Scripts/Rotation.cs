using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{

    [SerializeField] private Transform posStart;
    [SerializeField] private Image arrowImg;
    public float zRotation;
    public bool canRotate = false;
    public bool canKick = false;

    // Start is called before the first frame update
    void Start()
    {
        ArrowPosition();
        BallPosition();
    }

    // Update is called once per frame
    void Update()
    {
        ArrowRotation();
        RotationInput();
        LimitsRotation();
    }

    private void ArrowPosition()
        => arrowImg.rectTransform.position = posStart.position;

    private void BallPosition()
        => this.gameObject.transform.position = posStart.position;

    private void ArrowRotation()
        => arrowImg.rectTransform.eulerAngles = new Vector3(0, 0, zRotation);

    private void RotationInput()
    {
        if (canRotate)
        {            
            float moveY = Input.GetAxis("Mouse Y");

            if (zRotation < 90)
                if (moveY > 0)
                    zRotation += 2.5f;

            if (zRotation > 0)
                if (moveY < 0)
                    zRotation -= 2.5f;
        }

    }

    private void LimitsRotation()
    {
        if (zRotation >= 90)
            zRotation = 90;

        if (zRotation <= 0)
            zRotation = 0;

    }

    private void OnMouseDown()
    {
        canRotate = true;
    }

    private void OnMouseUp()
    {
        canRotate = false;
        canKick = true;
    }
}
