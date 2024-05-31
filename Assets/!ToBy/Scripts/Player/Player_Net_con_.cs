using Unity.Netcode;
using UnityEngine;

public class Player_Net_con_ : NetworkBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject cinemachineCam;

    [Space(10)]
    [SerializeField] Component[] components;

    public override void OnNetworkSpawn()
    {
        //if (IsOwner)
        //{
        gameObject.name = $"Player ({OwnerClientId})";
        //}

        if (!IsOwner)
        {
            Destroy(cam);
            Destroy(cinemachineCam);

            foreach (var component in components)
                Destroy(component);
        }
    }
}
