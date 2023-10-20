using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements requirements);
}

public class CycleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.NumberOfWheels == 1) return new Unicycle();
                return new Bicycle();
            case 2:
                return new Tandem();
            case 3:
                return new Tricycle();
            case 4:
                if (requirements.Cargo) return new GoKart();
                return new FamilyBike();
            default:
                return new Bicycle();
        }
    }
}

public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                return new Motorbike();
            case 2:
                if (requirements.Cargo && requirements.NumberOfWheels == 4) return new Truck();
                return new Car();
            default:
                return new Car();
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
        _factory = requirements.Engine ? (IVehicleFactory)new MotorVehicleFactory() : new CycleFactory();
        _requirements = requirements;
    }

    public override IVehicle Create()
    {
        return _factory.Create(_requirements);
    }
}