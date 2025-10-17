using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Stage : MonoBehaviour
{ 
    private Scene scene;

    private Comedian harry;
    private Comedian bob;
    private Comedian jhon;

    private int frame = 1;

    private void Start()
    {
        scene = new Scene();

        harry = new Comedian("Harry");
        bob = new Comedian("Bob");
        jhon = new Comedian("Jhon");

        harry.Face(bob);
        bob.Face(jhon);
        jhon.Face(harry);

        scene.Add(jhon);
        scene.Add(bob);
        scene.Add(harry);


        harry.Slap();

    }

    private void Update()
    {
        Debug.Log($"=== Frame {frame} ===");

        scene.Update();

        frame++;
    }
}
