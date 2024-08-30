using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System;

#if UNITY_ANDROID
using Google.Play.Review;
#endif

/// <summary>
/// Handles app evaluation Button.
/// </summary>
public class AppReviewHandler : MonoBehaviour
{
    #if UNITY_ANDROID
    [Header("Button References")]
    [SerializeField] Button appButtonRequest;

    // In app necessary Review
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;


    // OnDestroy is called when the script is being destroyed.
    void OnDestroy() => appButtonRequest.onClick.RemoveListener(RequestAppEvaluate);

    // Start is called before the first frame update
    void Start() => appButtonRequest.onClick.AddListener(RequestAppEvaluate);

    /// <summary>
    /// Request App Evaluate for Android Devices
    /// </summary>
    async void RequestAppEvaluate()
    {
        try
        {
            _reviewManager = new ReviewManager();
            StartCoroutine(RequestReviews());
        }
        catch (Exception e)
        {
            appButtonRequest.interactable = true;
            Debug.LogError(e.Message);
        }
    }


    private IEnumerator RequestReviews()
    {
        yield return new WaitForSeconds(5f);
        
        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();


        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            yield break;
        }
    }
#endif
}