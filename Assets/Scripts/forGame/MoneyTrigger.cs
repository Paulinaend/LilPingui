using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTrigger : BaseTrigger
{
    [SerializeField] int _cost;
    [SerializeField] TextMesh _costText;
    [SerializeField] GameObject[] Life = new GameObject[3];
    int life = 3;

    protected override void PlayerEnter()
    {
        //base.PlayerEnter();
    
        _costText.gameObject.SetActive(true);
        _costText.transform.parent = null;
        _costText.text = "+" + _cost;
        
       Destroy(gameObject);

    }

    protected override void Failure()
    {
        life--;
        Life[2].SetActive(false);

        Destroy(gameObject);
    }
    //    if (collider.tag == "RedStop")
    //    {
    //        life--;

    //        if (life <= 0)
    //        {
    //            Destroy(gameObject);
    //            //var id = SceneManager.GetActiveScene().buildIndex;
    //            //SceneManager.UnloadSceneAsync(id);
    //            //SceneManager.LoadScene(id);
    //        }
    //    }
    //    else if (collider.tag == "Player")
    //    {
    //        life++;
    //    }

    //    if (life >= 2)
    //    {
    //        Life[0].SetActive(true);
    //        Life[1].SetActive(true);
    //    }
    //    else if (life >= 1 && life < 2)
    //    {
    //        Life[1].SetActive(false);
    //    }
    //    else if (life < 1)
    //    {
    //        Life[0].SetActive(false);
    //        Life[1].SetActive(false);
    //    }
    //}

}
