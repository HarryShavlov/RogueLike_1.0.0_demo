
namespace RogueLike_1._0._0_demo.settings.config
{
    public class Config(int MapWidth, int MapHeight) : IConfig
    {
        public int map_width { get; } = MapWidth;
        public int map_height { get; } = MapHeight;

        public Guid id_player { get; private set; }
        public Guid id_finish { get; private set; }
        public bool game_over { get; private set; } = false;

        public void set_player_id(Guid playerId) => id_player = playerId;
        public void set_finish_id(Guid finishId) => id_finish = finishId;
        public bool change_game_status() => game_over = !game_over;
    }
}
