using UnityEngine;

/// <summary>
/// Static extension class for cameras.
/// </summary>
public static class CameraBounds
{
    /// <summary>
    /// Returns the ortographic bounds of a camera.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static Bounds OrthographicBounds(this Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(camera.transform.position, new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
