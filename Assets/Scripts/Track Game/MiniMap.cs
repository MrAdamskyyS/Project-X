using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject trackPath;

    public GameObject player;
    public GameObject MiniMapCamera;
    public GameObject MiniMapPlayer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        trackPath = this.gameObject;

        int path_num = trackPath.transform.childCount;
        lineRenderer.positionCount = path_num + 1;

        for(int i = 0; i < path_num; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(trackPath.transform.GetChild(i).transform.position.x, 4, trackPath.transform.GetChild(i).transform.position.z));
        }

        lineRenderer.SetPosition(path_num, lineRenderer.GetPosition(0));

        lineRenderer.startWidth = 18f;
        lineRenderer.endWidth = 18f;
        lineRenderer.startColor = Color.gray;
        lineRenderer.endColor = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        MiniMapCamera.transform.position = (new Vector3(player.transform.position.x, MiniMapCamera.transform.position.y, player.transform.position.z));

        MiniMapPlayer.transform.position = (new Vector3(player.transform.position.x, MiniMapPlayer.transform.position.y, player.transform.position.z));

    }
}
