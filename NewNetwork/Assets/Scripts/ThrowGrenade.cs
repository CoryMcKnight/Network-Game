using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace Chapter1
{
    public class ThrowGrenade : NetworkBehaviour
    {
        public GameObject grenadePrefab;
        private Transform myTransform;
        public float propulsionForce;


        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
           if (!isLocalPlayer)
                return;           
            if (Input.GetButtonDown("Fire1"))
            {
                CmdSpawnGrenade();
            }
        }

        void SetInitialReferences()
        {
            myTransform = transform;
        }

        [Command]
        void CmdSpawnGrenade()
        {
            GameObject go = (GameObject) Instantiate(grenadePrefab, myTransform.TransformPoint(0, 1, 0.5f), myTransform.rotation);
            go.GetComponent<Rigidbody>().AddForce(myTransform.forward * propulsionForce, ForceMode.Impulse);
            NetworkServer.Spawn(grenadePrefab);
            Destroy(go, 10);
        }
    }
}


