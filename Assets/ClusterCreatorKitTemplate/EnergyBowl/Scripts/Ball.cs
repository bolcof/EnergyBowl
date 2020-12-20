using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isThrowed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("MainCamera") && !isThrowed)
        {
            this.transform.position = new Vector3(GameObject.Find("MainCamera").transform.position.x, 0.6f, 38.0f);
        }
    }

    public void changeBall(SelectedBall Selected)
    {
        this.GetComponent<Rigidbody>().mass = Selected.weight;
        this.GetComponent<MeshRenderer>().material = Selected.gameObject.GetComponent<MeshRenderer>().material;
    }

    public void Reset()
    {
        isThrowed = false;
    }
}
