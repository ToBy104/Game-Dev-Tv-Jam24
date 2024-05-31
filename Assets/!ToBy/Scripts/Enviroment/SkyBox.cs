using UnityEngine;


public class SkyBox : MonoBehaviour
{
    private readonly float rotatSpeed = 2.5f;
    //private Material[] skyBoxs;

    //private void Awake()
    //{
    //    skyBoxs = Resources.LoadAll<Material>("Materials/Sky Boxs");

    //    int rand = Random.Range(0, skyBoxs.Length);
    //    RenderSettings.skybox = skyBoxs[rand];
    //}
    private void Update() => RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotatSpeed);
}
