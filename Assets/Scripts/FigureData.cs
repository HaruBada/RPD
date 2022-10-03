using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SimpleJSON;
using System;

public class FigureData
{
    public string _strkey = string.Empty;
    public FigureShapeType shape;
    public FigureColorType color;
    public int level = 0;
    public string sprite;
    public JSONArray evolutions;

    public FigureData(string key, JSONNode nodeData)
    {
        _strkey = key;

        // Á¤¸®
        shape = (FigureShapeType)Enum.Parse(typeof(FigureShapeType), nodeData["shape"]);
        color = (FigureColorType)Enum.Parse(typeof(FigureColorType), nodeData["color"]);
        level = nodeData["level"].AsInt;
        sprite = nodeData["sprite"];
        evolutions = nodeData["evolutions"].AsArray;
    }
}
