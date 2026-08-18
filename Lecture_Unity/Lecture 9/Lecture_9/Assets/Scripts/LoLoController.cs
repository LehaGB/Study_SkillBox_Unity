using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoLoController : MonoBehaviour
{

    public TextMeshProUGUI cubeText1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.z > 20)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        string a = collision.gameObject.name;
        cubeText1.text = $"Меня уничтожил {a}";
    }
}
