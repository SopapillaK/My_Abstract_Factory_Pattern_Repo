using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements requirements);
}

public class ShapeFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.NumberOfPoints)
        {
            case 3:
                return new Triangle();
            case 4:
                return new Square();
            default:
                return new Circle();
        }
    }
}


public class ColoredFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.NumberOfPoints)
        {
            case 3:
                if (requirements.NumberOfPoints == 3)
                    return new BlueTriangle();
                return new Triangle();
            case 4:
                if (requirements.NumberOfPoints == 4)
                    return new BlueSquare();
                return new Square();
            default:
                if(requirements.NumberOfPoints == 0) 
                    return new BlueCircle();
                return new Circle();
        }
    }
}

public class SizeFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.NumberOfPoints)
        {
            case 3:
                if (requirements.NumberOfPoints == 3 && requirements.Colors)
                    return new BigBlueTriangle();
                return new BigTriangle();
            case 4:
                if (requirements.NumberOfPoints == 4 && requirements.Colors)
                    return new BigBlueSquare();
                return new BigSquare();
            default:
                if (requirements.NumberOfPoints == 0 && requirements.Colors)
                    return new BigBlueCircle();
                return new BigCircle();
        }
    }
}

public abstract class AbstractVehicleFactory
{
    public abstract IVehicle Create();
}



public class VehicleFactory : AbstractVehicleFactory
{
    private readonly IVehicleFactory _factory;
    private readonly IVehicleFactory _factory2;
    private readonly VehicleRequirements _requirements;

    public VehicleFactory(VehicleRequirements requirements)
    {
        _factory = requirements.Colors ? (IVehicleFactory)new ColoredFactory() : new ShapeFactory();
        //_factory2 = requirements.BigSize ? (IVehicleFactory)new SizeFactory() : new ShapeFactory();
        _requirements = requirements;
    }

    public override IVehicle Create()
    {
        return _factory.Create(_requirements);
        //return _factory2.Create(_requirements);
    }
}