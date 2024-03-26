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

        public Guid id_player { get; }
        public Guid id_finish { get; }
        bool game_over { get; }

        public void set_player_id(Guid playerId);
        public void set_finish_id(Guid finishId);
        public bool change_game_status();
    }
}
