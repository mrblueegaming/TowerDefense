using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint bigCanon;

    void Start()
    {
        buildManager = BuildManager.instance;
        standardTurret.ShowCost();
        missileLauncher.ShowCost();
        laserBeamer.ShowCost();
        bigCanon.ShowCost();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            SelectStandardTurret();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            SelectMissileTurret();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            SelectLaserBeamer();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            SelectBigCanon();
        }
    }
    public void SelectStandardTurret()
    {
        //Debug.Log("Standard Turret selcted!");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        //Debug.Log("Another Turret selected!");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer selected!");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

    public void SelectBigCanon()
    { 
        Debug.Log("Big Canon selected!");
        buildManager.SelectTurretToBuild(bigCanon);
    }
}
