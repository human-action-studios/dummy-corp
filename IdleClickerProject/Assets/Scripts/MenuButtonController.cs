using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject menuPanel;
    public GameObject managerPanel;
    public GameObject cam;

    public Transform camPos;
    public Transform undergroundCamPos;

    private bool isUnderground;
    [SerializeField]private bool isLerping;
    //private bool clicked;

    private float lerpDist;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        isUnderground = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLerping == true)
        {
            LerpCam();
        }
    }

    public void ToggleUnderground()
    {
        //clicked = true;
        isLerping = true;
        startTime = Time.time;
        lerpDist = Vector3.Distance(camPos.position, undergroundCamPos.position);

        if (isUnderground == false)
        {
            //cam.transform.position = Vector3.Lerp(camPos.position, undergroundCamPos.position, 0.1f);
            isUnderground = true;
            //Change the UI
        }
        else if (isUnderground == true)
        {
            //cam.transform.position = Vector3.Lerp(undergroundCamPos.position, camPos.position, 0.1f);
            isUnderground = false;
            //Change the UI
        }
    }

    public void LerpCam()
    {
        float distCovered = (Time.time - startTime) * 1000f;
        float fracDist = distCovered / lerpDist;

        if (isUnderground == false)
        {
            cam.transform.position = Vector3.Lerp(camPos.position, undergroundCamPos.position, fracDist);
        }
        else if (isUnderground == true)
        {
            cam.transform.position = Vector3.Lerp(undergroundCamPos.position, camPos.position, fracDist);
        }

        if (cam.transform.position == camPos.position || cam.transform.position == undergroundCamPos.position)
        {
            isLerping = false;
        }
    }

    public void ToggleMenuPanel()
    {
        if (menuPanel.activeSelf == true)
        {
            menuPanel.SetActive(false);
            gameManager.UnpauseGame();
        }
        else
        {
            menuPanel.SetActive(true);
            managerPanel.SetActive(false);
            gameManager.PauseGame();
        }
    }

    public void ToggleManagerPanel()
    {
        if (managerPanel.activeSelf == true)
        {
            managerPanel.SetActive(false);
            gameManager.UnpauseGame();
        }
        else
        {
            managerPanel.SetActive(true);
            menuPanel.SetActive(false);
            gameManager.PauseGame();
        }
    }
}
