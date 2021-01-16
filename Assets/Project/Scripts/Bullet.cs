using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Speed;
    private Vector3 lastPos;
    public GameObject decal;

    public GameObject metalHitEffect;
    public GameObject fleshHitEffect;

    public int damage;

    void Start()
    {
        lastPos = transform.position;
        Destroy(gameObject, 10);
    }


    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        RaycastHit hit;

        Debug.DrawLine(lastPos, transform.position);
        if(Physics.Linecast(lastPos, transform.position, out hit))
        {
            print(hit.transform.name);

            

            string materialName = hit.collider.sharedMaterial.name;
            switch (materialName)
            {
                case "Metall":
                    SpawnDecal(hit, metalHitEffect);
                    break;
                case "Flesh":
                    SpawnDecal(hit, fleshHitEffect);
                    Meat(hit);
                    break;
            }
            // GameObject d = Instantiate<GameObject>(decal);
            // d.transform.position = hit.point + hit.normal * 0.001f;
            // d.transform.rotation = Quaternion.LookRotation(-hit.normal);
            // Destroy(d, 10);

            Destroy(gameObject);
        }
        lastPos = transform.position;
    }

    void SpawnDecal(RaycastHit hit, GameObject prefab)
    {
        GameObject spawnDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
        spawnDecal.transform.SetParent(hit.collider.transform);
        Destroy(spawnDecal.gameObject, 10);
    }

    public void Meat(RaycastHit hit)
    {
        if(hit.transform.GetComponent<HitPosition>() != null)
        {
            hit.transform.GetComponent<HitPosition>().Damage(damage);
        }
    }
}
