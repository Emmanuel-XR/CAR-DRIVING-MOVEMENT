using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COINrotate : MonoBehaviour
{
    private float RotarSpeed = 100.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up * RotarSpeed * Time.deltaTime);

    }
}
