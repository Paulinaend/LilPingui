using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerViewer : MonoBehaviour
{
    [SerializeField] List<Image> _hpImages;
    [SerializeField] Sprite _hasHPSprite;
    [SerializeField] Sprite _notHPSprite;
    int _hp = 0;


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //   // Loosing(collision.relativeVelocily.magnitude);
    //}

    private void Start()
    {
        Player.Instance.onHpChanged += UpdateHPCount;
    }

    void UpdateHPCount()
    {
        for(int i = 0; i < Player.Instance.HPCount(); i++)
        {
            _hpImages[i].sprite = _hasHPSprite;
        }
        for (int i = Player.Instance.HPCount(); i< _hpImages.Count; ++i)
        {
            _hpImages[i].sprite = _notHPSprite;
        }
    }

    //void Loosing()
    //{
//
    //}
    //float lastHpDamaged = 0;

    //public void Damage(int time)
    //{
    //if(Time.time - lastHpDamaged < _damageTime)
    //{
    //return
    //}
    //lastHpDamaged = Time.time;
    //_hp -= time;
    //if(_hp <=0)
    //{
    //}
    //}

}
