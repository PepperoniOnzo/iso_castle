public static class TileSettings
{
    //Impenetrable
    public static string TILE_OCEAN = "Ocean";
    public static string TILE_MOUNTAIN = "Mountain";

    //Penetrable
    public static string TILE_GROUND = "Ground";
    public static string TILE_FIELD = "Field";
    public static string TILE_FOREST = "Forest";
    public static string TILE_TOWN = "Town";
    public static string TILE_ROAD = "Road";

    //Speed
    public static float SPEED_GROUND = 10f;
    public static float SPEED_FIELD = 15f;
    public static float SPEED_FOREST = 20f;
    public static float SPEED_TOWN = 10f;
    public static float SPEED_ROAD = 5f;

    //Layers names
    public static string LAYER_GROUND = "Ground";
    public static string LAYER_TILES = "Tiles";

    //Level of tiles
    public static float LEWEL_WATER = 0.2f; 
    public static float LEWEL_FIELD = 0.4f;
    public static float LEWEL_FOREST = 0.5f;
    public static float LEWEL_MOUNTAIN = 0.7f;

    //Generation scales
    public static float SCALE_NOISE = 0.2f;
    public static float SCALE_FALLOFF = 2f;
}
