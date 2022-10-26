using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCon : MonoBehaviour
{
    
    Rigidbody rb;
   float lifeTime = 0;
    // Start is called before the first frame update
    void Start()
    {  
     rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         transform.parent = null;
     lifeTime += Time.deltaTime;
        if (lifeTime > 10)
        {
            Destroy(gameObject);
        }
    }
}
