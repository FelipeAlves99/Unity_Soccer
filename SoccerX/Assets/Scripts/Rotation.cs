using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{

    [SerializeField] private Transform posStart;
    [SerializeField] private Image arrowImg;
    public float zRotation;

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
    }

    private void ArrowPosition()
        => arrowImg.rectTransform.position = posStart.position;

    private void BallPosition()
        => this.gameObject.transform.position = posStart.position;

    private void ArrowRotation()
        => arrowImg.rectTransform.eulerAngles = new Vector3(0, 0, zRotation);

    private void RotationInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))        
            zRotation += 2.5f;
        if (Input.GetKey(KeyCode.DownArrow))        
            zRotation -= 2.5f;
        
    }

}
