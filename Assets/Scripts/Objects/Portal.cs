using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player")
        {
            GameManager.instance.SaveState();
            string scene = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(scene);
        }
    }
}
