using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PostProcessVolume postProcessVolume;
    public static PostProcessingManager instance;

    private void Awake() {
        instance = this;
    }

    private Vignette vignette;
    public ColorParameter baseVignetteColor;
    void Start() {
        postProcessVolume = GetComponent<PostProcessVolume>();
    }

    public void ChangeToNewVig(ColorParameter newColor) {
        if (postProcessVolume.profile.TryGetSettings(out vignette))
        {
            vignette.color = newColor;
        }
    }

    public void ReturnToNormal() {
        if (postProcessVolume.profile.TryGetSettings(out vignette))
        {
            vignette.color = baseVignetteColor;
        }
    }
}
