using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class themeSwitchScript : MonoBehaviour
{
    public Material lightSkyBox, darkSkyBox, windowLights1, windowLights2;
    public bool themeSwitch;
    public GameObject lightThemeStuff, darkThemeStuff;
    //public ReflectionProbe refProbe;
    RenderTexture targetTexture;
    public Cubemap darkSky, lightSky;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("MenuThemeSwitch"))
        {

        if(themeSwitch == true)
        {
            lightThemeStuff.SetActive(true);
            darkThemeStuff.SetActive(false);
            RenderSettings.skybox = lightSkyBox;
            RenderSettings.fog = false;
            RenderSettings.customReflection = lightSky;
                windowLights1.DisableKeyword("_EMISSION");
                windowLights2.DisableKeyword("_EMISSION");
            }
        else
        {
            lightThemeStuff.SetActive(false);
            darkThemeStuff.SetActive(true);
            RenderSettings.skybox = darkSkyBox;
            RenderSettings.fog = true;
            RenderSettings.customReflection = darkSky;
                windowLights1.EnableKeyword("_EMISSION");
                windowLights2.EnableKeyword("_EMISSION");
            }

            if (themeSwitch == true)
            {
                themeSwitch = false;
                DynamicGI.UpdateEnvironment();

            }
            else
            {
                themeSwitch = true;
                DynamicGI.UpdateEnvironment();
                //refProbe.RenderProbe(targetTexture = null);
            }
        }
    }
}
