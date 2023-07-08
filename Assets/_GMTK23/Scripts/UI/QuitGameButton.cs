using Willow.IDLUI;

public class QuitGameButton : IDLUIButton.Extension
{
    protected override void OnSelect()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
        UnityEngine.Application.Quit();
#endif
    }
}