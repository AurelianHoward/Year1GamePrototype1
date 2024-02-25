using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Trap : MonoBehaviour
{
    [SerializeField]
    float rawDamage = 75f;
    [SerializeField]
    bool isDeadly = true;
    [SerializeField]
    bool isPickupOnCollision = false;
    [SerializeField]
    Transform playerTransform;

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
            DeadlyTrap();
        }
        //else if(isDeadly == false)
        //{
        //    HealthPot();
        //}
    }

    private void DeadlyTrap()
    {

            SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
            Debug.Log("trap activated");

            Destroy(gameObject);
        }
    }
