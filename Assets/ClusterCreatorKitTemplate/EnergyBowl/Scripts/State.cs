using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class State : MonoBehaviour
{
    public int pinCount = 0;
    public TextMeshPro score;
    public GameObject pinRoot, havingBall;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetPin();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("SelectedBall"))
                {
                    Debug.Log(hit.collider.gameObject.GetComponent<SelectedBall>().weight);
                    GameObject.Find("PlayerNull").GetComponent<Throw>().change(hit.collider.gameObject.GetComponent<SelectedBall>());
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ScreenCapture.CaptureScreenshot("image.png");
            Debug.Log("screenshot");
        }
    }

    public void pinUp()
    {
        pinCount++;
        score.text = pinCount.ToString("d3");
    }

    public void resetPin()
    {
        Destroy(GameObject.FindGameObjectWithTag("PinRoot"));
        GameObject.Find("Ball").GetComponent<Ball>().Reset();
        Instantiate(pinRoot, Vector3.zero, Quaternion.identity);
        pinCount = 0;
        score.text = "000";
    }
}
