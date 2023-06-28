using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public event Action onFinished = delegate { };
    public event Action onLoose = delegate { };
    public event Action onCollectStar = delegate { };

    public LevelModel levelModel;
    int _index;

    [SerializeField] List<int> _moneyForStars;

    private void Awake()
    {
        Instance = this;
        levelModel.starsCount = 1;

    }

    private void Start()
    {
      // _index = GlobalLevelController.Instance.GetIndex;

    }

    public void FinishLevel()
    {
        if (levelModel.loosed)
        {
            return;
        }
        onFinished();
        levelModel.complited = true;
        //ApplyStars();
        //Money.AddMoney(EarnedMoney());
    }

    //void ApplyStars()
    //{
    //    if (LevelTimer.Instance.HasTime())
    //    {
    //        ++LevelModel.starsCount;
    //    }
    //    InformatoinAboutLevels.SetStarsCount(_index, LevelModel.star);
    //}

    //public void CollectStar()
    //{
    //    onCollectStar();
    //    LevelModel.starsCount = 2;
    //}

    //public int EarnedMoney()
    //{
    //    return _moneyForStars[Mathf.Min(LevelModel.starsCount - 1, 2)];
    //}

}
