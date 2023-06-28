using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Helph : MonoBehaviour
{


    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private GameObject heartPrefabl;

    private List<GameObject> hearts;

    [SerializeField]
    private int lives = 4;

    private void Start()
    {
        hearts = new List<GameObject>();

        for (int i = 0; i < lives; i++)
        {
            UpdateUIAdd();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            lives--;
            UpdateUIDel();
            if (lives <= 0)
            {
                Destroy(gameObject);
                var id = SceneManager.GetActiveScene().buildIndex;
                SceneManager.UnloadSceneAsync(id);
                SceneManager.LoadScene(id);
            }
        }
        else if (other.gameObject.CompareTag("Heart"))
        {
            lives++;
            UpdateUIAdd();
            Destroy(other.gameObject);
        }
    }
    private void UpdateUIDel()
    {
        var h = hearts.Last();
        Destroy(h);
        hearts.Remove(h);
    }

    private void UpdateUIAdd()
    {
        var heart = Instantiate(heartPrefabl);
        hearts.Add(heart);
        heart.transform.SetParent(mainPanel.transform);
    }
}