using UnityEngine;

[CreateAssetMenu(menuName = "Zone")]
public class Zone : ScriptableObject
{
    [SerializeField] private int seedNumber;
    public Maze mazePrefab;
    public Color zoneColour;
    public AudioClip zoneMusic;
    public GameObject crystalSpawn;
    
    public int GetZoneSeed() => this.seedNumber;
    public int SetZoneSeed(int x) => this.seedNumber = x;

    public void SpawnZone() {
        FindObjectOfType<GameManager>().BeginGame(this);
    }
}
