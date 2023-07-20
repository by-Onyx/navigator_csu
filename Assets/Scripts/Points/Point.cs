using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Point
{
    public PointProperties pointProperties {get; private protected set;}
    public ButtonProperties buttonProperties { get; private protected set;}

    public Point()
    {
        this.pointProperties = new PointProperties();
        this.buttonProperties = new ButtonProperties();
    }
}

