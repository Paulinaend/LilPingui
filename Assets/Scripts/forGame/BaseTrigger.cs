using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTrigger : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerEnter();
        }
        if (collider.tag == "RedStop")
        {
            Failure();

        }


    }

    protected virtual void PlayerEnter()
    {

    }

    protected virtual void Failure()
    {

    }
}



