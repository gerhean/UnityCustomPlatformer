using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStand : MonoBehaviour
{

    [SerializeField] GameObject starPlatinum;
    public GameObject dioRef;
    // Start is called before the first frame update
    void Start()
    {
        dioRef = GameObject.FindGameObjectWithTag("Dio Da");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, dioRef.transform.position) <= 2f)
        {
            starPlatinum.SetActive(true);    
        }
        else {
            starPlatinum.SetActive(false);
        }
    }
}
