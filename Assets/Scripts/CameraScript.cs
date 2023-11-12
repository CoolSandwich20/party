using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Rect Boundries;
    [SerializeField] Camera cam;
    [SerializeField]
    [Range(-1f, 1f)] float XOffset;
    [SerializeField]
    [Range(-1f, 1f)] float YOffset;
    [Tooltip("How fast does camera follows the player \n 0 - don't, 1 - immediatlly")][Range(0, 1)][SerializeField] float CameraSpeed;
    [SerializeField] List<RawImage> ParallaxImages;
    [SerializeField] List<float> ParallaxSpeeds;
    void Update()
    {
        var x = Mathf.Min(Mathf.Max(GameManager.Instance.Player.transform.position.x + XOffset * cam.orthographicSize * cam.aspect, Boundries.xMin + (cam.orthographicSize * cam.aspect)), Boundries.xMax - (cam.orthographicSize * cam.aspect));
        var y = Mathf.Min(Mathf.Max(GameManager.Instance.Player.transform.position.y + YOffset * cam.orthographicSize, Boundries.yMin + (cam.orthographicSize)), Boundries.yMax - (cam.orthographicSize));
        transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, transform.position.z), CameraSpeed);
        Parallax();
    }
    void Parallax()
    {
        for (int i = 0; i < ParallaxImages.Count; i++)
        {
            Rect r = ParallaxImages[i].uvRect;
            ParallaxImages[i].uvRect = new Rect(0 + (transform.position.x * ParallaxSpeeds[i]),r.y,r.width,r.height);
        }
    }
    #region Gizmo
    private Vector3 LeftTopCorner() => new Vector3(Boundries.xMin, Boundries.yMin);
    private Vector3 RightTopCorner() => new Vector3(Boundries.xMax, Boundries.yMin);
    private Vector3 LeftBottomCorner() => new Vector3(Boundries.xMin, Boundries.yMax);
    private Vector3 RightBottomCorner() => new Vector3(Boundries.xMax, Boundries.yMax);
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(LeftTopCorner(), RightTopCorner());
        Gizmos.DrawLine(RightTopCorner(), RightBottomCorner());
        Gizmos.DrawLine(RightBottomCorner(), LeftBottomCorner());
        Gizmos.DrawLine(LeftBottomCorner(), LeftTopCorner());
    }
    #endregion
}