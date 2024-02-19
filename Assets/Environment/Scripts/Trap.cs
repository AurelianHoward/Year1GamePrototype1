using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Trap : MonoBehaviour
{
    [SerializeField]
    float rawDamage = 1000f;
    [SerializeField]
    bool isPickupOnCollision = false;
    [SerializeField]
    bool isDeadly = true;

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
                TrapActivation();
            }
        }
    }

    private void TrapActivation()
    {

        if (isDeadly == true)
        {
            SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
        }
        else if (isDeadly == false)
        {
            rawDamage = -50f;
            SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
            Debug.Log("Yay Health");
        }

        Destroy(gameObject);
    }
}
