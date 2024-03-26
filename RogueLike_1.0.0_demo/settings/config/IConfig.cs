using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.settings.config
{
    public interface IConfig
    {
        int map_width { get; }
        int map_height { get; }

        Guid player_id { get; }
        Guid finish_id { get; }
        bool game_over { get; }

        void set_player_id(Guid player_id);
        void set_finish_id(Guid finish_id);
        bool change_game_status();
    }
}
