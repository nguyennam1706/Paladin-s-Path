using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public UnityEngine.U2D.Animation.SpriteLibrary Character;
    public UnityEngine.U2D.Animation.SpriteLibraryAsset[] Characters;

    private int _index;

    public void Update()
    {
        _index = CenterGameData.instance.GetPlayLevel();
        if (_index < CenterGameData.instance.GetMaxPlayLevel() - 1)
        {
            Character.spriteLibraryAsset = Characters[_index];
        }
        else
        {
            Character.spriteLibraryAsset = Characters[CenterGameData.instance.GetMaxPlayLevel() - 1];
        }
    }
}