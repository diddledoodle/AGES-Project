using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleportPlayertoNextScene : InteractiveObject
{
    private GameObject cabinetdoor;
    private MeshRenderer renderer;
    private MeshCollider collider;
    [SerializeField]
    private string scenetoLoad;
    private ParticleSystem particlesystem;
    private ParticleSystem.EmissionModule em;

    private void Start()
    {
        cabinetdoor = GameObject.Find("CDoor");
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<MeshCollider>();
        particlesystem = GetComponentInChildren<ParticleSystem>();
        em = particlesystem.emission;
        renderer.enabled = false;
        collider.enabled = false;
        em.enabled = false;
    }
    private void Update()
    {
        if (cabinetdoor.GetComponent<Door>().IsOpen == true)
        {
            renderer.enabled = true;
            collider.enabled = true;
            particlesystem.Play();
            em.enabled = true;
        }
    }
    public override void InteractWith()
    {
        base.InteractWith();
        SceneManager.LoadScene(scenetoLoad);
    }
}
