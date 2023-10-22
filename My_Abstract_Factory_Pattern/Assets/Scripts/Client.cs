using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Client : MonoBehaviour
{
    public int NumberOfPoints;
    public bool Engine;
    public int Passengers = 0;
    //public bool Cargo;

    // Start is called before the first frame update
    void Start()
    {
        // validate our data
        NumberOfPoints = Mathf.Max(NumberOfPoints);
        Passengers = Mathf.Max(Passengers, 1);
    }

    // Update is called once per frame
    public void SummonButton()
    {
        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfPoints = NumberOfPoints;
        requirements.Engine = Engine;
        //requirements.Passengers = Passengers;
        //requirements.Cargo = Cargo;

        //IVehicle v = new Unicycle();
        IVehicle v = GetVehicle(requirements);
        Debug.Log(v);
    }

    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        // based on requirements.Engine
        // choose a motorvehicle factory or a cycle factory
        // call create on the factory to get an appropriate vehicle
        // and return it

        //VehicleFactory factory = new VehicleFactory();

        //if (requirements.Engine)
        //{
        //    return factory.MotorVehicleFactory().Create(requirements);
        //}

        //return factory.CycleFactory().Create(requirements);

        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }

    public void OnCLickEngineButton()
    {
        if (Engine) { Engine = false; }
        else { Engine = true; }
    }

    //public void OnCLickCargoButton()
    //{
    //    if (Cargo) { Cargo = false; }
    //    else { Cargo = true; }
    //}

    public void ChooseNumPoints(int numPoints)
    {
        if (numPoints == 0)
        {
            NumberOfPoints = 0;
        }
        if (numPoints == 1) 
        {
            NumberOfPoints = 3;
        }
        if (numPoints == 2)
        {
            NumberOfPoints = 4;
        }
    }

    //public void OnClickAddPassenger()
    //{
    //    Passengers++;
    //}

    public void OnClickReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}