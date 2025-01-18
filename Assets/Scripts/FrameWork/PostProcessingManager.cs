using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PostProcessVolume postProcessVolume;
    public static PostProcessManager instance;

    private void Awake() {
        instance = this;
    }

    Vignette vignette;
    public ColorParameter baseVignetteColor;
    void Start() {
        postProcessVolume = GetComponent<PostProcessVolume>();
        vignette = postProcessVolume.GetComponent<Vignette>();
    }

    public void ChangeToNewVig(ColorParameter newColor) {
        vignette.color = newColor;
    }


}
