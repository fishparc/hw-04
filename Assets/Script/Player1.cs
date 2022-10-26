using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{ 
    CharacterController controller;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
             
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        controller.Move( dir * speed * Time.deltaTime );
     
     if (dir.magnitude > 0.1f)
        {
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
             Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
             transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
    }
}
