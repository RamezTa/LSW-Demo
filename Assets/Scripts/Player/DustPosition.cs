using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustPosition : MonoBehaviour
{
    public Transform foot;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.position = foot.position;
        
    }
}
