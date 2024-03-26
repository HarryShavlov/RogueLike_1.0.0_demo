using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.settings.config
{
    public class Config (int MapWidth, int MapHeight): IConfig
    {
        public int map_width { get; } = MapWidth;
        public int map_height { get; } = MapHeight;

        public Guid player_id { get; private set; }
        public Guid finish_id { get; private set; }
        public bool game_over { get; private set; } = false;

        public void set_player_id(Guid playerId) => player_id = playerId;
        public void set_finish_id(Guid finishId) => finish_id = finishId;
        public bool change_game_status() => game_over = !game_over;
    }
}
