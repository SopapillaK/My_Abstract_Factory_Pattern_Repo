using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Client : MonoBehaviour
{
    public int NumberOfPoints;
    public bool Colors;
    public bool BigSize;

    public TextMeshProUGUI colorOnOff;
    public TextMeshProUGUI bigsizeOnOff;
    public Image shapeImage;

    // Start is called before the first frame update
    void Start()
    {
        // validate our data
        NumberOfPoints = Mathf.Max(NumberOfPoints);
        colorOnOff.text = "Off";
        bigsizeOnOff.text = "Off";
    }

    // Update is called once per frame
    public void SummonButton()
    {

        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfPoints = NumberOfPoints;
        requirements.Colors = Colors;
        requirements.BigSize = BigSize;

        //IVehicle v = new Unicycle();
        IVehicle v = GetVehicle(requirements);
        Debug.Log(v);
        shapeImage.sprite = v.AddImage();
        shapeImage.transform.localScale = new Vector3(v.Size(), v.Size(), v.Size());

    }

    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }

    public void OnCLickColorButton()
    {
        if (Colors) { Colors = false; colorOnOff.text = "Off"; }
        else { Colors = true; colorOnOff.text = "On"; }
    }

    public void OnCLickSizeButton()
    {
       if (BigSize) { BigSize = false; bigsizeOnOff.text = "Off"; }
        else { BigSize = true; bigsizeOnOff.text = "On"; }
    }

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

    public void OnClickReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}