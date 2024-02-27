using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealItem : MonoBehaviour
{
    [SerializeField]
    float rawDamage = 50f;
    [SerializeField]
    bool isPickupOnCollision = false;
    //[SerializeField]
    //Transform playerTransform;

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
                collider.gameObject.GetComponent<HealthManager>().Heal(rawDamage);
                Debug.Log("trap activated");
                Destroy(gameObject);
            }
        }
    }
}