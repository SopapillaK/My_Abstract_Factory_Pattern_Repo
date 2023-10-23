using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public interface IVehicle 
{
    public Sprite AddImage();
    public float Size();
}
public class Circle : IVehicle 
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("whiteCircle");
    }

    public float Size() { return 1.0f; }
}
public class Triangle : IVehicle 
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("whiteTriangle");
    }
    public float Size() { return 1.0f; }

}
public class Square : IVehicle
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("whitesquare");
    }
    public float Size() { return 1.0f; }

}
public class BlueCircle : IVehicle 
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("blueCircle");
    }
    public float Size() { return 1.0f; }

}
public class BlueTriangle : IVehicle 
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("blueTriangle");
    }
    public float Size() { return 1.0f; }

}
public class BlueSquare : IVehicle 
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("blueSquare");
    }
    public float Size() { return 1.0f; }

}
public class BigCircle : IVehicle 
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("whiteCircle");
    }
    public float Size() { return 2.0f; }

}
public class BigTriangle : IVehicle
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("whiteTriangle");
    }
    public float Size() { return 2.0f; }

}
public class BigSquare : IVehicle 
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("whitesquare");
    }
    public float Size() { return 2.0f; }

}
public class BigBlueCircle : IVehicle 
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("blueCircle");
    }
    public float Size() { return 2.0f; }

}
public class BigBlueTriangle : IVehicle 
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("blueTriangle");
    }
    public float Size() { return 2.0f; }

}
public class BigBlueSquare : IVehicle 
{
    public Sprite AddImage()
    {
        return Resources.Load<Sprite>("blueSquare");
    }
    public float Size() { return 2.0f; }

}
