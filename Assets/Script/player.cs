using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject bullet; 
    public GameObject firePoint; 
  CharacterController controller;
    public float speed = 5f;
        private float passedTime = 0; // 用來累加時間的變數
    private float timerInterval = 0.5f; // 設定觸發間隔
    void Start()
    {  
        controller = GetComponent<CharacterController>();
    }

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
             transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.2f);
        }
        passedTime += Time.deltaTime;
     if (Input.GetKey(KeyCode.Space))
        {
             if (passedTime >= timerInterval)
        {
            // 執行要觸發的內容.....
Instantiate(bullet, firePoint.transform.position, transform.rotation);

            // 把經過時間歸零（為了讓之後還會反覆觸發）
            passedTime = 0;
        }
            
        }

    
    }
}

