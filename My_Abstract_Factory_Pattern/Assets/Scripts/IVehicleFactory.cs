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
            case 1:
                return new Circle();
            case 2:
                //if (requirements.NumberOfPoints == 3) return new Triangle();
                return new Circle();
            case 3:
                return new Triangle();
            //case 4:
            //    if (requirements.Cargo) return new GoKart();
            //    return new FamilyBike();
            case 4:
                return new Square();
            default:
                return new Circle();
        }
    }
}

public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.NumberOfPoints)
        {
            case 1:
                if (requirements.NumberOfPoints == 3)
                    return new Motorbike();
                return new Motorbike();

            default:
                return new ColoredCircle();
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
    private readonly VehicleRequirements _requirements;

    public VehicleFactory(VehicleRequirements requirements)
    {
        _factory = requirements.Engine ? (IVehicleFactory)new MotorVehicleFactory() : new ShapeFactory();
        _requirements = requirements;
    }

    public override IVehicle Create()
    {
        return _factory.Create(_requirements);
    }
}