using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Trap : MonoBehaviour
{
    [SerializeField]
    float rawDamage = 75f;
    [SerializeField]
    bool isPickupOnCollision = false;

    // Start is called before the first frame update
    void Start()
    {

        if (isPickupOnCollision)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider collider)
    {
        if (isPickupOnCollision)
        {
            if (collider.tag == "Player")
            {
                collider.gameObject.GetComponent<HealthManager>().Hit(rawDamage);
                Debug.Log("trap activated");
                Destroy(gameObject);
            }
        }
    }
}
