using UnityEngine;

public class CharacterSwitchMainMenu : MonoBehaviour
{
    public UnityEngine.U2D.Animation.SpriteLibrary Character;
    public UnityEngine.U2D.Animation.SpriteLibraryAsset[] Characters;
    public float timeToChangeSkin = 5f;
    private int _index = 0;
    private float timer;

    private void Start()
    {
        timer = timeToChangeSkin;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            _index += 1;
            if (_index < Characters.Length)
            {
                Character.spriteLibraryAsset = Characters[_index];
            }
            else
            {
                Character.spriteLibraryAsset = Characters[0];
                _index = 0;
            }
            timer = timeToChangeSkin;
        }
        
    }
}