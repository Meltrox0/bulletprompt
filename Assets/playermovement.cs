using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public GameObject Projectile;

    public float speed;
    public float maxRotation;
    public float minRotation;

    CharacterController playerMovement;
    public Transform camera;

    Vector3 vel;

    public float sensitivity;

    float xRotation = 0;

    List<GameObject> projectilePool = new List<GameObject>();
    public int projectileNum;
    int projectileIndex = 0;

    void Start()
    {
        playerMovement = GetComponent<CharacterController>();   
        CreateProjectilePool();
    }

    
    void Update()
    {
        vel.z = Input.GetAxis("Vertical") * speed;
        vel.x = Input.GetAxis("Horizontal") * speed;

        vel = transform.TransformDirection(vel);
        playerMovement.Move(vel * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -maxRotation, minRotation);
        camera.localRotation = Quaternion.Euler(xRotation, 0, 0);

        Debug.Log(projectileIndex);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentBullet = projectilePool[projectileIndex];
            currentBullet.SetActive(true);
            currentBullet.transform.position = transform.position;
            currentBullet.GetComponent<Rigidbody>().velocity = 5 * transform.forward;
            projectileIndex++;
            if(projectileIndex >= projectilePool.Count)
            {
                projectileIndex = 0;
            }
        }
    }

     void CreateProjectilePool()
     {
         for(int i = 0; i < projectileNum; i++)
         {
            GameObject newBullet = Instantiate(Projectile, transform.position, Quaternion.identity);
            newBullet.SetActive(false);
            projectilePool.Add(newBullet);
         }
     }
}
