using UnityEngine;


namespace Assets.PixelHeroes.Scripts.ExampleScripts
{
    public class CharacterSwitch : MonoBehaviour
    {
        public UnityEngine.U2D.Animation.SpriteLibrary Character;
        public UnityEngine.U2D.Animation.SpriteLibraryAsset[] Characters;

        private int _index;

        public void Update()
        {
            _index = CenterGameData.instance.GetPlayLevel();
            Character.spriteLibraryAsset = Characters[_index];
        }
    }
}