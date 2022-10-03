using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : Singleton<SpriteManager>
{
    [SerializeField] Sprite _defaultSprites;

    [SerializeField] Sprite[] _figureSprites;
    Dictionary<string, Sprite> _dicFigureSprites = new Dictionary<string, Sprite>();

    public override void Init()
    {
        base.Init();

        foreach (var item in _figureSprites)
        {
            _dicFigureSprites[item.name] = item;
        }    
    }

    public Sprite GetFigureSprite(string key)
    {
        if(!_dicFigureSprites.ContainsKey(key))
        {
            return _defaultSprites;
        }

        return _dicFigureSprites[key];
    }


    
}
