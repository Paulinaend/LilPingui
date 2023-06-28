using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 
    public static Player Instance;
    public PlayerData pingui;
    //PlayerLogic _playerLogic;
    public float speed;
    public int direct1;
    public int direct2;
    [SerializeField] int _maxHp;
    int _hp;

    public event Action onHpChanged = delegate { };


    void Awake()
    { 
        Instance = this; 

    }
    
    void Start()
    {
        // _playerLogic = GetComponent<PlayerLogic>();
        _maxHp = pingui.HP;
        _hp = _maxHp;
    }



    public void Update()
    {
        //CheckPosition();
         int direct1 = Convert.ToInt32(Input.GetAxis("Horizontal"));
         Turn(direct1);
         int direct2 = Convert.ToInt32(Input.GetAxis("Vertical"));
         UpDown(direct2);
          

    } 

    
    public void Turn(int dir)
    {
        transform.position += new Vector3(dir, 0, 0) * speed * Time.deltaTime;
    }

    public void UpDown(int dir)
    {
        transform.position += new Vector3(0, dir, 0) * speed * Time.deltaTime;
    }

    public int HPCount()
    {
        return Mathf.Max(_hp, 0);
    }

    //void CheckPosition()
    //{
    //
    //}

    //void Retry()
    //{
    //    gameObject.transform.position = new Vector3(-11.9f, -8.21f, -5);
    //}

}
