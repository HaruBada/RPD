using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SimpleJSON;

public class FigureDataManager : Singleton<FigureDataManager>
{
    public int figureMaxLevel = 3;
    Dictionary<int, FigureData> dicIdxDatas = new Dictionary<int, FigureData>();
    Dictionary<int, FigureData> dicDatas = new Dictionary<int, FigureData>();
    
    public override void Init()
    {
        //base.Init();

        TextAsset characterText = Resources.Load("JSON/FIGURE_TEMPLATE") as TextAsset;

        if (characterText != null)
        {
            // 텍스트 파일 -> JSON ( Dictionary : key, value )
            JSONObject rootNodeText = JSON.Parse(characterText.text) as JSONObject;

            if (rootNodeText != null)
            {
                // JSON 첫번째 껍질 까기
                JSONObject characterTemplateNode = rootNodeText["FIGURE_TEMPLATE"] as JSONObject;

                // Object들을 각각의 키로 정리합니다.
                foreach (KeyValuePair<string, JSONNode> templatenode in characterTemplateNode)
                {
                    FigureData data = new FigureData(templatenode.Key, templatenode.Value);

                    dicIdxDatas[int.Parse(data._strkey)] = data;

                    int idx = CalculateIndex(data.shape, data.color, data.level);
                    if (dicDatas.ContainsKey(idx))
                        Debug.Log('t');
                    dicDatas[idx] = data;
                }
            }
        }
    }

    public int CalculateIndex(FigureShapeType shapeType, FigureColorType colorType, int level)
    {
        return (int)shapeType * (int)(FigureColorType.Max) * (figureMaxLevel + 1) + (int)colorType * (figureMaxLevel + 1) + level;
    }

    public FigureData Get(FigureShapeType shapeType, FigureColorType colorType, int level)
    {
        int idx = CalculateIndex(shapeType, colorType, level);
        return dicDatas[idx];
    }

    public FigureData Get(int idxKey)
    {
        return dicIdxDatas[idxKey];
    }

}
