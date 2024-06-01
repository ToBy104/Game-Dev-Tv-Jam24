using Unity.Netcode;
using UnityEngine;

public class Player_Net_con_ : NetworkBehaviour
{
    [Header("------ Owner ------")]
    [SerializeField] private Material[] playerMaterials;
    [SerializeField] private SkinnedMeshRenderer[] playerMesh;

    [Header("------ !Owner ------")]
    //[SerializeField] private GameObject cam;
    //[SerializeField] private GameObject cinemachineCam;

    //[Space(10)]
    [SerializeField] Component[] components;

    [Space(10)]
    private GameObject player_Cam_;
    private Transform PlayerArmature;
    public void SetPlayerActive()
    {
        PlayerArmature.position = Vector3.zero;
        player_Cam_.SetActive(true);
    }

    private void Awake()
    {
        player_Cam_ = transform.GetChild(0).gameObject;
        PlayerArmature = transform.GetChild(1);
    }

    public override void OnNetworkSpawn()
    {
        gameObject.name = $"Player ({OwnerClientId})";
        //print($"is Owner : {IsOwner}");


        if (IsOwner)
        {
            foreach (SkinnedMeshRenderer renderer in playerMesh)
            {
                int random = Random.Range(0, playerMaterials.Length);
                renderer.material = playerMaterials[random];
            }
        }

        if (!IsOwner)
        {
            //Destroy(cam);
            //Destroy(cinemachineCam);
            Destroy(player_Cam_);

            foreach (var component in components)
                Destroy(component);
        }
    }
}
