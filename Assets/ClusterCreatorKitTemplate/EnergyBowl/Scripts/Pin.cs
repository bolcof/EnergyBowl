using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool culcing = false;
    private bool death = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (culcing && !death)
        {
            float angleX = this.transform.rotation.x;
            float angleZ = this.transform.rotation.z;

            if(Mathf.Abs(angleX) >= 0.28f || Mathf.Abs(angleZ) >= 0.28f)
            {
                GameObject.Find("PlayerNull").GetComponent<State>().pinUp();
                death = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Floor")
        {
            culcing = true;
        }
    }

}
