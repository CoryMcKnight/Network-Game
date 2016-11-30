
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Shoot : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float propulsionForce;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        // var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        // var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        // transform.Rotate(0, x, 0);
        // transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }

    // This [Command] code is called on the Client …
    // … but it is run on the Server!
    [Command]
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        // var bullet = (GameObject)Instantiate(
        //     bulletPrefab,
        //     bulletSpawn.position = new Vector3(0, 1, 1),
        //     bulletSpawn.rotation);
	        GameObject go = (GameObject) Instantiate(
	        	bulletPrefab, 
	        	bulletSpawn.TransformPoint(0, 1, 0.5f), 
	        	bulletSpawn.rotation);

        // // Add velocity to the bullet
        // bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
               go.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * propulsionForce;

        // // Spawn the bullet on the Clients
        // NetworkServer.Spawn(bullet);
		   NetworkServer.Spawn(go);
        // // Destroy the bullet after 2 seconds
        // Destroy(bullet, 2.0f);
		   Destroy(go, 5);
    	
    }

    public override void OnStartLocalPlayer ()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}